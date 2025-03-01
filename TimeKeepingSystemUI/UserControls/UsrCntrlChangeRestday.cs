using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingCode;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlChangeRestday : UserControl, TimeKeepingCode.Code.IForms, TimeKeepingCode.Code.ICancellable, TimeKeepingCode.Code.IPrint
    {
        private BindingSource sourceHist;
        private TimeKeepingCode.UserAction action;

        private DateTime serverDate;
        private BasicEmployeeInfo employee;

        public UsrCntrlChangeRestday()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            gridHistory.AutoGenerateColumns = false;
            gridSearhExchange.AutoGenerateColumns = false;
            SetControls();

            this.sourceHist = new BindingSource();
            gridHistory.DataSource = this.sourceHist;

            this.sourceHist.CurrentChanged += SelectedCurrentChanged;

            this.action = TimeKeepingCode.UserAction.View;
            ReadOnlyFields(true);

            this.employee = null;
            this.action = TimeKeepingCode.UserAction.View;
        }

        private void SelectedCurrentChanged(object sender,EventArgs e) 
        {
            LoadChangeRestday(this.sourceHist.Current as TimeKeepingDataCode.Biometrics.ChangeRestday);
        }

        public bool Save()
        {
            bool result = false;
            if (this.action == UserAction.Create) 
            {
                if (!IsHaveEmptyFields()) 
                {
                    if (MessageBox.Show("Are you sure to Save Created Change Restday?", "Save Created", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (ChangeRestday.CreateChangeRestday(TimeKeepingCode.Program.BiometricsConnection,
                        CreateChangeRD(), CreateChangeRDDetails()))
                    {
                        MessageBox.Show("Created Change Restday Successfuly Saved.", "Succes",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadOnlyFields(true);
                        LoadData(this.employee);
                        this.sourceHist.MoveFirst();
                        result = true;
                        this.action = UserAction.View;
                    }
                    else {
                        MessageBox.Show("Created Change Restday Failed to Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        result = false;
                    }
                }
            }
            else if (this.action == UserAction.Update) 
            {
                if (!IsHaveEmptyFields()) 
                {
                    if (MessageBox.Show("Are you sure to Save Updated Change Restday?", "Save Updated",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (ChangeRestday.UpdateChangeRestday(TimeKeepingCode.Program.BiometricsConnection,
                        CreateChangeRD(), CreateChangeRDDetails()))
                    {
                        MessageBox.Show("Updated Change Restday Successfuly Saved.", "Succes",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReadOnlyFields(true);
                        LoadData(this.employee);
                        result = true;
                        this.action = UserAction.View;
                    }
                    else {
                        MessageBox.Show("Updated Change Restday Failed to Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            ClearFields();
            ReadOnlyFields(false);
            txtDateCreated.Text = serverDate.ToString("MM/dd/yyyy");
            txtDateFrom.Focus();
            this.action = UserAction.Create;
            return true;
        }

        public bool Edit()
        {
            if (gridHistory.SelectedRows.Count == 0) {
                MessageBox.Show("Can't Update Empty Record.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            ChangeRestday changeRD = this.sourceHist.Current as ChangeRestday;
            if (changeRD != null)
            {
                if (changeRD.IsPosted || changeRD.IsCancelled)
                {
                    MessageBox.Show("Can't Update Already Posted or Cancelled Change Restday.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else {
                MessageBox.Show("Can't Update Empty Record.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            ReadOnlyFields(false);
            txtApprovedBy.Focus();
            this.action = UserAction.Update;
            return true;
        }

        public bool Cancel()
        {
            if (this.action == UserAction.Create) 
            {
                if (MessageBox.Show("Are you sure to Cancel Created Change Restday?", 
                    "Cancel Created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            else if (this.action == UserAction.Update) 
            {
                if (MessageBox.Show("Are you sure to Cancel Updated Change Restday?", "Cancel Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            ReadOnlyFields(true);
            LoadChangeRestday(this.sourceHist.Current as TimeKeepingDataCode.Biometrics.ChangeRestday);
            gridHistory.Focus();
            this.action = UserAction.View;
            return true;
        }

        public TimeKeepingCode.UserAction Action { get { return this.action; } }

        public void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            this.employee = employee;
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.ChangeRestday.GetAllChangeRestdays
                    (TimeKeepingCode.Program.BiometricsConnection, employee.PkId);
            }).ContinueWith(a => 
            {
                this.sourceHist.DataSource = a.Result.OrderByDescending(e => e.TrasactionDate);
                this.sourceHist.ResetBindings(false);
                gridDetails.Focus();
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadChangeRestday(TimeKeepingDataCode.Biometrics.ChangeRestday changerestday) 
        {
            if (changerestday != null)
            {
                LoadDetails(changerestday);
                LoadGridDetails(changerestday);
            }
            else
                Empty();
        }

        private void LoadDetails(TimeKeepingDataCode.Biometrics.ChangeRestday changeRestday) 
        {
            txtDateCreated.Text = changeRestday.TrasactionDate.ToString("MM/dd/yyyy");
            txtDayFrom.Text = changeRestday.ReqDayFrom;
            txtDayTo.Text = changeRestday.ReqDayTo;
            txtDateFrom.Text = changeRestday.ReqDateFrom.ToString("MM/dd/yyyy");
            txtDateTo.Text = changeRestday.ReqDateTo.ToString("MM/dd/yyyy");
            txtReason.Text = changeRestday.Reason;
            txtCoordinated.Text = changeRestday.Coordinated;
            txtRecommendedApproval.Text = changeRestday.RecommendedApprovedBy;
            txtNotedBy.Text = changeRestday.NotedBy;
            txtApprovedBy.Text = changeRestday.ApprovedBy;

            txtName.Text = changeRestday.ExWithName;
            txtExchangeDayFrom.Text = changeRestday.ExDayFrom;
            txtExchangeDayTo.Text = changeRestday.ExDayTo;
            txtExchangeDateFrom.Text = changeRestday.ExDateFrom.Equals(TimeKeepingCode.Program.DefaultDate) ? "" : changeRestday.ExDateFrom.ToString("MM/dd/yyyy");
            txtExchangeDateTo.Text = changeRestday.ExDateTo.Equals(TimeKeepingCode.Program.DefaultDate) ? "" : changeRestday.ExDateTo.ToString("MM/dd/yyyy");

            if (changeRestday.IsCancelled)
                lblStatus.Text = "C A N C E L L E D";
            else if (changeRestday.IsPosted)
                lblStatus.Text = "P O S T E D";
            else
                lblStatus.Text = "U N P O S T E D";

            lblLastUpdated.Text = "Last Updated: " + changeRestday.LastUpdatedBy;
        }

        private void LoadGridDetails(TimeKeepingDataCode.Biometrics.ChangeRestday changeRestday) 
        {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.ChangeRestdayDetails.
                    GetAllChangeRestdays(TimeKeepingCode.Program.BiometricsConnection, changeRestday.CdId);
            }).ContinueWith(a => 
            {
                var result = a.Result.OrderBy(c => c.Line).ToList();
                LoadDataGridDetails(result);
                
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadDataGridDetails(List<ChangeRestdayDetails> details) 
        {
            gridDetails.Rows.Clear();
            if (details.Count > 0)
            {
                gridDetails.Columns[2].HeaderText = details[0].Month1;
                gridDetails.Columns[3].HeaderText = details[0].Month2;
                gridDetails.Columns[4].HeaderText = details[0].Month3;
                gridDetails.Columns[5].HeaderText = details[0].Id.ToString();
                gridDetails.Columns[6].HeaderText = details[0].CId.ToString();

                for (int i = 1; i < details.Count; i++)
                {
                    gridDetails.Rows.Add(details[i].Description, details[i].Total,
                        details[i].Month1, details[i].Month2, details[i].Month3,details[i].Id,details[i].CId);
                }
            }
        }

        private void Empty() 
        {
            txtDateCreated.Text = string.Empty;
            txtDayFrom.Text = string.Empty;
            txtDayTo.Text = string.Empty;
            txtDateFrom.Text = string.Empty;
            txtDateTo.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtCoordinated.Text = string.Empty;
            txtRecommendedApproval.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;

            txtName.Text = string.Empty;
            txtExchangeDayFrom.Text = string.Empty;
            txtExchangeDayTo.Text = string.Empty;
            txtExchangeDateFrom.Text = string.Empty;
            txtExchangeDateTo.Text = string.Empty;

            gridDetails.Rows.Clear();
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

            gridSearhExchange.BackgroundColor = Code.Program.MainColor;
            gridSearhExchange.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridSearhExchange.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridSearhExchange.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridSearhExchange.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            pnlCancelHeader.BackColor = Code.Program.MainColor;
            lblCancelHeader.ForeColor = Code.Program.TextColor;
            btnCancelCancel.BackColor = Code.Program.MainColor;
            btnCancelCancel.ForeColor = Code.Program.TextColor;
            btnCancelSave.BackColor = Code.Program.MainColor;
            btnCancelSave.ForeColor = Code.Program.TextColor;

            lblStatus.ForeColor = Code.Program.MainColor;
        }

        private void ReadOnlyFields(bool b) 
        {
            txtDateFrom.ReadOnly = b;
            txtDateTo.ReadOnly = b;
            txtReason.ReadOnly = b;
            txtCoordinated.ReadOnly = b;
            txtRecommendedApproval.ReadOnly = b;
            txtNotedBy.ReadOnly = b;
            txtApprovedBy.ReadOnly = b;
            txtName.ReadOnly = b;
            txtExchangeDateFrom.ReadOnly = b;

            gridHistory.Enabled = b;
        }

        private void DateCreatedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDayFrom.Focus();
        }

        private void DayFrom(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDayTo.Focus();
        }

        private void DayToKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateFrom.Focus();
        }

        private void DateFromKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateTo.Focus();
        }

        private void DateToKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReason.Focus();
        }

        private void ReasonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCoordinated.Focus();
        }

        private void CoordinatedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRecommendedApproval.Focus();
        }

        private void RecommendedApprovalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNotedBy.Focus();
        }

        private void NotedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtApprovedBy.Focus();
        }

        private void ApprovedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridDetails.Focus();
        }

        private void NamKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectExchange();
            else if (e.KeyCode == Keys.Down)
                gridSearhExchange.Focus();
            else if (e.KeyCode == Keys.Escape) {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                    ClearExchnageWith();
                else
                    txtDateTo.Focus();
            }
        }

        private void ExchangeDayFrom(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExchangeDayTo.Focus();
        }

        private void ExchangeDateFrom(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExchangeDateTo.Focus();
        }

        private void ExchangeDateTo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtReason.Focus();
        }

        private void ExchangeDayTo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExchangeDateFrom.Focus();
        }

        private void DateFromValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.action == UserAction.Create || this.action == UserAction.Update) 
            {
                if (!string.IsNullOrWhiteSpace(txtDateFrom.Text)) 
                {
                    DateTime date;
                    if (IsDateValid(txtDateFrom.Text, out date))
                    {
                        DayOfWeek d;
                        if (!IsDateEqualToDatOfWeek(date, this.employee, out d))
                        {
                            MessageBox.Show("Date is not " + d.ToString(),
                                "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            e.Cancel = true;
                        }
                        else
                        {
                            txtDateFrom.Text = date.ToString("MM/dd/yyyy");
                            txtDayFrom.Text = d.ToString();
                            LoadDataGridDetails(GenerateChangeRDDetails());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Date Format. Ex (0101,01/01,01/01/,01/01/2019)", "Invalid Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                    }
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

        private void ClearFields() 
        {
            txtDateFrom.Text = string.Empty;
            txtDateTo.Text = string.Empty;
            txtDayFrom.Text = string.Empty;
            txtDayTo.Text = string.Empty;
            txtReason.Text = string.Empty;
            txtCoordinated.Text = string.Empty;
            txtRecommendedApproval.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtName.Text = string.Empty;
            txtExchangeDayFrom.Text = string.Empty;
            txtExchangeDayTo.Text = string.Empty;
            txtExchangeDateFrom.Text = string.Empty;
            txtExchangeDateTo.Text = string.Empty;
            gridDetails.Rows.Clear();
        }

        private void DateToValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDateTo.Text)) 
            {
                DateTime date;
                if (IsDateValid(txtDateTo.Text, out date))
                {
                    if (gridSearhExchange.SelectedRows.Count > 0)
                    {
                        if (!txtDateTo.Text.Equals(txtExchangeDayFrom.Text))
                        {
                            MessageBox.Show("Date not Equal to Exchange With.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            e.Cancel = true;
                        }
                    }
                    else {
                        txtDayTo.Text = date.DayOfWeek.ToString();
                        txtDateTo.Text = date.ToString("MM/dd/yyyy");
                    }
                }
                else {
                    MessageBox.Show("Invalid Date Format. Ex (0101,01/01,01/01/,01/01/2019)", "Invalid Format",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void ExchangeNameEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDateFrom.Text))
                txtDateFrom.Focus();
            else
                gridSearhExchange.Visible = true;
        }

        private void ExchangeNameLeave(object sender, EventArgs e)
        {
            if (!gridSearhExchange.Focused)
                gridSearhExchange.Visible = false;
        }

        private void GridExchangeLeave(object sender, EventArgs e)
        {
            if (!txtName.Focused)
                gridSearhExchange.Visible = false;
        }

        private void ExchangeNameChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                ClearExchnageWith();
            else
            {
                gridSearhExchange.DataSource = null;
                gridSearhExchange.DataSource = TimeKeepingCode.Program.ActiveEmployees.FindAll
                    (a => a.Fullname.ToLower().Contains(txtName.Text.ToLower()));
            }
        }

        private void GridExchangeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gridSearhExchange.SelectedRows[0].Index == 0)
                    txtName.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SelectExchange();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
                txtName.Focus();
        }

        private void SelectExchange() 
        {
            if (gridSearhExchange.SelectedRows.Count > 0)
            {
                BasicEmployeeInfo employee = gridSearhExchange.SelectedRows[0].DataBoundItem as BasicEmployeeInfo;
                txtName.Text = employee.Fullname;
                gridSearhExchange.Visible = false;
                txtExchangeDateFrom.Focus();
            }
        }

        private void ClearExchnageWith() 
        {
            txtExchangeDateFrom.Text = string.Empty;
            txtExchangeDateTo.Text = string.Empty;
            txtExchangeDayFrom.Text = string.Empty;
            txtExchangeDayTo.Text = string.Empty;
            txtName.Text = string.Empty;
            gridSearhExchange.DataSource = null;
        }

        private void DateToEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDateFrom.Text))
                txtDateFrom.Focus();
        }

        private void DateFromTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDateFrom.Text))
            {
                txtDayFrom.Text = string.Empty;
                txtExchangeDayTo.Text = string.Empty;
                txtExchangeDateTo.Text = string.Empty;
            }
        }

        private void ExchangeDateFrom(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                txtName.Focus();
        }

        private void DateToTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDateTo.Text))
            {
                txtDayTo.Text = string.Empty;
                ClearExchnageWith();
            }
        }

        private bool IsDateEqualToDatOfWeek(DateTime date,BasicEmployeeInfo employee,out DayOfWeek day) 
        {
            bool result = false;
            DayOfWeek d = DayOfWeek.Sunday;

            var current = EmployeeShifting.GetCurrentEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection,employee.PkId);

            if (current != null)
            {
                switch (current.Restday)
                {
                    case 1:
                        d = DayOfWeek.Monday;
                        break;
                    case 2:
                        d = DayOfWeek.Tuesday;
                        break;
                    case 3:
                        d = DayOfWeek.Wednesday;
                        break;
                    case 4:
                        d = DayOfWeek.Thursday;
                        break;
                    case 5:
                        d = DayOfWeek.Friday;
                        break;
                    case 6:
                        d = DayOfWeek.Saturday;
                        break;
                    case 7:
                        d = DayOfWeek.Sunday;
                        break;
                }

                result = d.Equals(date.DayOfWeek);
            }
            else
                MessageBox.Show("No current schedule foud.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);

            day = d;
            return result;
        }

        private void ExchangeDateFrom(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.action == UserAction.Create || this.action == UserAction.Update) 
            {
                if (!string.IsNullOrWhiteSpace(txtExchangeDateFrom.Text)) 
                {
                    if (gridSearhExchange.SelectedRows.Count > 0)
                    {
                        BasicEmployeeInfo emp = gridSearhExchange.SelectedRows[0].DataBoundItem as BasicEmployeeInfo;
                        DateTime date;
                        if (IsDateValid(txtExchangeDateFrom.Text.Trim(), out date))
                        {
                            DayOfWeek d;

                            if (!IsDateEqualToDatOfWeek(date, emp, out d))
                            {
                                MessageBox.Show("Date is not " + d.ToString(),
                                        "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                e.Cancel = true;
                            }
                            else {
                                txtExchangeDateFrom.Text = date.ToString("MM/dd/yyyy");
                                txtExchangeDayFrom.Text = d.ToString();
                                txtExchangeDateTo.Text = txtDateFrom.Text;
                                txtExchangeDayTo.Text = txtDayFrom.Text;
                                txtDateTo.Text = date.ToString("MM/dd/yyyy");
                                txtDayTo.Text = d.ToString();
                            }
                        }
                        else {
                            MessageBox.Show("Invalid Date Format. Ex (0101,01/01,01/01/,01/01/2019)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
                    else {
                        MessageBox.Show("No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        e.Cancel = true;
                    }
                }
            }
        }

        private List<ChangeRestdayDetails> GenerateChangeRDDetails() 
        {
            int changeRDId = 0;
            if (this.action == UserAction.Update) {
                ChangeRestday c = this.sourceHist.Current as ChangeRestday;
                if (c != null)
                    changeRDId = c.CdId;
            }

            DateTime date = Convert.ToDateTime(txtDateFrom.Text);
            List<ChangeRestdayDetails> result = new List<ChangeRestdayDetails>();

            result.Add(new ChangeRestdayDetails(0,0,0,"Description","Total",date.AddMonths(-2).ToString("MMM. yyyy"),
                date.AddMonths(-1).ToString("MMM. yyyy"),date.ToString("MMM. yyyy")));
            result.Add(new ChangeRestdayDetails(0, changeRDId, 1, "Leave", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new ChangeRestdayDetails(0, changeRDId, 2, "Ansences", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new ChangeRestdayDetails(0, changeRDId, 3, "Change RD", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new ChangeRestdayDetails(0, changeRDId, 4, "Undertime", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new ChangeRestdayDetails(0, changeRDId, 5, "Tardiness", string.Empty, string.Empty, string.Empty, string.Empty));

            var leaveUndertime = LeaveUndertime.GetAllLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId);
            for (int i = 0; i < leaveUndertime.Count; i++)
            {
                if (leaveUndertime[i].IsPosted && !leaveUndertime[i].IsCancelled)
                {
                    //leave
                    if (leaveUndertime[i].Type == 1)
                    {
                        string[] dates = leaveUndertime[i].EffectDates.Split(',');
                        for (int a = 0; a < dates.Length; a++)
                        {
                            if (!string.IsNullOrWhiteSpace(dates[a]))
                            {
                                DateTime eDate = Convert.ToDateTime(dates[a]);
                                if (date.AddMonths(-2).Month == eDate.Month && date.AddMonths(-2).Year == eDate.Year)
                                {
                                    result[1].Month1 += string.IsNullOrWhiteSpace(result[1].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[1].Total = string.IsNullOrWhiteSpace(result[1].Total) ? "1" : (Convert.ToInt32(result[1].Total) + 1).ToString();
                                }
                                else if (date.AddMonths(-1).Month == eDate.Month && date.AddMonths(-1).Year == eDate.Year)
                                {
                                    result[1].Month2 += string.IsNullOrWhiteSpace(result[1].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[1].Total = string.IsNullOrWhiteSpace(result[1].Total) ? "1" : (Convert.ToInt32(result[1].Total) + 1).ToString();
                                }
                                else if (date.Month == eDate.Month && date.Year == eDate.Year)
                                {
                                    result[1].Month3 += string.IsNullOrWhiteSpace(result[1].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[1].Total = string.IsNullOrWhiteSpace(result[1].Total) ? "1" : (Convert.ToInt32(result[1].Total) + 1).ToString();
                                }
                            }
                        }
                    }
                    //undertime
                    else if (leaveUndertime[i].Type == 2)
                    {
                        DateTime eDate = leaveUndertime[i].EffectiveDate;

                        if (date.AddMonths(-2).Month == eDate.Month && date.AddMonths(-2).Year == eDate.Year)
                        {
                            result[4].Month1 += string.IsNullOrWhiteSpace(result[4].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[4].Total = string.IsNullOrWhiteSpace(result[4].Total) ? "1" : (Convert.ToInt32(result[4].Total) + 1).ToString();
                        }
                        else if (date.AddMonths(-1).Month == eDate.Month && date.AddMonths(-1).Year == eDate.Year)
                        {
                            result[4].Month2 += string.IsNullOrWhiteSpace(result[4].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[4].Total = string.IsNullOrWhiteSpace(result[4].Total) ? "1" : (Convert.ToInt32(result[4].Total) + 1).ToString();
                        }
                        else if (date.Month == eDate.Month && date.Year == eDate.Year)
                        {
                            result[4].Month3 += string.IsNullOrWhiteSpace(result[4].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[4].Total = string.IsNullOrWhiteSpace(result[4].Total) ? "1" : (Convert.ToInt32(result[4].Total) + 1).ToString();
                        }
                    }
                }
            }

            var prw = PRW.GetAllPRW(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId);
            for (int i = 0; i < prw.Count; i++)
            {
                if (prw[i].IsPosted)
                {
                    //absent
                    if (prw[i].Type == 1)
                    {
                        string[] dates = prw[i].AllDates.Split(',');
                        for (int a = 0; a < dates.Length; a++)
                        {
                            if (!string.IsNullOrWhiteSpace(dates[a]))
                            {
                                DateTime eDate = Convert.ToDateTime(dates[a]);

                                if (date.AddMonths(-2).Month == eDate.Month && date.AddMonths(-2).Year == eDate.Year)
                                {
                                    result[2].Month1 += string.IsNullOrWhiteSpace(result[2].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[2].Total = string.IsNullOrWhiteSpace(result[2].Total) ? "1" : (Convert.ToInt32(result[2].Total) + 1).ToString();
                                }
                                else if (date.AddMonths(-1).Month == eDate.Month && date.AddMonths(-1).Year == eDate.Year)
                                {
                                    result[2].Month2 += string.IsNullOrWhiteSpace(result[2].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[2].Total = string.IsNullOrWhiteSpace(result[2].Total) ? "1" : (Convert.ToInt32(result[2].Total) + 1).ToString();
                                }
                                else if (date.Month == eDate.Month && date.Year == eDate.Year)
                                {
                                    result[2].Month3 += string.IsNullOrWhiteSpace(result[2].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                                    result[2].Total = string.IsNullOrWhiteSpace(result[2].Total) ? "1" : (Convert.ToInt32(result[2].Total) + 1).ToString();
                                }
                            }
                        }
                    }
                    //late
                    else if (prw[i].Type == 2)
                    {
                        DateTime eDate = Convert.ToDateTime(prw[i].AllDates);
                        if (date.AddMonths(-2).Month == eDate.Month && date.AddMonths(-2).Year == eDate.Year)
                        {
                            result[5].Month1 += string.IsNullOrWhiteSpace(result[5].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[5].Total = string.IsNullOrWhiteSpace(result[5].Total) ? "1" : (Convert.ToInt32(result[5].Total) + 1).ToString();
                        }
                        else if (date.AddMonths(-1).Month == eDate.Month && date.AddMonths(-1).Year == eDate.Year)
                        {
                            result[5].Month2 += string.IsNullOrWhiteSpace(result[5].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[5].Total = string.IsNullOrWhiteSpace(result[5].Total) ? "1" : (Convert.ToInt32(result[5].Total) + 1).ToString();
                        }
                        else if (date.Month == eDate.Month && date.Year == eDate.Year)
                        {
                            result[5].Month3 += string.IsNullOrWhiteSpace(result[5].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                            result[5].Total = string.IsNullOrWhiteSpace(result[5].Total) ? "1" : (Convert.ToInt32(result[5].Total) + 1).ToString();
                        }
                    }
                }
            }

            var changeRD = ChangeRestday.GetAllChangeRestdays(TimeKeepingCode.Program.BiometricsConnection, this.employee.PkId);
            for (int i = 0; i < changeRD.Count; i++)
            {
                if (changeRD[i].IsPosted && !changeRD[i].IsCancelled)
                {
                    DateTime eDate = changeRD[i].ReqDateTo;

                    if (date.AddMonths(-2).Month == eDate.Month && date.AddMonths(-2).Year == eDate.Year)
                    {
                        result[3].Month1 += string.IsNullOrWhiteSpace(result[3].Month1) ? eDate.Day.ToString() : "," + eDate.Day;
                        result[3].Total = string.IsNullOrWhiteSpace(result[3].Total) ? "1" : (Convert.ToInt32(result[3].Total) + 1).ToString();
                    }
                    else if (date.AddMonths(-1).Month == eDate.Month && date.AddMonths(-1).Year == eDate.Year)
                    {
                        result[3].Month2 += string.IsNullOrWhiteSpace(result[3].Month2) ? eDate.Day.ToString() : "," + eDate.Day;
                        result[3].Total = string.IsNullOrWhiteSpace(result[3].Total) ? "1" : (Convert.ToInt32(result[3].Total) + 1).ToString();
                    }
                    else if (date.Month == eDate.Month && date.Year == eDate.Year)
                    {
                        result[3].Month3 += string.IsNullOrWhiteSpace(result[3].Month3) ? eDate.Day.ToString() : "," + eDate.Day;
                        result[3].Total = string.IsNullOrWhiteSpace(result[3].Total) ? "1" : (Convert.ToInt32(result[3].Total) + 1).ToString();
                    }
                }
            }

            return result;
        }

        private bool IsHaveEmptyFields() 
        {
            if (string.IsNullOrWhiteSpace(txtDateCreated.Text)) {
                MessageBox.Show("Date Created Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtDateCreated.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDateFrom.Text)) {
                MessageBox.Show("Date From Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDateFrom.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDateTo.Text)) {
                MessageBox.Show("Date To Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtDateTo.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text)) {
                MessageBox.Show("Reason Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtReason.Focus();
                return true;
            }

            if (gridSearhExchange.SelectedRows.Count > 0 && string.IsNullOrWhiteSpace(txtExchangeDateFrom.Text)) {
                MessageBox.Show("Exchange Date From Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtExchangeDateFrom.Focus();
                return true;
            }

            if (gridSearhExchange.SelectedRows.Count > 0 && string.IsNullOrWhiteSpace(txtExchangeDateTo.Text))
            {
                MessageBox.Show("Exchange Date To Field is Empty.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtExchangeDateTo.Focus();
                return true;
            }

            return false;
        }

        private ChangeRestday CreateChangeRD()
        {
            BasicEmployeeInfo e = null;

            if(gridSearhExchange.SelectedRows.Count > 0)
                e = gridSearhExchange.SelectedRows[0].DataBoundItem as BasicEmployeeInfo;

            int pk = 0, cntrl = 0;

            if (this.action == UserAction.Update) 
            {
                var c = this.sourceHist.Current as ChangeRestday;
                if (c != null) {
                    pk = c.CdId;
                    cntrl = c.CntrlNo;
                }
            }

            return new ChangeRestday(pk, cntrl, this.serverDate, this.employee.PkId, this.employee.Fullname, txtDayFrom.Text,
                txtDayTo.Text, Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text),
                txtExchangeDayFrom.Text, txtExchangeDayTo.Text,( e != null ? Convert.ToDateTime(txtExchangeDateFrom.Text) : TimeKeepingCode.Program.DefaultDate),
                (e != null ? Convert.ToDateTime(txtExchangeDateTo.Text) : TimeKeepingCode.Program.DefaultDate), Restday(txtDayFrom.Text), Restday(txtDayTo.Text),
                txtReason.Text, txtCoordinated.Text, txtRecommendedApproval.Text, txtNotedBy.Text,
                txtApprovedBy.Text, this.serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName,
                false, e != null ? e.Fullname : "", e != null ? e.PkId : 0, false, string.Empty,
                string.Empty);

        }

        private List<ChangeRestdayDetails> CreateChangeRDDetails() 
        {
            List<ChangeRestdayDetails> result = new List<ChangeRestdayDetails>();

            result.Add(new ChangeRestdayDetails(Convert.ToInt32(gridDetails.Columns[5].HeaderText),
                Convert.ToInt32(gridDetails.Columns[6].HeaderText),0,gridDetails.Columns[0].HeaderText,
                gridDetails.Columns[1].HeaderText, gridDetails.Columns[2].HeaderText,
                gridDetails.Columns[3].HeaderText, gridDetails.Columns[4].HeaderText));

            for (int i = 0; i < gridDetails.Rows.Count; i++)
            {
                result.Add(new ChangeRestdayDetails(Convert.ToInt32(gridDetails.Rows[i].Cells[5].Value),
                    Convert.ToInt32(gridDetails.Rows[i].Cells[6].Value),(i+1),gridDetails.Rows[i].Cells[0].Value.ToString(),
                    gridDetails.Rows[i].Cells[1].Value.ToString(), gridDetails.Rows[i].Cells[2].Value.ToString(),
                    gridDetails.Rows[i].Cells[3].Value.ToString(), gridDetails.Rows[i].Cells[4].Value.ToString()));
            }

            return result;
        }

        private int Restday(string day) 
        {
            int result = 0;
            if (day.Equals("monday", StringComparison.CurrentCultureIgnoreCase))
                result = 1;
            else if (day.Equals("tuesday", StringComparison.CurrentCultureIgnoreCase))
                result = 2;
            else if (day.Equals("wednesday", StringComparison.CurrentCultureIgnoreCase))
                result = 3;
            else if (day.Equals("thursday", StringComparison.CurrentCultureIgnoreCase))
                result = 4;
            else if (day.Equals("friday", StringComparison.CurrentCultureIgnoreCase))
                result = 5;
            else if (day.Equals("saturday", StringComparison.CurrentCultureIgnoreCase))
                result = 6;
            else if (day.Equals("sunday", StringComparison.CurrentCultureIgnoreCase))
                result = 7;

            return result;
        }

        public void CancelTransaction()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Cancel With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            ChangeRestday c = this.sourceHist.Current as ChangeRestday;
            if (c != null)
            {
                if (c.IsCancelled) {
                    MessageBox.Show("Change Restday Already Cancelled.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
            }
            else {
                MessageBox.Show("Can't Cancel With No Selected Change Restday Transaction.",
                    "Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            pnlCancelled.Visible = true;
            rTxtCancelledReason.Focus();
        }

        private void LeaveResonCancel(object sender, EventArgs e)
        {
            LeaveCancel();
        }

        private void LeaveCancel() {
            pnlCancelled.Visible = false;
            rTxtCancelledReason.Text = string.Empty;
        }

        private void CancelCancelClick(object sender, EventArgs e)
        {
            LeaveCancel();
        }

        private void SaveCancelClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rTxtCancelledReason.Text))
            {
                if (MessageBox.Show("Are you sure to Cancel Change Restday?", "Cancel Transaction", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                ChangeRestday c = this.sourceHist.Current as ChangeRestday;
                c.ReasonCancelled = rTxtCancelledReason.Text;
                c.LastUpdatedBy = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
                ChangeRestday.CancelChangeRestday(TimeKeepingCode.Program.BiometricsConnection,c);
                LoadData(this.employee);
                gridHistory.Focus();
            }
            else {
                MessageBox.Show("Reason Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                rTxtCancelledReason.Focus();
            }
        }

        public bool PostTransaction()
        {
            if (this.employee == null)
            {
                MessageBox.Show("Can't Post With No Selected Employee.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            ChangeRestday l = this.sourceHist.Current as ChangeRestday;

            if (l != null)
            {
                if (l.IsCancelled)
                {
                    MessageBox.Show("Can't Post Already Cancelled Change Restday.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (l.IsPosted)
                {
                    MessageBox.Show("Can't Post Already Posted Change Restday.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(l.ApprovedBy))
                {
                    MessageBox.Show("Can't Post Empty Approved.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (MessageBox.Show("Are you sure to Post this Change Restday?", "Post Change Restday",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;

                l.LastUpdatedBy = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
                if (ChangeRestday.PostTransaction(TimeKeepingCode.Program.BiometricsConnection, l))
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
                MessageBox.Show("Can't Post With Empty Change Restday.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }

        public void Print()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Print With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            ChangeRestday changeRD = this.sourceHist.Current as ChangeRestday;

            if (changeRD == null) {
                MessageBox.Show("Can't Print With Empty Change Restday.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
                
            var details = CreateChangeRDDetails();

            Reports.FormPreviewReport report = new Reports.FormPreviewReport();
            report.rptViewer.LocalReport.DataSources.Clear();
            report.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportChangeRD.rdlc";
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("ctrlNo", changeRD.CntrlNo.ToString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dateFiled", changeRD.TrasactionDate.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reqName", this.employee.Fullname.ToString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reqDayFrom", changeRD.ReqDayFrom));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reqDateFrom", changeRD.ReqDateFrom.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reqdayTo", changeRD.ReqDayTo));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reqDateTo", changeRD.ReqDateTo.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("exName", changeRD.ExWithName));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("exDayFrom", changeRD.ExDayFrom));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("exDateFrom", changeRD.ExDateFrom.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("exDayTo", changeRD.ExDayTo));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("exDateTo", changeRD.ExDateTo.ToShortDateString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reason", changeRD.Reason));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("coordinatedWith", changeRD.Coordinated));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveTotal", details[1].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth1", details[1].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth2", details[1].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth3", details[1].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absencesTotal", details[2].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absencesMonth1", details[2].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absencesMonth2", details[2].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absencesMonth3", details[2].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("changeRDTotal", details[3].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("changeRDMonth1", details[3].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("changeRDMonth2", details[3].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("changeRDMonth3", details[3].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("undertimeTotal", details[4].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("undertimeMonth1", details[4].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("undertimeMonth2", details[4].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("undertimeMonth3", details[4].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessTotal", details[5].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth1", details[5].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth2", details[5].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth3", details[4].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month1", details[0].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month2", details[0].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month3", details[0].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("recommendedBy", changeRD.RecommendedApprovedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("notedBy", changeRD.NotedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("approvedBy", changeRD.ApprovedBy));
            report.rptViewer.RefreshReport();
            report.rptViewer.Refresh();
            report.ShowDialog();
            report.Dispose();
            report = null;
        }


        public string FormText
        {
            get { return "Change Restday"; }
        }
    }
}
