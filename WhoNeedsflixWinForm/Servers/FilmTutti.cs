using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class FilmTutti
    {
        public string searchGenioUrl = "http://www.filmpertutti.black/?s=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchGenioUrl + mySearch.Replace(" ", "+");
            return result;
        }

        public List<KeyValuePair<string, string>> getLibrary(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var webClient = new WebClient();
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='posts']"))
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
                        if (Regex.IsMatch(name, "[0-9].[0-9]"))
                        {
                            name = Regex.Replace(name, "[0-9].[0-9]", "");
                        }
                        name = Regex.Replace(name, @"\t|\n|\r", "");
                        // Rimuovi parentesi e contenuto con Regex
                        name = Regex.Replace(name, @"\[.+?\]\s*", "");
                        name = Regex.Replace(name, @"\(.+?\)\s*", "");
                        name = Regex.Replace(name, "HD", "");
                        name = Regex.Replace(name, @"N/A", "");
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
            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='posts']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("data-thumbnail", "");
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

            foreach (var div in doc.DocumentNode.SelectNodes("//iframe[@scrolling='NO']"))
            {
                var href = div.GetAttributeValue("src", "");
                result = href;
            }
            return result;
        }

    }

 
}
