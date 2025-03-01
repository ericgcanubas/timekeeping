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
    public partial class FrmLoading : Form
    {
        private string loadingMessage;

        public FrmLoading(string loadingMessage)
        {
            InitializeComponent();
            this.loadingMessage = loadingMessage;
            lblLoadding.Text = loadingMessage;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (lblLoadding.Text.Length < this.loadingMessage.Length + 12)
                lblLoadding.Text += " .";
            else
                lblLoadding.Text = this.loadingMessage;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            BackColor = Code.Program.MainColor;
            lblLoadding.ForeColor = Code.Program.TextColor;
            tmr.Enabled = true;
        }
    }
}
