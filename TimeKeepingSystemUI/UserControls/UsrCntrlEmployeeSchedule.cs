using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingCode.Code;
using TimeKeepingCode.Events;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlEmployeeSchedule : UserControl
    {
        private BindingSource sourceHistory;
        private BasicEmployeeInfo employee;

        public UsrCntrlEmployeeSchedule()
        {
            InitializeComponent();
            gridHistory.AutoGenerateColumns = false;

            this.sourceHistory = new BindingSource();
            this.sourceHistory.CurrentChanged += OnSourceSelected;

            gridHistory.DataSource = this.sourceHistory;

            this.Dock = DockStyle.Fill;
            ucBasicEmployeeProfile.SelectedEmployee += OnBasicProfileSelected;
            this.employee = null;

            ucBasicEmployeeProfile.InnerKeyEvent += KeyEvent;
        }

        private void OnSourceSelected(object sender,EventArgs e) 
        {
            LoadEmployeeShifting();
        }

        private void CreateClick(object sender, EventArgs e)
        {
            if (this.employee == null) {
                MessageBox.Show("Can Create Schedule With No Selected Employee.","Invalid",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            EmployeeShifting p = null;

            if (this.sourceHistory.Count > 0) 
                p = this.sourceHistory[0] as EmployeeShifting;

            UsrCntrlEmployeeScheduleCreateUpdate.Instance.LoadData(this.employee,p,TimeKeepingCode.UserAction.Create);   
            this.Parent.Controls.Add(UsrCntrlEmployeeScheduleCreateUpdate.Instance);
            UsrCntrlEmployeeScheduleCreateUpdate.Instance.BringToFront();
        }

        public void FirstFocus() 
        {
            ucBasicEmployeeProfile.Focus();
        }

        private static UsrCntrlEmployeeSchedule instance;
        public static UsrCntrlEmployeeSchedule Instance 
        {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlEmployeeSchedule();
                    instance.Name = "singletonEmployeeSchedule";
                }
                return instance;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            SetImage();
            ucBasicEmployeeProfile.SearchFocus();
            SetControls();
        }

        private void OnBasicProfileSelected(object sender,BasicInfoOnSelectedEventArgs e) 
        {
            LoadScheduleHistory(e.Selected);
            this.employee = e.Selected;
        }

        public void LoadScheduleHistory(BasicEmployeeInfo info) 
        {
            Task.Factory.StartNew(() =>
            {
                var r = EmployeeShifting.GetEmployeeShiftings(TimeKeepingCode.Program.BiometricsConnection, info.PkId);
                return r.OrderByDescending(s => s.EffectDate);
            }).ContinueWith(a => 
            {
                this.sourceHistory.DataSource = a.Result;
                this.sourceHistory.ResetBindings(false);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadEmployeeShifting() 
        {
            var schedule = this.sourceHistory.Current as EmployeeShifting;

            if (schedule != null)
            {
                string floor = string.Empty;
                string restday = string.Empty;

                if (schedule.MachineNo == 1)
                    floor = "First Floor";
                else if (schedule.MachineNo == 2)
                    floor = "Second Floor";
                else if (schedule.MachineNo == 3)
                    floor = "Third Floor";
                else if (schedule.MachineNo == 4)
                    floor = "Manila";

                if (schedule.Restday == 1)
                    restday = "Monday";
                else if (schedule.Restday == 2)
                    restday = "Tuesday";
                else if (schedule.Restday == 3)
                    restday = "Wednesday";
                else if (schedule.Restday == 4)
                    restday = "Thursday";
                else if (schedule.Restday == 5)
                    restday = "Friday";
                else if (schedule.Restday == 6)
                    restday = "Saturday";
                else if (schedule.Restday == 7)
                    restday = "Sunday";

                txtEffectDate.Text = schedule.EffectDate.ToString("MMMM dd, yyyy");
                txtFloor.Text = floor;
                txtBioId.Text = schedule.MachineId.ToString();
                txtRestday.Text = restday;
                txtLastModified.Text = schedule.LastModified;

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Sunday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleSunday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleSunday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Monday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleMonday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleMonday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Tuesday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleTuesday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleTuesday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Wednesday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleWednesday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleWednesday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Thursday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleThursday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleThursday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Friday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleFriday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleFriday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() => { return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == schedule.Saturday); })
                    .ContinueWith(a =>
                    {
                        ShiftingSchedule result = a.Result;
                        if (result != null)
                            ucScheduleSaturday.LoadSchedule(new Schedule(result));
                        else
                            ucScheduleSaturday.LoadSchedule(Schedule.Empty);
                    }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
                ClearText();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            EmployeeShifting shifting = this.sourceHistory.Current as EmployeeShifting;

            if (shifting != null)
            {
                UsrCntrlEmployeeScheduleCreateUpdate.Instance.LoadData
                (this.employee, this.sourceHistory.Current as EmployeeShifting, TimeKeepingCode.UserAction.Update);
                this.Parent.Controls.Add(UsrCntrlEmployeeScheduleCreateUpdate.Instance);
                UsrCntrlEmployeeScheduleCreateUpdate.Instance.BringToFront();
            }
            else
                MessageBox.Show("Select Schedule to Update.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ClearText() 
        {
            txtEffectDate.Text = string.Empty;
            txtFloor.Text = string.Empty;
            txtBioId.Text = string.Empty;
            txtRestday.Text = string.Empty;
            txtLastModified.Text = string.Empty;

            ucScheduleSunday.ClearText();
            ucScheduleMonday.ClearText();
            ucScheduleTuesday.ClearText();
            ucScheduleWednesday.ClearText();
            ucScheduleThursday.ClearText();
            ucScheduleFriday.ClearText();
            ucScheduleSaturday.ClearText();
        }

        private void KeyEvent(object sender,KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.F6)
                ucBasicEmployeeProfile.Focus();
            if (e.KeyCode == Keys.F1)
                CreateClick(sender, e);
            else if (e.KeyCode == Keys.F2)
                UpdateClick(sender, e);
            else if (e.KeyCode == Keys.Delete) {

                if (MessageBox.Show("Are you sure to Delete Shifting?", "Delete Shifting", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var shifting = this.sourceHistory.Current as EmployeeShifting;
                if (shifting != null)
                {
                    if (EmployeeShifting.DeleteShifting(TimeKeepingCode.Program.BiometricsConnection, shifting))
                        LoadScheduleHistory(this.employee);
                    else
                        MessageBox.Show("Failed to Delete Shift.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Can't Delete With No Selected Shifting.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void EffectDateKeyDow(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFloor.Focus();
            else
                KeyEvent(sender,e);
        }

        private void FloorKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBioId.Focus();
            else
                KeyEvent(sender,e);
        }

        private void BioIdKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRestday.Focus();
            else
                KeyEvent(sender,e);
        }

        private void CreatedKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLastModified.Focus();
            else
                KeyEvent(sender,e);
        }

        private void LastModifiedKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEffectDate.Focus();
            else
                KeyEvent(sender,e);
        }

        private void SetControls() 
        {
            btnCreateSchedule.BackColor = Code.Program.MainColor;
            btnUpdateSchedule.BackColor = Code.Program.MainColor;

            btnCreateSchedule.ForeColor = Code.Program.TextColor;
            btnUpdateSchedule.ForeColor = Code.Program.TextColor;

            gridHistory.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridHistory.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridHistory.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridHistory.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
        }

        private void SetImage() 
        {
            this.btnUpdateSchedule.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            this.btnCreateSchedule.Image = global::TimeKeepingSystemUI.Properties.Resources.addNew15;
        }

        private void RestdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLastModified.Focus();
            else
                KeyEvent(sender,e);
        }
    }
}
