using CloudFlareUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class GenioDelloStreaming
    {
        public string searchGenioUrl = "http://ilgeniodellostreaming.cc/?s=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchGenioUrl + mySearch.Replace(" ", "+");
            return result;
        }

        private async Task<string> getSourceFromUrl(string url)
        {
            try
            {
                // Create the clearance handler.
                var handler = new CloudFlareUtilities.ClearanceHandler
                {
                    MaxRetries = 2 // Optionally specify the number of retries, if clearance fails (default is 3).
                };

                // Create a HttpClient that uses the handler to bypass CloudFlare's JavaScript challange.
                var client = new System.Net.Http.HttpClient(handler);

                // Use the HttpClient as usual. Any JS challenge will be solved automatically for you.
                string content = "";
                while (content == "")
                {
                    var test = content.Count();
                    content = client.GetStringAsync(url).Result;
                }
                return content;
            }
            catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            {
                // After all retries, clearance still failed.
                return "";
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                return "";
                // Looks like we ran into a timeout. Too many clearance attempts?
                // Maybe you should increase client.Timeout as each attempt will take about five seconds.
            }
        }

        public async Task<List<KeyValuePair<string, string>>> getLibraryUrl(string toBeSearched)
        {
            // Prende in input un url di ricerca prodotto da searchGenio
            // Ritorna un dizionario formato da (ie) 
            // The Social Network http://ilgeniodellostreaming.cc/film/the-social-network/
            // Si recupera poi il valore a seconda della chiave che ci interessa e lo si passa alla funzione sotto

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var source = getSourceFromUrl(toBeSearched).Result;
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

            var source = getSourceFromUrl(url);
            source.Wait();
            var html = source.Result;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
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

            var source = getSourceFromUrl(url);
            source.Wait();
            var html = source.Result;
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
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

        public async Task<string> playUrl(string url)
        {
            // Prende in ingresso un link simil http://ilgeniodellostreaming.cc/film/the-social-network/
            // Ritorna il link di openload da streammare

            var source = await getSourceFromUrl(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            var link = doc.DocumentNode.SelectSingleNode("//iframe[@class='metaframe rptss']");
            var href = link.GetAttributeValue("src", ""); // l?iframe nel genio era "src"
            return href;
        }

        /*
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
            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='episodios']"))
            {
                //var divs = div.SelectNodes("//div[@class='episodiotitle']");
                var lis = div.Descendants("li").ToList();

                foreach (var li in lis)
                {
                    var episodes = li.SelectNodes("//div[@class='episodiotitle']");
                    foreach (var episode in episodes)
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
        */

    }
}
