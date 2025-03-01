using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlDragableHeader : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public delegate void OnClose(object sender,EventArgs e);
        public event OnClose OnCloseClick;

        private bool isHeaderShown;
        public UsrCntrlDragableHeader()
        {
            InitializeComponent();
            this.isHeaderShown = false;

            lblHeader.Visible = this.isHeaderShown;
        }

        private void OnDragableMouseDown(object sender, MouseEventArgs e)
        {
            Form f = GetFormParent();
            if (f != null) 
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(f.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            }
        }

        public bool MaximizeButton {
            get { return this.btnMaximize.Visible; }
            set { this.btnMaximize.Visible = value; }
        }

        public bool MinimizeButton {
            get { return this.btnMinimize.Visible; }
            set { this.btnMinimize.Visible = value; }
        }

        public bool CloseButton {
            get { return this.btnClose.Visible; }
            set { this.btnClose.Visible = value; }
        }

        private Form GetFormParent() 
        {
            Control c = this.Parent;
            while (!(c is Form))
            {
                c = c.Parent;
            }
            Form f = c as Form;
            return f;
        }

        private void CloseClick(object sender, EventArgs e)
        {
            if (OnCloseClick != null)
                OnCloseClick.Invoke(this,e);

            Form parentForm = GetFormParent();
            parentForm.Close();
        }

        private void MaximizeClick(object sender, EventArgs e)
        {
            Form parentForm = GetFormParent();
            parentForm.WindowState = FormWindowState.Maximized;
        }

        private void MinimizeClick(object sender, EventArgs e)
        {
            Form parentForm = GetFormParent();
            parentForm.WindowState = FormWindowState.Minimized;
        }

        public string SetHeaderText {
            get { return this.lblHeader.Text; }
            set { this.lblHeader.Text = value; }
        }

        public bool IsHeaderShown {
            get { return this.lblHeader.Visible; }
            set { this.lblHeader.Visible = value; }
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            lblHeader.ForeColor = this.ForeColor;
            btnClose.ForeColor = this.ForeColor;
            btnMaximize.ForeColor = this.ForeColor;
            btnMinimize.ForeColor = this.ForeColor;
        }
    }
}
