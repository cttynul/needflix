using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoNeedsflixWinForm
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("fav.txt", String.Empty);
            MessageBox.Show("La lista dei preferiti è stata svuotata con successo", "Yup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            BrowserForm webB = new BrowserForm("http://www.piratestreaming.club/", "Test");
            webB.Show();
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            BrowserForm webB = new BrowserForm("http://www.serietvu.com/", "Test");
            webB.Show();
        }
    }
}
