using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Utils
{
    class Openload
    {
        public string getOpenloadlink(List<string> res)
        {
            // In input una lista di stringhe che, spesso sono i risultati elaborati dai diversi server
            string rapid = "";
            foreach (var item in res)
            {
                if (item.StartsWith("https://openlo") || item.StartsWith("http://openlo"))
                    rapid = item;
            }
            return rapid;
        }

        public string getDownloadlink(string url)
        {
            string toBeDownloaded = url.Replace("embed", "f");
            return toBeDownloaded;
        }

        public bool checkIfWorks(string url)
        {
            try
            {
                bool result = true;

                var webClient = new WebClient();
                var source = webClient.DownloadString(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(source);

                var div = doc.DocumentNode.SelectSingleNode("//img[@class='image-blocked']");
                if (div != null)
                {
                    result = false;
                }

                return result;
            }
            catch
            {
                return false;
            }
        }

        public string getEmbedOpenloadlink(string url)
        {
            // Da mandare in pasto alla webview
            string toBeStreamed = url.Replace("f", "embed");
            return toBeStreamed;
        }

        public string downloadOpanload(string url)
        {
            string _9xRequest = "https://9xbuddy.com/process?url=";
            return _9xRequest = _9xRequest + url;
        }
    }
}
