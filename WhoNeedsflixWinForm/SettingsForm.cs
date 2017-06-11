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
            this.FormBorderStyle = FormBorderStyle.None;
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
    }
}
