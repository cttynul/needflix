using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Utils
{
    class Speedvideo
    {
        public string getEmbedLink(string url)
        {
            // Da mandare in pasto alla webview
            // from http://speedvideo.net/wd1q94gc5r74/The.Matrix.Revolutions.2003.iTABluray.720p.x264-TRL.mkv.html
            // to http://speedvideo.net/embed-wd1q94gc5r74-607x360.html
            var temp = url.Replace("http://speedvideo.net/", "http://speedvideo.net/embed-");
            var toBeStreamed = temp.Substring(0, 40);
            return toBeStreamed + "-607x360.html";
        }
    }
}
