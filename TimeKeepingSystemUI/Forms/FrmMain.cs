using System;
using System.Windows.Forms;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmMain : Form
    {
        private bool isToggle;
        private Timer t;

        public FrmMain()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.isToggle = false;
            TimeKeepingCode.Program.LoadData();
            t = new Timer();
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

        private void OnLoad(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();

            pnlNavLeft.BackColor = Code.Program.MainColor;
            pnlTitleSeparator.BackColor = Code.Program.SeparatorColor;
            lblTitle.ForeColor = Code.Program.TextColor;
            SetImage();

            if (TimeKeepingCode.Program.User != null)
                lblUserLogin.Text = "User Login: " + TimeKeepingCode.Program.User.UserName;

            HeaderTitleClick(sender,e);
        }

        private void FadeIn(object sender,EventArgs e) {
            if (this.Opacity >= 1)
                t.Stop();
            else
                Opacity += 0.05;
        }

        private void SelectNavigation(UserControls.UsrCntrlMenuBtn control) 
        {
            for (int i = 0; i < pnlNavLeft.Controls.Count; i++)
            {
                if (pnlNavLeft.Controls[i] is UserControls.UsrCntrlMenuBtn)
                {
                    UserControls.UsrCntrlMenuBtn b = pnlNavLeft.Controls[i] as UserControls.UsrCntrlMenuBtn;
                    if (pnlNavLeft.Controls[i] == control)
                        b.SelectButton();
                    else
                        b.UnSelectButton();
                }
            }
        }

        private void ApplicationFormsOnClick(object sender, EventArgs e)
        {
            SelectNavigation(btnForms);
            if (pnlWrapper.Controls[UserControls.UsrCntrlForms.Instance.Name] != null)
            {
                UserControls.UsrCntrlForms.Instance.BringToFront();
                UserControls.UsrCntrlForms.Instance.FirstFocus();
            }
            else
            {
                pnlWrapper.Controls.Add(UserControls.UsrCntrlForms.Instance);
                UserControls.UsrCntrlForms.Instance.BringToFront();
            }
        }

        private void ProfileOnClick(object sender, EventArgs e)
        {
            if(!IsAuthorized.IsHaveUserAccess(Roles.EmployeeShifting,UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            SelectNavigation(btnEmployee);
            if (pnlWrapper.Controls[UserControls.UsrCntrlAssignScheduleWrapper.Instance.Name] != null)
                UserControls.UsrCntrlAssignScheduleWrapper.Instance.BringToFront();
            else
            {
                pnlWrapper.Controls.Add(UserControls.UsrCntrlAssignScheduleWrapper.Instance);
                UserControls.UsrCntrlAssignScheduleWrapper.Instance.BringToFront();
            }
        }

        private void OtherFormsOnClick(object sender, EventArgs e)
        {
            SelectNavigation(btnOtherForms);
            if (pnlWrapper.Controls[UserControls.UsrCntrlOtherFormsWrapper.Instance.Name] != null)
                UserControls.UsrCntrlOtherFormsWrapper.Instance.BringToFront();
            else
            {
                pnlWrapper.Controls.Add(UserControls.UsrCntrlOtherFormsWrapper.Instance);
                UserControls.UsrCntrlOtherFormsWrapper.Instance.BringToFront();
            }
        }

        private void ReportsOnClick(object sender, EventArgs e)
        {
            SelectNavigation(btnReport);
            if (pnlWrapper.Controls[UserControls.UsrCntrlReportsWrapper.Instance.Name] != null)
                UserControls.UsrCntrlReportsWrapper.Instance.BringToFront();
            else
            {
                pnlWrapper.Controls.Add(UserControls.UsrCntrlReportsWrapper.Instance);
                UserControls.UsrCntrlReportsWrapper.Instance.BringToFront();
            }
        }

        private void ToolsOnClick(object sender, EventArgs e)
        {
            SelectNavigation(btnTools);
            if (pnlWrapper.Controls[UserControls.UsrCntrlToolsWrapper.Instance.Name] != null)
                UserControls.UsrCntrlToolsWrapper.Instance.BringToFront();
            else
            {
                pnlWrapper.Controls.Add(UserControls.UsrCntrlToolsWrapper.Instance);
                UserControls.UsrCntrlToolsWrapper.Instance.BringToFront();
            }
        }

        private void HeaderTitleClick(object sender, EventArgs e)
        {
            if (!isToggle)
            {
                pnlNavLeft.Width = 45;
                Toggle();
                this.isToggle = true;
                picHamburger.Visible = true;
                lblTitle.Visible = false;
            }
            else 
            {
                pnlNavLeft.Width = 180;
                Toggle();
                this.isToggle = false;
                picHamburger.Visible = false;
                lblTitle.Visible = true;
            }
        }

        private void Toggle() 
        {
            for (int i = 0; i < pnlNavLeft.Controls.Count; i++)
            {
                if (pnlNavLeft.Controls[i] is UserControls.UsrCntrlMenuBtn) 
                {
                    UserControls.UsrCntrlMenuBtn b = pnlNavLeft.Controls[i] as UserControls.UsrCntrlMenuBtn;
                    b.Toggle();
                }
            }
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

        private void FadeOut(object sender,EventArgs e) {
            if (this.Opacity <= 0)
            {
                t.Stop();
                Close();
            }
            else
                this.Opacity -= 0.05;
        }

        private void SetImage() 
        {
            this.btnTools.Icon = TimeKeepingSystemUI.Properties.Resources.tools35;
            this.btnReport.Icon = TimeKeepingSystemUI.Properties.Resources.reports35;
            this.btnOtherForms.Icon = TimeKeepingSystemUI.Properties.Resources.category2_35;
            this.btnForms.Icon = TimeKeepingSystemUI.Properties.Resources.forms35;
            this.btnEmployee.Icon = TimeKeepingSystemUI.Properties.Resources.profile35;
        }
    }
}
