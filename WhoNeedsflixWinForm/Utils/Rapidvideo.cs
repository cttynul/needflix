using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Utils
{
    class Rapidvideo
    {
        public string getEmbedElement(string url)
        {
            var temp = url.Replace("http://www.rapidvideo.cool/", "");
            int index = temp.LastIndexOf("/");
            if (index > 0)
                temp = temp.Substring(0, index);
            return temp;
        }

        public void initRapidvideo()
        {
            System.IO.File.Copy("rapidvideo_backup.html", "rapidvideo.html", true);
        }

        public bool checkIfWorks(string url)
        {
            bool result = true;

            var webClient = new WebClient();
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            var div = doc.DocumentNode.SelectSingleNode("//img[@src='http://imagerip.net/images/2017/03/21/be8a6f03.png']");
            if (div != null)
            {
                result = false;
            }

            return result;
        }

    }
}
