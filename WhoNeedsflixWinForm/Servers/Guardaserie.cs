using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class Guardaserie
    {
        public string searchUrl = "http://www.guardaserie.online/?s=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchUrl + mySearch.Replace(" ", "+");
            return result;
        }

        public List<KeyValuePair<string, string>> getLibraryUrl(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-2-5']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    if (name.Contains("star"))
                    {
                        name = name.Replace("star", "");
                    }
                    byte[] bytes = Encoding.Default.GetBytes(name);
                    var nameFixed = Encoding.UTF8.GetString(bytes);
                    // rimuovi caratteri di merda
                    if (nameFixed.Contains("&#8211;"))
                    {
                        nameFixed = nameFixed.Replace("&#8211;", "-");
                    }
                    if (nameFixed.Contains("&#8217;"))
                    {
                        nameFixed = nameFixed.Replace("&#8217;", "'");
                    }

                    result.Add(new KeyValuePair<string, string>(nameFixed.Trim(), href));
                }
            }
            return result;
        }

        public List<string> getUrlImage(string url)
        {
            List<string> result = new List<string>();
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//img[@class='img-responsive thumb-serie']"))
            {
                var href = div.GetAttributeValue("src", "");
                result.Add(href);

            }
            return result;
        }

        public List<string> getEpisodes(string toBeSearched)
        {
            List<string> result = new List<string>();

            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='number-episodes-on-img']"))
            {
                var number = div.InnerText;
                number = number.Replace(" ", "");
                result.Add(number);
            }
            //var name = div.Descendants("a").ToList();
            foreach (var link in doc.DocumentNode.SelectNodes("//span[@meta-serie]"))
            {
                // take the value of the attribute
                var href = link.GetAttributeValue("meta-embed", "");
                result.Add(href);
            }
            return result;
        }
    }
}
