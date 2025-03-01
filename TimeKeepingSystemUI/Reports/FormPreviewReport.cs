using System;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.Reports
{
    public partial class FormPreviewReport : Form
    {
        private Timer t;

        public FormPreviewReport()
        {
            InitializeComponent();
            t = new Timer();
        }

        private void FormPreviewReport_Load(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();

            this.rptViewer.RefreshReport();
        }

        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
                t.Stop();
            else
                Opacity += 0.05;
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            t.Tick -= FadeIn;
            t.Tick += new EventHandler(FadeOut);
            t.Start();

            if (Opacity == 0)
                e.Cancel = false;
        }

        private void FadeOut(object sender, EventArgs e)
        {
            if (this.Opacity <= 0)
            {
                t.Stop();
                Close();
            }
            else
                this.Opacity -= 0.05;
        }
    }
}
