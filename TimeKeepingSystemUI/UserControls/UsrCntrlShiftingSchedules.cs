using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlShiftingSchedules : UserControl
    {
        private BindingSource sourceList;
        private TimeKeepingCode.UserAction action;
        private DateTime serverDate;
        public UsrCntrlShiftingSchedules()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridScheduleList.AutoGenerateColumns = false;

            this.sourceList = new BindingSource();
            this.gridScheduleList.DataSource = this.sourceList;

            this.sourceList.CurrentChanged += SelectedCurrentChanged;
            ReadOnlyFields(true);
            this.action = TimeKeepingCode.UserAction.View;
        }

        private void SelectedCurrentChanged(object sender,EventArgs e) 
        {
            LoadDetails(this.sourceList.Current as ShiftingSchedule);
        }

        private static UsrCntrlShiftingSchedules instance;
        public static UsrCntrlShiftingSchedules Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlShiftingSchedules();
                    instance.Name = "singletonUsrCntrlShiftingSchedules";
                }
                return instance;
            }
        }

        private void SetControls() {
            btnOne.BackColor = Code.Program.MainColor;
            btnOne.ForeColor = Code.Program.TextColor;

            btnTwo.BackColor = Code.Program.MainColor;
            btnTwo.ForeColor = Code.Program.TextColor;

            gridScheduleList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridScheduleList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridScheduleList.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridScheduleList.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbShifting.ForeColor = Code.Program.MainColor;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            SetImage();
            SetControls();
            View(true);
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingCode.Program.ShiftingSchedule.FindAll(s => s.IsActive);
            }).ContinueWith(a => {
                this.sourceList.DataSource = a.Result;
                this.sourceList.ResetBindings(false);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());

            cmbScheduleType.DataSource = TimeKeepingCode.Program.ScheduleType;
            cmbShiftingType.DataSource = TimeKeepingCode.Program.ShiftingTypes;

            cmbScheduleType.DisplayMember = "ScheduleName";
            cmbShiftingType.DisplayMember = "ShiftType";
        }

        private void LoadDetails(ShiftingSchedule schedule) {
            if (schedule != null)
            {
                ScheduleType st = TimeKeepingCode.Program.ScheduleType.Find(t => t.Id == schedule.ScheduleType);
                ShiftingType shT = TimeKeepingCode.Program.ShiftingTypes.Find(t => t.Pk == schedule.ShiftingType);

                cmbScheduleType.Text = st != null ? st.ScheduleName : string.Empty;
                txtShiftingName.Text = schedule.ShiftingName;
                cmbShiftingType.Text = shT != null ? shT.ShiftType : string.Empty;
                txtAmIn.Text = schedule.StringAMIn;
                txtLunchOut.Text = schedule.StringLunchOut;
                txtLunchIn.Text = schedule.StringLunchIn;
                txtCoffeeOut.Text = schedule.StringCoffeeOut;
                txtCoffeeIn.Text = schedule.StringCoffeeIn;
                txtPmOut.Text = schedule.StringPmOut;
                txtLunch.Text = schedule.Lunchtime + " mins";
                txtBreak.Text = schedule.Breaktime + " mins";
                chkIsFixed.Checked = schedule.IsFixed;
                txtLastModified.Text = schedule.LastModified;
            }
            else
                EmptyFields();
        }

        private void EmptyFields() {
            cmbScheduleType.Text = string.Empty;
            txtShiftingName.Text = string.Empty;
            cmbShiftingType.Text = string.Empty;
            txtAmIn.Text = string.Empty;
            txtLunchOut.Text = string.Empty;
            txtLunchIn.Text = string.Empty;
            txtCoffeeOut.Text = string.Empty;
            txtCoffeeIn.Text = string.Empty;
            txtPmOut.Text = string.Empty;
            txtLunch.Text = string.Empty;
            txtBreak.Text = string.Empty;
            chkIsFixed.Checked = false;
            txtLastModified.Text = string.Empty;

            if (cmbScheduleType.Items.Count > 0)
                cmbScheduleType.SelectedIndex = 0;

            if (cmbShiftingType.Items.Count > 0)
                cmbShiftingType.SelectedIndex = 0;
        }

        private void Search(string search) {
            this.sourceList.SuspendBinding();
            this.sourceList.DataSource = TimeKeepingCode.Program.
                ShiftingSchedule.FindAll(s => s.ShiftingName.ToLower().Contains(search.ToLower()) && s.IsActive);
            this.sourceList.ResumeBinding();
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void SearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                gridScheduleList.Focus();
            else
                KeyEvent(sender,e);
        }

        private void GridListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gridScheduleList.SelectedRows[0].Index == 0)
                    txtSearch.Focus();
            }
            else
                KeyEvent(sender, e);
        }

        private void ReadOnlyFields(bool b) 
        {
            cmbScheduleType.Enabled = !b;
            txtShiftingName.ReadOnly = b;
            cmbShiftingType.Enabled = !b;
            txtAmIn.ReadOnly = b;
            txtLunchOut.ReadOnly = b;
            txtLunchIn.ReadOnly = b;
            txtCoffeeOut.ReadOnly = b;
            txtCoffeeIn.ReadOnly = b;
            txtPmOut.ReadOnly = b;
            chkIsFixed.Enabled = !b;
            txtSearch.ReadOnly = !b;
            gridScheduleList.Enabled = b;
        }

        private void KeyEvent(object sender,KeyEventArgs e) 
        {
            if (this.action == TimeKeepingCode.UserAction.View) {
                if (e.KeyCode == Keys.Escape)
                    this.Dispose();
                else if (e.KeyCode == Keys.F1)
                    ButtonOneClick(sender, e);
                else if (e.KeyCode == Keys.F2)
                    ButtonTwoClick(sender,e);
            }
            else if (this.action == TimeKeepingCode.UserAction.Create || 
                this.action == TimeKeepingCode.UserAction.Update) {

                    if (e.KeyCode == Keys.F5)
                        ButtonOneClick(sender, e);
                    else if (e.KeyCode == Keys.Escape)
                        ButtonTwoClick(sender,e);
            }
        }

        private void ButtonOneClick(object sender,EventArgs e) {
           
            if (this.action == TimeKeepingCode.UserAction.View)
                CreateClick();
            else
                SaveClick();
        }

        private void ButtonTwoClick(object sender,EventArgs e) {
            if (this.action != TimeKeepingCode.UserAction.View)
                CancelClick();
            else 
                MessageBox.Show("Can't Allow Update Shifting Schedule.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void CreateClick() {
            if (!IsAuthorized.IsHaveUserAccess(Roles.ShiftingSchedule, TimeKeepingCode.UserRoles.CanCreate))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            ReadOnlyFields(false);
            EmptyFields();
            this.action = TimeKeepingCode.UserAction.Create;
            cmbScheduleType.Focus();
            View(false);
        }

        private void ScheduleTypeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtShiftingName.Focus();
            else
                KeyEvent(sender,e);
        }

        private void ShiftingNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbShiftingType.Focus();
            else
                KeyEvent(sender,e);
        }

        private void ShiftingTypeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAmIn.Focus();
            else
                KeyEvent(sender,e);
        }

        private void AMInKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLunchOut.Focus();
            else
                KeyEvent(sender, e);
        }

        private void LunchOutKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLunchIn.Focus();
            else
                KeyEvent(sender,e);
        }

        private void LunchInKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCoffeeOut.Focus();
            else
                KeyEvent(sender, e);
        }

        private void CoffeeOutKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCoffeeIn.Focus();
            else
                KeyEvent(sender,e);
        }

        private void CoffeeInKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPmOut.Focus();
            else
                KeyEvent(sender,e);
        }

        private void PmOutKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLunch.Focus();
            else
                KeyEvent(sender, e);
        }

        private void LunchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBreak.Focus();
            else
                KeyEvent(sender,e);
        }

        private void BreakKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                chkIsFixed.Focus();
            else
                KeyEvent(sender,e);
        }

        private void IsFixedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLastModified.Focus();
            else
                KeyEvent(sender,e);
        }

        private void LastModifiedKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbScheduleType.Focus();
            else
                KeyEvent(sender,e);
        }

        private void ScheduleTypeSelectedChanged(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Update ||
                this.action == TimeKeepingCode.UserAction.Create) 
            {
                ScheduleType st = cmbScheduleType.SelectedItem as ScheduleType;

                if (st.Id == 2) {
                    txtLunchOut.Text = string.Empty;
                    txtLunchIn.Text = string.Empty;
                    txtLunch.Text = string.Empty;

                    txtLunchOut.ReadOnly = !false;
                    txtLunchIn.ReadOnly = !false;
                    txtCoffeeIn.ReadOnly = !true;
                    txtCoffeeOut.ReadOnly = !true;
                }
                else if (st.Id == 3) {
                    txtCoffeeOut.Text = string.Empty;
                    txtCoffeeIn.Text = string.Empty;
                    txtBreak.Text = string.Empty;

                    txtLunchOut.ReadOnly = !true;
                    txtLunchIn.ReadOnly = !true;
                    txtCoffeeIn.ReadOnly = !false;
                    txtCoffeeOut.ReadOnly = !false;
                }
                else if (st.Id == 4)
                {
                    txtLunchIn.Text = string.Empty;
                    txtLunchOut.Text = string.Empty;
                    txtCoffeeOut.Text = string.Empty;
                    txtCoffeeIn.Text = string.Empty;
                    txtLunch.Text = string.Empty;
                    txtBreak.Text = string.Empty;

                    txtLunchOut.ReadOnly = !false;
                    txtLunchIn.ReadOnly = !false;
                    txtCoffeeIn.ReadOnly = !false;
                    txtCoffeeOut.ReadOnly = !false;
                }
                else {
                    txtLunchOut.ReadOnly = false;
                    txtLunchIn.ReadOnly = false;
                    txtCoffeeIn.ReadOnly = false;
                    txtCoffeeOut.ReadOnly = false;
                }
            }
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

        private void AMInValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtAmIn, out date))
                e.Cancel = true;
        }

        private void LunchOutValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtLunchOut, out date))
                e.Cancel = true;
            else
                txtLunch.Text = CalculateTime(txtLunchOut,txtLunchIn) + " mins";
        }

        private bool ValidateText(TextBox textBox,out DateTime date)
        {
            bool result = true;
            DateTime vDate = TimeKeepingCode.Program.DefaultDate;
            if (this.action == TimeKeepingCode.UserAction.Create ||
                this.action == TimeKeepingCode.UserAction.Update)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (IsTimeValid(textBox.Text, out vDate))
                    {
                        textBox.Text = vDate.ToString("hh:mm tt");
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Time Format. Ex (1630,16:30,04:30 PM)", "Invalid Format",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                        result = false;
                    }
                }
            }
            date = vDate;
            return result;
        }

        private void LunchInValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtLunchIn, out date))
                e.Cancel = true;
            else
                txtLunch.Text = CalculateTime(txtLunchOut, txtLunchIn) + " mins";
        }

        private void CoffeeOutValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtCoffeeOut, out date))
                e.Cancel = true;
            else
                txtBreak.Text = CalculateTime(txtCoffeeOut, txtCoffeeIn) + " mins";
        }

        private void CoffeeInValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtCoffeeIn, out date))
                e.Cancel = true;
            else
                txtBreak.Text = CalculateTime(txtCoffeeOut, txtCoffeeIn) + " mins";
        }

        private void PmOutValidating(object sender, CancelEventArgs e)
        {
            DateTime date;
            if (!ValidateText(txtPmOut, out date))
                e.Cancel = true;
        }

        private int CalculateTime(TextBox text1, TextBox text2) {
            int result = 0;
            if (!string.IsNullOrWhiteSpace(text1.Text) && !string.IsNullOrWhiteSpace(text2.Text)) {
                result = (int)Convert.ToDateTime(text2.Text).TimeOfDay.Subtract(Convert.ToDateTime(text1.Text).TimeOfDay).TotalMinutes;
            }
            return result;
        }

        private void View(bool b) {
            if (b)
            {
                btnOne.Text = "CREATE";
                btnTwo.Text = "UPDATE";

                btnOne.Image = global::TimeKeepingSystemUI.Properties.Resources.addNew15;
                btnTwo.Image = global::TimeKeepingSystemUI.Properties.Resources.edit15;
            }
            else {
                btnOne.Text = "SAVE";
                btnTwo.Text = "CANCEL";

                btnOne.Image = global::TimeKeepingSystemUI.Properties.Resources.save15;
                btnTwo.Image = global::TimeKeepingSystemUI.Properties.Resources.cancel15;
            }
        }

        private ShiftingSchedule CreateShiftingSchedule() {

            ScheduleType st = cmbScheduleType.SelectedItem as ScheduleType;
            ShiftingType sht = cmbShiftingType.SelectedItem as ShiftingType;

            int id = 0;

            if (this.action == TimeKeepingCode.UserAction.Update) 
                id = (this.sourceList.Current as ShiftingSchedule).Id;

            return new ShiftingSchedule(id, st.Id, txtShiftingName.Text, sht.Pk, Convert.ToDateTime(txtAmIn.Text).TimeOfDay,
                string.IsNullOrWhiteSpace(txtLunchOut.Text) ? new TimeSpan() : Convert.ToDateTime(txtLunchOut.Text).TimeOfDay,
                string.IsNullOrWhiteSpace(txtLunchIn.Text) ? new TimeSpan() : Convert.ToDateTime(txtLunchIn.Text).TimeOfDay,
                string.IsNullOrWhiteSpace(txtCoffeeOut.Text) ? new TimeSpan() : Convert.ToDateTime(txtCoffeeOut.Text).TimeOfDay,
                string.IsNullOrWhiteSpace(txtCoffeeIn.Text) ? new TimeSpan() : Convert.ToDateTime(txtCoffeeIn.Text).TimeOfDay,
                Convert.ToDateTime(txtPmOut.Text).TimeOfDay, CalculateTime(txtLunchOut, txtLunchIn), CalculateTime(txtCoffeeOut, txtCoffeeIn),
                chkIsFixed.Checked, true,this.serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName);
        }

        private void SaveClick() {
            if (this.action == TimeKeepingCode.UserAction.Create) 
            {
                if (IsFieldsValid())
                {
                    if (MessageBox.Show("Are you sure to Save Created Shifting Schedule?", "Save Created",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    if (ShiftingSchedule.CreateShiftingSchedule(TimeKeepingCode.Program.BiometricsConnection, CreateShiftingSchedule()))
                    {
                        MessageBox.Show("Created Shifting Schedule Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.action = TimeKeepingCode.UserAction.View;
                        ReadOnlyFields(true);
                        gridScheduleList.Focus();
                        TimeKeepingCode.Program.ResetShiftingSchedule();
                        View(true);
                    }
                    else
                    {
                        MessageBox.Show("Creating Shifting Schedule Failed to Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool IsFieldsValid() {
            ScheduleType st = cmbScheduleType.SelectedItem as ScheduleType;

            if (string.IsNullOrWhiteSpace(txtShiftingName.Text)) {
                IsEmptyField(txtShiftingName, "Shifting Name is Empty.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAmIn.Text)) {
                IsEmptyField(txtAmIn, "AM In is Empty.");
                return false;
            }

            if (st.Id == 1) {
                if (string.IsNullOrWhiteSpace(txtLunchOut.Text)) {
                    IsEmptyField(txtLunchOut,"Lunch Out is Empty.");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtLunchIn.Text)) { 
                    IsEmptyField(txtLunchIn,"Lunch In is Empty.");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtCoffeeOut.Text)) {
                    IsEmptyField(txtCoffeeOut, "Coffee Out is Empty.");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtCoffeeIn.Text)) {
                    IsEmptyField(txtCoffeeIn, "Coffee In is Empty");
                    return false;
                }
            }
            else if (st.Id == 2) { 
                if (string.IsNullOrWhiteSpace(txtCoffeeOut.Text)) {
                    IsEmptyField(txtCoffeeOut, "Coffee Out is Empty.");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtCoffeeIn.Text)) {
                    IsEmptyField(txtCoffeeIn, "Coffee In is Empty");
                    return false;
                }
            }
            else if (st.Id == 3) {
                if (string.IsNullOrWhiteSpace(txtLunchOut.Text))
                {
                    IsEmptyField(txtLunchOut, "Lunch Out is Empty.");
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(txtLunchIn.Text))
                {
                    IsEmptyField(txtLunchIn, "Lunch In is Empty.");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtPmOut.Text))
            {
                IsEmptyField(txtPmOut, "PM Out is Empty.");
                return false;
            }

            return true;
        }

        private void IsEmptyField(TextBox text,string message) {
            MessageBox.Show(message,"Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
            text.Focus();
        }

        private void CancelClick() {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created Shifting Schedule?", "Cancel Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                this.action = TimeKeepingCode.UserAction.View;
                ReadOnlyFields(true);
                View(true);
                LoadDetails(this.sourceList.Current as ShiftingSchedule);
                gridScheduleList.Focus();
            }
        }

        private void OnBreadcumbMouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void OnBreadcumbMouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you to Cancel Created Shifting Schedule?", "Cancel Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Cancel Updated Shiftin Schedule?", "Cancel Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            this.Dispose();
        }

        private void SetImage() {
            btnOne.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
            btnTwo.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
        }
    }   
}
