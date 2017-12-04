using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class CinemaSubito
    {
        public string masterUrl { get; set; }
        public string searchUrl = "https://www.cinemasubito.biz/search.php?keywords=";

        public CinemaSubito()
        {
                    }

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
            foreach (var div in doc.DocumentNode.SelectNodes("//h3[@dir='ltr']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    // rimuovi parentesi tonde e contenuto digit
                    if (Regex.IsMatch(name, "\\(([0-9]+)\\)"))
                    {
                        name = Regex.Replace(name, "\\(([0-9]+)\\)", "");
                    }
                    // rimuovi parentesi quadre e contenuto words
                    if (Regex.IsMatch(name, "\\[HD\\]"))
                    {
                        name = Regex.Replace(name, "\\[HD\\]", "");
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

                    result.Add(new KeyValuePair<string, string>(nameFixed, href));

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
            foreach (var div in doc.DocumentNode.SelectNodes("//span[@class='pm-thumb-fix-clip']"))
            {
                var link = div.Descendants("img").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("src", "");
                    result.Add(href);
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

            foreach (var div in doc.DocumentNode.SelectNodes("//a[@rel='nofollow']"))
            {
                var href = div.GetAttributeValue("href", "");
                if (href.StartsWith("https://openload.co"))
                {
                    //href.Replace("/f/", "/embed/");
                    result = href;
                }
            }
            return result;
        }

        public string getOpenloadUrl(string url)
        {
            string result = "";
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='host']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    if (href.Contains("openload"))
                    {
                        result = href;
                    }
                }
            }
            return result;
        }
    }
}
