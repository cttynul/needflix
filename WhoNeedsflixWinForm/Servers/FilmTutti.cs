using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhoNeedsflixWinForm.Utils;

namespace WhoNeedsflixWinForm.Servers
{
    class FilmTutti
    {
        public string searchGenioUrl = "http://www.filmpertutti.black/?s=";

        public string search(string mySearch)
        {
            string result = "";
            result = searchGenioUrl + mySearch.Replace(" ", "+");
            return result;
        }

        public List<KeyValuePair<string, string>> getLibrary(string toBeSearched)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var webClient = new WebClient();
            var source = webClient.DownloadString(toBeSearched);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='posts']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("href", "");
                    var name = link.InnerText;
                    if (href.StartsWith("http://www.filmpertutti.black/fdh"))
                    {

                    }
                    else
                    {
                        name = name.Replace("Guarda ora", "");
                        if (Regex.IsMatch(name, "[0-9].[0-9]"))
                        {
                            name = Regex.Replace(name, "[0-9].[0-9]", "");
                        }
                        name = Regex.Replace(name, @"\t|\n|\r", "");
                        // Rimuovi parentesi e contenuto con Regex
                        name = Regex.Replace(name, @"\[.+?\]\s*", "");
                        name = Regex.Replace(name, @"\(.+?\)\s*", "");
                        name = Regex.Replace(name, "HD", "");
                        name = Regex.Replace(name, @"N/A", "");
                        byte[] bytes = Encoding.Default.GetBytes(name);
                        var nameFixed = Encoding.UTF8.GetString(bytes);
                        // rimuovi caratteri di merda
                        if (nameFixed.Contains("&#7;"))
                        {
                            nameFixed = nameFixed.Replace("&#7;", "'");
                        }
                        if (nameFixed.Contains("&#1;"))
                        {
                            nameFixed = nameFixed.Replace("&#1;", "-");
                        }
                        result.Add(new KeyValuePair<string, string>(nameFixed.Trim(), href));
                    }
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
            foreach (var div in doc.DocumentNode.SelectNodes("//ul[@class='posts']"))
            {
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    // take the value of the attribute
                    var href = link.GetAttributeValue("data-thumbnail", "");
                    if (href == "")
                    {

                    }
                    else
                    {
                        result.Add(href);
                    }
                }

            }
            return result;
        }

        public List<SeriesDictionary> getEpisodes(string url)
        {
            List<SeriesDictionary> result = new List<SeriesDictionary>();
            var webClient = new WebClient();
            int countEp = 1;
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            foreach (var div in doc.DocumentNode.SelectNodes("//p"))
            {
                SeriesDictionary _stagione = new SeriesDictionary();
                var nomeStagione = div.DescendantsAndSelf("strong").ToList();
                if (nomeStagione.First().InnerText.Contains("tagion") && nomeStagione.First().InnerText.Count() < 40)
                {
                    _stagione.Episodio = nomeStagione.First().InnerText.Replace("&#8211;", "-");
                    _stagione.Url = "";
                    countEp = 1;
                    result.Add(_stagione);
                }
                
                var links = div.Descendants("a").ToList();
                foreach (var link in links)
                {
                    var href = link.GetAttributeValue("href", "");
                    if (href.StartsWith("https://openload.co"))
                    {
                        SeriesDictionary _series = new SeriesDictionary();
                        href = href.Replace("f", "embed");
                        _series.Episodio = "Episodio " + countEp;
                        _series.Url = href;
                        countEp++;
                        result.Add(_series);
                    }
                    else if (href.StartsWith("http://speedvideo"))
                    {
                        SeriesDictionary _series = new SeriesDictionary();
                        href = href.Replace("http://speedvideo.net/", "");
                        int index = href.LastIndexOf("/");
                        if (index > 0)
                            href = href.Substring(0, index);
                        href = "http://speedvideo.net/embed-" + href + "-607x360.html";
                        _series.Episodio = "Episodio " + countEp;
                        _series.Url = href;
                        countEp++;
                        result.Add(_series);
                    }
                }
            }

            for(int i=0; i<result.Count; i++)
            {
                if (result.ElementAt(i).Url == "" && result.ElementAt(i+1).Url == "")
                    result.RemoveAt(i);
                else
                {
                    //tutto ok :)
                } 
            }

            return result;
        }

        public string playUrl(string url)
        {
            string result = "";
            int count = 0;
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            var source = webClient.DownloadString(url);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);

            try
            {
                foreach (var div in doc.DocumentNode.SelectNodes("//iframe[@scrolling='NO']"))
                {
                    var href = div.GetAttributeValue("src", "");
                    result = href;
                }
            }

            catch
            {
                result = "";
                Openload ol = new Openload();
                try
                {
                    foreach (var div in doc.DocumentNode.SelectNodes("//p"))
                    {
                        var links = div.Descendants("a").ToList();
                        foreach (var link in links)
                        {
                            var href = link.GetAttributeValue("href", "");
                            if (href.StartsWith("https://openload.co"))
                            {
                                href = href.Replace("/f/", "/embed/");
                                int index = href.LastIndexOf("/");
                                if (index > 0)
                                    href = href.Substring(0, index);
                                result = href;
                                count++;
                                if (count > 4)
                                    return "serie";
                            }
                            else if (href.StartsWith("http://speedvideo.net") && ol.checkIfWorks(result) == false)
                            {
                                count++;
                                href = href.Replace("http://speedvideo.net/", "");
                                int index = href.LastIndexOf("/");
                                if (index > 0)
                                    href = href.Substring(0, index);
                                href = "http://speedvideo.net/embed-" + href + "-607x360.html";
                                if (count > 4)
                                    return "serie";
                            }
                        }
                    }
                }
                catch
                {
                    //nothing
                }
            }
            return result;
        }

    }

 
}
