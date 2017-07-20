using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class SerieHD
    {
        public string searchUrl = "http://www.seriehd.me/?s=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchUrl + mySearch.Replace(" ", "+");
            return result;
        }


        public List<KeyValuePair<string, string>> getLibrary(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var webClient = new WebClient();
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='imagen']"))
            {


                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    var href = link.GetAttributeValue("href", "");

                    var names = div.Descendants("h2").ToList();
                    string name = names[0].InnerText;

                    byte[] bytes = Encoding.Default.GetBytes(name);
                    var nameFixed = Encoding.UTF8.GetString(bytes);
                    // rimuovi caratteri di merda
                    if (nameFixed.Contains("&#7;"))
                    {
                        nameFixed = nameFixed.Replace("&#7;", "'");
                    }
                    if (nameFixed.Contains("&#1;"))
                    {
                        nameFixed = nameFixed.Replace("&#1;", "-");
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
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='imagen']"))
            {
                var links = div.Descendants("img").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("src", "");
                    if (href == "")
                    {

                    }
                    else
                    {
                        result.Add(href);
                    }
                }

            }
            return result;
        }

        public string playUrl(string toBeSearched)
        {
            //List<string> result = new List<string>();

            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            string href = "";
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@id='content']"))
            {
                var links = div.Descendants("iframe").ToList();
                foreach (var link in links)
                {

                    if (link.GetAttributeValue("src", "").Contains("hdpass")) href = link.GetAttributeValue("src", "");
                }
            }

            return href;
        }
    }
}

