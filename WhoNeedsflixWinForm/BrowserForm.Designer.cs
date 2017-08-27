namespace WhoNeedsflixWinForm
{
    partial class BrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this._geckoWebBrowser = new Gecko.GeckoWebBrowser();
            this.SuspendLayout();
            // 
            // _geckoWebBrowser
            // 
            this._geckoWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this._geckoWebBrowser.FrameEventsPropagateToMainWindow = false;
            this._geckoWebBrowser.Location = new System.Drawing.Point(0, 0);
            this._geckoWebBrowser.Name = "_geckoWebBrowser";
            this._geckoWebBrowser.Size = new System.Drawing.Size(808, 384);
            this._geckoWebBrowser.TabIndex = 0;
            this._geckoWebBrowser.UseHttpActivityObserver = false;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 384);
            this.Controls.Add(this._geckoWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.Text = "Web Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private Gecko.GeckoWebBrowser _geckoWebBrowser;
    }
}