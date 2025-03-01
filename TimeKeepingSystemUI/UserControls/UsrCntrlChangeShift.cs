using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlChangeShift : UserControl, TimeKeepingCode.Code.IForms, TimeKeepingCode.Code.ICancellable
    {
        private BindingSource sourceList;
        private TimeKeepingCode.UserAction action;
        private DateTime serverDate;

        private TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee;

        public UsrCntrlChangeShift()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridHistory.AutoGenerateColumns = false;

            this.sourceList = new BindingSource();
            gridHistory.DataSource = this.sourceList;

            this.sourceList.CurrentChanged += CurrentSelectedChanged;

            this.action = TimeKeepingCode.UserAction.View;
            this.employee = null;
        }

        private void CurrentSelectedChanged(object sender,EventArgs e) 
        {
            LoadDetails(this.sourceList.Current as ChangeShift);
        }

        private void SetControls() {
            gridHistory.BackgroundColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridHistory.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridHistory.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            lblStatus.ForeColor = Code.Program.MainColor;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            SetControls();
            ReadOnlyFields(true);
        }

        public bool Save()
        {
            if (!IsHaveEmptyField()) {
                if (this.action == TimeKeepingCode.UserAction.Update)
                {
                    if (MessageBox.Show("Are you sure to Save Updated Change Shift?", "Save Updated",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (ChangeShift.UpdateChangeShift(TimeKeepingCode.Program.BiometricsConnection, CreateChangeShift()))
                    {
                        MessageBox.Show("Updated Change Shift Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadOnlyFields(true);
                        LoadData(this.employee);
                        this.action = TimeKeepingCode.UserAction.View;
                        gridHistory.Focus();
                        return true;
                    }
                    else {
                        MessageBox.Show("Failed to Save Updated Change Shift.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return false;
                    }
                }

                if (this.action == TimeKeepingCode.UserAction.Create)
                {
                    if (MessageBox.Show("Are you sure to Save Created Change Shift?", "Save Created",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (ChangeShift.CreateChangeShift(TimeKeepingCode.Program.BiometricsConnection, CreateChangeShift()))
                    {
                        MessageBox.Show("Created Change Shift Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadOnlyFields(true);
                        LoadData(this.employee);
                        this.sourceList.MoveFirst();
                        this.action = TimeKeepingCode.UserAction.View;
                        gridHistory.Focus();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save Created Change Shift.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return false;
        }

        public bool Edit()
        {
            if (this.employee == null)
            {
                MessageBox.Show("Can't Update With No Selected Employee.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            ChangeShift c = this.sourceList.Current as ChangeShift;
            if (c == null) {
                MessageBox.Show("Can't Update With No Selected Change Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (c.IsCancelled)
            {
                MessageBox.Show("Can't Update Cancelled Change Shift.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (c.IsPosted) {
                MessageBox.Show("Can't Update Posted Change Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            ReadOnlyFields(false);
            txtDateEffect.Focus();
            this.action = TimeKeepingCode.UserAction.Update;
            return true;
        }

        public bool Create()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Create With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            EmptyFields();
            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            txtCntrlNo.Text = ChangeShift.GenerateNewControlNo(TimeKeepingCode.Program.BiometricsConnection);
            txtDateApply.Text = this.serverDate.ToString("MM/dd/yyyy");
            ReadOnlyFields(false);
            txtDateEffect.Focus();
            this.action = TimeKeepingCode.UserAction.Create;
            return true;
        }

        public bool Cancel()
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created Change Shift?", "Cancel ChangeShift", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return false;
            }
            if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Cancel Updated Change Shift?", 
                    "Cancel Updated", MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }

            LoadDetails(this.sourceList.Current as ChangeShift);
            ReadOnlyFields(true);
            gridHistory.Focus();
            this.action = TimeKeepingCode.UserAction.View;
            return true;
        }

        public void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            this.employee = employee;
            Task.Factory.StartNew(() =>
            {
                return ChangeShift.GetAllChangeShift(TimeKeepingCode.Program.BiometricsConnection, employee.PkId);
            }).ContinueWith(a => {
                this.sourceList.DataSource = a.Result.OrderByDescending(c => c.Id);
                this.sourceList.ResetBindings(false);
                gridHistory.Focus();
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        public TimeKeepingCode.UserAction Action
        {
            get { return this.action; }
        }

        public string FormText
        {
            get { return "Change Shift"; }
        }

        public bool PostTransaction()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Post With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            ChangeShift c = this.sourceList.Current as ChangeShift;

            if (c == null)
            {
                MessageBox.Show("Can't Post With No Selected Change Shift.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else {
                if (c.IsCancelled) {
                    MessageBox.Show("Change Shift Already Posted.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (c.IsPosted)
                {
                    MessageBox.Show("Change Shift Already Posted.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }
            }

            if (MessageBox.Show("Are you sure to POST this Change Shift?", "Post Change Shift", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;

            c.LastModified = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
            if (ChangeShift.PostChangeShift(TimeKeepingCode.Program.BiometricsConnection, c))
            {
                LoadData(this.employee);
                gridHistory.Focus();
                return true;
            }
            else
                return false;
        }

        private void ReadOnlyFields(bool b) {

            txtDateEffect.ReadOnly = b;
            txtRefNo.ReadOnly = b;
            txtTimeFrom.ReadOnly = b;
            txtTimeTo.ReadOnly = b;
            txtNotedBy.ReadOnly = b;
            txtApprovedBy.ReadOnly = b;
            txtRemarks.ReadOnly = b;

            gridHistory.Enabled = b;

            if (b)
            {
                txtDateEffect.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtRefNo.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtTimeFrom.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtTimeTo.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtNotedBy.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtApprovedBy.BackColor = Color.FromKnownColor(KnownColor.Control);
                txtRemarks.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else {
                txtDateEffect.BackColor = Color.White;
                txtRefNo.BackColor = Color.White;
                txtTimeFrom.BackColor = Color.White;
                txtTimeTo.BackColor = Color.White;
                txtNotedBy.BackColor = Color.White;
                txtApprovedBy.BackColor = Color.White;
                txtRemarks.BackColor = Color.White;
            }
        }

        private void EmptyFields() {
            txtCntrlNo.Text = string.Empty;
            txtDateApply.Text = string.Empty;
            txtDateEffect.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtTimeFrom.Text = string.Empty;
            txtTimeTo.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            lblStatus.Text = string.Empty;
            lblLastUpdated.Text = string.Empty;
        }

        private void LoadDetails(ChangeShift changeShift) {
            if (changeShift != null)
            {
                txtCntrlNo.Text = changeShift.CntrlNo;
                txtDateApply.Text = changeShift.DateApply.ToString("MM/dd/yyyy");
                txtDateEffect.Text = changeShift.DateEffect.ToString("MM/dd/yyyy");
                txtRefNo.Text = changeShift.RefNo;
                txtTimeFrom.Text = DateTime.Today.Add(changeShift.TimeFrom).ToString("hh:mm tt");
                txtTimeTo.Text = DateTime.Today.Add(changeShift.TimeTo).ToString("hh:mm tt");
                txtNotedBy.Text = changeShift.NotedBy;
                txtApprovedBy.Text = changeShift.ApprovedBy;
                txtRemarks.Text = changeShift.Remarks;

                if(changeShift.IsCancelled)
                    lblStatus.Text = "C A N C E L L E D";
                else if (changeShift.IsPosted)
                    lblStatus.Text = "P O S T E D";
                else
                    lblStatus.Text = "U N P O S T E D";

                lblLastUpdated.Text = "Last Updated: " + changeShift.LastModified;
            }
            else
                EmptyFields();
        }

        private bool IsDateValid(string date, out DateTime dateResult)
        {
            DateTime o = new DateTime(1901, 1, 1);
            if (date.Length == 10)
                return DateTime.TryParse(date, out dateResult);

            if (date.Length == 6)
            {
                if (date.Substring(date.Length - 1, 1) != "/")
                {
                    dateResult = o;
                    return false;
                }
                else
                {
                    return DateTime.TryParse(date + this.serverDate.Year, out dateResult);
                }
            }
            if (date.Length == 5)
                return DateTime.TryParse(date + "/" + this.serverDate.Year, out dateResult);

            if (date.Length == 4)
                return DateTime.TryParse(date.Substring(0, 2) + "/" + date.Substring(2, 2) + "/" + this.serverDate.Year, out dateResult);

            dateResult = o;
            return false;
        }

        private bool IsTimeValid(string time, out DateTime dateResult)
        {
            DateTime o = new DateTime(1901, 1, 1);

            if (time.Length == 8)
                return DateTime.TryParse(time, out dateResult);

            if (time.Length == 5)
            {
                if (time.Substring(2, 1) != ":")
                {
                    dateResult = o;
                    return false;
                }
                else
                {
                    return DateTime.TryParse(time, out dateResult);
                }
            }

            if (time.Length == 4)
            {
                return DateTime.TryParse(time.Substring(0, 2) + ":" + time.Substring(2, 2), out dateResult);
            }

            dateResult = o;
            return false;
        }

        private void ControlNoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateApply.Focus();
        }

        private void DateApplyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateEffect.Focus();
        }

        private void DateEffectKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRefNo.Focus();
        }

        private void RefNoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTimeFrom.Focus();
        }

        private void TimeFromKeyDowm(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTimeTo.Focus();
        }

        private void TimeToKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNotedBy.Focus();
        }

        private void NotedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtApprovedBy.Focus();
        }

        private void ApprovedBykeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRemarks.Focus();
        }

        private void RemarksKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCntrlNo.Focus();
        }

        private void DateEffectValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update || 
                this.action == TimeKeepingCode.UserAction.Create) {

                    if (!string.IsNullOrWhiteSpace(txtDateEffect.Text)) {
                        DateTime date;

                        if (IsDateValid(txtDateEffect.Text, out date))
                        {
                            txtDateEffect.Text = date.ToString("MM/dd/yyyy");
                        }
                        else {
                            MessageBox.Show("Invalid Date Format. Ex (0101,01/01,01/01/,01/01/2019)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
            }
        }

        private void TimeFromValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || 
                this.action == TimeKeepingCode.UserAction.Update) {

                    if (!string.IsNullOrWhiteSpace(txtTimeFrom.Text)) {
                        DateTime date;

                        if (IsTimeValid(txtTimeFrom.Text, out date))
                        {
                            date = Convert.ToDateTime(txtDateEffect.Text).Add(date.TimeOfDay);
                            if (IsTimeFromValid(date))
                            {
                                txtTimeFrom.Text = date.ToString("hh:mm tt");
                            }
                            else
                            {
                                MessageBox.Show("Time is not Valid. No Scheduled " + date.ToString("hh:mm tt"),
                                    "Invalid Time",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                                e.Cancel = true;
                            }
                        }
                        else {
                            MessageBox.Show("Invalid Time Format. Ex (20:00,0800)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
            }
        }

        private bool IsTimeFromValid(DateTime timeFrom) 
        {
            EmployeeShifting current = EmployeeShifting.GetCurrentEmployeeShifting
                                (TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId,timeFrom);

            if (current == null) {
                MessageBox.Show("No Current Schedule Found.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            ShiftingSchedule schedule = null;

            switch (timeFrom.DayOfWeek) { 
                case DayOfWeek.Monday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Monday);
                    break;
                case DayOfWeek.Tuesday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Tuesday);
                    break;
                case DayOfWeek.Wednesday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Wednesday);
                    break;
                case DayOfWeek.Thursday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Thursday);
                    break;
                case DayOfWeek.Friday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Friday);
                    break;
                case DayOfWeek.Saturday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Saturday);
                    break;
                case DayOfWeek.Sunday:
                    schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == current.Sunday);
                    break;
            }

            if (schedule == null) {
                return false;
            }

            return schedule.AMIn.Equals(timeFrom.TimeOfDay) || schedule.LunchOut.Equals(timeFrom.TimeOfDay) ||
                schedule.LunchIn.Equals(timeFrom.TimeOfDay) || schedule.CoffeeOut.Equals(timeFrom.TimeOfDay) ||
                schedule.CoffeeIn.Equals(timeFrom.TimeOfDay) || schedule.PmOut.Equals(timeFrom.TimeOfDay);
        }

        private void TimeToValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update || 
                this.action == TimeKeepingCode.UserAction.Create) {

                    if (!string.IsNullOrWhiteSpace(txtTimeTo.Text)) {
                        DateTime date;

                        if (IsTimeValid(txtTimeTo.Text, out date))
                        {
                            txtTimeTo.Text = date.ToString("hh:mm tt");
                        }
                        else
                        {
                            MessageBox.Show("Invalid Time Format. Ex (20:00,0800)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
            }
        }

        private ChangeShift CreateChangeShift() {

            int changeShiftId = 0;
            if (this.action == TimeKeepingCode.UserAction.Update) {
                ChangeShift c = this.sourceList.Current as ChangeShift;
                changeShiftId = c.Id;
            }

            return new ChangeShift(changeShiftId, txtCntrlNo.Text, Convert.ToDateTime(txtDateApply.Text), this.employee.PkId,
                txtRefNo.Text, Convert.ToDateTime(txtDateEffect.Text), Convert.ToDateTime(txtTimeFrom.Text).TimeOfDay,
                Convert.ToDateTime(txtTimeTo.Text).TimeOfDay, txtRemarks.Text, txtNotedBy.Text, txtApprovedBy.Text,
                false,false, this.serverDate.ToString("MM/dd/yyyy hh:mm tt") + " " + TimeKeepingCode.Program.User.UserName);
        }

        private bool IsHaveEmptyField() 
        {
            if (string.IsNullOrWhiteSpace(txtDateEffect.Text)) {
                MessageBox.Show("Date Effect Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtDateEffect.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtTimeFrom.Text)) {
                MessageBox.Show("Time From Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtTimeFrom.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtTimeTo.Text)) {
                MessageBox.Show("Time To Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtTimeTo.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtApprovedBy.Text)) {
                MessageBox.Show("Approved Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtApprovedBy.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtRemarks.Text)) {
                MessageBox.Show("Remarks Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtRemarks.Focus();
                return true;
            }

            return false;
        }

        private void TimeFromEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDateEffect.Text))
                txtDateEffect.Focus();
        }

        private void TimeToEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimeFrom.Text))
                txtTimeFrom.Focus();
        }

        public void CancelTransaction()
        {
            var changeShift = this.sourceList.Current as ChangeShift;
            if(changeShift == null){
                MessageBox.Show("Can't cancel with no Selected Change Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (changeShift.IsCancelled) {
                MessageBox.Show("Change Shift Already Cancelled.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure to Discard Posted Change Shift?", "Discard", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            changeShift.LastModified = TimeKeepingCode.Program.User.UserName + " - " + TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            if (ChangeShift.CancelChangeShift(TimeKeepingCode.Program.BiometricsConnection, changeShift))
                MessageBox.Show("Change Shift Successfuly Discarded.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Change Shift Failed to Discard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
