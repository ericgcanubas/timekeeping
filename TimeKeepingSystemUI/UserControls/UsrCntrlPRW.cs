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
    public partial class UsrCntrlPRW : UserControl, TimeKeepingCode.Code.IForms, TimeKeepingCode.Code.IPrint
    {
        private BindingSource sourceHist;
        private TimeKeepingCode.UserAction action;
        private BasicEmployeeInfo employee;
        private DateTime serverDate;

        public UsrCntrlPRW()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            gridHistory.AutoGenerateColumns = false;

            SetControls();

            this.sourceHist = new BindingSource();
            gridHistory.DataSource = this.sourceHist;

            this.sourceHist.CurrentChanged += SelectedCurretChanged;
            this.employee = null;
            this.action = TimeKeepingCode.UserAction.View;

            ReadOnlyFields(true);
        }

        private void SelectedCurretChanged(object sender,EventArgs e) 
        {
            LoadPRW(this.sourceHist.Current as TimeKeepingDataCode.Biometrics.PRW);
        }

        public bool Edit()
        {
            if (this.gridHistory.SelectedRows.Count == 0) {
                MessageBox.Show("Can't Update With Empty List.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            PRW p = this.sourceHist.Current as PRW;
            if (p != null)
            {
                if (p.IsPosted)
                {
                    MessageBox.Show("Can't Update PRW With Posted Status.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Can't Update With Empty List.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            this.action = TimeKeepingCode.UserAction.Update;
            ReadOnlyFields(false);
            txtApprovedBy.Focus();
            return true;
        }

        public bool Save()
        {
            bool result = false;
            if (this.action == TimeKeepingCode.UserAction.Create) 
            {
                if (!IsHaveEmptyFields()) {
                    if (MessageBox.Show("Are you sure to Save Created PRW?", "Save Created", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (PRW.CreatePRW(TimeKeepingCode.Program.BiometricsConnection, CreatePRW(), CreatePRWDetails()))
                    {
                        MessageBox.Show("Created PRW Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        result = true;
                        this.action = TimeKeepingCode.UserAction.View;
                        LoadData(this.employee);
                        this.sourceHist.MoveFirst();
                        ReadOnlyFields(true);
                        gridHistory.Focus();
                    }
                    else {
                        MessageBox.Show("Failed to Save Created PRW.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        result = false;
                    }
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (!IsHaveEmptyFields()) {
                    if (MessageBox.Show("Are you sure to Save Updated PRW?", "Save Updated", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (PRW.UpdatePRW(TimeKeepingCode.Program.BiometricsConnection, CreatePRW(), CreatePRWDetails()))
                    {
                        MessageBox.Show("Updated PRW Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        result = true;
                        this.action = TimeKeepingCode.UserAction.View;
                        LoadData(this.employee);
                        ReadOnlyFields(true);
                        gridHistory.Focus();
                    }
                    else {
                        MessageBox.Show("Failed to Save Updated PRW.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool Create()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Create With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            ReadOnlyFields(false);
            ClearFields();
            txtDateCreated.Text = this.serverDate.ToString("MM/dd/yyyy");
            txtVerifiedBy.Text = TimeKeepingCode.Program.User.UserName;
            
            this.action = TimeKeepingCode.UserAction.Create;
            chkLate.Checked = true;
            txtReason.Focus();
            return true;
        }

        public TimeKeepingCode.UserAction Action { get { return this.action; } }

        public bool Cancel()
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created PRW?", "Cancel Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false; ;
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are You sure to Cancel Updated PRW?", "Cancel Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            ReadOnlyFields(true);
            LoadData(this.employee);
            this.action = TimeKeepingCode.UserAction.View;
            gridHistory.Focus();
            return true;
        }

        public void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            this.employee = employee;
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.PRW.
                    GetAllPRW(TimeKeepingCode.Program.BiometricsConnection, employee.PkId);
            }).ContinueWith(a => 
            {
                this.sourceHist.DataSource = a.Result.OrderByDescending(e => e.Id);
                this.sourceHist.ResetBindings(false);
                gridHistory.Focus();
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadPRW(TimeKeepingDataCode.Biometrics.PRW prw) 
        {
            if (prw != null)
            {
                LoadDetails(prw);
                LoadGridDetails(prw);
            }
            else
                Empty();
        }

        private void LoadDetails(TimeKeepingDataCode.Biometrics.PRW prw) 
        {
            if (prw.Type == 1)
            {
                chkAbsent.Checked = true;
                chkLate.Checked = false;
            }
            else if (prw.Type == 2)
            {
                chkAbsent.Checked = !true;
                chkLate.Checked = !false;
            }

            txtDateCreated.Text = prw.TransactionDate.ToString("MM/dd/yyyy");
            txtDateAbsenceLate.Text = prw.AllDates;
            txtReason.Text = prw.Reason;
            txtRecommendedBy.Text = prw.RecommendedBy;
            txtNotedBy.Text = prw.NotedBy1;
            txtNoDaysMins.Text = prw.NoDaysMins;
            txtVerifiedBy.Text = prw.VerifiedBy;
            txtApprovedBy.Text = prw.ApprovedBy1;
            txtReleaseBy.Text = prw.ReleaseBy;

            if (prw.DiscActType == 1)
                rBtnCounsilingWarning.Checked = true;
            else if (prw.DiscActType == 2)
                rBtnReprimand.Checked = true;
            else if (prw.DiscActType == 3)
                rBtnSuspensionFor.Checked = true;
            else if (prw.DiscActType == 4)
                rBtnWarningForTermination.Checked = true;
            else if (prw.DiscActType == 5)
                rBtnTerminationEffectOn.Checked = true;

            txtSuspensionFor.Text = prw.SuspensionFor;
            txtScheduledOn.Text = prw.SuspensionSched;
            txtTerminationEffect.Text = prw.TerminationDate.ToString("MM/dd/yyyy");
            txtRemarks.Text = prw.Remarks;
            txtPreparedBy2.Text = prw.PreparedBy;
            txtNotedBy2.Text = prw.NotedBy2;
            txtApprovedBy2.Text = prw.ApprovedBy2;
            txtConformeBy.Text = prw.ConfirmBy;

            if (prw.IsPosted)
                lblStatus.Text = "P O S T E D";
            else
                lblStatus.Text = "U N P O S T E D";

            lblLastUpdated.Text = "Last Updated: " + prw.LastUpdated;
        }

        private void LoadGridDetails(TimeKeepingDataCode.Biometrics.PRW prw) 
        {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.PRWDetails.
                    GetAllPRWDetails(TimeKeepingCode.Program.BiometricsConnection, prw.Id);
            }).ContinueWith(a => 
            {
                var result = a.Result.OrderBy(e => e.Line).ToList();
                LoadDataGridDatails(result);
                
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadDataGridDatails(List<PRWDetails> details) 
        {
            if (details.Count > 0)
            {
                gridDetails.Columns[1].HeaderText = details[0].Month1;
                gridDetails.Columns[2].HeaderText = details[0].Month2;
                gridDetails.Columns[3].HeaderText = details[0].Month3;
                gridDetails.Columns[4].HeaderText = details[0].Month4;
                gridDetails.Columns[5].HeaderText = details[0].Month5;
                gridDetails.Columns[6].HeaderText = details[0].Month6;
                gridDetails.Columns[7].HeaderText = details[0].Total;
                gridDetails.Columns[8].HeaderText = details[0].Id.ToString();
                gridDetails.Columns[9].HeaderText = details[0].PRWId.ToString();

                gridDetails.Rows.Clear();
                for (int i = 1; i < details.Count; i++)
                {
                    gridDetails.Rows.Add(details[i].Type, details[i].Month1, details[i].Month2,
                        details[i].Month3, details[i].Month4, details[i].Month5, details[i].Month6,details[i].Total,
                        details[i].Id,details[i].PRWId);
                }
            }
        }

        private void Empty() 
        {
            chkAbsent.Checked = false;
            chkLate.Checked = false;

            txtDateCreated.Text = string.Empty;
            txtDateAbsenceLate.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtRecommendedBy.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtNoDaysMins.Text = string.Empty;
            txtVerifiedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtReleaseBy.Text = string.Empty;

            rBtnCounsilingWarning.Checked = false;
            rBtnReprimand.Checked = false;
            rBtnSuspensionFor.Checked = false;
            rBtnWarningForTermination.Checked = false;
            rBtnTerminationEffectOn.Checked = false;

            txtSuspensionFor.Text = string.Empty;
            txtScheduledOn.Text = string.Empty;
            txtTerminationEffect.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtPreparedBy2.Text = string.Empty;
            txtNotedBy2.Text = string.Empty;
            txtApprovedBy2.Text = string.Empty;
            txtConformeBy.Text = string.Empty;

            gridDetails.Rows.Clear();
            gridDetails.Columns[1].HeaderText = string.Empty;
            gridDetails.Columns[2].HeaderText = string.Empty;
            gridDetails.Columns[3].HeaderText = string.Empty;
            gridDetails.Columns[4].HeaderText = string.Empty;
            gridDetails.Columns[5].HeaderText = string.Empty;
            gridDetails.Columns[6].HeaderText = string.Empty;
        }

        private void SetControls() 
        {
            gridHistory.BackgroundColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridHistory.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridHistory.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            gridDetails.BackgroundColor = Code.Program.MainColor;
            gridDetails.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridDetails.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridDetails.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridDetails.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            lblStatus.ForeColor = Code.Program.MainColor;
        }

        private void CheckAbsent(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create ||
                this.action == TimeKeepingCode.UserAction.Update)
            {
                chkLate.Checked = !chkAbsent.Checked;

                string o;
                txtNoDaysMins.Text = GetNumberDays(out o);
                txtDateAbsenceLate.Text = o;
                LoadDataGridDatails(GenerateDetails());
                Frequently(CalculateFrequently());
                txtReason.Focus();
            }
        }

        private void CheckLate(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update ||
                this.action == TimeKeepingCode.UserAction.Create)
            {
                chkAbsent.Checked = !chkLate.Checked;

                string o;
                txtNoDaysMins.Text = GetNumberDays(out o);
                txtDateAbsenceLate.Text = o;
                LoadDataGridDatails(GenerateDetails());
                Frequently(CalculateFrequently());
                txtReason.Focus();
            }
        }

        private void ReadOnlyFields(bool b) 
        {
            txtReason.ReadOnly = b;
            //txtVerifiedBy.ReadOnly = b;
            txtRecommendedBy.ReadOnly = b;
            txtApprovedBy.ReadOnly = b;
            txtNotedBy.ReadOnly = b;
            txtReleaseBy.ReadOnly = b;

            txtScheduledOn.ReadOnly = b;
            txtTerminationEffect.ReadOnly = b;
            txtRemarks.ReadOnly = b;
            txtPreparedBy2.ReadOnly = b;
            txtNotedBy2.ReadOnly = b;
            txtApprovedBy2.ReadOnly = b;
            txtConformeBy.ReadOnly = b;

            gridHistory.Enabled = b;
        }

        private void ClearFields() 
        {
            chkAbsent.Checked = false;
            chkLate.Checked = false;
            txtDateCreated.Text = string.Empty;
            txtDateAbsenceLate.Text = string.Empty;
            txtNoDaysMins.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtVerifiedBy.Text = string.Empty;
            txtRecommendedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtReleaseBy.Text = string.Empty;
            txtSuspensionFor.Text = string.Empty;
            txtScheduledOn.Text = string.Empty;
            txtTerminationEffect.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtPreparedBy2.Text = string.Empty;
            txtNotedBy2.Text = string.Empty;
            txtApprovedBy2.Text = string.Empty;
            txtConformeBy.Text = string.Empty;
            gridDetails.Rows.Clear();
        }

        private string GetNumberDays(out string dateAbsenceLate) 
        {
            string result = string.Empty;
            string o = string.Empty;

            if (chkLate.Checked) 
            {
                EmployeeShifting current = EmployeeShifting.GetCurrentEmployeeShifting
                    (TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId);

                if (current != null)
                {
                    ShiftingSchedule schedule = null;
                    switch (this.serverDate.DayOfWeek)
                    {
                        case DayOfWeek.Friday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Friday);
                            break;
                        case DayOfWeek.Monday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Monday);
                            break;
                        case DayOfWeek.Saturday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Saturday);
                            break;
                        case DayOfWeek.Sunday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Sunday);
                            break;
                        case DayOfWeek.Thursday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Thursday);
                            break;
                        case DayOfWeek.Tuesday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Tuesday);
                            break;
                        case DayOfWeek.Wednesday:
                            schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Wednesday);
                            break;
                    }

                    if (schedule != null)
                    {
                        TimeSpan time = new TimeSpan();
                        if (schedule.ScheduleType == 1) 
                        {
                            if (this.serverDate.TimeOfDay >= schedule.CoffeeIn)
                            {
                                time = schedule.LunchOut.Subtract(schedule.AMIn).Add
                                    (schedule.CoffeeOut.Subtract(schedule.LunchIn)).Add(this.serverDate.TimeOfDay.Subtract(schedule.CoffeeIn));
                            }
                            else if (this.serverDate.TimeOfDay >= schedule.CoffeeOut) 
                            {
                                time = schedule.LunchOut.Subtract(schedule.AMIn).Add(schedule.CoffeeOut.Subtract(schedule.LunchIn));
                            }
                            else if (this.serverDate.TimeOfDay >= schedule.LunchIn) 
                            {
                                time = schedule.LunchOut.Subtract(schedule.AMIn).Add(this.serverDate.TimeOfDay.Subtract(schedule.LunchIn));
                            }
                            else if (this.serverDate.TimeOfDay >= schedule.LunchOut) {
                                time = schedule.LunchOut.Subtract(schedule.AMIn);
                            }
                            else if (this.serverDate.TimeOfDay > schedule.AMIn) {
                                time = this.serverDate.TimeOfDay.Subtract(schedule.AMIn);
                            }
                        }
                        else if (schedule.ScheduleType == 2) 
                        {
                            if (this.serverDate.TimeOfDay >= schedule.CoffeeIn) {
                                time = schedule.CoffeeOut.Subtract(schedule.AMIn).Add(this.serverDate.TimeOfDay.Subtract(schedule.CoffeeIn));
                            }
                            else if (this.serverDate.TimeOfDay >= schedule.CoffeeOut) {
                                time = schedule.CoffeeOut.Subtract(schedule.AMIn);
                            }
                            else if (this.serverDate.TimeOfDay > schedule.AMIn) {
                                time = this.serverDate.TimeOfDay.Subtract(schedule.AMIn);
                            }
                        }
                        else if (schedule.ScheduleType == 3) 
                        {
                            if (this.serverDate.TimeOfDay >= schedule.LunchIn) {
                                time = schedule.LunchOut.Subtract(schedule.AMIn).Add(this.serverDate.TimeOfDay.Subtract(schedule.LunchIn));
                            }
                            else if (this.serverDate.TimeOfDay >= schedule.LunchOut) {
                                time = schedule.LunchOut.Subtract(schedule.AMIn);
                            }
                            else if (this.serverDate.TimeOfDay > schedule.AMIn) {
                                time = this.serverDate.TimeOfDay.Subtract(schedule.AMIn);
                            }
                        }
                        else if (schedule.ShiftingType == 4) 
                        {
                            time = this.serverDate.TimeOfDay.Subtract(schedule.AMIn);
                        }

                        result = time.Hours > 1 ? time.Hours + " hrs " + time.Minutes + (time.Minutes > 1 ? " mins" : " min") :
                                    time.Hours + " hr " + time.Minutes + (time.Minutes > 1 ? " mins" : " min");
                    }
                    else {
                        MessageBox.Show("No Shifting Schedule Found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("No Schedule Found.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                o = this.serverDate.ToString("MM/dd/yyyy hh:mm tt");
            }
            else if (chkAbsent.Checked) 
            {
                int count = 0;
                DateTime date = this.serverDate.AddDays(-1);
                string holidayType = string.Empty;
                while (true)
                {
                    if (!TransactionLog.IsEmployeeHaveTransactionLog(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId))
                    {
                        if (!EmployeeShifting.IsRestday(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId))
                        {
                            if (!HolidayEmployees.IsEmployeeHoliday(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId,out holidayType))
                            {
                                if (!LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, date, this.employee.PkId))
                                {
                                    count++;
                                    if (string.IsNullOrWhiteSpace(o))
                                        o = date.ToString("MM/dd/yyyy");
                                    else
                                        o += "," + date.ToString("MM/dd/yyyy");
                                }
                            }
                        }
                    }
                    else
                        break;

                    date = date.AddDays(-1);
                }

                result = count > 1 ? count + " Days" : count + " Day";
            }

            dateAbsenceLate = o;
            return result;
        }

        private void DateCreatedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateAbsenceLate.Focus();
        }

        private void DateAbsenceLateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNoDaysMins.Focus();
        }

        private void ReasonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtVerifiedBy.Focus();
        }

        private void VerifiedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRecommendedBy.Focus();
        }

        private void RecommendedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtApprovedBy.Focus();
        }

        private void ApprovedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNotedBy.Focus();
        }

        private void NotedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReleaseBy.Focus();
        }

        private void ReleaseByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rBtnCounsilingWarning.Focus();
        }

        private void CounsilingWarningKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rBtnReprimand.Focus();
        }

        private void ReprimandKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rBtnSuspensionFor.Focus();
        }

        private void SuspensionForKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSuspensionFor.Focus();
        }

        private void SuspensionTextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtScheduledOn.Focus();
        }

        private void ScheduledOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rBtnWarningForTermination.Focus();
        }

        private void WarningForTerminationKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rBtnTerminationEffectOn.Focus();
        }

        private void TerminationEffectOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTerminationEffect.Focus();
        }

        private void TerminationEffectKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRemarks.Focus();
        }

        private void RemarksKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPreparedBy2.Focus();
        }

        private void PreparedBy2KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNotedBy2.Focus();
        }

        private void NotedBy2Focus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtApprovedBy2.Focus();
        }

        private void ApprovedBy2KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtConformeBy.Focus();
        }

        private void ConformeByKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                gridDetails.Focus();
        }

        private void NoDaysMinsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReason.Focus();
        }

        private List<PRWDetails> GenerateDetails() 
        {
            DateTime date = this.serverDate;
            string month1 = string.Empty;
            string month2 = string.Empty;
            string month3 = string.Empty;
            string month4 = string.Empty;
            string month5 = string.Empty;
            string month6 = string.Empty;

            if (chkLate.Checked) {
                if (date.Month <= 3) {
                    month1 = "JAN. " + date.Year;
                    month2 = "FEB. " + date.Year;
                    month3 = "MAR. " + date.Year;
                }
                else if (date.Month > 3 && date.Month <= 6) {
                    month1 = "APR. " + date.Year;
                    month2 = "MAY. " + date.Year;
                    month3 = "JUN. " + date.Year;
                }
                else if (date.Month > 6 && date.Month <= 9) {
                    month1 = "JUL. " + date.Year;
                    month2 = "AUG. " + date.Year;
                    month3 = "SEP. " + date.Year;
                }
                else if (date.Month > 9 && date.Month <= 12) {
                    month1 = "OCT. " + date.Year;
                    month2 = "NOV. " + date.Year;
                    month3 = "DEC. " + date.Year;
                }
            }
            else if (chkAbsent.Checked) 
            {
                if (date.Month <= 6) {
                    month1 = "JAN. " + date.Year;
                    month2 = "FEB. " + date.Year;
                    month3 = "MAR. " + date.Year;
                    month4 = "APR. " + date.Year;
                    month5 = "MAY. " + date.Year;
                    month6 = "JUN. " + date.Year;
                }
                else if (date.Month > 6 && date.Month <= 12) {
                    month1 = "JUL. " + date.Year;
                    month2 = "AUG. " + date.Year;
                    month3 = "SEP. " + date.Year;
                    month4 = "OCT. " + date.Year;
                    month5 = "NOV. " + date.Year;
                    month6 = "DEC. " + date.Year;
                }
            }

            int prwId = 0;
            if (this.action == TimeKeepingCode.UserAction.Update) {
                PRW p = this.sourceHist.Current as PRW;
                prwId = p.Id;
            }

            List<PRWDetails> result = new List<PRWDetails>();
            result.Add(new PRWDetails(0, prwId, 0, "Description", month1, month2, month3, month4, month5, month6, "Total"));
            result.Add(new PRWDetails(0, prwId, 1, "Late", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new PRWDetails(0, prwId, 2, "Absent", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));

            var prw = PRW.GetAllPRW(TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId);
            for (int i = 0; i < prw.Count; i++)
            {
                if (prw[i].IsPosted) 
                {
                    if (chkLate.Checked)
                    {
                        if (prw[i].Type == 2) 
                        {
                            DateTime eDAte;
                            if (DateTime.TryParse(prw[i].AllDates, out eDAte)) 
                            {
                                if (eDAte.ToString("MMM. yyyy").Equals(month1, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    result[1].Month1 += string.IsNullOrWhiteSpace(result[1].Month1) ? eDAte.Day.ToString() : "," + eDAte.Day;
                                    result[1].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[1].Total) ? "0" : result[1].Total) + 1).ToString();
                                }
                                else if (eDAte.ToString("MMM. yyyy").Equals(month2, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    result[1].Month2 += string.IsNullOrWhiteSpace(result[1].Month2) ? eDAte.Day.ToString() : "," + eDAte.Day;
                                    result[1].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[1].Total) ? "0" : result[1].Total) + 1).ToString();
                                }
                                else if (eDAte.ToString("MMM. yyyy").Equals(month3, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    result[1].Month3 += string.IsNullOrWhiteSpace(result[1].Month3) ? eDAte.Day.ToString() : "," + eDAte.Day;
                                    result[1].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[1].Total) ? "0" : result[1].Total) + 1).ToString();
                                }
                            }
                        }
                    }
                    else if (chkAbsent.Checked) 
                    {
                        if (prw[i].Type == 1) {
                            string[] dates = prw[i].AllDates.Split(',');
                            for (int a = 0; a < dates.Length; a++)
                            {
                                DateTime eDate;
                                if (DateTime.TryParse(dates[a], out eDate))
                                {
                                    if (eDate.ToString("MMM. yyyy").Equals(month1, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month1 += string.IsNullOrWhiteSpace(result[2].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                    else if (eDate.ToString("MMM. yyyy").Equals(month2, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month2 += string.IsNullOrWhiteSpace(result[2].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                    else if (eDate.ToString("MMM. yyyy").Equals(month3, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month3 += string.IsNullOrWhiteSpace(result[2].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                    else if (eDate.ToString("MMM. yyyy").Equals(month4, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month4 += string.IsNullOrWhiteSpace(result[2].Month4) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                    else if (eDate.ToString("MMM. yyyy").Equals(month5, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month5 += string.IsNullOrWhiteSpace(result[2].Month5) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                    else if (eDate.ToString("MMM. yyyy").Equals(month6, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        result[2].Month6 += string.IsNullOrWhiteSpace(result[2].Month6) ? eDate.Day.ToString() : "," + eDate.Day;
                                        result[2].Total = (Convert.ToInt32(string.IsNullOrWhiteSpace(result[2].Total) ? "0" : result[2].Total) + 1).ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private int CalculateFrequently() 
        {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(txtDateAbsenceLate.Text)) 
            {
                string[] dates = txtDateAbsenceLate.Text.Split(',');
                for (int i = 0; i < dates.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(dates[i]))
                        result++;
                }
            }

            for (int i = 0; i < gridDetails.Rows.Count; i++)
            {
                result += string.IsNullOrWhiteSpace(gridDetails.Rows[i].Cells[7].Value.ToString()) ? 
                    0 : Convert.ToInt32(gridDetails.Rows[i].Cells[7].Value);
            }
            return result;
        }

        private void Frequently(int count) 
        {
            if (chkAbsent.Checked) 
            {
                if (count == 1)
                    rBtnReprimand.Checked = true;
                else if (count >= 2 && count <= 4)
                {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "1";
                }
                else if (count >= 5 && count <= 7)
                {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "2";
                }
                else if (count >= 8 && count <= 9)
                {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "3";
                }
                else if (count == 10)
                    rBtnWarningForTermination.Checked = true;
                else if(count == 11)
                    rBtnTerminationEffectOn.Checked = true;
            }
            else if (chkLate.Checked) {
                if (count <= 2)
                    rBtnCounsilingWarning.Checked = true;
                else if (count == 3)
                    rBtnReprimand.Checked = true;
                else if (count >= 4 && count <= 7) {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "1/2";
                }
                else if (count >= 8 && count <= 11) {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "1";
                }
                else if (count >= 12 && count <= 14) {
                    rBtnSuspensionFor.Checked = true;
                    txtSuspensionFor.Text = "1 1/2";
                }
                else if (count == 15)
                {
                    rBtnWarningForTermination.Checked = true;
                }
                else if(count == 16) {
                    rBtnTerminationEffectOn.Checked = true;
                }
            }
        }

        private PRW CreatePRW() 
        {
            int type= 0, cnt = 0, id = 0;
            DateTime start = TimeKeepingCode.Program.DefaultDate, end = TimeKeepingCode.Program.DefaultDate;

            if (this.action == TimeKeepingCode.UserAction.Update) {
                PRW p = this.sourceHist.Current as PRW;
                id = p.Id;
            }

            if(chkAbsent.Checked){
                type = 1;
                string[] dates = txtDateAbsenceLate.Text.Split(',');
                if(dates.Length > 0){
                    DateTime d;

                    if(DateTime.TryParse(dates[0],out d))
                        end = d;
                    if(DateTime.TryParse(dates[dates.Length -1],out d))
                        start = d;
                }
            }else if(chkLate.Checked){
                type = 2;
                
                DateTime d;
                if(DateTime.TryParse(txtDateAbsenceLate.Text,out d)){
                    start = d;
                    end = d;
                }
            }

            if (rBtnCounsilingWarning.Checked)
                 cnt = 1;
            else if (rBtnReprimand.Checked)
                 cnt = 2;
            else if (rBtnSuspensionFor.Checked)
                 cnt = 3;
            else if (rBtnWarningForTermination.Checked)
                 cnt = 4;
            else if (rBtnTerminationEffectOn.Checked)
                 cnt = 5;

            return new PRW(id,0,this.serverDate,type,this.employee.PkId,
                this.employee.IdNumber + " - " + this.employee.Fullname,this.employee.Section,this.employee.Position,
                txtDateAbsenceLate.Text,txtReason.Text,start,end,string.Empty,0,string.Empty,txtVerifiedBy.Text,
                txtRecommendedBy.Text,txtNotedBy.Text,txtApprovedBy.Text,txtReleaseBy.Text,cnt,txtSuspensionFor.Text,
                txtScheduledOn.Text,string.IsNullOrWhiteSpace(txtTerminationEffect.Text) ? 
                TimeKeepingCode.Program.DefaultDate : Convert.ToDateTime(txtTerminationEffect.Text),
                txtRemarks.Text,txtPreparedBy2.Text,txtNotedBy2.Text,txtApprovedBy2.Text,txtConformeBy.Text,
                false, this.serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName,
                txtNoDaysMins.Text, CalculateFrequently());
        }

        private List<PRWDetails> CreatePRWDetails() 
        {
            List<PRWDetails> result = new List<PRWDetails>();
            result.Add(new PRWDetails(Convert.ToInt32(gridDetails.Columns[8].HeaderText),Convert.ToInt32(gridDetails.Columns[9].HeaderText),
                0,gridDetails.Columns[0].HeaderText,gridDetails.Columns[1].HeaderText,gridDetails.Columns[2].HeaderText,
                gridDetails.Columns[3].HeaderText,gridDetails.Columns[4].HeaderText,gridDetails.Columns[5].HeaderText,
                gridDetails.Columns[6].HeaderText,gridDetails.Columns[7].HeaderText));

            for (int i = 0; i < gridDetails.Rows.Count; i++)
            {
                DataGridViewRow row = gridDetails.Rows[i];
                int id = row.Cells[8].Value != null ? Convert.ToInt32(row.Cells[8].Value) : 0;
                int prwId = row.Cells[9].Value != null ? Convert.ToInt32(row.Cells[9].Value) : 0;
                string desc = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                string m1 = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                string m2 = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
                string m3 = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
                string m4 = row.Cells[4].Value != null ? row.Cells[4].Value.ToString() : string.Empty;
                string m5 = row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : string.Empty;
                string m6 = row.Cells[6].Value != null ? row.Cells[6].Value.ToString() : string.Empty;
                string total = row.Cells[7].Value != null ? row.Cells[7].Value.ToString() : string.Empty;

                result.Add(new PRWDetails(id,prwId,i+1,desc,m1,m2,m3,m4,m5,m6,total));
            }

            return result;
        }

        private bool IsHaveEmptyFields() 
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text)) {
                MessageBox.Show("Reason Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtReason.Focus();
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtRecommendedBy.Text)) {
                MessageBox.Show("Recommended Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtRecommendedBy.Focus();
                return true;
            }

            return false;
        }

        public bool PostTransaction()
        {
            if (this.employee == null)
            {
                MessageBox.Show("Can't Post With No Selected Employee.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            PRW l = this.sourceHist.Current as PRW;

            if (l != null)
            {
                if (l.IsPosted)
                {
                    MessageBox.Show("Can't Post Already Posted PRW.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(l.ApprovedBy1)) {
                    MessageBox.Show("Can't Post Empty Approve.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (MessageBox.Show("Are you sure to Post this Leave/Underitime?", "Post PRW",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;

                l.LastUpdated = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
                if (PRW.PostPRW(TimeKeepingCode.Program.BiometricsConnection, l))
                {
                    LoadData(this.employee);
                    gridHistory.Focus();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                MessageBox.Show("Can't Post With Empty PRW.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        public void Print()
        {
            if (this.employee == null)
            {
                MessageBox.Show("Can't Print With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            PRW prw = this.sourceHist.Current as PRW;

            if (prw == null) {
                MessageBox.Show("Can't Print With Empty PRW.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            var details = CreatePRWDetails();
            Reports.FormPreviewReport report = new Reports.FormPreviewReport();
            report.rptViewer.LocalReport.DataSources.Clear();
            report.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportPRW.rdlc";
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("ctrlNo", prw.CntrlNo.ToString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dateFiled", prw.TransactionDate.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absent", prw.Type.Equals(1) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("late", prw.Type.Equals(2) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("name", this.employee.IdNumber + "-" + this.employee.Fullname));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("section", this.employee.Section));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("position", this.employee.Position));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dateAbsLate", prw.AllDates));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("noDaysMins", prw.NoDaysMins));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reason", prw.Reason));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth1", details[1].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth2", details[1].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth3", details[1].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth4", details[1].Month4));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth5", details[1].Month5));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateMonth6", details[1].Month6));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("lateTotal", details[1].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth1", details[2].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth2", details[2].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth3", details[2].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth4", details[2].Month4));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth5", details[2].Month5));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth6", details[2].Month6));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentTotal", details[2].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("verifiedBy", prw.VerifiedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("notedBy", prw.NotedBy1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("recommendBy", prw.RecommendedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("approvedBy", prw.ApprovedBy1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("releasedBy", prw.ReleaseBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("counselingWarning", prw.DiscActType.Equals(1) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reprimand", prw.DiscActType.Equals(2) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("suspension", prw.DiscActType.Equals(3) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("suspensionFor", prw.SuspensionFor));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("suspensionSched", prw.SuspensionSched));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("waningForTermination", prw.DiscActType.Equals(4) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("teminationEffective", prw.DiscActType.Equals(5) ? "X" : ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("remarks", prw.Remarks));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("approvedBy2", prw.ApprovedBy2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("preparedBy", prw.PreparedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("notedBy2", prw.NotedBy2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("confirmBy", prw.ConfirmBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month1", details[0].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month2", details[0].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month3", details[0].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month4", details[0].Month4));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month5", details[0].Month5));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month6", details[0].Month6));
            report.rptViewer.RefreshReport();
            report.rptViewer.Refresh();
            report.ShowDialog();
            report.Dispose();
            report = null;
        }


        public string FormText
        {
            get { return "PRW"; }
        }
    }
}
