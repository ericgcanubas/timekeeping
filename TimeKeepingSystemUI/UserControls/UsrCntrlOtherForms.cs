using System;
using System.Windows.Forms;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlOtherForms : UserControl
    {
        public UsrCntrlOtherForms()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlOtherForms instance;
        public static UsrCntrlOtherForms Instance {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlOtherForms();
                    instance.Name = "singletonUsrCntrlOtherForms";
                }

                return instance;
            }
        }

        private void FormResize(object sender, EventArgs e)
        {
            flowPnlCenter.Left = (this.Width - flowPnlCenter.Width) / 2;
        }

        private void ShiftingScheduleClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.ShiftingSchedule, UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsrCntrlOtherFormsWrapper.Instance.Controls[UsrCntrlShiftingSchedules.Instance.Name] != null)
                UsrCntrlShiftingSchedules.Instance.BringToFront();
            else
            {
                UsrCntrlOtherFormsWrapper.Instance.Controls.Add(UsrCntrlShiftingSchedules.Instance);
                UsrCntrlShiftingSchedules.Instance.BringToFront();
            }
        }

        private void CheckerCasherClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.CasherCheckerSchedule, UserRoles.CanView))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsrCntrlOtherFormsWrapper.Instance.Controls[UsrCntrlCasherCheckerWrapper.Instance.Name] != null)
                UsrCntrlCasherCheckerWrapper.Instance.BringToFront();
            else
            {
                UsrCntrlOtherFormsWrapper.Instance.Controls.Add(UsrCntrlCasherCheckerWrapper.Instance);
                UsrCntrlCasherCheckerWrapper.Instance.BringToFront();
            }
        }

        private void SetImage() 
        {
            ucItemShiftingSchedules.SetImage = TimeKeepingSystemUI.Properties.Resources.schedule100;
            ucItemCheckerCasherSchedule.SetImage = TimeKeepingSystemUI.Properties.Resources.casherChecker100;
            ucItemHoliday.SetImage = TimeKeepingSystemUI.Properties.Resources.holiday100;
            usrExtendedMidNight.SetImage = TimeKeepingSystemUI.Properties.Resources.sale100;
            ucCntrlTimeRecord.SetImage = TimeKeepingSystemUI.Properties.Resources.clock100;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
        }

        private void HolidayItemClick(object sender, EventArgs e)
        {
            if (UsrCntrlOtherFormsWrapper.Instance.Controls[UsrCntrlHolidayWrapper.Instance.Name] != null)
                UsrCntrlHolidayWrapper.Instance.BringToFront();
            else
            {
                UsrCntrlOtherFormsWrapper.Instance.Controls.Add(UsrCntrlHolidayWrapper.Instance);
                UsrCntrlHolidayWrapper.Instance.BringToFront();
            }
        }

        private void ExtendedMidNightClick(object sender, EventArgs e)
        {
            if (UsrCntrlOtherFormsWrapper.Instance.Controls[UsrCntrlMidNightExtended.Instance.Name] == null)
            {
                UsrCntrlOtherFormsWrapper.Instance.Controls.Add(UsrCntrlMidNightExtended.Instance);

            }
            UsrCntrlMidNightExtended.Instance.BringToFront();
        }

        private void TimeRecordClick(object sender, EventArgs e)
        {
            if (UsrCntrlOtherFormsWrapper.Instance.Controls[UsrCntrlTimeRecord.Instance.Name] == null)
            {
                UsrCntrlOtherFormsWrapper.Instance.Controls.Add(UsrCntrlTimeRecord.Instance);

            }
            UsrCntrlTimeRecord.Instance.BringToFront();
        }
    }
}
