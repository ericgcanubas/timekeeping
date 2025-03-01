using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlitem : UserControl
    {
        public UsrCntrlitem()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            SetImages();
            this.BackColor = Code.Program.MainColor;
            lblItemName.ForeColor = Code.Program.TextColor;
        }

        public Image SetImage {
            get {
                return picItem.Image;
            }
            set {
                picItem.Image = value;
            }
        }

        public string SetText {
            get {
                return lblItemName.Text;
            }
            set {
                lblItemName.Text = value;
            }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Code.Program.HoverColor;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Code.Program.MainColor;
        }

        private void OnClick(object sender,EventArgs e) {
            this.OnClick(e);
        }

        private void SetImages() 
        {
            this.picItem.Image = TimeKeepingSystemUI.Properties.Resources.nothing100;
        }
    }
}
