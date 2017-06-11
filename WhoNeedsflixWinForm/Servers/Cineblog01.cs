using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class Cineblog01
    {
        /*
         * Ritorna solo link di openload (Non embeddedati)
         * Usare le funzioni nelle utils di openload
         */ 

        public string searchUrl = "http://www.cineblog01.cool/?s=";

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
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='post-title']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    if (href.StartsWith("http://www.filmpertutti.black/fdh"))
                    {

                    }
                    else
                    {
                        name = name.Replace("Guarda ora", "");
                        string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
                        if (Regex.IsMatch(name, regex))
                        {
                            name = Regex.Replace(name, regex, "");
                        }
                        name = name.Replace("\t", "");
                        name = name.Replace("\n", "");
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
                        result.Add(new KeyValuePair<string, string>(nameFixed, href));
                    }
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
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='covershot']"))
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

        public string playUrl(string url)
        {
            string result = "";
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            foreach (var div in doc.DocumentNode.SelectNodes("//td"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    var href = link.GetAttributeValue("href", "");
                    if (href.Contains("openload"))
                        result = href;
                }
            }
            return result;
        }
    }
}
