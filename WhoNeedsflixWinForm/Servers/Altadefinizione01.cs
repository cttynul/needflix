using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class Altadefinizione01
    {
        public string masterUrl { get; set; }
        public string searchUrl { get; set; }

        public Altadefinizione01(){
             masterUrl = "http://www.altadefinizione01.love/";
             searchUrl = "?do=search&mode=advanced&subaction=search&story=";
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
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='cover boxcaption']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
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

                    // Togli la scritta sub-ita che blocca il search da tmdb
                    if (nameFixed.Contains("Sub"))
                    {
                        nameFixed = nameFixed.Replace("Sub Ita", "");
                        nameFixed = nameFixed.Replace("Sub ITA", "");
                        nameFixed = nameFixed.Replace("Sub ita", "");
                    }
                    // Solo per A01 che tronca i nomi
                    if (nameFixed.Contains("&#8"))
                    {
                        nameFixed = nameFixed.Replace("&#821", "");
                        nameFixed = nameFixed.Replace("&#82", "");
                        nameFixed = nameFixed.Replace("&#8", "");
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
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='cover_kapsul']"))
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

            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='single_icerik']"))
            {
                var link = div.Descendants("iframe").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("src", "");
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
                foreach(var link in links)
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
