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
    public partial class UsrCntrlChangeShiftWholeDay : UserControl, TimeKeepingCode.Code.IForms, TimeKeepingCode.Code.ICancellable
    {
        private TimeKeepingCode.UserAction action;
        private BindingSource source;
        private TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee;
        DateTime serverDate;
        private int selectedShift;

        public UsrCntrlChangeShiftWholeDay()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.selectedShift = 0;
            Task.Factory.StartNew(() => { this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate(); });

            this.employee = null;
            this.source = new BindingSource();
            this.source.CurrentChanged += SourceCurrentChange;

            gridHistory.AutoGenerateColumns = false;
            gridHistory.DataSource = this.source;
        }

        private void SourceCurrentChange(object sender,EventArgs e) 
        {
            WholeDayChangeShift changeShift = this.source.Current as WholeDayChangeShift;
            if (changeShift != null)
                LoadChangeShiftDetails(changeShift);
            else
                EmptyFields();
        }

        private void LoadChangeShiftDetails(WholeDayChangeShift changeShift) 
        {
            txtControlNo.Text = changeShift.ControlNo;
            txtDateApply.Text = changeShift.DateApply.ToString("MM/dd/yyyy");
            txtRefNo.Text = changeShift.RefNo;
            txtShift.Text = changeShift.Shift.ToString();
            txtDateEffective.Text = changeShift.DateEffective.ToString("MM/dd/yyyy");
            txtNotedBy.Text = changeShift.NotedBy;
            txtApprovedBy.Text = changeShift.ApprovedBy;
            txtReason.Text = changeShift.Remarks;
            lblLastUpdated.Text = changeShift.LastModified;

            if (changeShift.IsPosted)
                lblStatus.Text = "P O S T E D";
            else
                lblStatus.Text = "U N P O S T E D";

            var shifting = ShiftingSchedule.GetSchedule(TimeKeepingCode.Program.BiometricsConnection,changeShift.Shift);
            if(shifting != null)
                ucScheduleShift.LoadSchedule(new TimeKeepingCode.Code.Schedule(shifting));
        }

        private void EmptyFields() 
        {
            txtControlNo.Text = string.Empty;
            txtDateApply.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtShift.Text = string.Empty;
            txtDateApply.Text = string.Empty;
            txtDateEffective.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtReason.Text = string.Empty;
            lblLastUpdated.Text = string.Empty;
        }

        private static UsrCntrlChangeShiftWholeDay instance;
        public static UsrCntrlChangeShiftWholeDay Instance 
        {
            get {
                if (instance == null || instance.IsDisposed) 
                {
                    instance = new UsrCntrlChangeShiftWholeDay();
                    instance.Name = "singletonChangeShiftWholeDay";
                }
                return instance;
            }
        }

        public bool Save()
        {
            if (!IsFieldsValid())
                return false;

            bool result = false;
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Save Created Change Shift?", "Save Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;

                if (WholeDayChangeShift.CreateWholeChangeShift(TimeKeepingCode.Program.BiometricsConnection, CreateWholeChangeShift()))
                {
                    MessageBox.Show("Create Change Shift Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.action = TimeKeepingCode.UserAction.View;
                    ReadOnlyFields(true);
                    LoadData(this.employee);
                    result =  true;
                }
                else {
                    MessageBox.Show("Created Change Shift Failed to Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Save Updated Change Shift?", "Save Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;

                if (WholeDayChangeShift.UpdateChangeShift(TimeKeepingCode.Program.BiometricsConnection, CreateWholeChangeShift()))
                {
                    MessageBox.Show("Updated Change Shift Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.action = TimeKeepingCode.UserAction.View;
                    ReadOnlyFields(true);
                    LoadData(this.employee);
                    result = true;
                }
                else
                {
                    MessageBox.Show("Created Change Shift Failed to Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return result;
        }

        public bool Edit()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Update With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (this.gridHistory.SelectedRows.Count == 0) {
                MessageBox.Show("Can't Update With No Selected Change Shift.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var c = this.source.Current as WholeDayChangeShift;
            if (c == null)
            {
                MessageBox.Show("Can't Update With No Selected Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (c.IsPosted) 
            {
                MessageBox.Show("Can't Update Posted Change Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            this.selectedShift = c.Shift;
            ReadOnlyFields(false);
            txtRefNo.Focus();
            this.action = TimeKeepingCode.UserAction.Update;
            return true;
        }

        public bool Create()
        {
            if (this.employee == null) {
                MessageBox.Show("No Selected Employee","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            this.selectedShift = 0;
            ReadOnlyFields(false);
            EmptyFields();
            txtControlNo.Text = TimeKeepingDataCode.Biometrics.WholeDayChangeShift.GenerateNewControlNo(TimeKeepingCode.Program.BiometricsConnection);
            txtDateApply.Text = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy");
            txtRefNo.Focus();
            this.action = TimeKeepingCode.UserAction.Create;

            return true;
        }

        public bool Cancel()
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created Change Shift?", "Cancel Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (MessageBox.Show("Are you sure to Cancel Updated Change Shift?", "Cancel Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            ReadOnlyFields(true);
            this.action = TimeKeepingCode.UserAction.View;
            gridHistory.Focus();
            SourceCurrentChange(this, EventArgs.Empty);
            return true;
        }

        public void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            this.employee = employee;
            Task.Factory.StartNew(() =>
            {
                return WholeDayChangeShift.GetAllChangeShift(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId);
            }).ContinueWith(a => {
                this.source.DataSource = a.Result.OrderByDescending(b => b.Pk).ToList();
                this.source.ResetBindings(false);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        public TimeKeepingCode.UserAction Action
        {
            get { return this.action; }
        }

        public string FormText
        {
            get { return "Change Shift (WD)"; }
        }

        public bool PostTransaction()
        {
            var changeShift = this.source.Current as WholeDayChangeShift;
            if(changeShift == null){
                MessageBox.Show("Can't Post With No Selected Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (changeShift.IsPosted) {
                MessageBox.Show("Change Shift Already Posted.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (MessageBox.Show("Are you sure to Post Change Shift?", "Post Change Shift",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return false;

            changeShift.LastModified = TimeKeepingCode.Program.User.UserName + " - " + TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            if (!WholeDayChangeShift.PostChangeShift(TimeKeepingCode.Program.BiometricsConnection, changeShift))
            {
                MessageBox.Show("Failed to Post Change Shift.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else {
                changeShift.IsPosted = true;
                return true;
            }
        }

        private void ReadOnlyFields(bool b) 
        {
            txtRefNo.ReadOnly = b;
            txtDateEffective.ReadOnly = b;
            txtNotedBy.ReadOnly = b;
            txtApprovedBy.ReadOnly = b;
            txtReason.ReadOnly = b;

            gridHistory.Enabled = b;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
            ReadOnlyFields(true);
        }

        private void ShiftKeyDown(object sender, KeyEventArgs e)
        {
            if (this.action != TimeKeepingCode.UserAction.View) 
            {
                if (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Enter)
                {
                    Forms.FrmShiftingSchedules shifting = new Forms.FrmShiftingSchedules();
                    shifting.ShowDialog();
                    shifting.Dispose();

                    txtShift.Text = Forms.FrmShiftingSchedules.LastSelected != null ? Forms.FrmShiftingSchedules.LastSelected.ShiftingName : string.Empty;
                    this.selectedShift = Forms.FrmShiftingSchedules.LastSelected != null ? Forms.FrmShiftingSchedules.LastSelected.Id : 0;
                    if (!string.IsNullOrWhiteSpace(txtShift.Text))
                        txtDateEffective.Focus();
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.View) {
                if (e.KeyCode == Keys.Enter)
                    txtDateEffective.Focus();
            }
        }

        private void DateEffectiveValidating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDateEffective.Text)) {

                DateTime date;
                if (IsDateValid(txtDateEffective.Text, out date))
                {
                    txtDateEffective.Text = date.ToString("MM/dd/yyyy");
                    txtNotedBy.Focus();
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Invalid Date. Ex Date: (01/01/2019,0101,01/01)",
                        "Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
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

        private void ControlNoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateApply.Focus();
        }

        private void DateApplyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRefNo.Focus();
        }

        private void RefNoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtShift.Focus();
        }

        private void DateEffectiveKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNotedBy.Focus();
        }

        private void NoteByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtApprovedBy.Focus();
        }

        private void ApprovedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReason.Focus();
        }

        private void ReasonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtControlNo.Focus();
        }

        private bool IsFieldsValid() 
        {
            if (string.IsNullOrWhiteSpace(txtShift.Text)) {
                MessageBox.Show("Select Shift to Change.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtShift.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDateEffective.Text)) {
                MessageBox.Show("Provide Effectivity Date.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDateEffective.Focus();
                return false;
            }

            return true;
        }

        private WholeDayChangeShift CreateWholeChangeShift()
        {
            int changeShiftId = 0;
            string lastUpdated = string.Empty;
            if (this.action == TimeKeepingCode.UserAction.Update)
            {
                var c = this.source.Current as WholeDayChangeShift;
                if(c != null)
                    changeShiftId = c.Pk;
                lastUpdated = TimeKeepingCode.Program.User.UserName + " - " + TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            }

            return new WholeDayChangeShift(changeShiftId, txtControlNo.Text, Convert.ToDateTime(txtDateApply.Text),
                this.employee.PkId, txtRefNo.Text, this.selectedShift, Convert.ToDateTime(txtDateEffective.Text),
                txtReason.Text, txtNotedBy.Text, txtApprovedBy.Text, false, 0,lastUpdated);
        }

        private void SetControls() 
        {
            gridHistory.BackgroundColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridHistory.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridHistory.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridHistory.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
        }

        public void CancelTransaction()
        {
            var changeShift = this.source.Current as WholeDayChangeShift;
            if (changeShift != null)
            {
                if (MessageBox.Show("Are you sure to Unpost Change Shift?", "Unpost", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (WholeDayChangeShift.UnPostChangeShift(TimeKeepingCode.Program.BiometricsConnection, changeShift))
                    LoadData(this.employee);
                else
                    MessageBox.Show("Error When Unposting Change Shift.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Can't Allow Action with No Selected Change Shift.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }
    }
}
