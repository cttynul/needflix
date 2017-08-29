using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using WhoNeedsflixWinForm.Servers;
using WhoNeedsflixWinForm.Utils;
using Gecko;
using TMDbLib;
using TMDbLib.Client;
using YoutubeSearch;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Collections;

namespace WhoNeedsflixWinForm
{

    public partial class MainForm : Form
    {
        private Ping _ping = new Ping();
        private Genio _genio = new Genio();
        private GenioDelloStreaming _genioDelloStreaming = new GenioDelloStreaming();
        private Guardaserie _gSerie = new Guardaserie();
        private Altadefinizione01 _a01 = new Altadefinizione01();
        private Piratestreaming _pirate = new Piratestreaming();
        private FilmTutti _filmPerTutti = new FilmTutti();
        private CinemaSubito _cinemaSubito = new CinemaSubito();
        private Cineblog01 _cb01 = new Cineblog01();
        private AnimeTube _animeTube = new AnimeTube();
        private AnimeForge _animeForge = new AnimeForge();
        private SerieHD _serieHD = new SerieHD();

        // utils
        private Openload _openload = new Openload();
        private Nowvideo _nowVideo = new Nowvideo();
        private Rapidvideo _rapidvideo = new Rapidvideo();
        private TMDb _tmdb = new TMDb();

        // helpers
        private bool hasAnimeBeenClicked = false;

        private List<KeyValuePair<string, string>> _urlElementi = new List<KeyValuePair<string, string>>();
        //List<KeyValuePair<string, string>> _serieTVEpisodi = new List<KeyValuePair<string, string>>();

        private List<string> _urlSeries = new List<string>();
        private string _currentUrlSerie = "";

        // Qui viene storato il nome della serie TV attualmente aperta da guardaserie
        private string _currentSerieName = "";

        private List<string> _urlImmagini = new List<string>();
        private List<string> _descrizioneContenuti = new List<string>();

        private int goForwardInfoResult = 0;
        private int goSeries = 0;
        public bool fullScreenMode;
        private uint fPreviousExecutionState;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MoveWindow(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // Nascosti bordi
            //this.FormBorderStyle = FormBorderStyle.None;


            Xpcom.Initialize("Firefox");
            _hideButtonBar.Visible = false;
            this.AcceptButton = searchButton;

            _gridTVSeries.DefaultCellStyle.Font = new Font("Segoe UI", 13);

            _richDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;

            _nextBtn.Visible = false;
            _backBtn.Visible = false;
            _fullScreen.Visible = false;
            _homeBtn.Visible = false;
            _downloadButton.Visible = false;

            _mainPic.Visible = true;

           if (_radioGuarda.Checked)
                _addToFavBtn.Visible = true;

            _helpButton.Visible = true;

            _labelResult.Visible = true;
            _labelCountResult.Visible = true;
            _resultPictureBox.Visible = true;
            _guardaButton.Visible = true;
            _trailerButton.Visible = true;

            // questa in basso è lo sfondo dei results
            //pictureBox1.Visible = true;

            searchTextBox.Visible = true;
            //searchButton.Visible = true;
            _richDescription.Visible = true;
            _header.Visible = true;

            // show radios
            _radioGuarda.Visible = true;
            _radioA01.Visible = true;

            _combobox.Visible = true;
            PopulateCombobox();

            // show linklabes
            _tvShowTimeLabel.Visible = true;

            // show favs button
            _showFavsIcon.Visible = true;

        }

        public void PlayerLayout()
        {
            _headerBackground.Visible = true;
            _footerBackground.Visible = true;
            _headerPlayerImage.Visible = true;

            _closeBtn.Visible = false;
            _maximizeBtn.Visible = false;
            _iconizeBtn.Visible = false;

            _labelResult.Visible = false;
            _labelCountResult.Visible = false;
            _resultPictureBox.Visible = false;
            searchTextBox.Visible = false;
            //searchButton.Visible = false;
            _richDescription.Visible = false;
            _headerBGHome.Visible = false;
            _header.Visible = false;
            _nextBtn.Visible = false;
            _backBtn.Visible = false;
            _helpButton.Visible = false;
            pictureBox1.Visible = false;

            //black background
            this.BackColor = Color.Black;

            // Play button
            _guardaButton.Visible = false;
            _trailerButton.Visible = false;

            // Hide Radios
            _radioGuarda.Visible = false;
            _radioA01.Visible = false;
            _radioAnime.Visible = false;

            _combobox.Visible = false;

            //hide tvshowtime
            _tvShowTimeLabel.Visible = false;

            // hide add to favs label
            _addToFavBtn.Visible = false;

            // hide header icon (except fullscreen a cui fai un recolor, mi ero rotto il cazzo di scrivere in english)
            _showFavsIcon.Visible = false;
            _aboutIcon.Visible = false;
            _settingsIcon.Visible = false;
            _settingsIcon.Visible = false;
            _searchIcon.Visible = false;
            _helpIcon.Visible = false;
            _fullscreenHeaderBtn.BackColor = System.Drawing.Color.Black;

            // hide grid episodi serie tv
            _gridTVSeries.Visible = false;

            _homeBtn.Visible = true;
            _downloadButton.Visible = true;

            _fullScreen.Visible = true;
            _hideButtonBar.Visible = true;
        }

        public void InitBrowser(string url)
        {

            //Kill popup
            _geckoWebBrowser.CreateWindow += new EventHandler<GeckoCreateWindowEventArgs>(KillPopup);

            _geckoWebBrowser.Visible = true;
            //_geckoWebBrowser.Dock = DockStyle.Fill;
            _geckoWebBrowser.Navigate(url);
            GeckoPreferences.User["browser.xul.error_pages.enabled"] = true;
            GeckoPreferences.User["security.enable_ssl2"] = true;
            GeckoPreferences.User["security.default_personal_cert"] = "Ask Never";
            GeckoPreferences.User["security.warn_entering_weak"] = true;
            GeckoPreferences.User["security.warn_viewing_mixed"] = true;
            GeckoPreferences.User["dom.disable_open_during_load"] = true;
            GeckoPreferences.User["dom.allow_scripts_to_close_windows"] = true;
            GeckoPreferences.User["dom.popup_maximum"] = 0;
            GeckoPreferences.Default["extensions.blocklist.enabled"] = false;

            // boost prferences
            GeckoPreferences.User["browser.cache.disk.enable"] = true;
            GeckoPreferences.User["browser.xul.error_pages.enabled"] = true;
            GeckoPreferences.User["browser.cache.disk.capacity"] = 358400;
            GeckoPreferences.User["browser.cache.disk.filesystem_reported"] = 1;
            GeckoPreferences.User["browser.cache.disk.smart_size.first_run"] = false;
            GeckoPreferences.User["browser.cache.frecency* _experiment"] = 4;

            // enable fullscreen
            GeckoPreferences.User["full-screen-api.enabled"] = true;
            GeckoPreferences.User["full-screen-api.approval-required"] = false;
            GeckoPreferences.User["full-screen-api.content-only"] = true;
            GeckoPreferences.User["full-screen-api.ignore-widgets"] = true;

            _geckoWebBrowser.EnableDefaultFullscreen();

            PlayerLayout();
        }

        void KillPopup(object sender, GeckoCreateWindowEventArgs e)
        {
            if (e.Uri.ToString().Contains("facebook"))
            {

            }
            else
            {
                //Keep popup new window here!
                e.Cancel = true;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchBtn();
        }

        private void searchBtn()
        {
            // Reset things e nascondi immagine di errore
            _urlElementi.Clear();
            _currentSerieName = "";
            _labelResult.Text = "NoResult";
            _guardaButton.Visible = true;
            _trailerButton.Visible = true;
            //_serieTVEpisodi.Clear();
            _mainPic.Visible = false;

            // nascondi grid
            _gridTVSeries.Visible = false;

            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            _currentUrlSerie = "";
            goForwardInfoResult = 0;

            if (_radioGuarda.Checked == true && (string) _combobox.SelectedItem == "Serie TV - 720p")
                GuardaSerieCerca();

            else if (_radioGuarda.Checked == true && (string)_combobox.SelectedItem == "Film e Serie TV - 720p")
                FilmPerTuttiCerca();
            
            else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film (ITA) - 1080p")
                CinemaSubitoCerca();

            else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film (ENG) - 1080p")
                OpenLoadMovieCerca();

            else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film e Serie TV - 720p")
                FilmPerTuttiCerca();

            else if (_radioAnime.Checked == true && (string) _combobox.SelectedItem == "Anime ITA e SUB-ITA")
                AnimeForgeCerca();

            else if (_radioAnime.Checked && (string)_combobox.SelectedItem == "Anime (SUB-ITA)")
                AnimeTubeCerca();

            if (_labelResult.Text == "NoResult")
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
                _guardaButton.Visible = false;
                _trailerButton.Visible = false;
            }

            /*
            _errorNotFound.Visible = false;
            _errorNotFound.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
            _errorNotFound.BackColor = Color.Transparent;
            */
        }

        private void _labelResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (_radioGuarda.Checked && (string)_combobox.SelectedItem == "Serie TV - 720p")
                {
                    if (_gridTVSeries.Visible == true)
                    {
                        int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
                        string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
                        InitBrowser(urlSelectedSeries);
                    }
                    else
                        GuardaSerieLabelClick();
                }
                else if (_radioGuarda.Checked == true && (string)_combobox.SelectedItem == "Film e Serie TV - 720p")
                {
                    if (_gridTVSeries.Visible == true)
                    {
                        int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
                        string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
                        InitBrowser(urlSelectedSeries);
                    }
                    else
                        FilmPerTuttiLabelClick();
                }

                else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film (ITA) - 1080p")
                    CinemaSubitoLabelClick();

                else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film (ENG) - 1080p")
                    OpenLoadMovieLabelClick();

                else if (_radioA01.Checked == true && (string) _combobox.SelectedItem == "Film e Serie TV - 720p")
                    FilmPerTuttiLabelClick();

                else if (_radioAnime.Checked == true && (string)_combobox.SelectedItem == "Anime ITA e SUB-ITA")
                {
                    if (_gridTVSeries.Visible == true)
                    {
                        int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
                        string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
                        if (urlSelectedSeries.Contains("youtube"))
                        {
                            urlSelectedSeries = urlSelectedSeries.Replace("watch?v=", "embed/");
                            InitBrowser(urlSelectedSeries);
                        }
                        else
                        {
                            InitBrowser(urlSelectedSeries);
                        }
                    }
                    else
                        AnimeForgeLabelClick();
                }
                else if(_radioAnime.Checked == true && (string)_combobox.SelectedItem == "Anime (SUB-ITA)")
                {
                    if (_gridTVSeries.Visible == true)
                    {
                        int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
                        string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
                        InitBrowser(urlSelectedSeries);
                    }
                    else
                        AnimeTubeLabelClick();
                }
            }
            catch
            {
                MessageBox.Show("Impossibile aprire media selezionato a causa di un errore interno! Controlla la tua connessione internet", "Damn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _nextResult_Click(object sender, EventArgs e)
        {
            goForwardInfoResult++;
            try
            {
                PopulateInfo();
            }
            catch
            {
                goForwardInfoResult = 0;
                PopulateInfo();
            }
        }

        private void _backBtn_Click(object sender, EventArgs e)
        {
             goForwardInfoResult--;
             try
             {
                PopulateInfo();
             }
             catch
             {
                goForwardInfoResult = 0;
                PopulateInfo();
             }
           
        }


        private void PopulateInfo()
        {
            try
            {
                var goNextUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;
                var url = _urlElementi.ElementAt(goForwardInfoResult).Value;
                _labelResult.Text = goNextUrl;
                var currentUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;

                if (_radioAnime.Checked || _radioGuarda.Checked)
                {
                    try
                    {
                        if (_tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                        {
                            //_richDescription.Text = goNextDesc;
                            _richDescription.Text = _tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key);
                        }
                        else
                        {
                            _richDescription.Text = "Non c'è ancora nessuna descrizione disponibile per questo film o serie TV";
                        }

                        if (_tmdb.getTvSeriesPoster(currentUrl) != "")
                        {
                            _resultPictureBox.Load(_tmdb.getTvSeriesPoster(currentUrl));
                        }

                        else if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                        {
                            var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                            //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                            // Populate results

                            _resultPictureBox.Load(goNextPic);

                        }
                    }
                    catch
                    {
                        // nothing to change
                        if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                        {
                            var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                            //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                            // Populate results

                            _resultPictureBox.Load(goNextPic);
                        }

                    }
                }
                else
                {
                    if (_tmdb.getDescFilm(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                    {
                        _richDescription.Text = _tmdb.getDescFilm(_urlElementi.ElementAt(goForwardInfoResult).Key);
                    }
                    else if (_tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                    {
                        //_richDescription.Text = goNextDesc;
                        _richDescription.Text = _tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key);
                    }
                    else
                    {
                        _richDescription.Text = "Non c'è ancora nessuna descrizione disponibile per questo film o serie TV";
                    }

                    if (_tmdb.getFilmPoster(currentUrl) != "")
                    {
                        _resultPictureBox.Load(_tmdb.getFilmPoster(currentUrl));
                    }

                    else if (_tmdb.getTvSeriesPoster(currentUrl) != "")
                    {
                        _resultPictureBox.Load(_tmdb.getTvSeriesPoster(currentUrl));
                    }

                    else if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                    {
                        var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                        //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                        // Populate results

                        _resultPictureBox.Load(goNextPic);

                    }
                }

            }
            catch
            {
                try
                {
                    var goNextUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;
                    var goNextName = _urlElementi.ElementAt(goForwardInfoResult).Value;
                    _labelResult.Text = goNextUrl;
                    var currentUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;

                    if (_radioGuarda.Checked)
                    {
                        try
                        {
                            if (_tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                            {
                                //_richDescription.Text = goNextDesc;
                                _richDescription.Text = _tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key);
                            }
                        }
                        catch
                        {
                            _richDescription.Text = "Non c'è ancora nessuna descrizione disponibile per questo film o serie TV";
                        }

                        try
                        {
                            if (_tmdb.getTvSeriesPoster(currentUrl) != "")
                            {
                                _resultPictureBox.Load(_tmdb.getTvSeriesPoster(currentUrl));
                            }

                            else if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                            {
                                var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                                //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                                _resultPictureBox.Load(goNextPic);

                            }
                        }
                        catch
                        {
                            if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                            {
                                var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                                //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                                _resultPictureBox.Load(goNextPic);

                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_tmdb.getDescFilm(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                            {
                                _richDescription.Text = _tmdb.getDescFilm(_urlElementi.ElementAt(goForwardInfoResult).Key);
                            }
                            else if (_tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key) != "")
                            {
                                //_richDescription.Text = goNextDesc;
                                _richDescription.Text = _tmdb.getDescSerie(_urlElementi.ElementAt(goForwardInfoResult).Key);
                            }
                            else
                            {
                                _richDescription.Text = "Non c'è ancora nessuna descrizione disponibile per questo film o serie TV";
                            }
                        }
                        catch
                        {
                            _richDescription.Text = "Non c'è ancora nessuna descrizione disponibile per questo film o serie TV";
                        }

                        try
                        {
                            if (_tmdb.getFilmPoster(currentUrl) != "")
                            {
                                _resultPictureBox.Load(_tmdb.getFilmPoster(currentUrl));
                            }
                            else if (_tmdb.getTvSeriesPoster(currentUrl) != "")
                            {
                                _resultPictureBox.Load(_tmdb.getTvSeriesPoster(currentUrl));
                            }

                            else if (!Regex.IsMatch(goNextUrl, @"^\d+"))
                            {
                                var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                                //var goNextDesc = _descrizioneContenuti.ElementAt(goForwardInfoResult);

                                // Populate results

                                _resultPictureBox.Load(goNextPic);

                            }
                        }
                        catch
                        {
                            var goNextPic = _urlImmagini.ElementAt(goForwardInfoResult);
                            _resultPictureBox.Load(goNextPic);
                        }
                    }
                }
                catch
                {
                    goForwardInfoResult = 0;
                    if(_labelResult.Text == "NoResult")
                    {
                        _mainPic.Visible = true;
                        _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                    }
                }
            }
            int countCurrent = goForwardInfoResult + 1;
            int countTotal = Convert.ToInt32(_urlElementi.Count());
            _labelCountResult.Text = "Risultati: " + countCurrent + " di " + countTotal;
        }

        private void populateInfoTVDB(int goForwardInfoResult)
        {
            if (_genio.checkIfFilm(_urlElementi.ElementAt(goForwardInfoResult).Value))
            {
                _labelResult.Text = _urlElementi.ElementAt(goForwardInfoResult).Key;

                var filmResult = _tmdb.getFilmInfo(_urlElementi, goForwardInfoResult);
                var desc = filmResult.ElementAt(goForwardInfoResult).Value;
                var pic = filmResult.ElementAt(goForwardInfoResult).Key;

                _richDescription.Text = desc;
                _resultPictureBox.Load(pic);

                _resultPictureBox.Width = 85;
                _resultPictureBox.Height = 150;
            }
            else
            {
                var filmResult = _tmdb.getSerieInfo(_urlElementi, goForwardInfoResult);
                var pic = filmResult.ElementAt(goForwardInfoResult).Key;
                var desc = filmResult.ElementAt(goForwardInfoResult).Value;

                _labelResult.Text = _urlElementi.ElementAt(goForwardInfoResult).Key;

                _richDescription.Text = desc;
                _resultPictureBox.Load(pic);

                _resultPictureBox.Width = 85;
                _resultPictureBox.Height = 150;
            }
        }

        private void PopulateSerie()
        {
            try
            {
                var goNextUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;
                var goNextName = _urlElementi.ElementAt(goForwardInfoResult).Value;

                _labelResult.Text = goNextUrl;
                goForwardInfoResult = 0;
            }
            catch
            {
                goForwardInfoResult = 0;
                var goNextUrl = _urlElementi.ElementAt(goForwardInfoResult).Key;
                var goNextName = _urlElementi.ElementAt(goForwardInfoResult).Value;
            }

        }

        private void _fullScreen_Click(object sender, EventArgs e)
        {
            FullScreen fullScreen = new FullScreen();

            if (fullScreenMode == false)  // FullScreenMode is an enum
            {
                fullScreen.EnterFullScreenMode(this);
                fullScreenMode = true;

                if (_fullScreen.Image != null)
                    _fullScreen.Image = WhoNeedsflixWinForm.Properties.Resources.diagonal_1_;
                
                _fullscreenHeaderBtn.Image = WhoNeedsflixWinForm.Properties.Resources.diagonal_1_;

                // Prevent from going to sleep zzz
                fPreviousExecutionState = NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            }
            else
            {
                fullScreen.LeaveFullScreenMode(this);
                fullScreenMode = false;

                _fullScreen.Visible = true;

                if (_fullScreen.Image != null)
                    _fullScreen.Image = WhoNeedsflixWinForm.Properties.Resources.stretch_2_;

                _fullscreenHeaderBtn.Image = WhoNeedsflixWinForm.Properties.Resources.stretch_2_;

                // Restore old config from going to sleep
                NativeMethods.SetThreadExecutionState(fPreviousExecutionState);
            }
        }

        private void _miniFullScreen_Click(object sender, EventArgs e)
        {
            FullScreen fullScreen = new FullScreen();

            if (fullScreenMode == false)  // FullScreenMode is an enum
            {
                fullScreen.EnterFullScreenMode(this);
                fullScreenMode = true;

                //_miniNoFullScreen.Visible = true;

                // bottoni
                _hideButtonBar.Visible = false;
                _showBottomBar.Visible = true;

                // nascondi footer and header (tranne logo a dx)
                _footerBackground.Visible = false;
                _headerBackground.Visible = false;
                _headerPlayerImage.Visible = true;
            }
            else
            {
                fullScreen.LeaveFullScreenMode(this);
                fullScreenMode = false;

                // bottoni
                //_miniNoFullScreen.Visible = false;

                _hideButtonBar.Visible = false;
                _showBottomBar.Visible = true;

                // nascondi footer
                _footerBackground.Visible = false;

                _headerPlayerImage.Visible = true;
                _headerBackground.Visible = true;
            }
        }

        private void _homeBtn_Click(object sender, EventArgs e)
        {
            _geckoWebBrowser.Navigate("http://www.e-try.com/black.htm");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));

            if (_labelResult.Text.Contains("Episodi"))
                _gridTVSeries.Visible = true;

            _mainPic.Visible = false;

            /* reshowa close, minimize, iconize
            _closeBtn.Visible = true;
            _maximizeBtn.Visible = true;
            _iconizeBtn.Visible = true;
            */
            _geckoWebBrowser.Visible = false;
            _homeBtn.Visible = false;
            _downloadButton.Visible = false;
            _headerBackground.Visible = false;
            _headerBGHome.Visible = true;
            _footerBackground.Visible = false;
            _headerPlayerImage.Visible = false;

            if(_radioGuarda.Checked)
                _addToFavBtn.Visible = true;

            _helpButton.Visible = true;

            _labelResult.Visible = true;
            _labelCountResult.Visible = true;
            _resultPictureBox.Visible = true;
            _guardaButton.Visible = true;
            _trailerButton.Visible = true;

            // questa in basso è lo sfondo dei results
            //pictureBox1.Visible = true;

            searchTextBox.Visible = true;
            //searchButton.Visible = true;
            _richDescription.Visible = true;
            _header.Visible = true;
            _nextBtn.Visible = true;
            _backBtn.Visible = true;

            // show radios
            _radioGuarda.Visible = true;
            _radioA01.Visible = true;
            _radioAnime.Visible = true;

             _combobox.Visible = true;

            // show linklabes
            _tvShowTimeLabel.Visible = true;

            // show favs button
            _showFavsIcon.Visible = true;

            _fullScreen.Visible = false;
            _hideButtonBar.Visible = false;
            //_miniNoFullScreen.Visible = false;

            _headerBackground.Visible = false;
            _footerBackground.Visible = false;
            _headerPlayerImage.Visible = false;

            // reshow header icons and recolora _fullscreenheaderbtn
            _fullscreenHeaderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            _showFavsIcon.Visible = true;
            _aboutIcon.Visible = true;
            _settingsIcon.Visible = true;
            _settingsIcon.Visible = true;
            _searchIcon.Visible = true;
            _helpIcon.Visible = true;

            // Non voglio mostrare una pagina incompleta quindi faccio apparire lo splashscreen!
            if (_labelResult.Text == "NoResult")
            {
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
                _mainPic.BackColor = Color.Transparent;
            }
        }

        private void _hideButtonBar_Click(object sender, EventArgs e)
        {
            /*
            if (fullScreenMode == false)  // FullScreenMode is an enum
            {
               // _miniFullScreen.Visible = true;
            }
            else
            {
                ////_miniNoFullScreen.Visible = true;
            }

            _geckoWebBrowser.Dock = DockStyle.Fill;

            _noFullScreen.Visible = false;
            _fullScreen.Visible = false;
            _hideButtonBar.Visible = false;
            _homeBtn.Visible = false;
            _downloadButton.Visible = false;

            _footerBackground.Visible = false;
            _headerBackground.Visible = false;

            _showBottomBar.Visible = true;*/

            if (_geckoWebBrowser.Dock == DockStyle.None)
            {
                _geckoWebBrowser.Dock = DockStyle.Fill;
                if ((string)_combobox.SelectedItem == "Serie TV #2")
                {
                    _headerPlayerImage.Visible = true;
                    _headerBackground.Visible = true;
                    _headerBackground.Size = new System.Drawing.Size(1036, 177);
                    _headerBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                }
            }
            else
            {
                _geckoWebBrowser.Dock = DockStyle.None;
                _geckoWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                _geckoWebBrowser.Width = this.Width;
                _geckoWebBrowser.Height = this.Height - 56;

                if ((string)_combobox.SelectedItem == "Serie TV #2")
                {
                    _headerPlayerImage.Visible = false;
                    _headerBackground.Visible = false;
                    _headerBackground.Size = new System.Drawing.Size(1036, 56);
                    _headerBackground.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                }
            }

            if(_fullScreen.Image == null)
            {
                _homeBtn.Image = WhoNeedsflixWinForm.Properties.Resources.left_arrow;
                _downloadButton.Image = WhoNeedsflixWinForm.Properties.Resources.cloud_computing;
                _hideButtonBar.Image = WhoNeedsflixWinForm.Properties.Resources.slim_down;
                if(fullScreenMode == true)
                    _fullScreen.Image = WhoNeedsflixWinForm.Properties.Resources.diagonal_1_;
                else
                    _fullScreen.Image = WhoNeedsflixWinForm.Properties.Resources.stretch_2_;

            }
            else if(fullScreenMode == true)
            {
                //_geckoWebBrowser.Dock = DockStyle.Fill;
                _fullScreen.Image = null;
                _downloadButton.Image = null;
                _homeBtn.Image = null;
                _hideButtonBar.Image = WhoNeedsflixWinForm.Properties.Resources.slim_up;
            }
            else if(fullScreenMode == false)
            {
                _fullScreen.Image = null;
                _downloadButton.Image = null;
                _homeBtn.Image = null;
                _hideButtonBar.Image = WhoNeedsflixWinForm.Properties.Resources.slim_up;
                /*
                _geckoWebBrowser.Dock = DockStyle.None;
                _geckoWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                _geckoWebBrowser.Width = this.Width;
                _geckoWebBrowser.Height = this.Height - 56;
                */
            }

        }

        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
        }

        private void _downloadButton_Click(object sender, EventArgs e)
        {
            var currentUrl = _geckoWebBrowser.Url.ToString();
            
            if (currentUrl.Contains("openload"))
            {
                var toBeDownloaded = _openload.getDownloadlink(currentUrl);
                var downloadNow = _openload.downloadOpanload(toBeDownloaded);
                DialogResult result = MessageBox.Show("Wut!? Sembra che puoi scaricare questo film!\nSe sei interessato clicca sì, altrimenti verrai indirizzato alla pagina per il download dei sottotitoli", "Wut?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(downloadNow);
                }
                else if (result == DialogResult.No)
                {
                    string _srtSearch = "http://www.addic7ed.com/search.php?search=";
                    string _toBeSearched = _srtSearch + _currentSerieName.Replace(" ", "+") + _labelResult.Text.Replace(" ", "+");
                    System.Diagnostics.Process.Start(_toBeSearched);
                }
            }
            else
            {
                string _srtSearch = "http://www.addic7ed.com/search.php?search=";
                string _toBeSearched = _srtSearch + _currentSerieName.Replace(" ", "+") + _labelResult.Text.Replace(" ", "+");
                System.Diagnostics.Process.Start(_toBeSearched);
            }
        }

        private void _helpPic_Click(object sender, EventArgs e)
        {
            //_helpPic.Visible = false;
        }

        private void _helpButton_LinkClicked(object sender, EventArgs e)
        {
            //_helpPic.Visible = true;
        }

        /*
         * AGGIUNGI ELEMENTO A PREFERITI E VISUALIZZA PREFERITI
         * 
         */

        private void AddToFavsAndShow()
        {
            try
            {
                TextWriter writer = new StreamWriter("fav.txt", true);
                writer.WriteLine(_urlElementi.ElementAt(goForwardInfoResult).Value + "@" + _urlElementi.ElementAt(goForwardInfoResult).Key);
                writer.Close();

                List<string> tempList = new List<string>();
                List<KeyValuePair<string, string>> tempDictionary = new List<KeyValuePair<string, string>>();

                StreamReader file = new StreamReader("fav.txt");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] toBeSplitted = line.Split('@');

                    foreach (var element in toBeSplitted)
                    {
                        tempList.Add(element);
                    }
                }
                file.Close();

                for (int i = 0; i < tempList.Count(); i++)
                {
                    tempDictionary.Add(new KeyValuePair<string, string>(tempList.ElementAt(i + 1), tempList.ElementAt(i)));
                    i++;
                }
                _urlElementi = tempDictionary;
                _radioA01.Checked = true;
                PopulateInfo();
            }
            catch
            {
                MessageBox.Show("Impossibile aggiungere l'elemento selezionato alla lista dei preferiti!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToFavs()
        {
            try
            {
                TextWriter writer = new StreamWriter("fav.txt", true);
                writer.WriteLine(_urlElementi.ElementAt(goForwardInfoResult).Value + "@" + _urlElementi.ElementAt(goForwardInfoResult).Key);
                writer.Close();

                MessageBox.Show(_urlElementi.ElementAt(goForwardInfoResult).Key + " è stato correttamente aggiunto alla lista dei preferiti!", "Yeah", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Impossibile aggiungere l'elemento selezionato alla lista dei preferiti!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFavs()
        {
            try
            {
                List<string> tempList = new List<string>();
                List<KeyValuePair<string, string>> tempDictionary = new List<KeyValuePair<string, string>>();

                StreamReader file = new StreamReader("fav.txt");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] toBeSplitted = line.Split('@');

                    foreach (var element in toBeSplitted)
                    {
                        tempList.Add(element);
                    }
                }
                file.Close();

                for (int i = 0; i < tempList.Count(); i++)
                {
                    tempDictionary.Add(new KeyValuePair<string, string>(tempList.ElementAt(i + 1), tempList.ElementAt(i)));
                    i++;
                }
                _urlElementi = tempDictionary;
                _radioGuarda.Checked = true;
                PopulateInfo();

                if (_mainPic.Visible)
                {
                    _mainPic.Visible = false;
                    _guardaButton.Visible = true;
                    _trailerButton.Visible = true;
                    _nextBtn.Visible = true;
                    _backBtn.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("Impossibile visualizzare la lista dei preferiti!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
            if(_labelResult.Text == "NoResult")
            {
                MessageBox.Show("Impossibile visualizzare la lista dei preferiti!", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
        }

        /*
         * GUARDASERIE FUNZIONI
         * PER NON INTASARE IL CODICE
         */

        private void GuardaSerieCerca()
        {
            _addToFavBtn.Visible = true;
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;

                string resultSearch = _gSerie.search(searchTextBox.Text);
                _urlElementi = _gSerie.getLibraryUrl(resultSearch);

                _urlImmagini = _gSerie.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();
            }
            catch
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
        }

        private void GuardaSerieLabelClick()
        {
            if (_urlElementi.ElementAt(goForwardInfoResult).Value.Contains("guarda"))
            {
                List<SeriesDictionary> _serieTVEpisodi = new List<SeriesDictionary>();

                // Apro serie
                _urlSeries = _gSerie.getEpisodes(_urlElementi.ElementAt(goForwardInfoResult).Value);
                // salvo il nome della serie
                _currentSerieName = _urlElementi.ElementAt(goForwardInfoResult).Key;
                int countUrl = (_urlSeries.Count() / 3) * 2;
                int countEpName = _urlSeries.Count / 3;
                for (int countEp = 0; countEp < _urlSeries.Count() / 3; countEp++)
                {
                    //_serieTVEpisodi.Add(new KeyValuePair<string, string>(_urlSeries.ElementAt(countEp), _urlSeries.ElementAt(countUrl)));
                    SeriesDictionary _series = new SeriesDictionary();
                    {
                        var epNameTemp = _urlSeries.ElementAt(countEpName);
                        if(epNameTemp == String.Empty)
                            epNameTemp = "Nessun titolo disponibile";
                        
                        _series.Episodio = _urlSeries.ElementAt(countEp) + " - " + epNameTemp;
                        _series.Url = _urlSeries.ElementAt(countUrl);
                        _serieTVEpisodi.Add(_series);
                    }
                    countUrl++;
                    countEpName++;
                }
                //_urlElementi = _serieTVEpisodi;

                // Show grid
                seriesDictionaryBindingSource.DataSource = _serieTVEpisodi;
                _gridTVSeries.Visible = true;
                _labelResult.Text = _labelResult.Text + " - Episodi";
                goForwardInfoResult = 0;
                //PopulateSerie();
            }
            else
            {
                //InitBrowser(_urlElementi.ElementAt(goForwardInfoResult).Value);
            }
        }

        /*
         * AnimeForge
         * Handlers
         */
        private void AnimeForgeCerca()
        {
            _addToFavBtn.Visible = true;
            //try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;

                _urlElementi = _animeForge.search(searchTextBox.Text);

                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                foreach (var el in _urlElementi)
                {
                    _urlImmagini.Add("http://reelcinemas.ae/Images/Movies/not-found/no-poster.jpg");
                }

                // Populate results
                PopulateInfo();
                goForwardInfoResult = 0;
            }

        }

        private void AnimeForgeLabelClick()
        {
            var el = _urlElementi.ElementAt(goForwardInfoResult).Value;
            if (!el.Contains("?file=") || !el.Contains("vvvvid") || !el.Contains("youtube") || !el.Contains("bit"))
            {
                List<SeriesDictionary> _serieTVEpisodi = new List<SeriesDictionary>();

                // Apro serie
                var _urls = _animeForge.getEpisodes(_urlElementi.ElementAt(goForwardInfoResult).Value);
                // salvo il nome della serie

                foreach (var _url in _urls)
                {
                    //_serieTVEpisodi.Add(new KeyValuePair<string, string>(_urlSeries.ElementAt(countEp), _urlSeries.ElementAt(countUrl)));
                    SeriesDictionary _series = new SeriesDictionary();
                    _series.Episodio = _url.Key;
                    _series.Url = _url.Value;
                    _serieTVEpisodi.Add(_series);
                }
                //_urlElementi = _serieTVEpisodi;

                // Show grid
                seriesDictionaryBindingSource.DataSource = _serieTVEpisodi;
                _gridTVSeries.Visible = true;
                _labelResult.Text = _labelResult.Text + " - Episodi";
                goForwardInfoResult = 0;
                //PopulateSerie();
            }
            else
            {
                if (el.Contains("youtube"))
                {
                    el = el.Replace("watch?v=", "embed/");
                    InitBrowser(el);
                }
                else
                {
                    InitBrowser(el);
                }
            }
        }

        /*
         * AnimeTubeIta
         * Handlers
         */
        private void AnimeTubeCerca()
        {
            _addToFavBtn.Visible = true;
            //try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;
                
                _urlElementi = _animeTube.search(searchTextBox.Text);

                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                foreach(var el in _urlElementi)
                {
                    _urlImmagini.Add("http://reelcinemas.ae/Images/Movies/not-found/no-poster.jpg");
                }

                // Populate results
                PopulateInfo();
                goForwardInfoResult = 0;
            }
            
        }

        private void AnimeTubeLabelClick()
        {
            if (!_urlElementi.ElementAt(goForwardInfoResult).Value.Contains("strm"))
            {
                List<SeriesDictionary> _serieTVEpisodi = new List<SeriesDictionary>();

                // Apro serie
                var _urls = _animeTube.getEpisodes(_urlElementi.ElementAt(goForwardInfoResult).Value);
                // salvo il nome della serie

                foreach (var _url in _urls)
                {
                    //_serieTVEpisodi.Add(new KeyValuePair<string, string>(_urlSeries.ElementAt(countEp), _urlSeries.ElementAt(countUrl)));
                    SeriesDictionary _series = new SeriesDictionary();
                    _series.Episodio = _url.Key;
                    _series.Url = _url.Value;
                    _serieTVEpisodi.Add(_series);
                }
                //_urlElementi = _serieTVEpisodi;

                // Show grid
                seriesDictionaryBindingSource.DataSource = _serieTVEpisodi;
                _gridTVSeries.Visible = true;
                _labelResult.Text = _labelResult.Text + " - Episodi";
                goForwardInfoResult = 0;
                //PopulateSerie();
            }
            else if(_urlElementi.ElementAt(goForwardInfoResult).Value.EndsWith(".mp4"))
            {
                InitBrowser(_urlElementi.ElementAt(goForwardInfoResult).Value);
            }
        }

        /*
         * Altadefinizione01
         * Handlers
         */
        private void CinemaSubitoCerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_addToFavBtn.Visible = true;
                //_helpPic.Visible = false;

                string resultSearch = _cinemaSubito.search(searchTextBox.Text);
                _urlElementi = _cinemaSubito.getLibraryUrl(resultSearch);
                _urlImmagini = _cinemaSubito.getUrlImage(resultSearch);
                // Populate results
                PopulateInfo();

            }
            catch
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
        }

        private void CinemaSubitoLabelClick()
        {
            // cerca di recuperare il link di openload
            string _olUrl = _cinemaSubito.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
            // check se esiste url di openload
            var _toBeStreamed = _openload.getEmbedOpenloadlink(_olUrl);

            if (_openload.checkIfWorks(_toBeStreamed))
            {
                try
                {
                    InitBrowser(_toBeStreamed);
                }
                catch
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
        }

        /*
         * Altadefinizione01
         * Handlers
         */
        private void A01Cerca()
        {
            var isReachable = _ping.PingHost(_a01.masterUrl);
            if (isReachable == false)
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_addToFavBtn.Visible = true;
                //_helpPic.Visible = false;

                string resultSearch = _a01.search(searchTextBox.Text);
                _urlElementi = _a01.getLibraryUrl(resultSearch);

                _urlImmagini = _a01.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();

            }
            catch
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
        }

        private void A01LabelCLick()
        {
            string _filmUrl = "";
            // cerca di recuperare il link di openload
            string _olUrl = _a01.getOpenloadUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
            _olUrl = _openload.getEmbedOpenloadlink(_olUrl);
            // check se esiste url di openload

            if (_openload.checkIfWorks(_olUrl))
            {
                try
                {
                    InitBrowser(_olUrl);
                }
                catch
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
            // altrimenti prendi quello in iframe, spesso megahd
            else
            {
                _filmUrl = _a01.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                // nel caso in cui quello in iframe sia openload faccio il check
                if (_filmUrl.Contains("openload"))
                {
                    if (_openload.checkIfWorks(_filmUrl))
                    {
                        InitBrowser(_filmUrl);
                    }
                    else
                    {
                        InitBrowser("http://www.e-try.com/black.htm");
                        _mainPic.Visible = true;
                        _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                        _mainPic.BackColor = Color.Black;
                    }
                }
                else
                {
                    try
                    {
                        InitBrowser(_filmUrl);
                    }
                    catch
                    {
                        InitBrowser("http://www.e-try.com/black.htm");
                        _mainPic.Visible = true;
                        _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                        _mainPic.BackColor = Color.Black;
                    }
                }
            }
        }

        /*
         * Piratestreaming
         * Handlers
         */ 
        private void PirateCerca()
        {
            _addToFavBtn.Visible = false;
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;

                string resultSearch = _pirate.search(searchTextBox.Text);
                _urlElementi = _pirate.getLibraryUrl(resultSearch);

                _urlImmagini = _pirate.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();
            }
            catch
            {
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.ErrorSearch;
                _mainPic.BackColor = Color.Transparent;
                _mainPic.Visible = true;
            }
        }

        private void PirateLabelClick()
        {
            // FILM PLAY
            if (_pirate.checkIfFilm(_urlElementi.ElementAt(goForwardInfoResult).Value))
            {
                List<string> _filmUrls = new List<string>();
                _filmUrls = _pirate.getUrlFilm(_urlElementi.ElementAt(goForwardInfoResult).Value);
                foreach (var _filmUrl in _filmUrls)
                {
                    try
                    {
                        if (_filmUrl.Contains("openload"))
                        {
                            var oload = _openload.getEmbedOpenloadlink(_filmUrl);
                            InitBrowser(oload);
                        }
                        else if (_filmUrl.Contains("rapidvideo"))
                        {
                            var rapid = _rapidvideo.getEmbedElement(_filmUrl);
                            //InitBrowser(_openload.getEmbedOpenloadlink(_filmUrl));
                            _rapidvideo.initRapidvideo();
                            string iframe = File.ReadAllText("rapidvideo.html");
                            iframe = System.Text.RegularExpressions.Regex.Replace(iframe, "LINKDAINSERIRE", rapid);
                            File.WriteAllText("rapidvideo.html", iframe);
                            InitBrowser("file:///" + Directory.GetCurrentDirectory() + "\\rapidvideo.html");
                        }
                    }
                    catch
                    {
                        InitBrowser("http://www.e-try.com/black.htm");
                        _mainPic.Visible = true;
                        _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                        _mainPic.BackColor = Color.Black;
                    }
                }
            }

            else if (_currentUrlSerie.StartsWith("http"))
            {
                if (_currentUrlSerie.Contains("rapidvideo"))
                {
                    var rapid = _rapidvideo.getEmbedElement(_currentUrlSerie);
                    //InitBrowser(_openload.getEmbedOpenloadlink(_filmUrl));
                    _rapidvideo.initRapidvideo();
                    string iframe = File.ReadAllText("rapidvideo.html");
                    iframe = System.Text.RegularExpressions.Regex.Replace(iframe, "LINKDAINSERIRE", rapid);
                    File.WriteAllText("rapidvideo.html", iframe);
                    InitBrowser("file:///" + Directory.GetCurrentDirectory() + "\\rapidvideo.html");
                }
            }

            else
            {
                MessageBox.Show("Le serie TV non sono state ancora implementate in questo canale, fai la ricerca sulle sole Serie TV per avere risultati migliori!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                /*
                List<SeriesDictionary> _serieTVEpisodi = new List<SeriesDictionary>();

                // Apro serie
                _urlSeries = _pirate.getUrlTVSeries(_urlElementi.ElementAt(goForwardInfoResult).Value);
                
                foreach (var item in _urlSeries)
                {
                    SeriesDictionary _currentSerie = new SeriesDictionary();
                    _currentSerie.Episodio = item;
                    _serieTVEpisodi.Add(_currentSerie);
                }

                seriesDictionaryBindingSource.DataSource = _serieTVEpisodi;
                _gridTVSeries.Visible = true;
                goForwardInfoResult = 0;
                */
            }
        }

        /*
         * SerieHD
         * Shittyhandlers
         */
        private void SerieHDCerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;


                //_helpPic.Visible = false;

                string resultSearch = _serieHD.search(searchTextBox.Text);
                _urlElementi = _serieHD.getLibrary(resultSearch);

                _urlImmagini = _serieHD.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();

            }
            catch
            {

            }
        }

        private void SerieHDLabelClick()
        {
            string _filmUrl = "";
            try
            {
                _filmUrl = _serieHD.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                if (_openload.checkIfWorks(_filmUrl) == true)
                {
                    InitBrowser(_filmUrl);
                    _headerBackground.Visible = false;
                    _fullscreenHeaderBtn.Visible = false;
                    _headerPlayerImage.Visible = false;
                }
                else
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
            catch
            {
                InitBrowser("http://www.e-try.com/black.htm");
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                _mainPic.BackColor = Color.Black;
            }
        }

        /*
         * OpenLoadMovie
         * Handlers
         */
        private void OpenLoadMovieCerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;


                //_helpPic.Visible = false;

                string resultSearch = _genio.search(searchTextBox.Text);
                _urlElementi = _genio.getLibraryUrl(resultSearch);

                _urlImmagini = _genio.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();

            }
            catch
            {

            }
        }

        private void OpenLoadMovieLabelClick()
        {
            string _filmUrl = "";
            try
            {
                _filmUrl = _genio.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                if (_openload.checkIfWorks(_filmUrl) == true)
                {

                    InitBrowser(_filmUrl);
                }
                else
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
            catch
            {
                InitBrowser("http://www.e-try.com/black.htm");
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                _mainPic.BackColor = Color.Black;
            }
        }

        /*
        * GenioDelloStreaming
        * Handlers
        */
        private async Task<bool> GenioCerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                int i = 0;
                //_helpPic.Visible = false;

                string resultSearch = _genioDelloStreaming.search(searchTextBox.Text);
                while(_urlElementi.Count == 0)
                {
                    _urlElementi = await _genioDelloStreaming.getLibraryUrl(resultSearch);
                    i++;
                }
                //_urlImmagini = await _genioDelloStreaming.getUrlImage(resultSearch);
                //_descrizioneContenuti = await _genioDelloStreaming.getDescriptionData(resultSearch);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void GenioLabelClick()
        {
            string _filmUrl = "";
            try
            {
                _filmUrl = await _genioDelloStreaming.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                if (_openload.checkIfWorks(_filmUrl) == true)
                {

                    InitBrowser(_filmUrl);
                }
                else
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
            catch
            {
                InitBrowser("http://www.e-try.com/black.htm");
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                _mainPic.BackColor = Color.Black;
            }
        }

        /*
         * Cineblog01
         * Handlers
         */
        private void Cineblog01Cerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;

                string resultSearch = _cb01.search(searchTextBox.Text);
                _urlElementi = _cb01.getLibrary(resultSearch);

                _urlImmagini = _cb01.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();

            }
            catch
            {

            }
        }

        private void Cineblog01LabelClick()
        {
            string _filmUrl = "";
            try
            {
                var _rawLink = _cb01.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                _filmUrl = _openload.getEmbedOpenloadlink(_rawLink);
                if (_openload.checkIfWorks(_filmUrl) == true)
                {

                    InitBrowser(_filmUrl);
                }
                else
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
            }
            catch
            {
                InitBrowser("http://www.e-try.com/black.htm");
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                _mainPic.BackColor = Color.Black;
            }
        }

        /*
         * Film Per Tutti
         * Extractor (Serie TV in WIP)
         */
        private void FilmPerTuttiCerca()
        {
            try
            {
                _mainPic.Visible = false;
                _nextBtn.Visible = true;
                _backBtn.Visible = true;

                //_helpPic.Visible = false;

                string resultSearch = _filmPerTutti.search(searchTextBox.Text);
                _urlElementi = _filmPerTutti.getLibrary(resultSearch);

                _urlImmagini = _filmPerTutti.getUrlImage(resultSearch);
                //_descrizioneContenuti = _genio.getDescriptionData(resultSearch);

                // Populate results
                PopulateInfo();

            }
            catch
            {

            }
        }

        private void FilmPerTuttiLabelClick()
        {
            string _filmUrl = "";
            try
            {
                _filmUrl = _filmPerTutti.playUrl(_urlElementi.ElementAt(goForwardInfoResult).Value);
                if (_gridTVSeries.Visible == true)
                {
                    int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
                    string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
                    InitBrowser(urlSelectedSeries);
                }
                else if (_filmUrl == "serie")
                {
                    // e' una serie quindi faccio cose particolari
                    List<SeriesDictionary> _serieTVEpisodi = _filmPerTutti.getEpisodes(_urlElementi.ElementAt(goForwardInfoResult).Value);

                    //_urlElementi = _serieTVEpisodi;

                    // Show grid
                    seriesDictionaryBindingSource.DataSource = _serieTVEpisodi;
                    _gridTVSeries.Visible = true;
                    _labelResult.Text = _labelResult.Text + " - Episodi";
                    goForwardInfoResult = 0;
                }
                else if (_filmUrl == "")
                {
                    InitBrowser("http://www.e-try.com/black.htm");
                    _mainPic.Visible = true;
                    _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                    _mainPic.BackColor = Color.Black;
                }
                else
                    InitBrowser(_filmUrl);
            }
            catch
            {
                InitBrowser("http://www.e-try.com/black.htm");
                _mainPic.Visible = true;
                _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Error;
                _mainPic.BackColor = Color.Black;
            }
        }

        private void InitVVVVID()
        {
            if (_fullScreen.Image != null)
                _fullScreen.Image = WhoNeedsflixWinForm.Properties.Resources.diagonal_1_;
            _fullscreenHeaderBtn.Image = WhoNeedsflixWinForm.Properties.Resources.diagonal_1_;
            this.WindowState = FormWindowState.Maximized;
            fullScreenMode = true;
            InitBrowser("https://www.vvvvid.it/");
            _mainPic.Visible = false;
        }

        // Populate Combobox with film
        private void PopulateCombobox()
        {
            _combobox.Items.Clear();
            if (_radioA01.Checked)
            {
                _combobox.Items.Add("Film (ITA) - 1080p");
                //_combobox.Items.Add("Film #3 - HD");
                //_combobox.Items.Add("Film #4 - MD");
                _combobox.Items.Add("Film (ENG) - 1080p");
                _combobox.Items.Add("Film e Serie TV - 720p");
                _combobox.SelectedItem = "Film (ITA) - 1080p";
            }
            else if (_radioAnime.Checked)
            {
                _combobox.Items.Add("Anime ITA e SUB-ITA");
                //_combobox.Items.Add("Anime (SUB-ITA)");
                _combobox.Items.Add("VVVVID");
                _combobox.SelectedItem = "Anime ITA e SUB-ITA";
            }
            else if (_radioGuarda.Checked)
            {
                _combobox.Items.Add("Serie TV - 720p");
                _combobox.Items.Add("Film e Serie TV - 720p");
                //_combobox.Items.Add("Serie TV #2");
                _combobox.SelectedItem = "Serie TV - 720p";
            }
        }

        private void _tvShowTimeLabel_Click(object sender, EventArgs e)
        {
            /* nascondi robe
            _mainPic.Visible = false;
            _mainPic.Visible = false;

            InitBrowser("http://tvtime.com");

            _headerBackground.Visible = false;
            _headerPlayerImage.Visible = false;
            */
            BrowserForm _tvTimeForm = new BrowserForm("http://tvtime.com", "TVTime");
            _tvTimeForm.Show();

        }

        private void _gridTVSeries_Click(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = _gridTVSeries.SelectedCells[0].RowIndex;
            string urlSelectedSeries = Convert.ToString(_gridTVSeries.Rows[selectedrowindex].Cells[1].Value);
            InitBrowser(urlSelectedSeries);
        }

        private void _trailerButton_Click(object sender, EventArgs e)
        {
            VideoSearch _ytResult = new VideoSearch();
            var _firstResult = _ytResult.SearchQuery(_labelResult.Text + " trailer ita", 1).First();
            var _urlTrailer = _firstResult.Url;
            _urlTrailer = _urlTrailer.Replace("watch?v=", "embed/");
            InitBrowser(_urlTrailer);
        }

        private void _addToFavBtn_Click(object sender, EventArgs e)
        {
            AddToFavs();
        }

        private void _showFavsButton_Click(object sender, EventArgs e)
        {
            _gridTVSeries.Visible = false;
            ShowFavs();
        }

        private void _settingsIcon_Click(object sender, EventArgs e)
        {
            SettingsForm _settingsForm = new SettingsForm();
            _settingsForm.Show();
        }

        private void _radioA01_CheckedChanged(object sender, EventArgs e)
        {
            _mainPic.Visible = true;
            _mainPic.BackColor = Color.Transparent;
            _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
            PopulateCombobox();
            if (_radioA01.Checked)
                _combobox.Visible = true;
        }

        private void _radioGuarda_CheckedChanged(object sender, EventArgs e)
        {
            _mainPic.Visible = true;
            _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
            if (_radioGuarda.Checked)
                _combobox.Visible = true;
            PopulateCombobox();
        }

        private void _radioAnime_CheckedChanged(object sender, EventArgs e)
        {
            _mainPic.Visible = true;
            _mainPic.Image = WhoNeedsflixWinForm.Properties.Resources.Blackground;
            if (_radioAnime.Checked)
            {
                _combobox.Visible = true;
                PopulateCombobox();
                if(hasAnimeBeenClicked == false)
                {
                    MessageBox.Show("Funzione ancora sperimentale! Non è ancora perfetta ma potrebbe diventarlo :3\nPer anime commerciali effettua la ricerca in Serie TV", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    hasAnimeBeenClicked = true;
                }
                if ((string)_combobox.SelectedItem == "Anime ITA e SUB-ITA")
                {
                    _urlElementi = _animeForge.getLibrary();
                }
                else
                {
                    //_urlElementi = _animeTube.getLibrary();
                }

                _urlImmagini.Clear();
            }
        }

        // thingz to make window resizable
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
        // fine thingz to make window resizable


        private void _closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _maximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void _iconizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void _combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)_combobox.SelectedItem == "VVVVID")
                InitVVVVID();
        }
    }

}