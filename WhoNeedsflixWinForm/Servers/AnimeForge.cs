using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WhoNeedsflixWinForm.Servers
{
    class AnimeForge
    {
        public List<KeyValuePair<string, string>> getLibrary()
        {
            // Ritorna la lista di tutti gli anime
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            string toBeSearched = "http://www.animeforce.org/lista-anime/";
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//li"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;

                    string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
                    if (Regex.IsMatch(name, regex))
                        name = Regex.Replace(name, regex, "");
                    name = name.Replace("\t", "");
                    name = name.Replace("\n", "");
                    byte[] bytes = Encoding.Default.GetBytes(name);
                    var nameFixed = Encoding.UTF8.GetString(bytes);
                    // rimuovi caratteri di merda
                    if (nameFixed.Contains("&#8211;"))
                        nameFixed = nameFixed.Replace("&#8211;", "-");
                    if (nameFixed.Contains("&#8217;"))
                        nameFixed = nameFixed.Replace("&#8217;", "'");
                    if (nameFixed.Contains("Sub Ita Download &#038; Streaming"))
                        nameFixed = nameFixed.Replace("Sub Ita Download &#038; Streaming", "");
                    if (nameFixed.Contains("Sub Ita Download &amp; Streaming"))
                        nameFixed = nameFixed.Replace("Sub Ita Download &amp; Streaming", "");
                    if (nameFixed.Contains("Sub Ita Streaming"))
                        nameFixed = nameFixed.Replace("Sub Ita Streaming", "");
                    if (nameFixed.Contains("ANIME") || nameFixed.Contains("Lista Anime A-Z") || nameFixed.Contains("Ultime Serie") || nameFixed.Contains("Anime In Corso") || nameFixed.Contains("Anime Con Uscita Irregolare") || nameFixed.Contains("Ultma Serie") || nameFixed.Contains("Hentai") || nameFixed.Contains("Contacts") || nameFixed.Contains("Chat"))
                    {
                        // jump
                    }
                    else
                    {
                        // add
                        result.Add(new KeyValuePair<string, string>(nameFixed, href));
                    }
                }
            }
            return result;
        }

        public List<KeyValuePair<string, string>> search(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, string>> _db = getLibrary();

            for (int i = 0; i < _db.Count(); i++)
            {
                if (_db.ElementAt(i).Value.Contains(toBeSearched))
                {
                    result.Add(new KeyValuePair<string, string>(_db.ElementAt(i).Key, _db.ElementAt(i).Value));
                }
            }

            return result;
        }

        public List<KeyValuePair<string, string>> getEpisodes(string url)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            int i = 1;
            foreach (var div in doc.DocumentNode.SelectNodes("//td[@style='text-align: center;']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    if (link.InnerHtml.Contains("streaming"))
                    {
                        if (href.StartsWith("/ds.php"))
                            href = "http://www.animeforce.org/" + href;
                        result.Add(new KeyValuePair<string, string>("Episodio " + i, href));
                        i++;
                    }
                }

            }
            return result;
        }

        public List<string> playUrl(string url)
        {
            List<string> result = new List<string>();
            var webClient = new System.Net.WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            foreach (var div in doc.DocumentNode.SelectNodes("//h3[@class='web']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    result.Add(link.InnerText);
                }
            }
            return result;
        }
    }
}
