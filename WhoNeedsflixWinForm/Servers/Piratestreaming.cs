using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhoNeedsflixWinForm.Utils;

namespace WhoNeedsflixWinForm.Servers
{
    class Piratestreaming
    {
        public string searchUrl = "http://www.piratestreaming.black/cerca.php?all=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchUrl + mySearch.Replace(" ", "+");
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

        public List<KeyValuePair<string, string>> getLibraryUrl(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var webClient = new WebClient();
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            //var div = doc.DocumentNode.SelectSingleNode("//div[@class='featuredItem']");
            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='featuredText']"))
            {
                // there is only one links
                var link = div.Descendants("a").FirstOrDefault();
                if (link != null)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    string nameWithoutVK = name;
                    if (name.Contains("vk") || name.Contains("VK") || name.Contains("Vk"))
                    {
                        nameWithoutVK = nameWithoutVK.Replace("Vk", "");
                        nameWithoutVK = nameWithoutVK.Replace("VK", "");
                        nameWithoutVK = nameWithoutVK.Replace("vk", "");
                    }
                    byte[] bytes = Encoding.Default.GetBytes(nameWithoutVK);
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
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//a[@class='featuredImg']"))
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

        public List<string> getUrlFilm(string urlElement)
        {
            var webClient = new WebClient();
            var source = webClient.DownloadString(urlElement);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            List<string> result = new List<string>();

            foreach (var div in doc.DocumentNode.SelectNodes("//div[@class='featuredText']"))
            {
                // inizia lettura ogni linea dell'innerspan
                using (System.IO.StringReader reader = new StringReader(div.InnerText))
                {
                    string lines;

                    // leggi ogni linea
                    while ((lines = reader.ReadLine()) != null)
                    {
                        /// NON NECESSARIO PER FILM /////
                        string[] s_array = lines.Split('\n');
                        foreach (string line in s_array)
                        {
                            var links = div.Descendants("a").ToList();
                            foreach (var link in links)
                            {
                                var href = link.GetAttributeValue("href", "");
                                // L'innertext di link è il nome dell'host
                                var name = link.InnerText;
                                //name_host.Add(new KeyValuePair<string, string>(name, href));
                                if (name != " " || !name.Contains("Disqus") || name != "Continua a leggere")
                                {
                                    //result.Add(name);
                                }

                                result.Add(href);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public List<string> getUrlTVSeries(string urlElement)
        {
            // Cerco di recuperare la coppia numero episodio - link rapidvideo
            var webClient = new WebClient();
            var source = webClient.DownloadString(urlElement);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            List<string> result = new List<string>();

            foreach (var div in doc.DocumentNode.SelectNodes("//span[@style='font-size:12px;']"))
            {
                // inizia lettura ogni linea dell'innerspan
                using (StringReader reader = new StringReader(div.InnerText))
                {
                    string lines;

                    // leggi ogni linea
                    while ((lines = reader.ReadLine()) != null)
                    {
                        /// NON NECESSARIO PER FILM /////
                        string[] s_array = lines.Split('\n');
                        foreach (string line in s_array)
                        {
                            // Rimuovi i tab
                            string en_no = "";
                            string ep_notab = "";
                            try
                            {
                                en_no = line.Substring(0, line.IndexOf("&nbsp;"));
                            }
                            catch
                            {
                                en_no = line.Substring(0, line.IndexOf(" "));
                            }
                            try
                            {
                                ep_notab = en_no.Replace("\t", "");
                            }
                            catch
                            {

                            }
                            //Commento di debug, non aggiunto il numero dell'episodio
                            //result.Add(ep_notab);
                        }
                        var links = div.Descendants("a").ToList();//.Take(3); Perché usavo take 3????
                        foreach (var link in links)
                        {
                            var href = link.GetAttributeValue("href", "");
                            // L'innertext di link è il nome dell'host
                            var name = link.InnerText;
                            //name_host.Add(new KeyValuePair<string, string>(name, href));
                            // Non aggiungo il nome dell'host
                            //result.Add(name);
                            if (href.Contains("rapidvideo"))
                                result.Add(href);
                        }
                    }


                }

                //var name = div.InnerText.Substring(0, div.InnerText.IndexOf("&nbsp;"));
                //result.Add(name);
            }

            return result;

        }
    }
}
