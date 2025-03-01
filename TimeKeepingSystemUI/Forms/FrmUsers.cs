using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmUsers : Form
    {
        private System.Windows.Forms.Timer t;

        public FrmUsers()
        {
            InitializeComponent();
            t = new System.Windows.Forms.Timer();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private static FrmUsers instance;
        public static FrmUsers Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new FrmUsers();
                    instance.Name = "singletonFormUsers";
                }
                return instance;
            }
        }

        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
                t.Stop();
            else
                Opacity += 0.05;
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

        private void OnLoad(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();

            pnlCenter.Controls.Add(UserControls.UsrCntrlUsers.Instance);
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
    }
}
