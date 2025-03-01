using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;
using System.Drawing;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmCasherCheckerSettings : Form
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        private List<CasherCheckerPOS> posList;
        private List<ShiftingSchedule> schedules;

        private TimeKeepingCode.UserAction posAction;
        private TimeKeepingCode.UserAction shiftingAction;
        private TimeKeepingCode.UserAction posShiftingAction;

        private System.Windows.Forms.Timer t;

        public FrmCasherCheckerSettings()
        {
            InitializeComponent();

            this.tokenSource = new CancellationTokenSource();
            this.token = this.tokenSource.Token;
            this.posList = new List<CasherCheckerPOS>();
            this.schedules = new List<ShiftingSchedule>();

            this.posAction = TimeKeepingCode.UserAction.View;
            this.shiftingAction = TimeKeepingCode.UserAction.View;
            this.posShiftingAction = TimeKeepingCode.UserAction.View;

            cmbPosShiftingPos.DisplayMember = "POS";
            cmbPosShiftingShifting.DisplayMember = "ShiftingType";
            cmbType.SelectedIndex = 0;
            t = new System.Windows.Forms.Timer();
        }

        private static FrmCasherCheckerSettings instance;
        public static FrmCasherCheckerSettings Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new FrmCasherCheckerSettings();
                    instance.Name = "singletonFrmCasherCheckerSettings";
                }
                return instance;
            }
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

        private void OnLoad(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();

            SetControls();
            LoadPOS();
            LoadSchedule();
            LoadPosShifting();
            Viewable(true);
            ViewableShifting(true);
            SetImage();
            SetDefaults();
        }

        private void SetDefaults() 
        {
            Task.Factory.StartNew(() =>
            {
                return CasherCheckerDefaults.GetDefaults(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a => {
                var result = a.Result;
                if (result != null) { 
                    switch(result.Restday){
                        case 0:
                            cmbRestday.Text = "UnAssigned";
                            break;
                        case 1:
                            cmbRestday.Text = "Monday";
                            break;
                        case 2:
                            cmbRestday.Text = "Tuesday";
                            break;
                        case 3:
                            cmbRestday.Text = "Wednesday";
                            break;
                        case 4:
                            cmbRestday.Text = "Thursday";
                            break;
                        case 5:
                            cmbRestday.Text = "Friday";
                            break;
                        case 6:
                            cmbRestday.Text = "Saturday";
                            break;
                        case 7:
                            cmbRestday.Text = "Sunday";
                            break;
                    }
                    cmbShifting.SelectedIndex = a.Result.Shifting;
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetControls() {
            btnOne.BackColor = Code.Program.MainColor;
            btnOne.ForeColor = Code.Program.TextColor;
            btnTwo.BackColor = Code.Program.MainColor;
            btnTwo.ForeColor = Code.Program.TextColor;

            gridPOSList.BackgroundColor = Code.Program.MainColor;
            gridPOSList.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridPOSList.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridPOSList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridPOSList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            gridScheduleList.BackgroundColor = Code.Program.MainColor;
            gridScheduleList.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridScheduleList.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridScheduleList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridScheduleList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            gridPosShifting.BackgroundColor = Code.Program.MainColor;
            gridPosShifting.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridPosShifting.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridPosShifting.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridPosShifting.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            btnShiftingOne.BackColor = Code.Program.MainColor;
            btnShiftingOne.ForeColor = Code.Program.TextColor;
            btnShiftingTwo.BackColor = Code.Program.MainColor;
            btnShiftingTwo.ForeColor = Code.Program.TextColor;

            btnPosShiftingOne.BackColor = Code.Program.MainColor;
            btnPosShiftingTwo.BackColor = Code.Program.MainColor;
            btnPosShiftingOne.ForeColor = Code.Program.TextColor;
            btnPosShiftingTwo.ForeColor = Code.Program.TextColor;

            btnPosShiftingAdd.BackColor = Code.Program.MainColor;
            btnPosShiftingRemove.BackColor = Code.Program.MainColor;
            btnPosShiftingAdd.ForeColor = Code.Program.TextColor;
            btnPosShiftingRemove.ForeColor = Code.Program.TextColor;

            btnPosShiftingAssign.BackColor = Code.Program.MainColor;
            btnPosShiftingCancelAssign.BackColor = Code.Program.MainColor;
            btnPosShiftingAssign.ForeColor = Code.Program.TextColor;
            btnPosShiftingCancelAssign.ForeColor = Code.Program.TextColor;

            lblSelectedPOS.ForeColor = Code.Program.MainColor;
            lblShitingCount.ForeColor = Code.Program.MainColor;
            lblPosShiftingCount.ForeColor = Code.Program.MainColor;
        }

        private void LoadPOS() {
            Task.Factory.StartNew(() =>
            {
                this.posList = CasherCheckerPOS.GetAllCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a => {
                LoadGridData();
            },token,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            this.tokenSource.Cancel();

            e.Cancel = true;
            t.Tick -= FadeIn;
            t.Tick += new EventHandler(FadeOut);
            t.Start();

            if (Opacity == 0)
                e.Cancel = false;
        }

        private void Add() {
            this.posAction = TimeKeepingCode.UserAction.Create;
            gridPOSList.Rows.Add();
            gridPOSList.FirstDisplayedScrollingRowIndex = this.gridPOSList.Rows.Count - 1;
            gridPOSList.CurrentCell = gridPOSList.Rows[gridPOSList.Rows.Count - 1].Cells[1];
            gridPOSList.AllowUserToAddRows = true;
            gridPOSList.BeginEdit(false);
        }

        private void UpdateSettings() {
            this.posAction = TimeKeepingCode.UserAction.Update;
            for (int i = 0; i < gridPOSList.Rows.Count; i++)
            {
                gridPOSList.Rows[i].ReadOnly = false;
            }
            gridPOSList.BeginEdit(false);
        }

        private void Cancel() {
            if (this.posAction == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created POS?", "Cancel Created",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    gridPOSList.Focus();
                    return;
                }
            }
            else if (this.posAction == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Cancel Updated POS?", "Cancel Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    gridPOSList.Focus();
                    return;
                }
            }

            this.posAction = TimeKeepingCode.UserAction.View;
            gridPOSList.EndEdit();
            gridPOSList.AllowUserToAddRows = false;
            LoadGridData();
        }

        private List<CasherCheckerPOS> CreateListCasherPOS() {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            List<CasherCheckerPOS> list = new List<CasherCheckerPOS>();
            for (int i = 0; i < gridPOSList.Rows.Count; i++)
            {
                if (!gridPOSList.Rows[i].ReadOnly)
                {
                    if (gridPOSList.Rows[i].Cells[1].Value != null &&
                        !string.IsNullOrWhiteSpace(gridPOSList.Rows[i].Cells[1].Value.ToString()))
                    {
                        int id = gridPOSList.Rows[i].Cells[0].Value == null ? 0 : Convert.ToInt32(gridPOSList.Rows[i].Cells[0].Value);
                        list.Add(new CasherCheckerPOS(id, gridPOSList.Rows[i].Cells[1].Value.ToString(),
                            Convert.ToBoolean(gridPOSList.Rows[i].Cells[2].Value), serverDate, TimeKeepingCode.Program.User.UserName));
                    }
                }
            }
            return list;
        }

        private bool SaveCreated() {
            var list = CreateListCasherPOS();
            return CasherCheckerPOS.CreateCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection,list);
        }

        private bool SaveUpdated() {
            var list = CreateListCasherPOS();
            return CasherCheckerPOS.UpdateCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection,list);
        }

        private void ButtonOneClick(object sender, EventArgs e)
        {
            if (this.posAction == TimeKeepingCode.UserAction.View) {
                Add();
                Viewable(false);
            }
            else if (this.posAction == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Save Created POS?", "Save Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                if (SaveCreated())
                {
                    gridPOSList.AllowUserToAddRows = false;
                    SaveSuccess();
                    MessageBox.Show("Created POS Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Created POS Failed to Save.","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    gridPOSList.Focus();
                }
            }
            else if (this.posAction == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Save Updated POS?", "Save Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                if (SaveUpdated())
                {
                    SaveSuccess();
                    MessageBox.Show("Updated POS Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Updated POS Failed to Save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    gridPOSList.Focus();
                }
            }
        }

        private void SaveSuccess() {
            this.posList = CasherCheckerPOS.GetAllCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection);
            LoadGridData();
            Viewable(true);
            this.posAction = TimeKeepingCode.UserAction.View;
        }

        private void LoadGridData() {
            gridPOSList.Rows.Clear();
            int availablePOs = 0;
            var list = this.posList.OrderBy(a => a.POS).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                gridPOSList.Rows.Add(list[i].Id, list[i].POS, list[i].IsOpen);
                gridPOSList.Rows[i].ReadOnly = true;
                if (list[i].IsOpen)
                    availablePOs++;
            }
            lblSelectedPOS.Text = "Available POS: " + availablePOs;
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

        private void Viewable(bool b) {
            if (b)
            {
                btnOne.Text = "ADD";
                btnTwo.Text = "UPDATE";
            }
            else {
                btnOne.Text = "SAVE";
                btnTwo.Text = "CANCEL";
            }
        }

        private void ButtonTwoClick(object sender, EventArgs e)
        {
            if (this.posAction == TimeKeepingCode.UserAction.Create ||
                this.posAction == TimeKeepingCode.UserAction.Update) {
                    Cancel();
                    Viewable(true);
            }
            else if (this.posAction == TimeKeepingCode.UserAction.View) {
                UpdateSettings();
                Viewable(false);
            }
        }

        private void SearchEnter(object sender, EventArgs e)
        {
            gridSearchResult.Visible = true;
        }

        private void SearchLeave(object sender, EventArgs e)
        {
            if (!gridSearchResult.Focused)
            {
                gridSearchResult.Visible = false;
                ClearGridSearch();
            }
        }

        private void GridSearchResultLeave(object sender, EventArgs e)
        {
            if (!txtSearchSchedule.Focused)
            {
                gridSearchResult.Visible = false;
                ClearGridSearch();
            }
        }

        private void AddShiftingSchedule() {
            this.shiftingAction = TimeKeepingCode.UserAction.Create;
            ViewableShifting(false);
            txtSearchSchedule.Focus();
        }

        private void ViewableShifting(bool b) {
            if (b)
            {
                btnShiftingOne.Text = "ADD";
                btnShiftingTwo.Text = "Delete";
            }
            else {
                btnShiftingOne.Text = "SAVE";
                btnShiftingTwo.Text = "CANCEL";
            }

            lblSearchschedule.Visible = !b;
            txtSearchSchedule.Visible = !b;
        }

        private void ButtonShiftingOneClick(object sender, EventArgs e)
        {
            if (this.shiftingAction == TimeKeepingCode.UserAction.View) {
                AddShiftingSchedule();
            }
            else if (this.shiftingAction == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Save Selected Schedules?", "Save Selected", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                if (SaveSelectedSchedule())
                {
                    this.schedules = ShiftingSchedule.GetAllCasherCheckerSchedulePicker(TimeKeepingCode.Program.BiometricsConnection);
                    this.shiftingAction = TimeKeepingCode.UserAction.View;
                    ViewableShifting(true);
                    gridScheduleList.Focus();
                    MessageBox.Show("Selected Schedules Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Selected Schedules Failed to Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    gridScheduleList.Focus();
                }
            }
        }

        private void SearchSchedule(string text) {
            gridSearchResult.Rows.Clear();
            var schedules = TimeKeepingCode.Program.ShiftingSchedule.FindAll(s => s.ShiftingName.ToLower().Contains(text.ToLower()) && s.IsActive);
            for (int i = 0; i < schedules.Count; i++)
            {
                var type = TimeKeepingCode.Program.ShiftingTypes.Find(s => s.Pk == schedules[i].ShiftingType);
                gridSearchResult.Rows.Add(schedules[i].Id,type != null ? type.ShiftType : "",schedules[i].ShiftingName);
            }
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtSearchSchedule.Text))
                SearchSchedule(txtSearchSchedule.Text);
        }

        private void ClearGridSearch() {
            txtSearchSchedule.Text = string.Empty;
            gridSearchResult.Rows.Clear();
        }

        private void SearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (gridSearchResult.SelectedRows.Count > 0)
                {
                    if (gridSearchResult.SelectedRows[0].Index + 1 <= gridSearchResult.Rows.Count -1)
                    {
                        int lastIndex = gridSearchResult.SelectedRows[0].Index;
                        gridSearchResult.Rows[lastIndex].Selected = false;
                        gridSearchResult.CurrentCell = gridSearchResult.Rows[lastIndex + 1].Cells[1];
                        gridSearchResult.Rows[lastIndex + 1].Selected = true;
                        gridSearchResult.Focus();
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Selected();
            }
            else if (e.KeyCode == Keys.Escape)
                gridScheduleList.Focus();
        }

        private void GridSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gridSearchResult.SelectedRows.Count > 0)
                {
                    if (gridSearchResult.SelectedRows[0].Index == 0)
                        txtSearchSchedule.Focus();
                }
                else
                    txtSearchSchedule.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
                Selected();
            else if (e.KeyCode == Keys.Escape)
                txtSearchSchedule.Focus();
        }

        private void Selected() {
            if (gridSearchResult.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(gridSearchResult.SelectedRows[0].Cells[0].Value);
                if (IsAlreadySelected(id)) {
                    MessageBox.Show("Selected Schedule Already in the List.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return;
                }
                SelectSchedule(id);
            }
        }

        private void SelectSchedule(int id) {
            var schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == id);
            if (schedule != null) {
                var type = TimeKeepingCode.Program.ShiftingTypes.Find(s => s.Pk == schedule.ShiftingType);
                gridScheduleList.Rows.Add(schedule.Id,schedule.ShiftingName,type != null ? type.ShiftType : "",
                    schedule.StringAMIn,schedule.StringLunchOut,schedule.StringLunchIn,schedule.StringCoffeeOut,
                    schedule.StringCoffeeIn,schedule.StringPmOut);
            }
        }

        private bool IsAlreadySelected(int id) {
            for (int i = 0; i < gridScheduleList.Rows.Count; i++)
            {
                int sId = Convert.ToInt32(gridScheduleList.Rows[i].Cells[0].Value);
                if (id == sId)
                    return true;
            }
            return false;
        }

        private void LoadSchedule() 
        {
            Task.Factory.StartNew(() =>
            {
                this.schedules = ShiftingSchedule.GetAllCasherCheckerSchedulePicker(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a => {
                LoadSchedules();
            },this.token,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());    
        }

        private void LoadSchedules() {
            gridScheduleList.Rows.Clear();
            var schedules = this.schedules.OrderBy(a => a.ShiftingName).ToList();
            for (int i = 0; i < schedules.Count; i++)
            {
                var type = TimeKeepingCode.Program.ShiftingTypes.Find(s => s.Pk == schedules[i].ShiftingType);
                gridScheduleList.Rows.Add(schedules[i].Id, schedules[i].ShiftingName, type != null ? type.ShiftType : "",
                    schedules[i].StringAMIn, schedules[i].StringLunchOut, schedules[i].StringLunchIn,
                    schedules[i].StringCoffeeOut, schedules[i].StringCoffeeIn, schedules[i].StringPmOut);
            }
            lblShitingCount.Text = "No. Shiftings: " + schedules.Count;
        }

        private bool SaveSelectedSchedule() {
            List<ShiftingSchedule> schedules = new List<ShiftingSchedule>();
            for (int i = 0; i < gridScheduleList.Rows.Count; i++)
            {
                var schedule = TimeKeepingCode.Program.ShiftingSchedule.Find(s => s.Id == 
                    Convert.ToInt32(gridScheduleList.Rows[i].Cells[0].Value));
                if (schedule != null)
                    schedules.Add(schedule);
            }
            return ShiftingSchedule.CreateCasherCheckerShiftingPicker(TimeKeepingCode.Program.BiometricsConnection,schedules);
        }

        private void CancelSelectedSchedule() {
            if (MessageBox.Show("Are you sure to Cancel Selected?", "Cancel", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            this.shiftingAction = TimeKeepingCode.UserAction.View;
            ViewableShifting(true);
            LoadSchedule();
            gridScheduleList.Focus();
        }

        private void DeleteSelectedSchedule() {
            if (gridScheduleList.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure to Delete Selected Schedule?", "Delete Selected", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                int id = Convert.ToInt32(gridScheduleList.SelectedRows[0].Cells[0].Value);
                if (ShiftingSchedule.DeleteCasherCheckerShiftingPicker(TimeKeepingCode.Program.BiometricsConnection, id))
                    LoadSchedule();
                else
                    MessageBox.Show("Error When Deleting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("Select Schedule to Delete.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                gridScheduleList.Focus();
            }
        }

        private void ButtonShiftingTwoClick(object sender, EventArgs e)
        {
            if (this.shiftingAction == TimeKeepingCode.UserAction.Create)
                CancelSelectedSchedule();
            else if (this.shiftingAction == TimeKeepingCode.UserAction.View)
                DeleteSelectedSchedule();
        }

        private void ViewablePosShifting(bool b) {
            if (b)
                btnPosShiftingTwo.Text = "UPDATE";
            else
                btnPosShiftingTwo.Text = "CANCEL";

            btnPosShiftingOne.Visible = !b;
            btnPosShiftingAdd.Visible = !b;
            btnPosShiftingRemove.Visible = !b;
        }

        private void ButtonPosShiftingTwoClick(object sender, EventArgs e)
        {
            if (this.posShiftingAction == TimeKeepingCode.UserAction.View)
            {
                ViewablePosShifting(false);
                this.posShiftingAction = TimeKeepingCode.UserAction.Update;
            }
            else
            {
                ViewablePosShifting(true);
                this.posShiftingAction = TimeKeepingCode.UserAction.View;
            }
        }

        private void ButtonAssignPosShiftingCancel(object sender, EventArgs e)
        {
            pnlPosShiftingAdd.Visible = false;
        }

        private void ButtonPosShiftingAssignAdd(object sender, EventArgs e)
        {
            pnlPosShiftingAdd.Visible = !false;
            cmbPosShiftingPos.Focus();
        }

        private void TabSettingsIndexChanged(object sender, EventArgs e)
        {
            if (tabSettings.SelectedIndex == 2) {
                List<TimeKeepingCode.Code.ShiftingScheduleWithType> list = new List<TimeKeepingCode.Code.ShiftingScheduleWithType>();
                for (int i = 0; i < this.schedules.Count; i++)
                {
                    var type = TimeKeepingCode.Program.ShiftingTypes.Find(s => s.Pk == this.schedules[i].ShiftingType);
                    list.Add(new TimeKeepingCode.Code.ShiftingScheduleWithType(type != null?type.ShiftType:"",this.schedules[i]));
                }

                cmbPosShiftingPos.DataSource = this.posList.FindAll(p => p.IsOpen);
                cmbPosShiftingShifting.DataSource = list;

                if (cmbPosShiftingPos.Items.Count > 0)
                    cmbPosShiftingPos.SelectedIndex = 0;
                if (cmbPosShiftingShifting.Items.Count > 0)
                    cmbPosShiftingShifting.SelectedIndex = 0;
            }
        }

        private void ComboPosKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPosShiftingShifting.Focus();
        }

        private void ComboShiftingKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPosShiftingAssign.Focus();
        }

        private void AddAssignPos() {
            var pos = cmbPosShiftingPos.SelectedItem as TimeKeepingDataCode.Biometrics.CasherCheckerPOS;
            var shift = cmbPosShiftingShifting.SelectedItem as TimeKeepingCode.Code.ShiftingScheduleWithType;
            

            gridPosShifting.Rows.Add(0,(pos!= null?pos.Id:0),(shift!=null?shift.Shifting.Id:0),
                (pos!=null?pos.POS:string.Empty),cmbType.Text,(shift!=null?shift.ShiftingType:string.Empty),
                (shift!=null?shift.Shifting.ShiftingName:string.Empty));
        }

        private void AssignAddClick(object sender, EventArgs e)
        {
            AddAssignPos();
        }

        private void ButtonPosShiftingDeleteClick(object sender, EventArgs e)
        {
            DeleteSelectedPosShifting();
        }

        private void DeleteSelectedPosShifting() {
            if (gridPosShifting.SelectedRows.Count > 0) {
                if (MessageBox.Show("Are you sure to Remove Selected POS-Shifting?", "Delete", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                gridPosShifting.Rows.Remove(gridPosShifting.SelectedRows[0]);
            }
        }

        private void LoadPosShifting()
        {
            List<CasherCheckerPOS> posList = new List<CasherCheckerPOS>();
            gridPosShifting.Rows.Clear();
            Task.Factory.StartNew(() =>
            {
                posList = CasherCheckerPOS.GetAllCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection);
                return CasherCheckerPosShifting.GetAllCasherCheckerPosShifting(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a => {
                var list = a.Result.OrderBy(e => e.PosId).ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    string shiftingTypeName = string.Empty;
                    var pos = posList.Find(p => p.Id == list[i].PosId);

                    var shiftingType = string.Empty;
                    string type = list[i].CType == 1 ? "Casher" : "Checker";

                    gridPosShifting.Rows.Add(list[i].Id,pos!=null?pos.Id:0,0,
                        pos!=null?pos.POS:string.Empty,type,string.Empty,string.Empty);
                }
                lblPosShiftingCount.Text = "No. POS-Shifting: " + list.Count;
            },this.token,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void GridPosShiftingList(object sender, KeyEventArgs e)
        {
            if (this.posShiftingAction == TimeKeepingCode.UserAction.Update)
            {
                if (e.KeyCode == Keys.Delete)
                    DeleteSelectedPosShifting();
                else if (e.KeyCode == Keys.Insert)
                {
                    pnlPosShiftingAdd.Visible = !false;
                    cmbPosShiftingPos.Focus();
                }
            }
        }

        private List<CasherCheckerPosShifting> CreatePosShiftingList() {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            List<CasherCheckerPosShifting> result = new List<CasherCheckerPosShifting>();
            for (int i = 0; i < gridPosShifting.Rows.Count; i++)
            {
                int type = 0;
                if (gridPosShifting.Rows[i].Cells[4].Value.ToString().Equals("casher", StringComparison.CurrentCultureIgnoreCase))
                    type = 1;
                else if (gridPosShifting.Rows[i].Cells[4].Value.ToString().Equals("checker", StringComparison.CurrentCultureIgnoreCase))
                    type = 2;

                result.Add(new CasherCheckerPosShifting(Convert.ToInt32(gridPosShifting.Rows[i].Cells[0].Value),
                    Convert.ToInt32(gridPosShifting.Rows[i].Cells[1].Value),type,
                    serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName));
            }
            return result;
        }

        private void ButtonPosShiftingoneClick(object sender, EventArgs e)
        {
            if (this.posShiftingAction == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Save Changes?", "Save Changes", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                if (CasherCheckerPosShifting.UpdatePosShifting(TimeKeepingCode.Program.BiometricsConnection, CreatePosShiftingList()))
                {
                    MessageBox.Show("Updated Changes Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewablePosShifting(true);
                    this.posShiftingAction = TimeKeepingCode.UserAction.View;
                    LoadPosShifting();
                }
                else {
                    MessageBox.Show("Failed to Save Changes.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }

        private void SetImage() 
        {
            this.btnPosShiftingRemove.Image = TimeKeepingSystemUI.Properties.Resources.minus15;
            this.btnPosShiftingAdd.Image = TimeKeepingSystemUI.Properties.Resources.plus15;
        }

        private void SaveClickDefaults(object sender, EventArgs e)
        {
            if (cmbRestday.SelectedIndex == -1) {
                MessageBox.Show("Missing Default Restday","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmbRestday.Focus();
                return;
            }

            if (cmbShifting.SelectedIndex == -1) {
                MessageBox.Show("Missing Default Shifting","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                cmbShifting.Focus();
                return;
            }

            CasherCheckerDefaults defaults = new CasherCheckerDefaults(0,cmbRestday.SelectedIndex,cmbShifting.SelectedIndex);

            if (MessageBox.Show("Are you sure to Update Defaults?", "Update Defaults",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            if (CasherCheckerDefaults.SaveDefaults(TimeKeepingCode.Program.BiometricsConnection, defaults))
                MessageBox.Show("Updated Defaults Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error When Updating Defaults.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
