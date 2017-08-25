using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhoNeedsflix.Utils;
using System.Windows.Forms;
using WhoNeedsflixWinForm.Utils;

namespace WhoNeedsflixWinForm.Servers
{
    class Genio
    {
        public string genioUrl = "http://ilgeniodellostreaming.cc/";
        public string searchGenioUrl = "https://openloadmovie.me/?s=";

        public void killCloudflare()
        {
            System.Threading.Thread.Sleep(5000);
        }

        public string search(string mySearch)
        {
            string result = "";
            result = searchGenioUrl + mySearch.Replace(" ", "+");
            return result;
        }

        public List<KeyValuePair<string, string>> getLibraryUrl(string toBeSearched)
        {
            // Prende in input un url di ricerca prodotto da searchGenio
            // Ritorna un dizionario formato da (ie) 
            // The Social Network http://ilgeniodellostreaming.cc/film/the-social-network/
            // Si recupera poi il valore a seconda della chiave che ci interessa e lo si passa alla funzione sotto

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(toBeSearched);
            if(webClient == null)
            {
                MessageBox.Show("broken :(");
            }
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='title']"))
            {
                var link = div.Descendants("a").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    byte[] bytes = Encoding.Default.GetBytes(name);
                    var nameFixed = Encoding.UTF8.GetString(bytes);
                    //result.Add(name, href);
                    string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
                    nameFixed = System.Text.RegularExpressions.Regex.Replace(nameFixed, regex, "");

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
            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='thumbnail animation-2']"))
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

        public List<string> getDescriptionData(string url)
        {
            List<string> result = new List<string>();
            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='contenido']"))
            {
                var link = div.Descendants("p").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.InnerText;
                    byte[] bytes = Encoding.Default.GetBytes(href);
                    var nameFixed = Encoding.UTF8.GetString(bytes);
                    result.Add(nameFixed);
                }
            }
            return result;
        }

        public bool checkIfFilm(string url)
        {
            if (url.Contains("/film/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfSerie(string url)
        {
            if (url.Contains("/serietv/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfEpisode(string url)
        {
            if (url.Contains("/episodi/"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string playUrl(string url)
        {
            // Prende in ingresso un link simil http://ilgeniodellostreaming.cc/film/the-social-network/
            // Ritorna il link di openload da streammare

            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            var link = doc.DocumentNode.SelectSingleNode("//iframe[@class='metaframe rptss']");
            var href = link.GetAttributeValue("src", ""); // l?iframe nel genio era "src"
            return href;
        }

        public List<KeyValuePair<string, string>> playSerieFromGenio(string url)
        {
            // Prende in ingresso un link simil http://ilgeniodellostreaming.cc/serietv/mia-serie-tv/
            // Ritorna il link di openload da streammare

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);


            //foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='episodiotitle']"))
            foreach(var div in doc.DocumentNode.SelectNodes("//ul[@class='episodios']"))
            {
                //var divs = div.SelectNodes("//div[@class='episodiotitle']");
                var lis = div.Descendants("li").ToList();

                foreach(var li in lis)
                {
                    var episodes = li.SelectNodes("//div[@class='episodiotitle']");
                    foreach(var episode in episodes)
                    {
                        var link_names = episode.Descendants("a").ToList();
                        foreach (var link in link_names)
                        {
                            var href = link.GetAttributeValue("href", "");
                            var name = link.InnerText;
                            byte[] bytes = Encoding.Default.GetBytes(name);
                            var nameFixed = Encoding.UTF8.GetString(bytes);
                            //result.Add(name, href);
                            result.Add(new KeyValuePair<string, string>(nameFixed, href));
                        }
                    }
                }
            }

            return result;
        }

        public List<string> getSerieImage(string url)
        {
            List<string> result = new List<string>();
            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='imagen']"))
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

        public List<string> getNumEpisode(string url)
        {
            List<string> result = new List<string>();
            CookieContainer cookies = new CookieContainer();
            CookieEater webClient = new CookieEater(cookies);

            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='numerando']"))
            {
                var name = div.InnerText;
                result.Add(name);
                
            }
            return result;
        }

    }
}
