using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class Cinemalibero
    {
        public string searchUrl = "http://www.cinemalibero.tv/?s=";

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
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            //var div = doc.DocumentNode.SelectSingleNode("//div[@class='featuredItem']");
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='locandine']"))
            {
                // there is only one links
                var link = div.Descendants("a").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    result.Add(new KeyValuePair<string, string>(name, href));
                }
            }

            return result;
        }

        public List<string> getUrlImage(string url)
        {
            List<string> result = new List<string>();
            var webClient = new WebClient();
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//a[@class='locandina']"))
            {
                var images = doc.DocumentNode.Descendants("img").Where(d => d.Attributes.Contains("style") && d.Attributes["style"].Value.Contains("background-image: url")).ToList();
                if (images != null)
                {
                    // take the value of the attribute
                    var href = images.FirstOrDefault().ToString();
                    result.Add(href);
                }
            }
            return result;
        }
    }
}
