using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;

namespace WhoNeedsflixWinForm.Utils
{
    class TMDb
    {
        //TVDB Data
        TMDbClient _tmdb = new TMDbClient("6984403bd1456ef6dbc6a33a59cb32f4");

        public string getDescFilm(string filmName)
        {
            string result = "";

            try
            {
                var _filmresult = (_tmdb.SearchMovieAsync(filmName, "it").Result).Results.First();
                result = _filmresult.Overview;
                return result;
            }
            catch
            {
                return result;
            }
        }

        public string getDescSerie(string serieName)
        {
            string result = "";
            try
            {
                _tmdb.DefaultLanguage = "it";
                var _rmresult = (_tmdb.SearchTvShowAsync(serieName).Result).Results.First();
                result = _rmresult.Overview;
                return result;
            }
            catch
            {
                return result;
            }
        }

        public string getFilmPoster(string filmName)
        {
            string result = "";

            var _filmresult = (_tmdb.SearchMovieAsync(filmName).Result).Results.First();
            result = "https://image.tmdb.org/t/p/w640/" + _filmresult.PosterPath;
            return result;
        }

        public string getTvSeriesPoster(string filmName)
        {
            string result = "";

            var _filmresult = (_tmdb.SearchTvShowAsync(filmName).Result).Results.First();
            result = "https://image.tmdb.org/t/p/original/" + _filmresult.PosterPath;
            return result;
        }

        public string getBackgroundPoster(string fileName)
        {
            string result = "";
            var test = (_tmdb.SearchTvShowAsync(fileName).Result).Results.First();
            result = "https://image.tmdb.org/t/p/original/" + test.BackdropPath;
            return result;
        }

        public List<KeyValuePair<string, string>> getFilmInfo(List<KeyValuePair<string, string>> _urlElementi, int goForwardInfoResult)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var _myFilm = _urlElementi.ElementAt(goForwardInfoResult).Key;
            var _tmresult = _tmdb.SearchMovieAsync(_myFilm, "it").Result;

            foreach (var res in _tmresult.Results)
            {
                var desc = res.Overview;
                //result.Add(name, href);
                var url = "https://image.tmdb.org/t/p/w640/" + res.PosterPath;
                //result.Add(name, href);
                result.Add(new KeyValuePair<string, string>(url, desc));
            }
            return result;
        }

        public List<KeyValuePair<string, string>> getSerieInfo(List<KeyValuePair<string, string>> _urlElementi, int goForwardInfoResult)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            var _myFilm = _urlElementi.ElementAt(goForwardInfoResult).Key;
            var _tmresult = _tmdb.SearchTvShowAsync(_myFilm).Result;

            foreach (var res in _tmresult.Results)
            {
                var desc = res.Name;
                var url = "https://image.tmdb.org/t/p/w640/" + res.PosterPath;
                //result.Add(name, href);
                result.Add(new KeyValuePair<string, string>(url, desc));
            }
            return result;
        }
    }
}
