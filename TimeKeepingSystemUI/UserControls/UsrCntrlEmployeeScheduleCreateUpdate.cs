using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingCode.Code;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlEmployeeScheduleCreateUpdate : UserControl
    {
        private TimeKeepingCode.UserAction action;
        private EmployeeShifting shifting;
        private ShiftingSchedule[] selectedSchedules;
        private BasicEmployeeInfo employee;

        public UsrCntrlEmployeeScheduleCreateUpdate()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            if (cmbFloor.Items.Count > 0)
                cmbFloor.SelectedIndex = 0;
            if (cmbRestday.Items.Count > 0)
                cmbRestday.SelectedIndex = 0;

            ucSunday.SelectedSchedule += SelectedSchedule;
            ucMonday.SelectedSchedule += SelectedSchedule;
            ucTuesday.SelectedSchedule += SelectedSchedule;
            ucWednesday.SelectedSchedule += SelectedSchedule;
            ucThursday.SelectedSchedule += SelectedSchedule;
            ucFriday.SelectedSchedule += SelectedSchedule;
            ucSaturday.SelectedSchedule += SelectedSchedule;

            ucMonday.InnerKeyEvent += KeyEvent;
            ucTuesday.InnerKeyEvent += KeyEvent;
            ucWednesday.InnerKeyEvent += KeyEvent;
            ucThursday.InnerKeyEvent += KeyEvent;
            ucFriday.InnerKeyEvent += KeyEvent;
            ucSaturday.InnerKeyEvent += KeyEvent;
            ucSunday.InnerKeyEvent += KeyEvent;

            this.action = TimeKeepingCode.UserAction.View;
            this.shifting = null;
            this.selectedSchedules = new ShiftingSchedule[7];
            this.employee = null;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Cancel Changes?", "Cancel", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            UsrCntrlEmployeeSchedule.Instance.BringToFront();
            UsrCntrlEmployeeSchedule.Instance.Focus();
            this.Dispose();
        }

        private static UsrCntrlEmployeeScheduleCreateUpdate instance;
        public static UsrCntrlEmployeeScheduleCreateUpdate Instance {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlEmployeeScheduleCreateUpdate();
                    instance.Name = "singletonEmployeeScheduleCreateUpdate";
                }
                return instance;
            }
        }

        private void UCLoad(object sender, EventArgs e)
        {
            ucMonday.Focus();
            SetControls();
        }

        private void SelectedSchedule(object sender,TimeKeepingCode.Events.ShiftingScheduleOnSelectedEventArgs e) 
        {
            if (sender == ucMonday)
                this.selectedSchedules[0] = e.Selected;
            else if (sender == ucTuesday)
                this.selectedSchedules[1] = e.Selected;
            else if (sender == ucWednesday)
                this.selectedSchedules[2] = e.Selected;
            else if (sender == ucThursday)
                this.selectedSchedules[3] = e.Selected;
            else if (sender == ucFriday)
                this.selectedSchedules[4] = e.Selected;
            else if (sender == ucSaturday)
                this.selectedSchedules[5] = e.Selected;
            else if (sender == ucSunday)
                this.selectedSchedules[6] = e.Selected;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (!IsTextFieldValid())
                return;

            if (!IsScheduleValid())
                return;

            if (this.action == TimeKeepingCode.UserAction.Create) 
            {
                if (MessageBox.Show("Are You Sure to Save Created Schedule?", "Save Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (SaveCreatedSchedule())
                {
                    MessageBox.Show("Created Schedule Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsrCntrlEmployeeSchedule.Instance.LoadScheduleHistory(this.employee);
                    UsrCntrlEmployeeSchedule.Instance.BringToFront();
                    UsrCntrlEmployeeSchedule.Instance.Focus();
                    this.Dispose();
                }
                else {
                    MessageBox.Show("Created Schedule Failed to Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (MessageBox.Show("Are You Sure to Save Updated Schedule?", "Save Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (SaveUpdatedSchedule())
                {
                    MessageBox.Show("Updated Schedule Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsrCntrlEmployeeSchedule.Instance.LoadScheduleHistory(this.employee);
                    UsrCntrlEmployeeSchedule.Instance.BringToFront();
                    UsrCntrlEmployeeSchedule.Instance.Focus();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Updated Schedule Failed to Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        public void LoadData(BasicEmployeeInfo employee,EmployeeShifting shifting,TimeKeepingCode.UserAction action)
        {
            this.employee = employee;
            this.action = action;
            this.shifting = shifting;
            LoadScheduleDetails();
        }

        private void LoadScheduleDetails()
        {
            if (this.shifting != null) 
            {
                dtpDateEffect.Value = this.shifting.EffectDate;
                cmbFloor.SelectedIndex = this.shifting.MachineNo - 1;
                cmbRestday.SelectedIndex = this.shifting.Restday - 1;
                txtBioId.Text = this.shifting.MachineId.ToString();
                //txtDateCreated.Text = this.shifting.DateCreated.ToString("MMMM dd, yyyy");
                //txtCreatedBy.Text = this.shifting.CreatedBy;

                if (this.action == TimeKeepingCode.UserAction.Create) 
                {
                    DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
                    dtpDateEffect.Value = serverDate;
                    txtDateCreated.Text = serverDate.ToString("MMMM dd, yyyy");
                    txtCreatedBy.Text = "System";
                }

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Sunday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucSunday.LoadData(new Schedule(result));
                    else
                        ucSunday.LoadData(Schedule.Empty);
                    this.selectedSchedules[6] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Monday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucMonday.LoadData(new Schedule(result));
                    else
                        ucMonday.LoadData(Schedule.Empty);
                    this.selectedSchedules[0] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Tuesday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucTuesday.LoadData(new Schedule(result));
                    else
                        ucTuesday.LoadData(Schedule.Empty);
                    this.selectedSchedules[1] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Wednesday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucWednesday.LoadData(new Schedule(result));
                    else
                        ucWednesday.LoadData(Schedule.Empty);
                    this.selectedSchedules[2] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Thursday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucThursday.LoadData(new Schedule(result));
                    else
                        ucThursday.LoadData(Schedule.Empty);
                    this.selectedSchedules[3] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Friday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucFriday.LoadData(new Schedule(result));
                    else
                        ucFriday.LoadData(Schedule.Empty);
                    this.selectedSchedules[4] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                Task.Factory.StartNew(() =>
                {
                    return TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == this.shifting.Saturday);
                }).ContinueWith(a =>
                {
                    ShiftingSchedule result = a.Result;
                    if (result != null)
                        ucSaturday.LoadData(new Schedule(result));
                    else
                        ucSaturday.LoadData(Schedule.Empty);
                    this.selectedSchedules[5] = result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (this.action == TimeKeepingCode.UserAction.Create) 
            {
                txtDateCreated.Text = TimeKeepingCode.Program.BiometricsConnection.ServerDate().ToString("MMMM dd, yyyy");
                txtCreatedBy.Text = "System";
            }
        }

        private bool SaveCreatedSchedule() 
        {
            EmployeeShifting s = new EmployeeShifting(0, this.employee.PkId, this.employee.IdNumber,
                this.employee.Fullname,dtpDateEffect.Value,
                this.selectedSchedules[6].Id, this.selectedSchedules[0].Id, this.selectedSchedules[1].Id,
                this.selectedSchedules[2].Id, this.selectedSchedules[3].Id, this.selectedSchedules[4].Id,
                this.selectedSchedules[5].Id, Convert.ToInt32(txtBioId.Text), cmbFloor.SelectedIndex + 1,
                cmbRestday.SelectedIndex + 1, TimeKeepingCode.Program.User.UserName + " - " + TimeKeepingCode.Program.BiometricsConnection.ServerDate());

            return EmployeeShifting.CreateEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection,s);
        }

        private bool SaveUpdatedSchedule() 
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            this.shifting.EffectDate = dtpDateEffect.Value;
            this.shifting.MachineNo = cmbFloor.SelectedIndex + 1;
            this.shifting.Restday = cmbRestday.SelectedIndex + 1;
            this.shifting.LastModified = "Last updated by: " + TimeKeepingCode.Program.User.UserName + " on " + serverDate;
            this.shifting.Monday = this.selectedSchedules[0].Id;
            this.shifting.Tuesday = this.selectedSchedules[1].Id;
            this.shifting.Wednesday = this.selectedSchedules[2].Id;
            this.shifting.Thursday = this.selectedSchedules[3].Id;
            this.shifting.Friday = this.selectedSchedules[4].Id;
            this.shifting.Saturday = this.selectedSchedules[5].Id;
            this.shifting.Sunday = this.selectedSchedules[6].Id;

            return EmployeeShifting.UpdateEmployeeShifting(TimeKeepingCode.Program.BiometricsConnection,this.shifting);
        }

        private bool IsTextFieldValid() 
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            //if (dtpDateEffect.Value <= serverDate) {
            //    MessageBox.Show("Date should be Advance of Current Date.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    dtpDateEffect.Focus();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(cmbFloor.Text)) 
            {
                MessageBox.Show("Must have Selected Floor.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                cmbFloor.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbRestday.Text)) 
            {
                MessageBox.Show("Must have Selected Restday.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbRestday.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBioId.Text)) {
                MessageBox.Show("Must have Bio Id.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtBioId.Focus();
                return false;
            }

            return true;
        }

        private bool IsScheduleValid() {
            bool result = true;
            for (int i = 0; i < this.selectedSchedules.Length; i++)
            {
                if (this.selectedSchedules[i] == null)
                {
                    if (i == 0){
                        MessageBox.Show("Monday Schedule not Assign.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        ucMonday.Focus();
                    }
                    else if(i == 1){
                        MessageBox.Show("Tuesday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucTuesday.Focus();
                    }
                    else if (i == 2) {
                        MessageBox.Show("Wednesday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucWednesday.Focus();
                    }
                    else if (i == 3) {
                        MessageBox.Show("Thursday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucThursday.Focus();
                    }
                    else if (i == 4) {
                        MessageBox.Show("Friday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucFriday.Focus();
                    }
                    else if (i == 5) {
                        MessageBox.Show("Saturday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucSaturday.Focus();
                    }
                    else if (i == 6) {
                        MessageBox.Show("Sunday Schedule not Assign.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ucSunday.Focus();
                    }

                    return false;
                }
            }

            return result;
        }

        private void GenerateId(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBioId.Text))
                MessageBox.Show("Already have Bio Id.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
                txtBioId.Text = EmployeeShifting.GenerateRandomBioID(TimeKeepingCode.Program.BiometricsConnection).ToString();
        }

        private void DateEffectKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbFloor.Focus();
            else
                KeyEvent(sender,e);
        }

        private void FloorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRestday.Focus();
            else
                KeyEvent(sender, e);
        }

        private void RestdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBioId.Focus();
            else
                KeyEvent(sender, e);
        }

        private void BioIdKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDateCreated.Focus();
            else
                KeyEvent(sender, e);
        }

        private void DateCreatedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCreatedBy.Focus();
            else
                KeyEvent(sender, e);
        }

        private void CreatedByKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGenerateId.Focus();
            else
                KeyEvent(sender, e);
        }

        private void GenerateIdKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateEffect.Focus();
            else
                KeyEvent(sender, e);
        }

        private void KeyEvent(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape)
                CancelClick(selectedSchedules, e);
            else if (e.KeyCode == Keys.F5)
                SaveClick(selectedSchedules,e);
        }

        private void SetControls() 
        {
            btnSave.BackColor = Code.Program.MainColor;
            btnCancel.BackColor = Code.Program.MainColor;
            btnGenerateId.BackColor = Code.Program.MainColor;

            btnSave.ForeColor = Code.Program.TextColor;
            btnCancel.ForeColor = Code.Program.TextColor;
            btnGenerateId.ForeColor = Code.Program.TextColor;

            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbSchedule.ForeColor = Code.Program.MainColor;
        }

        private void OnBreadcumbEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void OnBreadcumbLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            CancelClick(sender,e);
        }

        private void SetImage() 
        {
            this.btnCancel.Image = TimeKeepingSystemUI.Properties.Resources.cancel15;
            this.btnSave.Image = TimeKeepingSystemUI.Properties.Resources.save15;
        }
    }
}
