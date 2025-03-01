using System;
using System.Windows.Forms;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlToolsSelection : UserControl
    {
        public UsrCntrlToolsSelection()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlToolsSelection instance;
        public static UsrCntrlToolsSelection Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlToolsSelection();
                    instance.Name = "singletonUsrCntrlToolsSelection";
                }
                return instance;
            }
        }

        private void FormResize(object sender, EventArgs e)
        {
            flowPnlCenter.Left = (this.Width - flowPnlCenter.Width) / 2;
        }

        private void MachineIdClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.AvailableMachineId, TimeKeepingCode.UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Forms.FrmActiveMachineId.Instance.Show();
            if (!Forms.FrmActiveMachineId.Instance.Focused)
            {
                if (Forms.FrmActiveMachineId.Instance.WindowState == FormWindowState.Minimized)
                    Forms.FrmActiveMachineId.Instance.WindowState = FormWindowState.Normal;
                else
                    Forms.FrmActiveMachineId.Instance.Focus();
            }
        }

        private void LoadImage() 
        {
            ucMachineId.SetImage = TimeKeepingSystemUI.Properties.Resources.fingerPrint100;
            ucUserAccounts.SetImage = TimeKeepingSystemUI.Properties.Resources.userAccount100;
            ucTimeRecordTools.SetImage = TimeKeepingSystemUI.Properties.Resources.repost100;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void UserAccountClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.UserAccounts, TimeKeepingCode.UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Forms.FrmUsers.Instance.Show();
            if (!Forms.FrmUsers.Instance.Focused)
            {
                if (Forms.FrmUsers.Instance.WindowState == FormWindowState.Minimized)
                    Forms.FrmUsers.Instance.WindowState = FormWindowState.Normal;
                else
                    Forms.FrmUsers.Instance.Focus();
            }
        }

        private void RepostUpdateTimeClick(object sender, EventArgs e)
        {
            Forms.FrmTimeRecordTools.Instance.Show();
            if (!Forms.FrmTimeRecordTools.Instance.Focused)
            {
                if (Forms.FrmTimeRecordTools.Instance.WindowState == FormWindowState.Minimized)
                    Forms.FrmTimeRecordTools.Instance.WindowState = FormWindowState.Normal;
                else
                    Forms.FrmTimeRecordTools.Instance.Focus();
            }
        }
    }
}
