using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlReportsOptions : UserControl
    {
        public UsrCntrlReportsOptions()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlReportsOptions instance;
        public static UsrCntrlReportsOptions Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlReportsOptions();
                    instance.Name = "singletonReportsOptions";
                }
                return instance;
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            flowPnlCenter.Left = (this.Width - flowPnlCenter.Width) / 2;
        }

        private void AttendanceClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.AttendanceReport, TimeKeepingCode.UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsrCntrlReportsWrapper.Instance.Controls[UsrCntrlReportsAttendance.Instance.Name] != null)
                UsrCntrlReportsAttendance.Instance.BringToFront();
            else
            {
                UsrCntrlReportsWrapper.Instance.Controls.Add(UsrCntrlReportsAttendance.Instance);
                UsrCntrlReportsAttendance.Instance.BringToFront();
            }
        }

        private void SetImage()
        {
            ucAttendance.SetImage = TimeKeepingSystemUI.Properties.Resources.attendance100;
            ucNotEightHours.SetImage = TimeKeepingSystemUI.Properties.Resources.notEightHours100;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
        }

        private void NotEightHoursClick(object sender, EventArgs e)
        {
            if (UsrCntrlReportsWrapper.Instance.Controls[UsrCntrlReportNotEightHours.Instance.Name] != null)
                UsrCntrlReportNotEightHours.Instance.BringToFront();
            else
            {
                UsrCntrlReportsWrapper.Instance.Controls.Add(UsrCntrlReportNotEightHours.Instance);
                UsrCntrlReportNotEightHours.Instance.BringToFront();
            }
        }
    }
}
