using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Utils
{
    class Nowvideo
    {
        // http://www.5nowvideo.com/video/865f0df8671f2
        // http://www.5nowvideo.com/embed/?v=

        public string getEmbedLink(string url)
        {
            // Da mandare in pasto alla webview
            string toBeStreamed = url.Replace("/video/", "/embed/?v=");
            //string toBeStreamed = url.Replace("video/", "mobile/index.php?id=");
            return toBeStreamed;
        }
    }
}
