using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmTimeRecordTools : Form
    {
        private System.Windows.Forms.Timer t;
        private string loadingText = string.Empty;

        public FrmTimeRecordTools()
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

        private static FrmTimeRecordTools instance;
        public static FrmTimeRecordTools Instance 
        {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmTimeRecordTools();
                    instance.Name = "singletonFrmTimeRecordTools";
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
            cmbCategory.SelectedIndex = 0;
            SetControls();
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();
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

        private void RepostClick(object sender, EventArgs e)
        {
            if (dtpRepostFrom.Value > dtpRepostTo.Value) 
            {
                MessageBox.Show("Check you Date, Date From is higher than Date To.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if ((dtpRepostFrom.Value.Day <= 15 && dtpRepostTo.Value.Day > 15) ||
                dtpRepostFrom.Value.Day >= 16 && dtpRepostTo.Value.Day <= 15) 
            {
                MessageBox.Show("Dates must be in same period.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            var timeRecordLocked = TimeRecord.GetAllLockedTimeRecord
                (TimeKeepingCode.Program.BiometricsConnection, dtpRepostFrom.Value, dtpRepostTo.Value);

            if (timeRecordLocked.Count > 0) 
            {
                MessageBox.Show("Selected Date Already Locked.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure to Repost Time Record between " + 
                dtpRepostFrom.Value.ToShortDateString() + " and " + dtpRepostTo.Value.ToShortDateString() + "?", 
                "Repost Time Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            btnRepost.Text = "Reposting . . .";
            Task.Factory.StartNew(() => 
            {
                return TimeRecord.RepostTimeRecordByRange(TimeKeepingCode.Program.BiometricsConnection, dtpRepostFrom.Value, dtpRepostTo.Value);
            }).ContinueWith(a => {
                btnRepost.Text = "Repost";
                if (a.Result)
                    MessageBox.Show("Time Record Successfully Reposted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to Repost Time Record","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetControls() 
        {
            btnRepost.BackColor = Code.Program.MainColor;
            btnRepost.ForeColor = Code.Program.TextColor;
            pnlSeparator.BackColor = Code.Program.MainColor;
            btnUpdateTimeSummary.BackColor = Code.Program.MainColor;
            btnUpdateTimeSummary.ForeColor = Code.Program.TextColor;
        }

        private void CategorySelectedIndex(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex == 2)
            {
                listResult.Top = 172;
                listResult.Height = 134;
            }
            else {
                listResult.Top = 144;
                listResult.Height = 160;
            }

            if (cmbCategory.SelectedIndex == 0)
            {
                ClearListResult();
            }
            else if (cmbCategory.SelectedIndex == 1)
            {
                ClearListResult();
                listResult.Items.Add("MW1 - B");
                listResult.Items.Add("MW2 - A");
                listResult.Items.Add("MW2 - B");
                listResult.Items.Add("CONTRACTUAL");
                listResult.Items.Add("OJT1");
                listResult.Items.Add("OJT2");
                listResult.Items.Add("EXPOSURE");
                listResult.Items.Add("SEASONAL");
                listResult.Items.Add("PROMO - ACCOUNT");
                listResult.Items.Add("INACTIVE (COMPANY)");
                listResult.Items.Add("NON-REGULAR CONTRACT");
                listResult.SelectedIndex = 0;
            }
            else if (cmbCategory.SelectedIndex == 2) 
            {
                listResult.DisplayMember = "Fullname";
                listResult.Items.Clear();
            }
            else if (cmbCategory.SelectedIndex == 3) 
            {
                ClearListResult();
            }
        }

        private void ClearListResult() 
        {
            listResult.DataSource = null;
            listResult.Items.Clear();
            listResult.DisplayMember = "";
        }

        private void SearchChange(object sender, EventArgs e)
        {
            var search = TimeKeepingCode.Program.ActiveEmployees.FindAll
                (p => p.Fullname.ToLower().Trim().Contains(txtSearchEmployee.Text.Trim().ToLower()));
            listResult.DataSource = search;
        }

        private void UpdateTimeSummaryClicked(object sender, EventArgs e)
        {
            if (!IsLocked())
            {
                if (MessageBox.Show("Are you sure to Update Time Summary?", "Update Time Summary", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                loadingText = "Please Wait";
                DateTime dateFrom = new DateTime(dtpTimeSummaryFrom.Value.Year,dtpTimeSummaryFrom.Value.Month,dtpTimeSummaryFrom.Value.Day);
                DateTime dateTo = new DateTime(dtpTimeSummaryTo.Value.Year,dtpTimeSummaryTo.Value.Month,dtpTimeSummaryTo.Value.Day);

                if (cmbCategory.SelectedIndex == 0) 
                {
                    btnUpdateTimeSummary.Enabled = false;
                    tmr.Start();
                    Task.Factory.StartNew(() =>
                    {
                        UpdateTimeSummary(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee.
                        GetAllTimeSummaryEmployees(TimeKeepingCode.Program.PayrollConnection, dateFrom, dateTo));
                    }).ContinueWith(a => {
                        tmr.Stop();
                        btnUpdateTimeSummary.Text = "Update Time Summary";
                        btnUpdateTimeSummary.Enabled = true;
                        MessageBox.Show("Time Summary Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
                }
                else if (cmbCategory.SelectedIndex == 1) 
                {
                    if (listResult.SelectedItems.Count > 0) 
                    {
                        btnUpdateTimeSummary.Enabled = false;
                        tmr.Start();
                        Task.Factory.StartNew(() =>
                        {
                            UpdateTimeSummary(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee.
                            GetAllTimeSummaryEmployeesByGroup(TimeKeepingCode.Program.PayrollConnection, dateFrom, dateTo, listResult.SelectedIndex));
                        }).ContinueWith(a => {
                            tmr.Stop();
                            btnUpdateTimeSummary.Text = "Update Time Summary";
                            btnUpdateTimeSummary.Enabled = false;
                            MessageBox.Show("Time Summary Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
                else if (cmbCategory.SelectedIndex == 2) 
                {
                    if (listResult.SelectedItems.Count > 0)
                    {
                        var employee = listResult.SelectedItem as TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo;
                        if (employee != null) 
                        {
                            btnUpdateTimeSummary.Enabled = false;
                            tmr.Start();
                            Task.Factory.StartNew(() =>
                            {
                                UpdateTimeSummary(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee.
                                GetTimeSummaryEmployee(TimeKeepingCode.Program.PayrollConnection, dateFrom, dateTo, employee.PkId));
                            }).ContinueWith(a => {
                                tmr.Stop();
                                btnUpdateTimeSummary.Text = "Update Time Summary";
                                btnUpdateTimeSummary.Enabled = true;
                                MessageBox.Show("Time Summary Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }
                }
                else if (cmbCategory.SelectedIndex == 3) 
                {
                    btnUpdateTimeSummary.Enabled = false;
                    tmr.Start();
                    Task.Factory.StartNew(() =>
                    {
                        UpdateTimeSummary(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee.
                        GetAllTimeSummaryEmployeesByAgenctGuard(TimeKeepingCode.Program.PayrollConnection, dateFrom, dateTo));
                    }).ContinueWith(a => {
                        tmr.Stop();
                        btnUpdateTimeSummary.Text = "Update Time Summary";
                        btnUpdateTimeSummary.Enabled = false;
                        MessageBox.Show("Time Summary Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
            else {
                MessageBox.Show("Payroll Already Locked.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        private bool IsLocked() 
        {
            switch (cmbCategory.SelectedIndex)
            {
                case 0:
                    return StaticHelper.IsPayrollLocked(TimeKeepingCode.Program.BiometricsConnection,dtpTimeSummaryFrom.Value,dtpTimeSummaryTo.Value);
                case 1:
                    switch (listResult.SelectedIndex)
                    {
                        case 0:
                            return StaticHelper.IsMW1BLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 1:
                            return StaticHelper.IsMW2ALocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 2:
                            return StaticHelper.IsMW2BLocked(TimeKeepingCode.Program.BiometricsConnection,dtpTimeSummaryFrom.Value,dtpTimeSummaryTo.Value);
                        case 3:
                            return StaticHelper.IsContractualLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 4:
                            return StaticHelper.IsOJT1Locked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 5:
                            return StaticHelper.IsOJT2Locked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 6:
                            return StaticHelper.IsExposureLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 7:
                            return StaticHelper.IsSeasonalLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 8:
                            return StaticHelper.IsPromoAccLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 9:
                            return StaticHelper.IsInactiveCompanyLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        case 10:
                            return StaticHelper.IsNonRegularContractLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);
                        default:
                            break;
                    }
                    break;
                case 2:
                    TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo e = listResult.SelectedItem as TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo;
                    if (e != null) 
                    {
                        var action = TimeKeepingDataCode.PayrollSystem.ActionMemo.GetCurrentActionMemo(TimeKeepingCode.Program.PayrollConnection, e.PkId, dtpTimeSummaryTo.Value);
                        if (action != null)
                        {
                            if (action.Hired != 2)
                            {
                                return StaticHelper.IsEmployeeLocked(TimeKeepingCode.Program.BiometricsConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value, e.PkId);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

        private void UpdateTimeSummary(List<TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee> timeSummaryEmployees) 
        {
            var employeesWithoutBio = TimeKeepingDataCode.PayrollSystem.EmployeeWithoutBio.
                GetAllEmployeesWithoutBio(TimeKeepingCode.Program.PayrollConnection);

            var period = TimeKeepingDataCode.PayrollSystem.Period.GetPeriod
                (TimeKeepingCode.Program.PayrollConnection,dtpTimeSummaryFrom.Value,dtpTimeSummaryTo.Value);

            if (period == null) {
                MessageBox.Show("No Period Found.\nPlease contact the developer","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < timeSummaryEmployees.Count; i++)
            {
                if (employeesWithoutBio.Exists(e => e.EmpNo == timeSummaryEmployees[i].EmpNo && e.EffectDate <= dtpTimeSummaryTo.Value))
                {
                    TimeSummary.DeleteTimeSummary(TimeKeepingCode.Program.BiometricsConnection,
                        timeSummaryEmployees[i].EmpNo, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);

                    TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary
                        (TimeKeepingCode.Program.PayrollConnection, timeSummaryEmployees[i].EmpNo, period.PeriodNo, 1);
                }
                else {
                    if (timeSummaryEmployees[i].CompType == 1)
                        MonthlyComputation(timeSummaryEmployees[i], period);
                    else if (timeSummaryEmployees[i].CompType == 2)
                        DailyComputation(timeSummaryEmployees[i],period);
                }
            }
        }

        private void UpdateTimeSummary(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee timeSummaryEmployee)
        {
            var employeesWithoutBio = TimeKeepingDataCode.PayrollSystem.EmployeeWithoutBio.
                GetAllEmployeesWithoutBio(TimeKeepingCode.Program.PayrollConnection);

            var period = TimeKeepingDataCode.PayrollSystem.Period.GetPeriod
                (TimeKeepingCode.Program.PayrollConnection, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);

            if (period == null)
            {
                MessageBox.Show("No Period Found.\nPlease contact the developer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (employeesWithoutBio.Exists(e => e.EmpNo == timeSummaryEmployee.EmpNo && e.EffectDate <= dtpTimeSummaryTo.Value))
            {
                TimeSummary.DeleteTimeSummary(TimeKeepingCode.Program.BiometricsConnection,
                    timeSummaryEmployee.EmpNo, dtpTimeSummaryFrom.Value, dtpTimeSummaryTo.Value);

                TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary
                    (TimeKeepingCode.Program.PayrollConnection, timeSummaryEmployee.EmpNo, period.PeriodNo, 1);
            }
            else
            {
                if (timeSummaryEmployee.CompType == 1)
                    MonthlyComputation(timeSummaryEmployee, period);
                else if (timeSummaryEmployee.CompType == 2)
                    DailyComputation(timeSummaryEmployee,period);
            }
        }

        private void MonthlyComputation(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee employee,
            TimeKeepingDataCode.PayrollSystem.Period period) 
        {
            DateTime dateFrom = new DateTime(dtpTimeSummaryFrom.Value.Year,dtpTimeSummaryFrom.Value.Month,dtpTimeSummaryFrom.Value.Day);
            DateTime dateTo = new DateTime(dtpTimeSummaryTo.Value.Year,dtpTimeSummaryTo.Value.Month,dtpTimeSummaryTo.Value.Day);
            DateTime dateHired = TimeKeepingDataCode.PayrollSystem.StaticHelper.DateHired(TimeKeepingCode.Program.PayrollConnection,employee.EmpNo);

            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();

            double defaultMinMidNight = TimeKeepingDataCode.PayrollSystem.StaticHelper.
                MidNightMinimum(TimeKeepingCode.Program.PayrollConnection,dtpTimeSummaryFrom.Value);

            //OVER ALL TOTAL VARIABLES
            double totalHours = 120;
            double totalRDDuty = 0;
            double totalMidNight = 0;
            double totalOverTime = 0;
            double totalSpecialHoliday = 0;
            double totalRegularHoliday = 0;
            List<TimeSummaryDetail> details = new List<TimeSummaryDetail>();

            DateTime originalDateFrom = dateFrom;

            while (dateFrom <= dateTo)
            {
                if (serverDate < dateFrom) 
                {
                    //END COMPUTATION
                    break;
                }

                //COMPUTATION NOT APPLY WHEN DATE HIRED IS ABOVE DATE FROM
                if (dateHired > dateFrom) 
                {
                    dateFrom = dateFrom.AddDays(1);
                    continue;
                }

                //DAILY RECORD VARIABLES
                TimeRecord record = TimeRecord.GetTimeRecord(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom);
                double dailyNetHours = 0;
                double dailyMidNight = 0;
                double dailyExtended = 0;
                double dailyRestday = 0;
                double dailyOvertime = 0;
                double sh = 0;
                double lh = 0;
                string remarks = string.Empty;

                //IF HAVE TIME RECORD
                if (record != null)
                {
                    //IF HAVE TIME ADJUST
                    if (string.IsNullOrWhiteSpace(record.AdjustmentCntrlNo))
                        dailyNetHours = record.NetHours;
                    else
                        dailyNetHours = record.AdjustedTime;

                    dailyMidNight = record.MidNightTotal;

                    //IF MIDNIGHT TOTAL HOURS IS LESS THAH DEFAULT MIDNIGHT TOTAL HOURS
                    if (dailyMidNight < defaultMinMidNight)
                        dailyMidNight = 0;

                    //EXTENDED HOURS
                    if (record.TotalExtended > 0)
                        dailyExtended = record.TotalExtended;

                    //WITH TIME RECORD BUT HAVE LEAVE RECORD
                    if (LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                    {
                        remarks = "LV";
                        totalHours -= 8;
                    }
                    //WITH TIME RECORD BUT HAVE SUSPENDED RECORD
                    else if (Suspension.IsSuspended(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom))
                    {
                        remarks = "S";
                        totalHours -= 8;
                    }
                    else
                    {
                        //BOLEAN VALUE TO DETERMINE IF THE TOTAL HOUR IS DEDUCTED
                        bool isTotalHourDeducted = false;

                        //WITH TIME RECORD BUT REST DAY
                        bool isRestDay = false;

                        if (EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                        {
                            //IF DAILY TOTAL HOURS OIS GREATER THAN 4 THEN ADD TO TOTAL REST DAY DUTY ELSE 0
                            if (dailyNetHours >= 4)
                                dailyRestday = dailyNetHours;

                            remarks = "RD";
                            isRestDay = true;
                        }

                        //BOOLEAN VALUE TO DETERMINE IF DAY IS HOLIDAY
                        bool isDateHoliday = false;

                        string holidayType = string.Empty;

                        //CHECK IF DATE IS HOLIDAY
                        if (HolidayName.IsDateHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, out holidayType))
                        {
                            //IF DATE IS HOLIDAY
                            isDateHoliday = true;
                            int holiday = HolidayEmployees.CheckHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo);

                            //SPECIAL HOLIDAY COMPUTATION
                            if (holidayType.Trim().Equals("special", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //CHECK IF RESTDAY DUTY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            if (dailyNetHours > 0)
                                            {
                                                remarks = dailyNetHours.ToString("#,##0.00");
                                                sh = dailyNetHours;
                                            }
                                            break;
                                        //NO DUTY
                                        case 0:
                                            remarks = "RD,SH";
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            if (dailyNetHours > 0)
                                            {
                                                remarks = dailyNetHours.ToString("#,##0.00");
                                                sh = dailyNetHours;
                                            }
                                            break;
                                    }
                                }
                                //IF NOT RESTDAY
                                else
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                            {
                                                sh = dailyNetHours;
                                            }
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "SH";
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                totalHours -= 8;
                                                isTotalHourDeducted = true;
                                            }
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                sh = dailyNetHours;
                                            break;
                                    }
                                }
                            }
                            //REGULAR HOLIDAY COMPUTATION
                            else if (holidayType.Trim().Equals("regular", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF RESTDAY DUTY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                            {
                                                lh = 8;
                                            }
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD,LH";
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                            {
                                                lh = 8;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //IF NOT RESTDAY
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                            {
                                                lh = 8;
                                            }
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            //CHECK IF PRESENT BEFORE 
                                            //IF PRESET BEFORE NO LH FEE, BUT HAVE DAILY NET HOUR
                                            //IF NOT PRESENT BEFORE NO DAILY NET HOUR
                                            remarks = "LH";
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                isTotalHourDeducted = true;
                                                totalHours -= 8;
                                            }
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                            {
                                                lh = 8;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }

                        //IF TOTAL HOUR IS NOT DEDUCTED, LESS DAILY ACTUAL TIME TO TOTAL HOUR
                        if (!isTotalHourDeducted) 
                        {
                            //LESS DIFFERENCE BETWEEN 8 AND ACTUAL TIME IN TOTAL HOUR
                            if (dailyNetHours > 0)
                            {
                                if(!isDateHoliday)
                                    remarks = dailyNetHours.ToString("#,##0.00");
                                totalHours -= (8 - dailyNetHours);
                            }
                            //IF DAILY NET HOUR IS BELOW 0 THEN ABSENT
                            else {
                                totalHours -= 8;
                                remarks = "A";
                            }
                        }
                    }
                }
                //NO TIME RECORD
                else {

                    //LEAVED
                    if (LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                    {
                        remarks = "LV";
                        totalHours -= 8;
                    }
                    //SUSPENDED
                    else if (Suspension.IsSuspended(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom))
                    {
                        remarks = "S";
                        totalHours -= 8;
                    }
                    else {

                        //RESTDAY
                        bool isRestDay = false;
                        if (EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                        {
                            //REST DAY REMARKS
                            remarks = "RD";
                            isRestDay = true;
                        }

                        string holidayType = string.Empty;

                        //IF DATE IS HOLIDAY
                        if (HolidayName.IsDateHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, out holidayType))
                        {
                            int holiday = HolidayEmployees.CheckHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo);

                            //SPECIAL HOLIDAY COMPUTATION
                            if (holidayType.Trim().Equals("special", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF REST DAY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            totalHours -= 8;
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = "RD";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            totalHours -= 8;
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "SH";
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                totalHours -= 8;
                                            }
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                totalHours -= 8;
                                                remarks = "A";
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            //REGULAR HOLIDAY COMPUTATION
                            else if (holidayType.Trim().Equals("regular", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF REST DAY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            totalHours -= 8;
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = "RD";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            totalHours -= 8;
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "LH";
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                totalHours -= 8;
                                            }
                                            break;
                                        //NO HOLIDAY RECORD
                                        case 2:
                                            remarks = "LH";
                                            if (!TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                            {
                                                totalHours -= 8;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        else {
                            //NO RECORD, ABSENT
                            if (!isRestDay) {
                                remarks = "A";
                                totalHours -= 8;
                            }
                        }
                    }
                }

                //TOTAL MIDNIGHT
                totalMidNight += dailyMidNight;

                //DAILY OVERTIME
                OvertimeSummary o = OvertimeSummary.GetOverTimeSummary(TimeKeepingCode.Program.BiometricsConnection,dateFrom,employee.EmpNo);
                if (o != null)
                    dailyOvertime = (o.TotalOvertime + dailyExtended);
                else
                    dailyOvertime = dailyExtended;

                //TOTAL HOLIDAY
                totalRegularHoliday += lh;
                totalSpecialHoliday += sh;

                //TOTAL REST DAY DUTY;
                totalRDDuty += dailyRestday;

                //TOTAL OVERTIME
                totalOverTime += dailyOvertime;

                details.Add(new TimeSummaryDetail(0,dateFrom,remarks,sh,lh,dailyRestday,dailyOvertime,dailyMidNight));

                dateFrom = dateFrom.AddDays(1);
            }

            if (totalHours <= 0) 
            {
                TimeSummary.DeleteTimeSummary(TimeKeepingCode.Program.BiometricsConnection,employee.EmpNo,originalDateFrom,dateTo);
                if (employee.Hired == 3 || employee.Hired == 1) {
                    TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary(TimeKeepingCode.Program.PayrollConnection,employee.EmpNo,period.PeriodNo,1);
                }
                else if (employee.Hired == 2) {
                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.DeleteAgencyHourSalary(TimeKeepingCode.Program.PayrollConnection,employee.EmpName,period.PeriodNo);
                }
                return;
            }

            //CLEARING
            double totalClearing = StaticHelper.TotalClearing(TimeKeepingCode.Program.BiometricsConnection, originalDateFrom, dateTo, employee.EmpNo);

            //AGENCY NAME
            string agencyName = string.Empty;
            TimeKeepingDataCode.PayrollSystem.ActionMemo actionMemo = 
                TimeKeepingDataCode.PayrollSystem.ActionMemo.GetCurrentActionMemo(TimeKeepingCode.Program.PayrollConnection,employee.EmpNo,dateTo);
            if (actionMemo != null)
                agencyName = actionMemo.PositionRemarks;

            //TIME SUMMARY DETAILS
            TimeSummary summary = TimeSummary.GetTimeSummary(TimeKeepingCode.Program.BiometricsConnection,employee.EmpNo,originalDateFrom,dateTo);

            if (summary != null)
            {
                summary.EmpPam = employee.PamId;
                summary.Hired = employee.Hired;
                summary.DepId = employee.DepId;
                summary.DepartmentName = employee.DepartmentName;
                summary.SectSort = employee.SecSort;
                summary.SectionName = employee.SectionName;
                summary.PClass_Back = employee.PClassBack;
                summary.TIN = employee.TIN;
                summary.EGroup = employee.EGroup;
                summary.DateHired = dateHired;
                summary.Supplier = employee.Supplier;
                summary.Compensation = employee.CompType;
                summary.PostId = employee.PostId;
                summary.PostName = employee.PostName;
                summary.EmpStatus = employee.Status;
                summary.SectionId = employee.SectionId;
                summary.TotalHours = totalHours;
                summary.SH = 0;
                summary.SH_OT = totalSpecialHoliday;
                summary.LH = 0;
                summary.LH_OT = totalRegularHoliday;
                summary.RD = totalRDDuty;
                summary.REG_OT = totalOverTime;
                summary.MidNight = totalMidNight;
                summary.Clearing = totalClearing;
                summary.AgencyName = agencyName;

                TimeSummary.UpdateTimeSummary(TimeKeepingCode.Program.BiometricsConnection, summary);
            }
            else {
                summary = TimeSummary.CreateEmptyTimeSummary();

                summary.EmpNo = employee.EmpNo;
                summary.DateFrom = originalDateFrom;
                summary.DateTo = dateTo;
                summary.EmpPam = employee.PamId;
                summary.Hired = employee.Hired;
                summary.DepId = employee.DepId;
                summary.DepartmentName = employee.DepartmentName;
                summary.SectSort = employee.SecSort;
                summary.SectionId = employee.SectionId;
                summary.SectionName = employee.SectionName;
                summary.PClass_Back = employee.PClassBack;
                summary.TIN = employee.TIN;
                summary.EGroup = employee.EGroup;
                summary.DateHired = dateHired;
                summary.Supplier = employee.Supplier;
                summary.Compensation = employee.CompType;
                summary.PostId = employee.PostId;
                summary.PostName = employee.PostName;
                summary.EmpStatus = employee.Status;
                summary.TotalHours = totalHours;
                summary.SH = 0;
                summary.SH_OT = totalSpecialHoliday;
                summary.LH = 0;
                summary.LH_OT = totalRegularHoliday;
                summary.RD = totalRDDuty;
                summary.REG_OT = totalOverTime;
                summary.MidNight = totalMidNight;
                summary.Clearing = totalClearing;
                summary.Remarks = string.Empty;
                summary.AgencyName = agencyName;

                TimeSummary.InsertTimeSummary(TimeKeepingCode.Program.BiometricsConnection,summary);
            }

            summary = TimeSummary.GetTimeSummary(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, originalDateFrom, dateTo);
            if (summary != null) 
            {
                TimeSummaryDetail.DeleteTimeSummaryByKey(TimeKeepingCode.Program.BiometricsConnection,summary.Pk);
                TimeSummaryDetail.InsertTimeSummaryDetail(TimeKeepingCode.Program.BiometricsConnection,summary.Pk,details);
            }

            if (employee.Hired == 1 || employee.Hired == 3) 
            {
                //COMAPANY PROMO
                TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary(TimeKeepingCode.Program.PayrollConnection,employee.EmpNo,period.PeriodNo,1);

                var dtrSummary = TimeKeepingDataCode.PayrollSystem.DTRSummary.CreateEmptyDTRSummary();

                dtrSummary.EmpNo = employee.EmpNo;
                dtrSummary.Period = period.PeriodNo;
                dtrSummary.CurrentPAM = employee.PamId;
                dtrSummary.NoHours = totalHours;
                dtrSummary.SH = 0;
                dtrSummary.SH_OT = totalSpecialHoliday;
                dtrSummary.LH = 0;
                dtrSummary.LH_OT = totalRegularHoliday;
                dtrSummary.RD = totalRDDuty;
                dtrSummary.Reg_OT = totalOverTime;
                dtrSummary.MidNight = totalMidNight;
                dtrSummary.Clearing = totalClearing;
                dtrSummary.Bio = 1;
                dtrSummary.SickLeave = 0;
                dtrSummary.EmpName = employee.EmpName;

                TimeKeepingDataCode.PayrollSystem.DTRSummary.InsertDTRSummary(TimeKeepingCode.Program.PayrollConnection,dtrSummary);
            }
            else if (employee.Hired == 2) 
            {
                //AGENCY SECURITY

                //AGENCY RATE PER HOUR COLA
                double ratePerHour = 0;
                double colaPerHour = 0;

                var memo = TimeKeepingDataCode.PayrollSystem.ActionMemo.GetCurrentActionMemo
                    (TimeKeepingCode.Program.PayrollConnection,employee.EmpNo,dateTo);

                if (memo != null) 
                {
                    ratePerHour = memo.RatePerHour;
                    colaPerHour = memo.ColaPerHour;
                }

                TimeKeepingDataCode.PayrollSystem.AgencyName agency = TimeKeepingDataCode.PayrollSystem.AgencyName.
                    GetAgency(TimeKeepingCode.Program.PayrollConnection,agencyName);

                //INSERT NEW AGENCY
                if (agency == null)
                    TimeKeepingDataCode.PayrollSystem.AgencyName.InsertAgency
                        (TimeKeepingCode.Program.PayrollConnection,new TimeKeepingDataCode.PayrollSystem.AgencyName(agencyName));

                double agencyTotalClearingSession = StaticHelper.TotalClearing(TimeKeepingCode.Program.BiometricsConnection, originalDateFrom, dateTo, employee.EmpNo);
                double agencyClearingRate = 0;
                double securityRate = TimeKeepingDataCode.PayrollSystem.StaticHelper.SecurityOTRate(TimeKeepingCode.Program.PayrollConnection,dateTo);

                var clearingRate = TimeKeepingDataCode.PayrollSystem.ClearingRate.GetCurrentClearingRate(TimeKeepingCode.Program.PayrollConnection,dateFrom);
                if (clearingRate != null)
                    agencyClearingRate = clearingRate.Rate;

                if (agencyTotalClearingSession > 0) 
                {
                    var agencyClearing = TimeKeepingDataCode.PayrollSystem.AgencyClearing.GetAgencyClearing
                    (TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, period.PeriodNo);
                    if (agencyClearing != null)
                    {
                        TimeKeepingDataCode.PayrollSystem.AgencyClearing.DeleteAgencyClearing(TimeKeepingCode.Program.PayrollConnection, agencyClearing);
                        agencyClearing = TimeKeepingDataCode.PayrollSystem.AgencyClearing.CreateEmptyAgencyClearing();

                        agencyClearing.EmpNo = employee.EmpNo;
                        agencyClearing.Department = employee.DepId;
                        agencyClearing.Section = employee.SectionId;
                        agencyClearing.PClassStoreBack = employee.PClassBack;
                        agencyClearing.Period = period.PeriodNo;
                        agencyClearing.ClearingSession = agencyTotalClearingSession;
                        agencyClearing.ClearingRate = agencyClearingRate;

                        TimeKeepingDataCode.PayrollSystem.AgencyClearing.InsertClearing
                            (TimeKeepingCode.Program.PayrollConnection,agencyClearing);

                    }
                }

                TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary agencyHourSalary =
                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.GetAgencyHourSalary
                    (TimeKeepingCode.Program.PayrollConnection,employee.EmpName,period.PeriodNo);

                if (agencyHourSalary != null)
                {
                    agencyHourSalary.HoursSMC = totalHours + totalRDDuty;
                    agencyHourSalary.RegHours = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) : 0);
                    agencyHourSalary.Descripancy = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) - agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency - (totalHours + totalRDDuty) : 0);
                    agencyHourSalary.Overtime = totalMidNight + totalOverTime;
                    agencyHourSalary.RatePerHour = ratePerHour;
                    agencyHourSalary.ColaPerHour = colaPerHour;
                    agencyHourSalary.OvertimePerHour = securityRate;
                    agencyHourSalary.RegPaid = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? (totalRDDuty + totalHours) : 0) * ratePerHour;
                    agencyHourSalary.Cola = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalRDDuty + totalHours) <= agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) : 0) * colaPerHour;
                    agencyHourSalary.OvertimePaid = (totalOverTime + totalMidNight) * securityRate;
                    agencyHourSalary.AgencyName = agencyName;


                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.UpdateAgencySalary(TimeKeepingCode.Program.PayrollConnection, agencyHourSalary);
                }
                else {
                    agencyHourSalary = TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.CreateEmptyAgencyHourSalary();
                    agencyHourSalary.EmpName = employee.EmpName;
                    agencyHourSalary.Period = period.PeriodNo;
                    agencyHourSalary.HoursSMC = totalHours + totalRDDuty;
                    agencyHourSalary.Overtime = totalOverTime + totalMidNight;
                    agencyHourSalary.RatePerHour = ratePerHour;
                    agencyHourSalary.ColaPerHour = colaPerHour;
                    agencyHourSalary.OvertimePerHour = securityRate;
                    agencyHourSalary.OvertimePaid = (totalOverTime + totalMidNight) * securityRate;
                    agencyHourSalary.AgencyName = agencyName;

                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.InsertAgencySalary(TimeKeepingCode.Program.PayrollConnection,agencyHourSalary);
                }
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (btnUpdateTimeSummary.Text.Length > loadingText.Length + 6)
                btnUpdateTimeSummary.Text = loadingText;
            else
                btnUpdateTimeSummary.Text += " .";
        }

        private void DailyComputation(TimeKeepingDataCode.PayrollSystem.TimeSummaryEmployee employee,
            TimeKeepingDataCode.PayrollSystem.Period period) 
        {
            DateTime dateFrom = new DateTime(dtpTimeSummaryFrom.Value.Year,dtpTimeSummaryFrom.Value.Month,dtpTimeSummaryFrom.Value.Day);
            DateTime dateTo = new DateTime(dtpTimeSummaryTo.Value.Year,dtpTimeSummaryTo.Value.Month,dtpTimeSummaryTo.Value.Day);
            DateTime dateHired = TimeKeepingDataCode.PayrollSystem.StaticHelper.DateHired(TimeKeepingCode.Program.PayrollConnection,employee.EmpNo);

            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();

            double defaultMinMidNight = TimeKeepingDataCode.PayrollSystem.StaticHelper.
                MidNightMinimum(TimeKeepingCode.Program.PayrollConnection,dtpTimeSummaryFrom.Value);

            //OVER ALL TOTAL VARIABLES
            double totalHours = 0;
            double totalRDDuty = 0;
            double totalMidNight = 0;
            double totalOverTime = 0;
            double totalSpecialHoliday = 0;
            double totalRegularHoliday = 0;
            List<TimeSummaryDetail> details = new List<TimeSummaryDetail>();

            DateTime originalDateFrom = dateFrom;

            while (dateFrom <= dateTo)
            {
                if (serverDate < dateFrom)
                {
                    //END COMPUTATION
                    break;
                }

                //COMPUTATION NOT APPLY WHEN DATE HIRED IS ABOVE DATE FROM
                if (dateHired > dateFrom)
                {
                    dateFrom = dateFrom.AddDays(1);
                    continue;
                }

                //DAILY RECORD VARIABLES
                double dailyNetHours = 0;
                double dailyMidNight = 0;
                double dailyExtended = 0;
                double dailyRestday = 0;
                double dailyOvertime = 0;
                double sh = 0;
                double lh = 0;
                string remarks = string.Empty;

                TimeRecord record = null;

                if (employee.Hired == 2)
                {
                    record = TimeRecord.GetTimeRecord(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom);
                    if (record == null)
                        record = TimeRecord.GetLockedTimeRecord(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom);
                }
                else {
                    record = TimeRecord.GetTimeRecord(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom);
                }

                if (record != null)
                {
                    //IF HAVE TIME ADJUST
                    if (string.IsNullOrWhiteSpace(record.AdjustmentCntrlNo))
                        dailyNetHours = record.NetHours;
                    else
                        dailyNetHours = record.AdjustedTime;

                    dailyMidNight = record.MidNightTotal;

                    //IF MIDNIGHT TOTAL HOURS IS LESS THAH DEFAULT MIDNIGHT TOTAL HOURS
                    if (dailyMidNight < defaultMinMidNight)
                        dailyMidNight = 0;

                    //EXTENDED HOURS
                    if (record.TotalExtended > 0)
                        dailyExtended = record.TotalExtended;

                    //WITH TIME RECORD BUT HAVE LEAVE RECORD
                    if (LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                    {
                        remarks = "LV";
                        dailyNetHours = 0;
                    }
                    //WITH TIME RECORD BUT HAVE SUSPENDED RECORD
                    else if (Suspension.IsSuspended(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom))
                    {
                        remarks = "S";
                        dailyNetHours = 0;
                    }
                    else
                    {
                        //WITH TIME RECORD BUT REST DAY
                        bool isRestDay = false;

                        if (EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                        {
                            //IF DAILY TOTAL HOURS IS GREATER THAN 4 THEN ADD TO TOTAL REST DAY DUTY ELSE 0
                            if (dailyNetHours >= 4)
                                dailyRestday = dailyNetHours;

                            remarks = dailyNetHours.ToString("#,##0.00");
                            isRestDay = true;
                        }

                        //BOOLEAN VALUE TO DETERMINE IF DAY IS HOLIDAY
                        bool isDateHoliday = false;

                        string holidayType = string.Empty;

                        //CHECK IF DATE IS HOLIDAY
                        if (HolidayName.IsDateHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, out holidayType))
                        {
                            //IF DATE IS HOLIDAY
                            isDateHoliday = true;
                            int holiday = HolidayEmployees.CheckHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo);

                            //SPECIAL HOLIDAY COMPUTATION
                            if (holidayType.Trim().Equals("special", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //CHECK IF RESTDAY DUTY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                sh = dailyNetHours;
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                sh = dailyNetHours;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                //IF NOT RESTDAY
                                else
                                {
                                    switch (holiday)
                                    {
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                sh = dailyNetHours;
                                            break;
                                        case 0:
                                            remarks = "SH";
                                            break;
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                sh = dailyNetHours;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            //REGULAR HOLIDAY COMPUTATION
                            else if (holidayType.Trim().Equals("regular", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF RESTDAY DUTY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                lh = 8;
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                lh = 8;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //IF NOT RESTDAY
                                    switch (holiday)
                                    {
                                        case 1:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                lh = 8;
                                            break;
                                        case 0:
                                            remarks = "LH";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        case 2:
                                            remarks = dailyNetHours.ToString("#,##0.00");
                                            if (dailyNetHours > 0)
                                                lh = 8;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }

                        //ADDING TOTAL DAILY HOURS
                        if (dailyNetHours > 0)
                        {
                            if (!isDateHoliday && !isDateHoliday)
                                remarks = dailyNetHours.ToString("#,##0.00");
                            totalHours += dailyNetHours;
                        }
                    }
                }
                //NO RECORD
                else {

                    //LEAVED
                    if (LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                    {
                        remarks = "LV";
                        dailyNetHours = 0;
                    }
                    //SUSPENDED
                    else if (Suspension.IsSuspended(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, dateFrom))
                    {
                        remarks = "S";
                        dailyNetHours = 0;
                    }
                    else
                    {

                        //RESTDAY
                        bool isRestDay = false;
                        if (EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                        {
                            //REST DAY REMARKS
                            remarks = "RD";
                            isRestDay = true;
                        }

                        string holidayType = string.Empty;

                        //IF DATE IS HOLIDAY
                        if (HolidayName.IsDateHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, out holidayType))
                        {
                            int holiday = HolidayEmployees.CheckHoliday(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo);

                            //SPECIAL HOLIDAY COMPUTATION
                            if (holidayType.Trim().Equals("special", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF REST DAY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = "RD";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "SH";
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = "SH";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            //REGULAR HOLIDAY COMPUTATION
                            else if (holidayType.Trim().Equals("regular", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //IF REST DAY
                                if (isRestDay)
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "RD";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = "RD";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (holiday)
                                    {
                                        //DUTY
                                        case 1:
                                            remarks = "A";
                                            break;
                                        //HOLIDAY
                                        case 0:
                                            remarks = "LH";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        //NO RECORD
                                        case 2:
                                            remarks = "LH";
                                            if (TimeRecord.IsPresentBefore(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo))
                                                lh = 8;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //NO RECORD, ABSENT
                            if (!isRestDay)
                            {
                                remarks = "A";
                                dailyNetHours = 0;
                            }
                        }
                    }
                }

                //TOTAL MIDNIGHT
                totalMidNight += dailyMidNight;

                //DAILY OVERTIME
                OvertimeSummary o = OvertimeSummary.GetOverTimeSummary(TimeKeepingCode.Program.BiometricsConnection, dateFrom, employee.EmpNo);
                if (o != null)
                    dailyOvertime = (o.TotalOvertime + dailyExtended);
                else
                    dailyOvertime = dailyExtended;

                //TOTAL HOLIDAY
                totalRegularHoliday += lh;
                totalSpecialHoliday += sh;

                //TOTAL REST DAY DUTY;
                totalRDDuty += dailyRestday;

                //TOTAL OVERTIME
                totalOverTime += dailyOvertime;

                details.Add(new TimeSummaryDetail(0, dateFrom, remarks, sh, lh, dailyRestday, dailyOvertime, dailyMidNight));

                dateFrom = dateFrom.AddDays(1);
            }

            //IF TOTAL HOURS IS ZERO OR LESS THAN ZERO NO COMPUTATION
            if (totalHours <= 0)
            {
                TimeSummary.DeleteTimeSummary(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, originalDateFrom, dateTo);
                if (employee.Hired == 3 || employee.Hired == 1)
                {
                    TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary(TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, period.PeriodNo, 1);
                }
                else if (employee.Hired == 2)
                {
                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.DeleteAgencyHourSalary(TimeKeepingCode.Program.PayrollConnection, employee.EmpName, period.PeriodNo);
                }
                return;
            }

            //CLEARING
            double totalClearing = StaticHelper.TotalClearing(TimeKeepingCode.Program.BiometricsConnection, originalDateFrom, dateTo, employee.EmpNo);

            //AGENCY NAME
            string agencyName = string.Empty;
            TimeKeepingDataCode.PayrollSystem.ActionMemo actionMemo =
                TimeKeepingDataCode.PayrollSystem.ActionMemo.GetCurrentActionMemo(TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, dateTo);
            if (actionMemo != null)
                agencyName = actionMemo.PositionRemarks;

            //TIME SUMMARY DETAILS
            TimeSummary summary = TimeSummary.GetTimeSummary(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, originalDateFrom, dateTo);

            if (summary != null)
            {
                summary.EmpPam = employee.PamId;
                summary.Hired = employee.Hired;
                summary.DepId = employee.DepId;
                summary.DepartmentName = employee.DepartmentName;
                summary.SectSort = employee.SecSort;
                summary.SectionName = employee.SectionName;
                summary.PClass_Back = employee.PClassBack;
                summary.TIN = employee.TIN;
                summary.EGroup = employee.EGroup;
                summary.DateHired = dateHired;
                summary.Supplier = employee.Supplier;
                summary.Compensation = employee.CompType;
                summary.PostId = employee.PostId;
                summary.PostName = employee.PostName;
                summary.EmpStatus = employee.Status;
                summary.SectionId = employee.SectionId;
                summary.TotalHours = totalHours;
                summary.SH = totalSpecialHoliday;
                summary.SH_OT = 0;
                summary.LH = totalRegularHoliday;
                summary.LH_OT = 0;
                summary.RD = totalRDDuty;
                summary.REG_OT = totalOverTime;
                summary.MidNight = totalMidNight;
                summary.Clearing = totalClearing;
                summary.AgencyName = agencyName;

                TimeSummary.UpdateTimeSummary(TimeKeepingCode.Program.BiometricsConnection, summary);
            }
            else
            {
                summary = TimeSummary.CreateEmptyTimeSummary();

                summary.EmpNo = employee.EmpNo;
                summary.DateFrom = originalDateFrom;
                summary.DateTo = dateTo;
                summary.EmpPam = employee.PamId;
                summary.Hired = employee.Hired;
                summary.DepId = employee.DepId;
                summary.DepartmentName = employee.DepartmentName;
                summary.SectSort = employee.SecSort;
                summary.SectionId = employee.SectionId;
                summary.SectionName = employee.SectionName;
                summary.PClass_Back = employee.PClassBack;
                summary.TIN = employee.TIN;
                summary.EGroup = employee.EGroup;
                summary.DateHired = dateHired;
                summary.Supplier = employee.Supplier;
                summary.Compensation = employee.CompType;
                summary.PostId = employee.PostId;
                summary.PostName = employee.PostName;
                summary.EmpStatus = employee.Status;
                summary.TotalHours = totalHours;
                summary.SH = totalSpecialHoliday;
                summary.SH_OT = 0;
                summary.LH = totalRegularHoliday;
                summary.LH_OT = 0;
                summary.RD = totalRDDuty;
                summary.REG_OT = totalOverTime;
                summary.MidNight = totalMidNight;
                summary.Clearing = totalClearing;
                summary.Remarks = string.Empty;
                summary.AgencyName = agencyName;

                TimeSummary.InsertTimeSummary(TimeKeepingCode.Program.BiometricsConnection, summary);
            }

            summary = TimeSummary.GetTimeSummary(TimeKeepingCode.Program.BiometricsConnection, employee.EmpNo, originalDateFrom, dateTo);
            if (summary != null)
            {
                TimeSummaryDetail.DeleteTimeSummaryByKey(TimeKeepingCode.Program.BiometricsConnection, summary.Pk);
                TimeSummaryDetail.InsertTimeSummaryDetail(TimeKeepingCode.Program.BiometricsConnection, summary.Pk, details);
            }

            if (employee.Hired == 1 || employee.Hired == 3)
            {
                //COMAPANY PROMO
                TimeKeepingDataCode.PayrollSystem.DTRSummary.DeleteDTRSummary(TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, period.PeriodNo, 1);

                var dtrSummary = TimeKeepingDataCode.PayrollSystem.DTRSummary.CreateEmptyDTRSummary();

                dtrSummary.EmpNo = employee.EmpNo;
                dtrSummary.Period = period.PeriodNo;
                dtrSummary.CurrentPAM = employee.PamId;
                dtrSummary.NoHours = totalHours;
                dtrSummary.SH = 0;
                dtrSummary.SH_OT = totalSpecialHoliday;
                dtrSummary.LH = 0;
                dtrSummary.LH_OT = totalRegularHoliday;
                dtrSummary.RD = totalRDDuty;
                dtrSummary.Reg_OT = totalOverTime;
                dtrSummary.MidNight = totalMidNight;
                dtrSummary.Clearing = totalClearing;
                dtrSummary.Bio = 1;
                dtrSummary.SickLeave = 0;
                dtrSummary.EmpName = employee.EmpName;

                TimeKeepingDataCode.PayrollSystem.DTRSummary.InsertDTRSummary(TimeKeepingCode.Program.PayrollConnection, dtrSummary);
            }
            else if (employee.Hired == 2)
            {
                //AGENCY SECURITY

                //AGENCY RATE PER HOUR COLA
                double ratePerHour = 0;
                double colaPerHour = 0;

                var memo = TimeKeepingDataCode.PayrollSystem.ActionMemo.GetCurrentActionMemo
                    (TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, dateTo);

                if (memo != null)
                {
                    ratePerHour = memo.RatePerHour;
                    colaPerHour = memo.ColaPerHour;
                }

                TimeKeepingDataCode.PayrollSystem.AgencyName agency = TimeKeepingDataCode.PayrollSystem.AgencyName.
                    GetAgency(TimeKeepingCode.Program.PayrollConnection, agencyName);

                //INSERT NEW AGENCY
                if (agency == null)
                    TimeKeepingDataCode.PayrollSystem.AgencyName.InsertAgency
                        (TimeKeepingCode.Program.PayrollConnection, new TimeKeepingDataCode.PayrollSystem.AgencyName(agencyName));

                double agencyTotalClearingSession = StaticHelper.TotalClearing(TimeKeepingCode.Program.BiometricsConnection, originalDateFrom, dateTo, employee.EmpNo);
                double agencyClearingRate = 0;
                double securityRate = TimeKeepingDataCode.PayrollSystem.StaticHelper.SecurityOTRate(TimeKeepingCode.Program.PayrollConnection, dateTo);

                var clearingRate = TimeKeepingDataCode.PayrollSystem.ClearingRate.GetCurrentClearingRate(TimeKeepingCode.Program.PayrollConnection, dateFrom);
                if (clearingRate != null)
                    agencyClearingRate = clearingRate.Rate;

                if (agencyTotalClearingSession > 0)
                {
                    var agencyClearing = TimeKeepingDataCode.PayrollSystem.AgencyClearing.GetAgencyClearing
                    (TimeKeepingCode.Program.PayrollConnection, employee.EmpNo, period.PeriodNo);
                    if (agencyClearing != null)
                    {
                        TimeKeepingDataCode.PayrollSystem.AgencyClearing.DeleteAgencyClearing(TimeKeepingCode.Program.PayrollConnection, agencyClearing);
                        agencyClearing = TimeKeepingDataCode.PayrollSystem.AgencyClearing.CreateEmptyAgencyClearing();

                        agencyClearing.EmpNo = employee.EmpNo;
                        agencyClearing.Department = employee.DepId;
                        agencyClearing.Section = employee.SectionId;
                        agencyClearing.PClassStoreBack = employee.PClassBack;
                        agencyClearing.Period = period.PeriodNo;
                        agencyClearing.ClearingSession = agencyTotalClearingSession;
                        agencyClearing.ClearingRate = agencyClearingRate;

                        TimeKeepingDataCode.PayrollSystem.AgencyClearing.InsertClearing
                            (TimeKeepingCode.Program.PayrollConnection, agencyClearing);

                    }
                }

                TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary agencyHourSalary =
                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.GetAgencyHourSalary
                    (TimeKeepingCode.Program.PayrollConnection, employee.EmpName, period.PeriodNo);

                if (agencyHourSalary != null)
                {
                    agencyHourSalary.HoursSMC = totalHours + totalRDDuty;
                    agencyHourSalary.RegHours = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) : 0);
                    agencyHourSalary.Descripancy = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) - agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency - (totalHours + totalRDDuty) : 0);
                    agencyHourSalary.Overtime = totalMidNight + totalOverTime;
                    agencyHourSalary.RatePerHour = ratePerHour;
                    agencyHourSalary.ColaPerHour = colaPerHour;
                    agencyHourSalary.OvertimePerHour = securityRate;
                    agencyHourSalary.RegPaid = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalHours + totalRDDuty) <= agencyHourSalary.HoursAgency ? (totalRDDuty + totalHours) : 0) * ratePerHour;
                    agencyHourSalary.Cola = (totalHours + totalRDDuty) > agencyHourSalary.HoursAgency ? agencyHourSalary.HoursAgency :
                        ((totalRDDuty + totalHours) <= agencyHourSalary.HoursAgency ? (totalHours + totalRDDuty) : 0) * colaPerHour;
                    agencyHourSalary.OvertimePaid = (totalOverTime + totalMidNight) * securityRate;
                    agencyHourSalary.AgencyName = agencyName;


                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.UpdateAgencySalary(TimeKeepingCode.Program.PayrollConnection, agencyHourSalary);
                }
                else
                {
                    agencyHourSalary = TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.CreateEmptyAgencyHourSalary();
                    agencyHourSalary.EmpName = employee.EmpName;
                    agencyHourSalary.Period = period.PeriodNo;
                    agencyHourSalary.HoursSMC = totalHours + totalRDDuty;
                    agencyHourSalary.Overtime = totalOverTime + totalMidNight;
                    agencyHourSalary.RatePerHour = ratePerHour;
                    agencyHourSalary.ColaPerHour = colaPerHour;
                    agencyHourSalary.OvertimePerHour = securityRate;
                    agencyHourSalary.OvertimePaid = (totalOverTime + totalMidNight) * securityRate;
                    agencyHourSalary.AgencyName = agencyName;

                    TimeKeepingDataCode.PayrollSystem.AgencyHoursSalary.InsertAgencySalary(TimeKeepingCode.Program.PayrollConnection, agencyHourSalary);
                }
            }
        }
    }
}
