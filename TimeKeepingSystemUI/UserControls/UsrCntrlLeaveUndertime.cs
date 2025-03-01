using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlLeaveUndertime : UserControl, TimeKeepingCode.Code.IForms, TimeKeepingCode.Code.ICancellable, TimeKeepingCode.Code.IPrint
    {
        private BindingSource sourceHist;
        private TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee;

        private TimeKeepingCode.UserAction action;
        private DateTime serverDate;

        private string leaveUndertimeEffectDates;

        public UsrCntrlLeaveUndertime()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            SetControls();
            gridHistory.AutoGenerateColumns = false;
            gridOtherDetails.AutoGenerateColumns = false;

            this.sourceHist = new BindingSource();
            gridHistory.DataSource = this.sourceHist;

            this.sourceHist.CurrentChanged += CurrentChanged;
            this.action = TimeKeepingCode.UserAction.View;
            ReadOnlyFields(true);
            this.leaveUndertimeEffectDates = string.Empty;
        }

        private void CurrentChanged(object sender,EventArgs e) 
        {
            LoadLeaveUndertime(this.sourceHist.Current as LeaveUndertime);
        }

        public bool Edit()
        {
            LeaveUndertime l = this.sourceHist.Current as LeaveUndertime;
            if (l == null)
            {
                MessageBox.Show("Can't Update Empty Record.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            if (l.IsPosted || l.IsCancelled) {
                MessageBox.Show("Can't Update Already Posted or Cancelled Leave/Undertime","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            this.leaveUndertimeEffectDates = l.EffectDates;
            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            ReadOnlyFields(false);
            txtApprovedBy.Focus();
            this.action = TimeKeepingCode.UserAction.Update;
            return true;
        }

        public bool Save()
        {
            if (this.action == TimeKeepingCode.UserAction.Create)
            {
                if (!IsHaveEmptyFields())
                {
                    if (MessageBox.Show("Are you sure to Save Created Leave/Undertime?", 
                        "Save Created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                         return false;

                    if (LeaveUndertime.CreateLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection,
                        CreateLeaveUndertime(), CreateLeaveUndertimeDetails(), CreateLeaveUndertimeOtherDetails()))
                    {
                        MessageBox.Show("Created Leave/Undertime Successfuly Saved.",
                            "Created Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(this.employee);
                        this.sourceHist.MoveFirst();
                        ReadOnlyFields(true);
                        this.action = TimeKeepingCode.UserAction.View;
                        return true;
                    }
                    else {
                        MessageBox.Show("Created Leave/Undertime Failed to Save.",
                            "Created Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            else if(this.action == TimeKeepingCode.UserAction.Update)
            {
                if (!IsHaveEmptyFields()) 
                {
                    if (MessageBox.Show("Are you sure to Save Updated Leave/Undertime?",
                        "Save Updated", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false;

                    if (LeaveUndertime.UpdateLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection,
                        CreateLeaveUndertime(), CreateLeaveUndertimeDetails(), CreateLeaveUndertimeOtherDetails()))
                    {
                        MessageBox.Show("Updated Leave/Undertime Successfuly Saved.",
                            "Updated Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(this.employee);
                        ReadOnlyFields(true);
                        this.action = TimeKeepingCode.UserAction.View;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Updated Leave/Undertime Failed to Save.",
                            "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }

            return false;
        }

        public bool Create()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Create With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();

            EmptyFields();
            ReadOnlyFields(false);

            txtDateCreated.Text = this.serverDate.ToString("MM/dd/yyyy");
            txtFilledBy.Text = this.employee.Fullname;
            txtVerifiedBy.Text = TimeKeepingCode.Program.User.UserName;
            txtDateEffect.Focus();

            this.action = TimeKeepingCode.UserAction.Create;
            chkLeave.Checked = true;
            return true;
        }

        public bool Cancel()
        {
            if (this.action == TimeKeepingCode.UserAction.Create)
            {
                if (MessageBox.Show("Are you sure to Cancel Created Leave/Undertime?", "Cancel Created",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (MessageBox.Show("Are you sure to Cancel Updated Leave/Undertime?", "Cancel Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }

            ReadOnlyFields(true);
            LoadLeaveUndertime(this.sourceHist.Current as LeaveUndertime);
            this.action = TimeKeepingCode.UserAction.View;
            gridHistory.Focus();
            return true;
        }

        public TimeKeepingCode.UserAction Action { get { return this.action; } }

        public void LoadData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee)
        {
            if (employee != null)
            {
                this.employee = employee;
                Task.Factory.StartNew(() =>
                {
                    return LeaveUndertime.
                        GetAllLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection, employee.PkId);
                }).ContinueWith(a =>
                {
                    this.sourceHist.DataSource = a.Result.OrderByDescending(e => e.Id);
                    this.sourceHist.ResetBindings(false);
                    gridHistory.Focus();
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private static UsrCntrlLeaveUndertime instance;
        public static UsrCntrlLeaveUndertime Instance {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlLeaveUndertime();
                    instance.Name = "sigletonUstCntrlLeaveUndertime";
                    return instance;
                }
                else
                    return instance;
            }
        }

        private void FormResize(object sender, EventArgs e)
        {
            gridDetails.Width = Convert.ToInt32((0.52578475336322869955156950672646 * this.Width));
            gridOtherDetails.Left = gridDetails.Width + 25;
            gridOtherDetails.Width = Convert.ToInt32(0.42488789237668161434977578475336 * this.Width);
            lblPastLeaveUndertime.Left = gridDetails.Left;
            lblOtherDetails.Left = gridOtherDetails.Left;

            pnlCancelled.Left = (this.Width - pnlCancelled.Width) / 2;
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

            gridOtherDetails.BackgroundColor = Code.Program.MainColor;
            gridOtherDetails.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridOtherDetails.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridOtherDetails.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridOtherDetails.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            pnlCancelHeader.BackColor = Code.Program.MainColor;
            lblCancelHeader.ForeColor = Code.Program.TextColor;
            btnCancelCancel.BackColor = Code.Program.MainColor;
            btnCancelCancel.ForeColor = Code.Program.TextColor;
            btnCancelSave.BackColor = Code.Program.MainColor;
            btnCancelSave.ForeColor = Code.Program.TextColor;

            lblStatus.ForeColor = Code.Program.MainColor;
        }

        private void LoadLeaveUndertime(LeaveUndertime leaveUndertime)
        {
            if (leaveUndertime != null)
            {
                Details(leaveUndertime);
                LoadGridDetails(leaveUndertime);
                LoadGridOtherDetails(leaveUndertime);
            }
            else
                EmptyFields();
        }

        private void EmptyFields() 
        {
            this.chkLeave.Checked = false;
            this.chkUndertime.Checked = false;

            txtDateCreated.Text = string.Empty;
            txtDateEffect.Text = string.Empty;
            txtDateFrom.Text = string.Empty;
            txtDateTo.Text = string.Empty;
            txtNoDaysMins.Text = string.Empty;
            txtResumeDate.Text = string.Empty;
            txtCoordinatedWith.Text = string.Empty;
            txtFilledBy.Text = string.Empty;
            txtRecommendedBy.Text = string.Empty;
            txtVerifiedBy.Text = string.Empty;
            txtNotedBy.Text = string.Empty;
            txtApprovedBy.Text = string.Empty;
            txtReason.Text = string.Empty;

            gridDetails.Rows.Clear();
            gridOtherDetails.DataSource = null;
        }

        private void Details(LeaveUndertime leaveUndertime) 
        {
            string[] effectDates = null;
            if (leaveUndertime.Type == 1)
            {
                chkLeave.Checked = true;
                chkUndertime.Checked = false;
                effectDates = leaveUndertime.EffectDates.Split(',');
            }
            else
            {
                chkLeave.Checked = false;
                chkUndertime.Checked = true;
                effectDates = leaveUndertime.EffectDates.Split('-');
            }

            txtDateCreated.Text = leaveUndertime.TransactionDate.ToString("MM/dd/yyyy");
            txtDateEffect.Text = leaveUndertime.EffectiveDate.ToString("MM/dd/yyyy");
            txtDateFrom.Text = effectDates.Length > 0 ? effectDates[0] : string.Empty;
            txtDateTo.Text = effectDates.Length > 0 ? effectDates[effectDates.Length - 1] : string.Empty;
            txtNoDaysMins.Text = leaveUndertime.NoDaysMins;
            txtResumeDate.Text = leaveUndertime.ResumetoWork;
            txtCoordinatedWith.Text = leaveUndertime.CoordinatedBy;
            txtFilledBy.Text = leaveUndertime.FiledBy;
            txtRecommendedBy.Text = string.Empty;
            txtVerifiedBy.Text = leaveUndertime.VerifiedBy;
            txtNotedBy.Text = leaveUndertime.NotedBy;
            txtApprovedBy.Text = leaveUndertime.ApprovedBy;
            txtReason.Text = leaveUndertime.Reason;

            if (leaveUndertime.IsCancelled)
                lblStatus.Text = "C A N C E L L E D";
            else if (leaveUndertime.IsPosted)
                lblStatus.Text = "P O S T E D";
            else
                lblStatus.Text = "U N P O S T E D";

            lblLastUpdated.Text = "Last Updated: " + leaveUndertime.LastModified;
        }

        private void LoadGridDetails(LeaveUndertime leaveUndertime) 
        {
            Task.Factory.StartNew(() =>
            {
                return LeaveUndertimeDetails.
                    GetLeaveUndertimeDetails(TimeKeepingCode.Program.BiometricsConnection, leaveUndertime.Id);
            }).ContinueWith(a => 
            {
                LoadDataGridDetails(a.Result.OrderBy(l => l.Line).ToList());
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadDataGridDetails(List<LeaveUndertimeDetails> details) 
        {
            gridDetails.Rows.Clear();
            if (details.Count > 0)
            {
                gridDetails.Columns[0].HeaderText = "Description";
                gridDetails.Columns[1].HeaderText = "Total";
                gridDetails.Columns[2].HeaderText = details[0].Month1;
                gridDetails.Columns[3].HeaderText = details[0].Month2;
                gridDetails.Columns[4].HeaderText = details[0].Month3;
                gridDetails.Columns[5].HeaderText = details[0].Id.ToString();
                gridDetails.Columns[6].HeaderText = details[0].LUId.ToString();

                for (int i = 1; i < details.Count; i++)
                {
                    gridDetails.Rows.Add(details[i].Description, details[i].Total, details[i].Month1,
                        details[i].Month2, details[i].Month3,details[i].Id,details[i].LUId);
                }
            }
        }

        private void LoadGridOtherDetails(LeaveUndertime leaveUndertime) 
        {
            Task.Factory.StartNew(() =>
            {
                return LeaveUndertimeOtherDetails.
                    GetAllLeaveUndertimeOtherDetails(TimeKeepingCode.Program.BiometricsConnection, leaveUndertime.Id);
            }).ContinueWith(a => 
            {
                gridOtherDetails.DataSource = null;
                gridOtherDetails.DataSource = a.Result;
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void ReadOnlyFields(bool b) 
        {
            txtDateEffect.ReadOnly = b;
            txtDateFrom.ReadOnly = b;
            txtDateTo.ReadOnly = b;
            txtCoordinatedWith.ReadOnly = b;
            txtFilledBy.ReadOnly = b;
            txtRecommendedBy.ReadOnly = b;
            txtNotedBy.ReadOnly = b;
            txtApprovedBy.ReadOnly = b;
            txtReason.ReadOnly = b;

            chkLeave.Enabled = !b;
            chkUndertime.Enabled = !b;

            gridHistory.Enabled = b;
        }

        private void LeaveCheckChanged(object sender, EventArgs e)
        {
            if (this.action != TimeKeepingCode.UserAction.View)
            {
                chkUndertime.Checked = !chkLeave.Checked;
                ResetLeaveUndertime();
            }
        }

        private void UndertimeCheckedChanged(object sender, EventArgs e)
        {
            if (this.action != TimeKeepingCode.UserAction.View)
            {
                chkLeave.Checked = !chkUndertime.Checked;
                ResetLeaveUndertime();
            }
        }

        private bool IsDateValid(string date,out DateTime dateResult) 
        {
            DateTime o = new DateTime(1901,1,1);
            if (date.Length == 10)
                return DateTime.TryParse(date,out dateResult);

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
                return DateTime.TryParse(date + "/" + this.serverDate.Year,out dateResult);

            if (date.Length == 4)
                return DateTime.TryParse(date.Substring(0, 2) + "/" + date.Substring(2, 2) + "/" + this.serverDate.Year, out dateResult);

            dateResult = o;
            return false;
        }

        private bool IsTimeValid(string time,out DateTime dateResult) 
        {
            DateTime o = new DateTime(1901,1,1);

            if (time.Length == 8)
                return DateTime.TryParse(time,out dateResult);

            if (time.Length == 5) 
            {
                if (time.Substring(2, 1) != ":")
                {
                    dateResult = o;
                    return false;
                }
                else {
                    return DateTime.TryParse(time,out dateResult);
                }
            }

            if (time.Length == 4) 
            {
                return DateTime.TryParse(time.Substring(0,2) + ":" + time.Substring(2,2),out dateResult);
            }

            dateResult = o;
            return false;
        }

        private void DateEffectKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.action == TimeKeepingCode.UserAction.Create || 
                    this.action == TimeKeepingCode.UserAction.Update) 
                {
                    if (chkLeave.Checked)
                        txtDateTo.Focus();
                    else if (chkUndertime.Checked)
                        txtDateFrom.Focus();
                }
                else
                    txtDateFrom.Focus();
            }
        }

        private void DateCreatedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateEffect.Focus();
        }

        private void DateFromKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateTo.Focus();
        }

        private void DateToKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.action == TimeKeepingCode.UserAction.Update || 
                    this.action == TimeKeepingCode.UserAction.Create) 
                {
                    txtCoordinatedWith.Focus();
                }
                else
                    txtNoDaysMins.Focus();
            }
        }

        private void NoDaysMinsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtResumeDate.Focus();
        }

        private void ResumeDateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCoordinatedWith.Focus();
        }

        private void CoordinatedWithKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFilledBy.Focus();
        }

        private void FilledByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRecommendedBy.Focus();
        }

        private void RecommendedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtVerifiedBy.Focus();
        }

        private void VerifiedByKeyDown(object sender, KeyEventArgs e)
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
                txtReason.Focus();
        }

        private void ReasonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridHistory.Focus();
        }

        private void DateEffectValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || 
                this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (!string.IsNullOrWhiteSpace(txtDateEffect.Text)) 
                {
                    DateTime date;
                    if (IsDateValid(txtDateEffect.Text.Trim(), out date))
                    {
                        txtDateEffect.Text = date.ToString("MM/dd/yyyy");
                        if(chkLeave.Checked)
                            txtDateFrom.Text = date.ToString("MM/dd/yyyy");

                        Task.Factory.StartNew(() =>
                        {
                            return CreateLeaveUndertimeDetails(date);
                        }).ContinueWith(d => {
                            LoadDataGridDetails(d.Result);
                        },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
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

        private void DateFromValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update ||
                this.action == TimeKeepingCode.UserAction.Create)
            {
                if (!string.IsNullOrWhiteSpace(txtDateFrom.Text))
                {
                    if (chkLeave.Checked)
                    {
                        if (!txtDateEffect.Text.Trim().Equals(txtDateFrom.Text.Trim()))
                        {
                            MessageBox.Show("Date must the same to Date Effect.", "Invalid",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        DateTime date;
                        if (!IsTimeValid(txtDateFrom.Text.Trim(), out date))
                        {
                            MessageBox.Show("Invalid Time Format. Ex (20:00,0800)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                        else
                            txtDateFrom.Text = date.ToString("hh:mm tt");
                    }
                }
            }
        }

        private void DateFromEnter(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || 
                this.action == TimeKeepingCode.UserAction.Update)
            {
                if (string.IsNullOrWhiteSpace(txtDateEffect.Text))
                    txtDateEffect.Focus();
            }
        }

        private void DateToEnter(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update || 
                this.action == TimeKeepingCode.UserAction.Create)
            {
                if (string.IsNullOrWhiteSpace(txtDateFrom.Text))
                    txtDateFrom.Focus();
            }
        }

        private void DateToValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || 
                this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (!string.IsNullOrWhiteSpace(txtDateTo.Text)) 
                {
                    if (chkLeave.Checked)
                    {
                        DateTime date;
                        if (IsDateValid(txtDateTo.Text.Trim(), out date))
                        {
                            if (Convert.ToDateTime(txtDateFrom.Text) > date)
                            {
                                MessageBox.Show("Date is Higher than From Date.", "Invalid Date",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                e.Cancel = true;
                            }
                            else
                            {
                                txtDateTo.Text = date.ToString("MM/dd/yyyy");
                                
                                string noDaysmins;
                                gridOtherDetails.DataSource = null;
                                gridOtherDetails.DataSource = CalculateOtherDetails(out noDaysmins);
                                txtResumeDate.Text = ResumeDate();
                                txtNoDaysMins.Text = noDaysmins;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Date Format. Ex (0101,01/01,01/01/,01/01/2019)", "Invalid Format",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                        }
                    }
                    else {
                        DateTime date;
                        if (IsTimeValid(txtDateTo.Text.Trim(), out date))
                        {
                            if (Convert.ToDateTime(txtDateFrom.Text).TimeOfDay > date.TimeOfDay)
                            {
                                MessageBox.Show("Time is Higher than From Date.", "Invalid Date",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                e.Cancel = true;
                            }
                            else
                            {
                                txtDateTo.Text = date.ToString("hh:mm tt");

                                string noDaysmins;
                                gridOtherDetails.DataSource = null;
                                gridOtherDetails.DataSource = CalculateOtherDetails(out noDaysmins);
                                txtResumeDate.Text = ResumeDate();
                                txtNoDaysMins.Text = noDaysmins;
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
        }

        private string ResumeDate() 
        {
            string result = string.Empty;
            var shift = EmployeeShifting.
                GetCurrentEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId);

            if (shift == null) 
            {
                MessageBox.Show("No Schedule Found.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return string.Empty;
            }

            DateTime dateEnd = Convert.ToDateTime(txtDateTo.Text);
            if (chkLeave.Checked) 
            {
                while (true)
                {
                    string holidayType = string.Empty;
                    dateEnd = dateEnd.AddDays(1);
                    if (!HolidayEmployees.IsEmployeeHoliday
                        (TimeKeepingCode.Program.BiometricsConnection,dateEnd,this.employee.PkId,out holidayType))
                    {
                        if (!EmployeeShifting.IsRestday
                            (TimeKeepingCode.Program.BiometricsConnection, dateEnd,this.employee.PkId))
                        {
                            if (!LeaveUndertime.IsLeave
                                (TimeKeepingCode.Program.BiometricsConnection,dateEnd,this.employee.PkId))
                            {
                                result = dateEnd.ToString("MM/dd/yyyy");
                                break;
                            }
                        }
                    }
                }
            }
            else if (chkUndertime.Checked) 
            {
                ShiftingSchedule shifting = null;
                if (dateEnd.DayOfWeek == DayOfWeek.Monday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Monday);
                else if(dateEnd.DayOfWeek == DayOfWeek.Tuesday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Tuesday);
                else if(dateEnd.DayOfWeek == DayOfWeek.Wednesday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Wednesday);
                else if(dateEnd.DayOfWeek == DayOfWeek.Thursday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Thursday);
                else if(dateEnd.DayOfWeek == DayOfWeek.Friday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Friday);
                else if (dateEnd.DayOfWeek == DayOfWeek.Saturday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Saturday);
                else if (dateEnd.DayOfWeek == DayOfWeek.Sunday)
                    shifting = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == shift.Sunday);

                if (shifting != null)
                {
                    if (dateEnd.TimeOfDay >= shifting.PmOut)
                    {
                        dateEnd = Convert.ToDateTime(txtDateEffect.Text).Add(dateEnd.TimeOfDay);
                        string holidayType = string.Empty;
                        while (true)
                        {
                            dateEnd = dateEnd.AddDays(1);
                            if (!HolidayEmployees.IsEmployeeHoliday
                                (TimeKeepingCode.Program.BiometricsConnection, dateEnd, this.employee.PkId,out holidayType))
                            {
                                if (!EmployeeShifting.IsRestday
                                    (TimeKeepingCode.Program.BiometricsConnection, dateEnd, this.employee.PkId))
                                {
                                    if (!LeaveUndertime.IsLeave
                                        (TimeKeepingCode.Program.BiometricsConnection, dateEnd, this.employee.PkId))
                                    {
                                        result = dateEnd.ToString("MM/dd/yyyy");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else {
                        if (shifting.ScheduleType == 2)
                        {
                            if (dateEnd.TimeOfDay >= shifting.CoffeeOut)
                            {
                                if (dateEnd.TimeOfDay <= shifting.CoffeeIn)
                                    result = DateTime.Today.Add(shifting.CoffeeIn).ToString("hh:mm tt");
                                else
                                    result = dateEnd.ToString("hh:mm tt");
                            }
                            else
                                result = dateEnd.ToString("hh:mm tt");
                        }
                        else if (shifting.ScheduleType == 3)
                        {
                            if (dateEnd.TimeOfDay >= shifting.LunchOut)
                            {
                                if (dateEnd.TimeOfDay <= shifting.LunchIn)
                                    result = DateTime.Today.Add(shifting.LunchIn).ToString("hh:mm tt");
                                else
                                    result = dateEnd.ToString("hh:mm tt");
                            }
                            else
                                result = dateEnd.ToString("hh:mm tt");
                        }
                        else if (shifting.ScheduleType == 1)
                        {
                            if (dateEnd.TimeOfDay >= shifting.CoffeeOut)
                            {
                                if (dateEnd.TimeOfDay <= shifting.CoffeeIn)
                                    result = DateTime.Today.Add(shifting.CoffeeIn).ToString("hh:mm tt");
                                else
                                    result = dateEnd.ToString("hh:mm tt");
                            }
                            if (dateEnd.TimeOfDay >= shifting.LunchOut)
                            {
                                if (dateEnd.TimeOfDay <= shifting.LunchIn)
                                    result = DateTime.Today.Add(shifting.LunchIn).ToString("hh:mm tt");
                                else
                                    result = dateEnd.ToString("hh:mm tt");
                            }
                            else
                                result = dateEnd.ToString("hh:mm tt");
                        }
                        else
                            result = dateEnd.ToString("hh:mm tt");
                    }
                }
                else
                    MessageBox.Show("Nayabag ang Program.","Pinka grabi na Error.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return result;
        }

        private List<LeaveUndertimeOtherDetails> CalculateOtherDetails(out string daysMins) 
        {
            List<LeaveUndertimeOtherDetails> result = 
                new List<LeaveUndertimeOtherDetails>();
            string resultDaysMins = string.Empty;
            this.leaveUndertimeEffectDates = string.Empty;

            if (chkLeave.Checked) 
            {
                DateTime dateStartOrig = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateEndOrig = Convert.ToDateTime(txtDateTo.Text);

                DateTime dateStart = Convert.ToDateTime(txtDateFrom.Text).AddDays(-2);
                DateTime dateEnd = Convert.ToDateTime(txtDateTo.Text).AddDays(2);
                int count = 0;
                string holidayType = string.Empty;
                while (!dateStart.Equals(dateEnd.AddDays(1))) 
                {
                    if (!HolidayEmployees.IsEmployeeHoliday
                        (TimeKeepingCode.Program.BiometricsConnection, dateStart, this.employee.PkId,out holidayType))
                    {
                        if (!EmployeeShifting.IsRestday
                            (TimeKeepingCode.Program.BiometricsConnection, dateStart, this.employee.PkId))
                        {
                            if (!LeaveUndertime.IsLeave(TimeKeepingCode.Program.BiometricsConnection, dateStart, this.employee.PkId))
                            {
                                if (dateStart >= dateStartOrig && dateStart <= dateEndOrig)
                                {
                                    count++;
                                    leaveUndertimeEffectDates += string.IsNullOrWhiteSpace(leaveUndertimeEffectDates) ? 
                                        dateStart.ToString("MM/dd/yyyy") : "," + dateStart.ToString("MM/dd/yyyy");
                                }
                            }
                            else {
                                LeaveUndertimeOtherDetails detail =
                            result.Find(r => r.Description.Equals(dateStart.ToString("MMMM"), StringComparison.CurrentCultureIgnoreCase));
                                if (detail != null)
                                    detail.Leave += string.IsNullOrWhiteSpace(detail.Leave) ? dateStart.Day.ToString() : "," + dateStart.Day;
                                else
                                    result.Add(new LeaveUndertimeOtherDetails(0, string.Empty, string.Empty,dateStart.Day.ToString(), dateStart.ToString("MMMM")));
                            }
                        }
                        else {
                            LeaveUndertimeOtherDetails detail =
                            result.Find(r => r.Description.Equals(dateStart.ToString("MMMM"), StringComparison.CurrentCultureIgnoreCase));
                            if (detail != null)
                                detail.Restday += string.IsNullOrWhiteSpace(detail.Restday) ? dateStart.Day.ToString() : "," + dateStart.Day;
                            else
                                result.Add(new LeaveUndertimeOtherDetails(0, dateStart.Day.ToString(),string.Empty,string.Empty, dateStart.ToString("MMMM")));
                        }
                    }
                    else {
                        LeaveUndertimeOtherDetails detail =
                            result.Find(r => r.Description.Equals(dateStart.ToString("MMMM"), StringComparison.CurrentCultureIgnoreCase));
                        if (detail != null)
                            detail.Holiday += string.IsNullOrWhiteSpace(detail.Holiday) ? dateStart.Day.ToString() : "," + dateStart.Day;
                        else
                            result.Add(new LeaveUndertimeOtherDetails(0, string.Empty, dateStart.Day.ToString(), string.Empty, dateStart.ToString("MMMM")));
                    }
                    dateStart = dateStart.AddDays(1);
                }
                resultDaysMins = count > 1 ? count + " Days" : count + " Day";
            }
            else if (chkUndertime.Checked) 
            {
                DateTime dateStart = Convert.ToDateTime(txtDateFrom.Text);
                DateTime dateEnd = Convert.ToDateTime(txtDateTo.Text);

                TimeSpan t = dateEnd.TimeOfDay.Subtract(dateStart.TimeOfDay);
                resultDaysMins = t.Hours > 1 ? t.Hours + " hrs " + t.Minutes + (t.Minutes > 1 ? " mins" : " min") : 
                    t.Hours + " hr " + t.Minutes + (t.Minutes > 1 ? " mins" : " min");

                this.leaveUndertimeEffectDates = dateStart.ToString("hh:mm tt") + "-" + dateEnd.ToString("hh:mm tt");
            }

            int leave = 0, holiday = 0, restday = 0;
            for (int i = 0; i < result.Count; i++)
            {
                leave += !string.IsNullOrWhiteSpace(result[i].Leave)  ?  result[i].Leave.Split(',').Length : 0;
                holiday += !string.IsNullOrWhiteSpace(result[i].Holiday) ? result[i].Holiday.Split(',').Length : 0;
                restday += !string.IsNullOrWhiteSpace(result[i].Restday) ? result[i].Restday.Split(',').Length : 0;
            }

            result.Add(new LeaveUndertimeOtherDetails(0,restday.ToString(),holiday.ToString(),leave.ToString(),"Total"));
            daysMins = resultDaysMins;
            return result;
        }

        private void ResetLeaveUndertime() 
        {
            gridOtherDetails.DataSource = null;
            txtResumeDate.Text = string.Empty;
            txtNoDaysMins.Text = string.Empty;
            txtDateTo.Text = string.Empty;
            txtDateFrom.Text = string.Empty;
            txtDateEffect.Focus();
        }

        private List<LeaveUndertimeDetails> CreateLeaveUndertimeDetails(DateTime date) 
        {
            int leaveUndertimeId = 0;

            if (this.action == TimeKeepingCode.UserAction.Update) 
            {
                LeaveUndertime l = this.sourceHist.Current as LeaveUndertime;
                if (l != null)
                    leaveUndertimeId = l.Id;
            }

            List<LeaveUndertimeDetails> result = new List<LeaveUndertimeDetails>();
            result.Add(new LeaveUndertimeDetails(0,0,0,"Description","Total",date.AddMonths(-2).
                ToString("MMM. yyyy"),date.AddMonths(-1).ToString("MMM. yyyy"),date.ToString("MMM. yyyy")));
            result.Add(new LeaveUndertimeDetails(0,0,1,"Leave",string.Empty,string.Empty,string.Empty,string.Empty));
            result.Add(new LeaveUndertimeDetails(0, leaveUndertimeId, 2, "Absences", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new LeaveUndertimeDetails(0, leaveUndertimeId, 3, "Change RD", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new LeaveUndertimeDetails(0, leaveUndertimeId, 4, "Undertime", string.Empty, string.Empty, string.Empty, string.Empty));
            result.Add(new LeaveUndertimeDetails(0, leaveUndertimeId, 5, "Tardiness", string.Empty, string.Empty, string.Empty, string.Empty));

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

            var prw = PRW.GetAllPRW(TimeKeepingCode.Program.BiometricsConnection,this.employee.PkId);
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

            if (string.IsNullOrWhiteSpace(txtDateEffect.Text)) {
                MessageBox.Show("Date Effect Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtDateEffect.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDateFrom.Text))
            {
                MessageBox.Show("Date From Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtDateFrom.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtDateTo.Text)) {
                MessageBox.Show("Date To Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtDateTo.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtFilledBy.Text)) {
                MessageBox.Show("Filled By Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtFilledBy.Focus();
                return true;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text)) {
                MessageBox.Show("Reason Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtReason.Focus();
                return true;
            }

            return false;
        }

        private LeaveUndertime CreateLeaveUndertime()
        {
            int id = 0, cntrlNo = 0;

            if (this.action == TimeKeepingCode.UserAction.Update) 
            {
                LeaveUndertime l = this.sourceHist.Current as LeaveUndertime;
                id = l.Id;
                cntrlNo = l.CntrlNo;
            }

            return new LeaveUndertime(id, cntrlNo, Convert.ToDateTime(txtDateCreated.Text),
                        chkLeave.Checked ? 1 : 2, this.employee.PkId, this.employee.IdNumber + " - " + this.employee.Fullname,
                        this.employee.Section, this.employee.Position, Convert.ToDateTime(txtDateEffect.Text),
                        this.leaveUndertimeEffectDates, txtResumeDate.Text, txtReason.Text, txtCoordinatedWith.Text,
                        txtRecommendedBy.Text, txtFilledBy.Text, txtNotedBy.Text, txtVerifiedBy.Text, txtApprovedBy.Text,
                        this.serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName, false, txtNoDaysMins.Text,
                        false, string.Empty);
        }

        private List<LeaveUndertimeDetails> CreateLeaveUndertimeDetails() 
        {
            List<LeaveUndertimeDetails> result = new List<LeaveUndertimeDetails>();
            result.Add(new LeaveUndertimeDetails(Convert.ToInt32(gridDetails.Columns[5].HeaderText), 
                Convert.ToInt32(gridDetails.Columns[6].HeaderText), 0, "Description", "Total", 
                gridDetails.Columns[2].HeaderText,gridDetails.Columns[3].HeaderText, gridDetails.Columns[4].HeaderText));

            for (int i = 0; i < gridDetails.Rows.Count; i++)
            {
                result.Add(new LeaveUndertimeDetails(Convert.ToInt32(gridDetails.Rows[i].Cells[5].Value),
                    Convert.ToInt32(gridDetails.Rows[i].Cells[6].Value),i+1,gridDetails.Rows[i].Cells[0].Value.ToString(),
                    gridDetails.Rows[i].Cells[1].Value.ToString(),gridDetails.Rows[i].Cells[2].Value.ToString(),
                    gridDetails.Rows[i].Cells[3].Value.ToString(),gridDetails.Rows[i].Cells[4].Value.ToString()));
            }
            return result;
        }

        private List<LeaveUndertimeOtherDetails> CreateLeaveUndertimeOtherDetails() 
        {
            List<LeaveUndertimeOtherDetails> result = new List<LeaveUndertimeOtherDetails>();
            for (int i = 0; i < gridOtherDetails.Rows.Count; i++)
            {
                result.Add(gridOtherDetails.Rows[i].DataBoundItem as LeaveUndertimeOtherDetails);
            }
            return result;
        }

        public void CancelTransaction()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Cancel With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            LeaveUndertime p = this.sourceHist.Current as LeaveUndertime;
            if (p == null)
            {
                MessageBox.Show("Can't Cancel With No Selected Leave/Undertime.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else {
                if (p.IsCancelled)
                {
                    MessageBox.Show("Leave/Undertime Already Cancelled.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            pnlCancelled.Visible = true;
            rTxtCancelledReason.Focus();
        }

        private void CancelledLeave(object sender, EventArgs e)
        {
            LeaveCancelReason();
        }

        private void ReasonCancelClick(object sender, EventArgs e)
        {
            LeaveCancelReason();
        }

        private void LeaveCancelReason() {
            pnlCancelled.Visible = false;
            rTxtCancelledReason.Text = string.Empty;
        }

        private void CancelReasonSaveClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rTxtCancelledReason.Text))
            {
                if (MessageBox.Show("Are you sure to Cancel Leave/Undertime Transaction?", "Invalid", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                LeaveUndertime l = this.sourceHist.Current as LeaveUndertime;
                l.CancelledReason = rTxtCancelledReason.Text;
                l.LastModified = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
                LeaveUndertime.CancelLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection,l);
                LoadData(this.employee);
                gridHistory.Focus();
            }
            else {
                MessageBox.Show("Empty Reason Field.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                rTxtCancelledReason.Focus();
            }
        }

        public bool PostTransaction()
        {
            if (this.employee == null) {
                MessageBox.Show("Can't Post With No Selected Employee.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }

            LeaveUndertime l = this.sourceHist.Current as LeaveUndertime;

            if (l != null)
            {
                if (l.IsCancelled)
                {
                    MessageBox.Show("Can't Post Already Cancelled Leave/Undertime.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (l.IsPosted)
                {
                    MessageBox.Show("Can't Post Already Posted Leave/Undertime.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                if (string.IsNullOrWhiteSpace(l.ApprovedBy)) {
                    MessageBox.Show("Can't Post With Empty Approved.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return false;
                }

                if (MessageBox.Show("Are you sure to Post this Leave/Underitime?", "Post Leave/Undertime",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;

                l.LastModified = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;
                if (LeaveUndertime.PostLeaveUndertime(TimeKeepingCode.Program.BiometricsConnection, l))
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
                MessageBox.Show("Can't Post With Empty Leave/Undertime.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }
        }

        public void Print()
        {
            if (this.employee == null)
            {
                MessageBox.Show("Can't Print With No Selected Employee.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            LeaveUndertime leaveUndertime = this.sourceHist.Current as LeaveUndertime;

            if (leaveUndertime == null) {
                MessageBox.Show("Can't Print With Empty Leave/Undertime.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Restday", typeof(string));
            dt.Columns.Add("Holiday", typeof(string));
            dt.Columns.Add("Leave", typeof(string));

            var otherDetails = CreateLeaveUndertimeOtherDetails();
            var details = CreateLeaveUndertimeDetails();
            foreach (var detail in otherDetails)
                dt.Rows.Add(detail.Description, detail.Restday, detail.Holiday, detail.Leave);
            var dates = leaveUndertime.EffectDates.Split(',');
            string date1 = string.Empty;
            string date2 = string.Empty;

            for (int i = 0; i < dates.Length; i++)
            {
                if (i > 3)
                    date2 += dates[i] + ",";
                else
                    date1 += dates[i] + ",";
            }

            if (date1.Length > 0)
                date1 = date1.Substring(0, date1.Length - 1);
            if (date2.Length > 0)
                date2 = date2.Substring(0, date2.Length - 1);

            Reports.FormPreviewReport report = new Reports.FormPreviewReport();
            report.rptViewer.LocalReport.DataSources.Clear();
            report.rptViewer.LocalReport.DataSources.Add(new
                Microsoft.Reporting.WinForms.ReportDataSource("leaveUndertimeDs", dt));
            report.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportLeaveUndertime.rdlc";
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("ctrlNo", leaveUndertime.CntrlNo.ToString()));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("name", this.employee.IdNumber + " - " + this.employee.Fullname));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dateFiled", leaveUndertime.TransactionDate.ToString("MM/dd/yyyy")));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("section", this.employee.Section));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("brand", this.employee.Position));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dateEffect", leaveUndertime.EffectiveDate.ToString("MM/dd/yyyy")));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("daysMins", leaveUndertime.NoDaysMins));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("resume", leaveUndertime.ResumetoWork));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("reason", leaveUndertime.Reason));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("coordinated", leaveUndertime.CoordinatedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveTotal", details[1].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth1", details[1].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth2", details[1].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("leaveMonth3", details[1].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentTotal", details[2].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth1", details[2].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth2", details[2].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("absentMonth3", details[2].Month3));
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
                Microsoft.Reporting.WinForms.ReportParameter("unsertimeMonth3", details[4].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessTotal", details[5].Total));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth1", details[5].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth2", details[5].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("tardinessMonth3", details[5].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("filedBy", leaveUndertime.FiledBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("recommendedBy", ""));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("verifiedBy", leaveUndertime.VerifiedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("notedBy", leaveUndertime.NotedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("approvedBy", leaveUndertime.ApprovedBy));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dates1", date1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("dates2", date2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month1", details[0].Month1));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month2", details[0].Month2));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("month3", details[0].Month3));
            report.rptViewer.LocalReport.SetParameters(new
                Microsoft.Reporting.WinForms.ReportParameter("header", leaveUndertime.Type.Equals(1) ?
                "LEAVE APPROVAL FORM" : "UNDERTIME APPROVAL FORM"));
            report.rptViewer.RefreshReport();
            report.rptViewer.Refresh();
            report.ShowDialog();
            report.Dispose();
            report = null;
        }


        public string FormText
        {
            get { return "Leave/Undertime"; }
        }
    }
}
