using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlMenuBtn : UserControl
    {
        private bool isSelected;
        private bool isToggle;

        public UsrCntrlMenuBtn()
        {
            InitializeComponent();
            this.isSelected = false;
            this.isToggle = false;
            ToggleOff();
        }

        public string LabelText {
            get { return this.lblText.Text; }
            set { this.lblText.Text = value; }
        }

        public Image Icon 
        {
            get { return picIcon.Image; }
            set { picIcon.Image = value; }
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Code.Program.HoverColor;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (!this.isSelected)
                this.BackColor = Code.Program.MainColor;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
            this.BackColor = Code.Program.MainColor;
            lblText.ForeColor = Code.Program.TextColor;
        }

        public void UnSelectButton() 
        {
            this.BackColor = Code.Program.MainColor;
            this.isSelected = false;
        }

        public void SelectButton() 
        {
            this.BackColor = Code.Program.HoverColor;
            this.isSelected = true;
        }

        private void OnClick(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        public void Toggle() 
        {
            if (isToggle)
            {
                ToggleOff();
                isToggle = false;
            }
            else 
            {
                ToggleOn();
                isToggle = true;
            }
        }

        private void ToggleOn()
        {
            lblText.Visible = false;
            picIcon.Location = new Point((this.Width - picIcon.Width) / 2);
        }

        private void ToggleOff() 
        {
            lblText.Visible = true;
            picIcon.Location = new Point(10, 5);
            lblText.Location = new Point(50, 12);
        }

        private void SetImage() 
        {
            this.picIcon.Image = TimeKeepingSystemUI.Properties.Resources.profile35;
        }
    }
}
