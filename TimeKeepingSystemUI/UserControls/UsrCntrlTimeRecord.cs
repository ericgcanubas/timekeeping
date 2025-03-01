using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlTimeRecord : UserControl
    {
        private DateTime periodFrom;
        private DateTime periodTo;
        private DateTime serverDate;
        private BasicEmployeeInfo employee;

        private bool isPayrollLocked;

        public UsrCntrlTimeRecord()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.isPayrollLocked = false;
        }

        private static UsrCntrlTimeRecord instance;
        public static UsrCntrlTimeRecord Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlTimeRecord();
                    instance.Name = "singletonUsrCntrlTimeRecord";
                }
                return instance;
            }
        }

        private void SelectedProfileChanged(object sender, TimeKeepingCode.Events.BasicInfoOnSelectedEventArgs e)
        {
            this.employee = e.Selected;
            RefreshTimeRecord();
            gridDailyRecord.Focus();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
            txtType.Text = string.Empty;
            txtBioId.Text = string.Empty;
            txtBioLocation.Text = string.Empty;

            Task.Factory.StartNew(() =>
            {
                this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            }).ContinueWith(a => 
            {
                if (this.serverDate.Day <= 15)
                {
                    this.periodFrom = new DateTime(this.serverDate.Year,this.serverDate.Month,1);
                    this.periodTo = new DateTime(this.serverDate.Year,this.serverDate.Month,15);
                }
                else {
                    this.periodFrom = new DateTime(this.serverDate.Year,this.serverDate.Month,16);
                    this.periodTo = new DateTime(this.serverDate.Year,this.serverDate.Month,DateTime.DaysInMonth(this.serverDate.Year,this.serverDate.Month));
                }
                LoadDailyDate();
                txtPeriod.Text = this.periodFrom.ToString("MM/dd/yyyy") + " - " + this.periodTo.ToString("MM/dd/yyyy");
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadDailyDate() 
        {
            gridDailyRecord.Rows.Clear();
            DateTime onGoingDate = this.periodFrom;
            while (onGoingDate <= this.periodTo) {
                gridDailyRecord.Rows.Add(onGoingDate.ToString("MM/dd/yyyy"),onGoingDate.DayOfWeek.ToString().ToUpper());
                onGoingDate = onGoingDate.AddDays(1);
            }
        }

        private void LoadFloor() 
        {
            if (this.employee == null)
                return;

            Task.Factory.StartNew(() =>
            {
                return EmployeeShifting.GetCurrentEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId,this.periodTo);
            }).ContinueWith(a =>
            {
                if (a.Result != null)
                {
                    txtBioId.Text = a.Result.MachineId.ToString();
                    if (a.Result.MachineNo == 1)
                        txtBioLocation.Text = "FIRST FLOOR";
                    else if (a.Result.MachineNo == 2)
                        txtBioLocation.Text = "SECOND FLOOR";
                    else if (a.Result.MachineNo == 3)
                        txtBioLocation.Text = "THIRD FLOOR";
                    else if (a.Result.MachineNo == 4)
                        txtBioLocation.Text = "MANILA";
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadOtherDetails() 
        {
            if (this.employee == null)
                return;

            Task<Tuple<int, string, string>>.Factory.StartNew(() =>
            {
                var actionMemo = ActionMemo.GetCurrentActionMemo(TimeKeepingCode.Program.PayrollConnection, this.employee.PkId, this.periodTo);
                if (actionMemo == null)
                {
                    return Tuple.Create(-1, string.Empty, string.Empty);
                }
                else
                {
                    var supplier = Supplier.GetSupplier(TimeKeepingCode.Program.PayrollConnection, actionMemo.Supplier);
                    return Tuple.Create(actionMemo.TypeOfCompensation, supplier != null ? supplier.SupplierName : string.Empty, actionMemo.Location);
                }
            }).ContinueWith(a =>
            {
                txtType.Text = a.Result.Item1 == 1 ? "MONTHLY" : (a.Result.Item1 == -1 ? string.Empty : "DAILY");
                txtSupplier.Text = a.Result.Item2;
                txtLocation.Text = a.Result.Item3;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadTimeRecord() 
        {
            if (this.employee == null)
                return;

            Task<List<TimeRecord>>.Factory.StartNew(() =>
            {
                var unlockedTimeRecord = TimeRecord.GetAllTimeRecord(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, this.periodFrom, this.periodTo);
                if (unlockedTimeRecord.Count != 0)
                {
                    this.isPayrollLocked = false;
                    return unlockedTimeRecord;
                }
                else
                {
                    this.isPayrollLocked = true;
                    return TimeRecord.GetAllLockedTimeRecord(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, this.periodFrom, this.periodTo);
                }
            }).ContinueWith(a => {
                for (int i = 0; i < gridDailyRecord.Rows.Count; i++)
                {
                    DataGridViewRow row = gridDailyRecord.Rows[i];
                    DateTime date = Convert.ToDateTime(row.Cells[0].Value);
                    var timerRecord = a.Result.Find(e => e.ActualDate == date);
                    if (timerRecord != null)
                    {
                        if (!string.IsNullOrWhiteSpace(timerRecord.AdjustmentCntrlNo))
                        {
                            row.Cells[2].Value = timerRecord.AdjustedTime.ToString("#,##0.00");
                            row.Cells[5].Value = timerRecord.AdjustmentCntrlNo;
                        }
                        else
                        {
                            row.Cells[2].Value = timerRecord.NetHours.ToString("#,##0.00");
                        }
                        if (timerRecord.MidNightTotal > 0)
                            row.Cells[3].Value = timerRecord.MidNightTotal.ToString("#,##0.00");
                        if (timerRecord.TotalExtended > 0)
                            row.Cells[4].Value = timerRecord.TotalExtended.ToString("#,##0.00");
                    }

                    string holidayType = string.Empty;
                    if (row.Cells[5].Value == null || string.IsNullOrWhiteSpace(row.Cells[5].Value.ToString())) {
                        if (EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId))
                            row.Cells[5].Value = "Restday";
                        else if (HolidayEmployees.IsEmployeeHoliday(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId,out holidayType))
                            row.Cells[5].Value = holidayType + " Holiday";
                        else if (LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId))
                            row.Cells[5].Value = "Leave";
                    }
                }
                lblPayrollLocked.Visible = this.isPayrollLocked;
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnResize(object sender, EventArgs e)
        {
            pnlChangePeriod.Left = (this.Width - pnlChangePeriod.Width) / 2;
            pnlChangePeriod.Top = (this.Height - pnlChangePeriod.Height) / 2;

            pnlRepost.Left = (this.Width - pnlRepost.Width) / 2;
            pnlRepost.Top = (this.Height - pnlRepost.Height) / 2;
        }

        private void TextDateFromValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDateFrom.Text)) {
                DateTime date;
                if (DateTime.TryParse(txtDateFrom.Text, out date))
                {
                    txtDateFrom.Text = date.ToString("MM/dd/yyyy");
                }
                else {
                    e.Cancel = true;
                    MessageBox.Show("Invalid Entry Date","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtDateFrom.Focus();
                }
            }
        }

        private void TextDateToValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDateTo.Text))
            {
                DateTime date;
                if (DateTime.TryParse(txtDateTo.Text, out date))
                {
                    txtDateTo.Text = date.ToString("MM/dd/yyyy");
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Invalid Entry Date", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDateTo.Focus();
                }
            }
        }

        private void TextDateFromKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateTo.Focus();
            else
                ChangePeriodKeyEvent(e);
        }

        private void TextDateToKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnChangePeriod.Focus();
            else
                ChangePeriodKeyEvent(e);
        }

        private void ChangePeriodClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDateFrom.Text))
            {
                DateTime date = Convert.ToDateTime(txtDateFrom.Text);
                if (date.Day <= 15)
                {
                    this.periodFrom = new DateTime(date.Year, date.Month, 1);
                    this.periodTo = new DateTime(date.Year, date.Month, 15);
                }
                else {
                    this.periodFrom = new DateTime(date.Year,date.Month,16);
                    this.periodTo = new DateTime(date.Year,date.Month,DateTime.DaysInMonth(date.Year,date.Month));
                }
                txtPeriod.Text = this.periodFrom.ToString("MM/dd/yyyy") + " - " + this.periodTo.ToString("MM/dd/yyyy");
                pnlChangePeriod.Visible = false;
                RefreshTimeRecord();
            }
            else {
                MessageBox.Show("Fill Date From Period","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDateFrom.Focus();
            }
        }

        private void DailyRecordRowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.employee == null)
                return;

            DateTime date = Convert.ToDateTime(gridDailyRecord.Rows[e.RowIndex].Cells[0].Value);
            var logs = TransactionLog.GetAllTransactionLog(TimeKeepingCode.Program.BiometricsConnection,date, this.employee.PkId);

            gridTimeLogs.Rows.Clear();
            for (int i = 0; i < logs.Count; i++)
            {
                gridTimeLogs.Rows.Add(logs[i].ActualTime.ToString("hh:mm tt"),logs[i].InOutMode);
            }

            gridRepost.Rows.Clear();
            for (int i = 0; i < logs.Count; i++)
            {
                gridRepost.Rows.Add(logs[i].Pk,logs[i].ActualTime.ToString("hh:mm tt"), logs[i].InOutMode);
            }

            List<TimeRecordDetail> timeRecordDetail = null;
            if(this.isPayrollLocked)
                timeRecordDetail = TimeRecordDetail.GetAllLockedTimeRecordDetail(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, date);
            else
                timeRecordDetail = TimeRecordDetail.GetAllTimeRecordDetail(TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId,date);

            gridDailyRecordDetails.Rows.Clear();
            for (int i = 0; i < timeRecordDetail.Count; i++)
			{
                gridDailyRecordDetails.Rows.Add(timeRecordDetail[i].ActualTimeIn != TimeKeepingCode.Program.DefaultDate ? 
                    timeRecordDetail[i].ActualTimeIn.ToString("hh:mm tt") : string.Empty,timeRecordDetail[i].ActualTimeOut != TimeKeepingCode.Program.DefaultDate ?
                    timeRecordDetail[i].ActualTimeOut.ToString("hh:mm tt") : string.Empty,timeRecordDetail[i].Late == 0 ? "" : timeRecordDetail[i].Late.ToString("#,##0.00"),
                    timeRecordDetail[i].Undertime == 0 ? "" : timeRecordDetail[i].Undertime.ToString("#,##0.00"),timeRecordDetail[i].Remarks);
			}

            var changeShifts = WholeDayChangeShift.GetAllChangeShift(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, date);
            changeShifts = changeShifts.OrderByDescending(c => c.Pk).ToList();

            var changeShift = changeShifts.Find(c => c.IsPosted);
            if (changeShift != null)
                LoadShiftingSchedule(changeShift.Shift, true);
            else
            {
                var employeeShifting = EmployeeShifting.GetCurrentEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, date);
                if (employeeShifting != null)
                {
                    int id = 0;
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Friday:
                            id = employeeShifting.Friday;
                            break;
                        case DayOfWeek.Monday:
                            id = employeeShifting.Monday;
                            break;
                        case DayOfWeek.Saturday:
                            id = employeeShifting.Saturday;
                            break;
                        case DayOfWeek.Sunday:
                            id = employeeShifting.Sunday;
                            break;
                        case DayOfWeek.Thursday:
                            id = employeeShifting.Thursday;
                            break;
                        case DayOfWeek.Tuesday:
                            id = employeeShifting.Tuesday;
                            break;
                        case DayOfWeek.Wednesday:
                            id = employeeShifting.Wednesday;
                            break;
                        default:
                            break;
                    }
                    LoadShiftingSchedule(id, false);
                }
                else
                    ClearShiftings();
            }

            if (gridDailyRecord.Rows[e.RowIndex].Cells[3].Value != null &&
                        gridDailyRecord.Rows[e.RowIndex].Cells[3].Value.ToString().Equals("restday", StringComparison.CurrentCultureIgnoreCase))
                chkRestday.Checked = true;
            else
                chkRestday.Checked = false;
        }

        private void CancelChangePeriodClick(object sender, EventArgs e)
        {
            pnlChangePeriod.Visible = false;
        }

        private void LoadShiftingSchedule(int shiftingId,bool isChangeShift) 
        {
            ClearShiftings();
            var shiftingSchedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shiftingId);
            if (shiftingSchedule != null)
            {
                grpBoxShiftingSchedule.Text = shiftingSchedule.ShiftingName;
                if (shiftingSchedule.ScheduleType == 1)
                {
                    lblLunchOut.Text = shiftingSchedule.StringLunchOut;
                    lblLunchIn.Text = shiftingSchedule.StringLunchIn;
                    lblCoffeeOut.Text = shiftingSchedule.StringCoffeeOut;
                    lblCoffeeIn.Text = shiftingSchedule.StringCoffeeIn;
                }
                else if (shiftingSchedule.ScheduleType == 2)
                {
                    lblCoffeeOut.Text = shiftingSchedule.StringCoffeeOut;
                    lblCoffeeIn.Text = shiftingSchedule.StringCoffeeIn;
                }
                else if (shiftingSchedule.ScheduleType == 3)
                {
                    lblLunchIn.Text = shiftingSchedule.StringLunchIn;
                    lblLunchOut.Text = shiftingSchedule.StringLunchOut;
                }

                lblAMIn.Text = shiftingSchedule.StringAMIn;
                lblPMOut.Text = shiftingSchedule.StringPmOut;

                lblLunchBreakTime.Text = shiftingSchedule.Lunchtime + " min/s";
                lblCoffeeBreakTime.Text = shiftingSchedule.Breaktime + " min/s";

                chkFixedSchedule.Checked = shiftingSchedule.IsFixed;
            }

            lblChangeShift.Visible = isChangeShift;
        }

        private void ClearShiftings()
        {
            lblAMIn.Text = string.Empty;
            lblLunchOut.Text = string.Empty;
            lblLunchIn.Text = string.Empty;
            lblCoffeeOut.Text = string.Empty;
            lblCoffeeIn.Text = string.Empty;
            lblPMOut.Text = string.Empty;
            lblLunchBreakTime.Text = string.Empty;
            lblCoffeeBreakTime.Text = string.Empty;
            chkRestday.Checked = false;
            chkFixedSchedule.Checked = false;
        }

        private void RefreshTimeRecord() 
        {
            LoadOtherDetails();
            LoadFloor();
            LoadDailyDate();
            LoadTimeRecord();
            LoadTimeSummary();
            gridDailyRecord.Focus();
        }

        private void SetControls() 
        {
            gridTimeLogs.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridTimeLogs.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridTimeLogs.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridTimeLogs.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            gridDailyRecord.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridDailyRecord.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridDailyRecord.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridDailyRecord.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            gridDailyRecordDetails.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridDailyRecordDetails.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridDailyRecordDetails.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridDailyRecordDetails.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            gridTimeSummary.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridTimeSummary.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridTimeSummary.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridTimeSummary.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            btnChanged.BackColor = Code.Program.MainColor;
            btnChanged.ForeColor = Code.Program.TextColor;
            btnRepost.BackColor = Code.Program.MainColor;
            btnRepost.ForeColor = Code.Program.TextColor;
            btnRefresh.BackColor = Code.Program.MainColor;
            btnRefresh.ForeColor = Code.Program.TextColor;

            btnChanged.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            btnRepost.Image = TimeKeepingSystemUI.Properties.Resources.post15;
            btnRefresh.Image = TimeKeepingSystemUI.Properties.Resources.reset15;

            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbTimeRecord.ForeColor = Code.Program.MainColor;
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

        private void HomeClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            RefreshTimeRecord();
        }

        private void RepostClick(object sender, EventArgs e)
        {
            if (this.isPayrollLocked) {
                MessageBox.Show("Can't Repost, Payroll already Locked.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            pnlChangePeriod.Visible = false;
            pnlRepost.Visible = true;
            gridRepost.Focus();
        }

        private void RepostCancelClick(object sender, EventArgs e)
        {
            pnlRepost.Visible = false;
        }

        private void ChangeClick(object sender, EventArgs e)
        {
            pnlRepost.Visible = false;
            pnlChangePeriod.Visible = true;
            txtDateFrom.Focus();
        }

        private void GridRepostKeyDown(object sender, KeyEventArgs e)
        {
            RepostKeyEvent(e);
            if (gridRepost.Rows.Count > 0 && gridRepost.CurrentCell.ColumnIndex == 2)
            {
                if (e.KeyCode == Keys.I)
                    gridRepost.CurrentCell.Value = "I";
                else if (e.KeyCode == Keys.O)
                    gridRepost.CurrentCell.Value = "O";
            }
        }

        private void RepostSaveClick(object sender, EventArgs e)
        {
            if (this.isPayrollLocked)
            {
                MessageBox.Show("Can't Repost, Payroll already Locked.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (this.employee == null) {
                MessageBox.Show("Can't Repost with Empty Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (gridDailyRecord.Rows.Count == 0) {
                MessageBox.Show("Can't Repost with Empty Time Record.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure to Repost Record?", "Repost Record", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            List<Tuple<int, string>> pair = new List<Tuple<int, string>>();
            for (int i = 0; i < gridRepost.Rows.Count; i++)
            {
                pair.Add(Tuple.Create(Convert.ToInt32(gridRepost.Rows[i].Cells[0].Value), gridRepost.Rows[i].Cells[2].Value.ToString()));
            }

            TransactionLog.RepostTransactionLog(TimeKeepingCode.Program.BiometricsConnection,
                Convert.ToDateTime(gridDailyRecord.SelectedRows[0].Cells[0].Value),this.employee.PkId,pair);
            RefreshTimeRecord();
            pnlRepost.Visible = false;
            gridDailyRecord.Focus();
        }

        private void ChangePeriodLeave(object sender, EventArgs e)
        {
            pnlChangePeriod.Visible = false;
        }

        private void RepostPanelLeave(object sender, EventArgs e)
        {
            pnlRepost.Visible = false;
        }

        private void RepostSaveKeyDown(object sender, KeyEventArgs e)
        {
            RepostKeyEvent(e);
        }

        private void RepostCancelKeyDown(object sender, KeyEventArgs e)
        {
            RepostKeyEvent(e);
        }

        private void BtnChangePeriodKeyDown(object sender, KeyEventArgs e)
        {
            ChangePeriodKeyEvent(e);
        }

        private void BtnCancelChangePeriod(object sender, KeyEventArgs e)
        {
            ChangePeriodKeyEvent(e);
        }

        private void ChangePeriodKeyEvent(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlRepost.Visible = false;

                if (tabRecords.SelectedIndex == 0)
                    gridDailyRecord.Focus();
                else if (tabRecords.SelectedIndex == 1)
                    gridTimeSummary.Focus();
            }
        }

        private void RepostKeyEvent(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Escape)
            {
                pnlRepost.Visible = false;

                if (tabRecords.SelectedIndex == 0)
                    gridDailyRecord.Focus();
                else if (tabRecords.SelectedIndex == 1)
                    gridTimeSummary.Focus();
            }
        }

        private void KeyEventArgs(object sender,KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.F8)
            {
                if(tabRecords.SelectedIndex == 0)
                    RepostClick(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
                RefreshTimeRecord();
            else if (e.KeyCode == Keys.F6)
                ucProfile.Focus();
            else if (e.KeyCode == Keys.F1)
            {
                pnlChangePeriod.Visible = true;
                txtDateFrom.Focus();
            }

        }

        private void TabRecordResize(object sender, EventArgs e)
        {
            gridDailyRecord.Width = (tabRecords.Width - (gridTimeLogs.Width + 5)) / 2;
            gridDailyRecordDetails.Left = gridDailyRecord.Left + gridDailyRecord.Width + 5;
            gridDailyRecordDetails.Width = (tabRecords.Width - (gridTimeLogs.Width + 5)) / 2;
            gridTimeLogs.Left = gridDailyRecordDetails.Left + gridDailyRecordDetails.Width + 5;
        }

        private void LoadTimeSummary()
        {
            if (this.employee == null)
                return;

           TimeSummary timeSummary = null;
           List<TimeSummaryDetail> timeSummaryDetails = null;

           Task.Factory.StartNew(() =>
           {
               timeSummary = TimeSummary.GetTimeSummary(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, this.periodFrom, this.periodTo);
               if (timeSummary == null)
               {
                   timeSummary = TimeSummary.GetLockedTimeSummary(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId, this.periodFrom, this.periodTo);
                   if (timeSummary != null)
                       timeSummaryDetails = TimeSummaryDetail.GetAllLockedTimeSummaryDetails(TimeKeepingCode.Program.BiometricsConnection, timeSummary.Pk);
               }
               else {
                   timeSummaryDetails = TimeSummaryDetail.GetAllTimeSummaryDetails(TimeKeepingCode.Program.BiometricsConnection,timeSummary.Pk);
               }
           }).ContinueWith(a => 
           {
               if (timeSummary != null)
               {
                   txtNoHrs.Text = timeSummary.TotalHours.ToString("#,##0.00");
                   txtSickLeave.Text = timeSummary.SL.ToString("#,##0.00");
                   txtSpecialHoliday.Text = timeSummary.SH.ToString("#,##0.00");
                   txtLegalHoliday.Text = timeSummary.LH.ToString("#,##0.00");
                   txtOverSpecialHoliday.Text = timeSummary.SH_OT.ToString("#,##0.00");
                   txtOverLegalHoliday.Text = timeSummary.LH_OT.ToString("#,##0.00");
                   txtRestday.Text = timeSummary.RD.ToString("#,##0.00");
                   txtRegular.Text = timeSummary.REG_OT.ToString("#,##0.00");
                   txtMidNightDuty.Text = timeSummary.MidNight.ToString("#,##0.00");
                   txtClearingSession.Text = timeSummary.Clearing.ToString("#,##0.00");
               }
               else {
                   txtNoHrs.Text = string.Empty;
                   txtSickLeave.Text = string.Empty;
                   txtSpecialHoliday.Text = string.Empty;
                   txtLegalHoliday.Text = string.Empty;
                   txtOverSpecialHoliday.Text = string.Empty;
                   txtOverLegalHoliday.Text = string.Empty;
                   txtRestday.Text = string.Empty;
                   txtRegular.Text = string.Empty;
                   txtMidNightDuty.Text = string.Empty;
                   txtClearingSession.Text = string.Empty;
               }

               gridTimeSummary.Rows.Clear();
               if (timeSummaryDetails != null)
               {
                   for (int i = 0; i < timeSummaryDetails.Count; i++)
                   {
                       gridTimeSummary.Rows.Add(timeSummaryDetails[i].Date.ToString("MM/dd/yyyy"),
                           timeSummaryDetails[i].RegTime,
                           timeSummaryDetails[i].SH != 0 ? timeSummaryDetails[i].SH.ToString("#,##0.00") : string.Empty,
                           timeSummaryDetails[i].LH != 0 ? timeSummaryDetails[i].LH.ToString("#,##0.00") : string.Empty,
                           timeSummaryDetails[i].RD != 0 ? timeSummaryDetails[i].RD.ToString("#,##0.00") : string.Empty,
                           timeSummaryDetails[i].OT != 0 ? timeSummaryDetails[i].OT.ToString("#,##0.00") : string.Empty);
                   }
               }

           },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void TabRecordsSelectedChanged(object sender, EventArgs e)
        {
            if (tabRecords.SelectedIndex == 0)
            {
                btnChanged.Visible = true;
                btnRepost.Visible = true;
                btnRefresh.Visible = true;
            }
            else {
                btnChanged.Visible = false;
                btnRepost.Visible = false;
                btnRefresh.Visible = false;
            }
        }

    }
}
