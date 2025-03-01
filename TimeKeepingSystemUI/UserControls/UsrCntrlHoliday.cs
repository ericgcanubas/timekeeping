using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlHoliday : UserControl
    {
        private BindingSource source;

        public UsrCntrlHoliday()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            gridList.AutoGenerateColumns = false;

            this.source = new BindingSource();
            gridList.DataSource = this.source;

        }

        private static UsrCntrlHoliday instance;
        public static UsrCntrlHoliday Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlHoliday();
                    instance.Name = "singletonUsercntrlHoliday";
                }
                
                return instance;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
            LoadHolidays();
        }

        public void LoadHolidays() 
        {
            Task.Factory.StartNew(() =>
            {
                return Holiday.GetAllHolidays(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a =>
            {
                this.source.DataSource = a.Result.OrderByDescending(h => h.CntrlId);
                this.source.ResetBindings(false);
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CreateClick(object sender, EventArgs e)
        {
            if (UsrCntrlHolidayWrapper.Instance.Controls[UsrCntrlHolidayDetails.Instance.Name] == null)
                UsrCntrlHolidayWrapper.Instance.Controls.Add(UsrCntrlHolidayDetails.Instance);

            UsrCntrlHolidayDetails.Instance.Create();
            UsrCntrlHolidayDetails.Instance.BringToFront();
        }

        private void ViewClick(object sender, EventArgs e)
        {
            if (UsrCntrlHolidayWrapper.Instance.Controls[UsrCntrlHolidayDetails.Instance.Name] == null)
                UsrCntrlHolidayWrapper.Instance.Controls.Add(UsrCntrlHolidayDetails.Instance);

            UsrCntrlHolidayDetails.Instance.View(this.source.Current as TimeKeepingDataCode.Biometrics.Holiday);
            UsrCntrlHolidayDetails.Instance.BringToFront();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            TimeKeepingDataCode.Biometrics.Holiday holiday = this.source.Current as TimeKeepingDataCode.Biometrics.Holiday;
            if (holiday != null)
            {
                if (UsrCntrlHolidayWrapper.Instance.Controls[UsrCntrlHolidayDetails.Instance.Name] == null)
                    UsrCntrlHolidayWrapper.Instance.Controls.Add(UsrCntrlHolidayDetails.Instance);

                UsrCntrlHolidayDetails.Instance.Update(holiday);
                UsrCntrlHolidayDetails.Instance.BringToFront();
            }
            else {
                MessageBox.Show("Can't Update Selected.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void SetControls() 
        {
            btnView.BackColor = Code.Program.MainColor;
            btnView.ForeColor = Code.Program.TextColor;
            btnCreate.BackColor = Code.Program.MainColor;
            btnCreate.ForeColor = Code.Program.TextColor;
            btnUpdate.BackColor = Code.Program.MainColor;
            btnUpdate.ForeColor = Code.Program.TextColor;
            btnDelete.BackColor = Code.Program.MainColor;
            btnDelete.ForeColor = Code.Program.TextColor;

            gridList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridList.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridList.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            btnView.Image = TimeKeepingSystemUI.Properties.Resources.view15;
            btnCreate.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
            btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            btnDelete.Image = TimeKeepingSystemUI.Properties.Resources.print15;
        }

        private void BreadCumbEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void BreadCumbLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void LinkHomeClick(object sender, EventArgs e)
        {
            UsrCntrlHolidayWrapper.Instance.Dispose();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (gridList.Rows.Count <= 0) {
                MessageBox.Show("Can't Delete With No Selected Holiday.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            Holiday holiday = this.source.Current as Holiday;
            if (holiday == null) {
                MessageBox.Show("Can't Delete With Empty Holiday.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure to Delete Selected Holiday?", "Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            bool isHavePayrollLocked = false;
            var holidayNames = HolidayName.GetAllHolidayNames(TimeKeepingCode.Program.BiometricsConnection,holiday.CntrlId);
            for (int i = 0; i < holidayNames.Count; i++)
            {
                if (TimeKeepingDataCode.PayrollSystem.StaticHelper.IsPayrollLocked(TimeKeepingCode.Program.PayrollConnection, holidayNames[i].Date))
                    isHavePayrollLocked = true;
            }

            if (isHavePayrollLocked)
            {
                MessageBox.Show("Can't delete whole holiday, some holiday is locked.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else {
                if (Holiday.DeleteHoliday(TimeKeepingCode.Program.BiometricsConnection, holiday))
                {
                    MessageBox.Show("Successfully Deleted Holiday Schedule.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHolidays();
                }
                else
                    MessageBox.Show("Error in Deleting Scheduled Holiday.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
