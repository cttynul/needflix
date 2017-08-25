using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoNeedsflixWinForm
{
    public partial class BrowserForm : Form
    {
        public string url { get; set; }
        public BrowserForm(string url, string formText)
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            InitBrowser(url);
            this.Text = formText;
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
    }
}
