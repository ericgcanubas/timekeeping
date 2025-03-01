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
    public partial class UsrCntrlCasherCheckerScheduleDetails : UserControl
    {
        private List<CasherCheckerPosShifting> posShifitng;
        private List<CasherCheckerPOS> pos;
        private bool isGenerated;

        public delegate void OnSave(object sender,TimeKeepingCode.Events.CasherCheckerEventArgs e);
        public event OnSave OnSaveSuccess;

        private TimeKeepingCode.UserAction action;
        private CasherCheckerAssignSchedule casherChekerSchedule;
        private List<TimeKeepingCode.Code.ShiftingScheduleWithType> shiftingType;

        public UsrCntrlCasherCheckerScheduleDetails()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridCasher.AutoGenerateColumns = false;
            gridChecker.AutoGenerateColumns = false;
            gridSelectedSearchResult.AutoGenerateColumns = false;

            this.posShifitng = new List<CasherCheckerPosShifting>();
            this.pos = new List<CasherCheckerPOS>();

            this.action = TimeKeepingCode.UserAction.View;
            this.casherChekerSchedule = null;
        }

        private static UsrCntrlCasherCheckerScheduleDetails instance;
        public static UsrCntrlCasherCheckerScheduleDetails Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlCasherCheckerScheduleDetails();
                    instance.Name = "singletonUsrCntrlCasherCheckerScheduleDetails";
                }
                return instance;
            }
        }

        private void SetControls() {
            gridCasher.BackgroundColor = Code.Program.MainColor;
            gridCasher.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridCasher.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridCasher.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridCasher.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            gridChecker.BackgroundColor = Code.Program.MainColor;
            gridChecker.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridChecker.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridChecker.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridChecker.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            lblCheckerList.ForeColor = Code.Program.TextColor;
            pnlCheckerTop.BackColor = Code.Program.HoverColor;

            lblCasherlist.ForeColor = Code.Program.TextColor;
            pnlCasherTop.BackColor = Code.Program.HoverColor;

            btnSave.BackColor = Code.Program.MainColor;
            btnSave.ForeColor = Code.Program.TextColor;
            btnCancel.BackColor = Code.Program.MainColor;
            btnCancel.ForeColor = Code.Program.TextColor;
            btnGenerate.BackColor = Code.Program.MainColor;
            btnGenerate.ForeColor = Code.Program.TextColor;
            btnReset.BackColor = Code.Program.MainColor;
            btnReset.ForeColor = Code.Program.TextColor;
            btnPrint.BackColor = Code.Program.MainColor;
            btnPrint.ForeColor = Code.Program.TextColor;

            gridCacherChecker.BackgroundColor = Code.Program.MainColor;
            gridCacherChecker.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridCacherChecker.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridCacherChecker.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridCacherChecker.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            lblResultTop.ForeColor = Code.Program.TextColor;
            pnlResultTop.BackColor = Code.Program.HoverColor;

            btnSelectedCancel.BackColor = Code.Program.MainColor;
            btnSelectedSubmit.BackColor = Code.Program.MainColor;
            btnSelectedCancel.ForeColor = Code.Program.TextColor;
            btnSelectedSubmit.ForeColor = Code.Program.TextColor;

            lblSelectedCashers.ForeColor = Code.Program.MainColor;
            lblSelectedCheckers.ForeColor = Code.Program.MainColor;
            lblDateEffect.ForeColor = Code.Program.TextColor;
            lblApprovedBy.ForeColor = Code.Program.TextColor;

            lblHeaderStatus.ForeColor = Code.Program.MainColor;

            lblBreadcumbDetails.ForeColor = Code.Program.MainColor;
            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbSchedule.ForeColor = Code.Program.MainColor;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
            SetControls();

            var shiftings = ShiftingSchedule.GetAllCasherCheckerSchedulePicker(TimeKeepingCode.Program.BiometricsConnection);
            shiftingType = new List<TimeKeepingCode.Code.ShiftingScheduleWithType>();

            for (int i = 0; i < shiftings.Count; i++)
            {
                var s = TimeKeepingCode.Program.ShiftingSchedule.Find(a => a.Id == shiftings[i].Id);
                if (s != null)
                {
                    var t = TimeKeepingCode.Program.ShiftingTypes.Find(a => a.Pk == s.ShiftingType);
                    if (t != null)
                        shiftingType.Add(new TimeKeepingCode.Code.ShiftingScheduleWithType(t.ShiftType, s));
                }
            }
        }

        private void LoadCreateCashers() {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingCode.Program.ActiveEmployees.FindAll(e => e.PositionId == 19).OrderBy(e => e.LastName).ToList();
            }).ContinueWith(a => {
                var r = a.Result;
                List<TimeKeepingCode.Code.CEmployee> empList = new List<TimeKeepingCode.Code.CEmployee>();
                for (int i = 0; i < r.Count; i++)
                {
                    empList.Add(new TimeKeepingCode.Code.CEmployee(r[i],false));
                }
                gridCasher.DataSource = empList;
                lblCasherlist.Text = "Cashers List (Select only " + this.posShifitng.FindAll(p => p.CType == 1).Count + " Cashers)";
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadCreateChecker() {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingCode.Program.ActiveEmployees.FindAll(e => e.PositionId == 74).OrderBy(e => e.LastName).ToList();
            }).ContinueWith(a => {
                var r = a.Result;
                List<TimeKeepingCode.Code.CEmployee> empList = new List<TimeKeepingCode.Code.CEmployee>();
                for (int i = 0; i < r.Count; i++)
                {
                    empList.Add(new TimeKeepingCode.Code.CEmployee(r[i],false));
                }
                gridChecker.DataSource = empList;
                lblCheckerList.Text = "Checkers List (Select only " + this.posShifitng.FindAll(p => p.CType == 2).Count + " Checkers)";
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadPOS() {
            gridCacherChecker.Rows.Clear();
            for (int i = 0; i < this.posShifitng.Count; i++)
            {
                var pos = this.pos.Find(p => p.Id == this.posShifitng[i].PosId);

                string type = this.posShifitng[i].CType == 1 ? "Casher" : "Checker";
                gridCacherChecker.Rows.Add(0,(pos!=null?pos.POS:string.Empty),type,string.Empty,string.Empty,
                    string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 
                    string.Empty, string.Empty, 0,0, 0, 0, 0, 0, 0);
            }
        }

        private int CountChecked(DataGridView grid) {
            int result = 0;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid.Rows[i].Cells[1].Value))
                    result++;
            }
            return result;
        }

        private void GridViewValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                int count = 0;
                if (grid == gridCasher)
                    count = this.posShifitng.FindAll(p => p.CType == 1).Count;
                else if (grid == gridChecker)
                    count = this.posShifitng.FindAll(p => p.CType == 2).Count;

                if (CountChecked(grid) > count)
                {
                    MessageBox.Show("Only " + count + " Allowed to Select.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                }
            }
            if (grid.Equals(gridCasher))
                lblSelectedCashers.Text = "SELECTED CASHERS: " + GetSelected(grid,true).Count;
            else if (grid.Equals(gridChecker))
                lblSelectedCheckers.Text = "SELECTED CHECKERS: " + GetSelected(grid,true).Count;
        }

        private void DataGridCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                grid.EndEdit();
            }
        }

        private void DataGridKeyDown(object sender, KeyEventArgs e)
        {
            if (this.action != TimeKeepingCode.UserAction.View)
            {
                DataGridView grid = sender as DataGridView;
                if (e.KeyCode == Keys.Enter)
                {
                    if (grid.SelectedRows.Count > 0)
                    {
                        grid.SelectedRows[0].Cells[1].Value = !Convert.ToBoolean(grid.SelectedRows[0].Cells[1].Value);
                    }
                }
            }
        }

        private List<TimeKeepingCode.Code.CEmployee> GetSelected(DataGridView grid,bool isSelected) {
            List<TimeKeepingCode.Code.CEmployee> result = new List<TimeKeepingCode.Code.CEmployee>();
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid.Rows[i].Cells[1].Value) == isSelected)
                    result.Add(grid.Rows[i].DataBoundItem as TimeKeepingCode.Code.CEmployee);
            }
            return result;
        }

        private void GenerateCasherChecker() {

            var cashers = GetSelected(gridCasher,true);
            var checkers = GetSelected(gridChecker,true);

            Random rand = new Random();
            for (int i = 0; i < gridCacherChecker.Rows.Count; i++)
            {
                if (gridCacherChecker.Rows[i].Cells[2].Value.ToString().Equals("casher", StringComparison.CurrentCultureIgnoreCase)) {
                    int r = rand.Next(cashers.Count);
                    gridCacherChecker.Rows[i].Cells[3].Value = cashers[r].Fullname;
                    gridCacherChecker.Rows[i].Cells[0].Value = cashers[r].Id;
                    gridCacherChecker.Rows[i].Cells[12].Value = cashers[r].IdNumber;
                    cashers.RemoveAt(r);
                }
                else if (gridCacherChecker.Rows[i].Cells[2].Value.ToString().Equals("checker", StringComparison.CurrentCultureIgnoreCase))
                {
                    int r = rand.Next(checkers.Count);
                    gridCacherChecker.Rows[i].Cells[3].Value = checkers[r].Fullname;
                    gridCacherChecker.Rows[i].Cells[0].Value = checkers[r].Id;
                    gridCacherChecker.Rows[i].Cells[12].Value = checkers[r].IdNumber;
                    checkers.RemoveAt(r);
                }
                for (int a = 5; a <= 11; a++)
                {
                    gridCacherChecker.Rows[i].Cells[a].Value = rand.Next(1, 6);
                }
            }
            this.isGenerated = true;
        }

        private void GenerateWarehouse() 
        {
            var cashers = GetSelected(gridCasher,false);
            var checkers = GetSelected(gridChecker,false);

            var defaults = CasherCheckerDefaults.GetDefaults(TimeKeepingCode.Program.BiometricsConnection);
            if (defaults != null) {

                string dRestday = defaults.Restday == 0 ? "UnAssigned" : defaults.Restday.ToString();
                string dShifting = defaults.Shifting == 0 ? "UnAssigned" : defaults.Shifting.ToString();

                for (int i = 0; i < cashers.Count; i++)
                {
                    gridCacherChecker.Rows.Add(cashers[i].Id,string.Empty,"Casher", cashers[i].Fullname ,dRestday,dShifting,
                        dShifting,dShifting,dShifting,dShifting,dShifting,dShifting,cashers[i].IdNumber);
                }

                for (int i = 0; i < checkers.Count; i++)
                {
                    gridCacherChecker.Rows.Add(checkers[i].Id, string.Empty, "Checker", checkers[i].Fullname ,dRestday, dShifting,
                        dShifting, dShifting, dShifting, dShifting, dShifting, dShifting, checkers[i].IdNumber);
                }
            }
        }

        private void SelectedSearchEnter(object sender, EventArgs e)
        {
            gridSelectedSearchResult.Visible = true;
        }

        private void SelectedSearchLeave(object sender, EventArgs e)
        {
            if (!gridSelectedSearchResult.Focused)
                gridSelectedSearchResult.Visible = false;
        }

        private void GridSelectedSearchResultLeave(object sender, EventArgs e)
        {
            if (!txtSelectedName.Focused)
                gridSelectedSearchResult.Visible = false;
        }

        private void GridResultKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.action != TimeKeepingCode.UserAction.View) 
                {
                    if (gridCacherChecker.SelectedRows[0].Cells[3].Value != null &&
                    !string.IsNullOrWhiteSpace(gridCacherChecker.SelectedRows[0].Cells[3].Value.ToString()))
                    {
                        e.Handled = true;
                        pnlSelectedDetails.Visible = true;
                        cmbSelectedRestday.Focus();
                        SelectDetails();
                    }
                }
            }
        }

        private void PanelSelectedDetailsLeave(object sender, EventArgs e)
        {
            SelecteDetailsLeave();
        }

        private void SelectedSearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectedSearch();
            else if (e.KeyCode == Keys.Escape)
            {
                if (string.IsNullOrWhiteSpace(txtSelectedName.Text))
                    SelecteDetailsLeave();
                else
                    txtSelectedName.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (gridSelectedSearchResult.SelectedRows[0].Index + 1 <= gridSelectedSearchResult.Rows.Count - 1)
                {
                    int lastIndex = gridSelectedSearchResult.SelectedRows[0].Index;
                    gridSelectedSearchResult.Rows[lastIndex + 1].Selected = true;
                    gridSelectedSearchResult.Rows[lastIndex].Selected = false;
                    gridSelectedSearchResult.CurrentCell = gridSelectedSearchResult.Rows[lastIndex + 1].Cells[0];
                    gridSelectedSearchResult.Focus();
                }
            }
        }

        private void SelectDetails() {
            if (gridCacherChecker.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gridCacherChecker.SelectedRows[0];
                txtSelectedName.Text = row.Cells[3].Value.ToString();
                txtSelectedPOS.Text = row.Cells[2].Value.ToString();
                if (row.Cells[4].Value != null && !string.IsNullOrWhiteSpace(row.Cells[4].Value.ToString()))
                    cmbSelectedRestday.Text = row.Cells[4].Value.ToString();

                int valueR;

                cmbMonday.SelectedIndex = int.TryParse(row.Cells[5].Value.ToString(),out valueR) ? valueR : 0;
                cmbTuesday.SelectedIndex = int.TryParse(row.Cells[6].Value.ToString(), out valueR) ? valueR : 0;
                cmbWednesday.SelectedIndex = int.TryParse(row.Cells[7].Value.ToString(), out valueR) ? valueR : 0;
                cmbThursday.SelectedIndex = int.TryParse(row.Cells[8].Value.ToString(), out valueR) ? valueR : 0;
                cmbFriday.SelectedIndex = int.TryParse(row.Cells[9].Value.ToString(), out valueR) ? valueR : 0;
                cmbSaturday.SelectedIndex = int.TryParse(row.Cells[10].Value.ToString(), out valueR) ? valueR : 0;
                cmbSunday.SelectedIndex = int.TryParse(row.Cells[11].Value.ToString(), out valueR) ? valueR : 0;
            }
        }

        private void RestdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSelectedPOS.Focus();
            else if(e.KeyCode == Keys.Escape)
                SelecteDetailsLeave();
        }

        private void PosKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMonday.Focus();
            else if(e.KeyCode == Keys.Escape)
                SelecteDetailsLeave();
        }

        private void ShiftingKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSelectedSubmit.Focus();
            else if(e.KeyCode == Keys.Escape)
                SelecteDetailsLeave();
        }

        private void SelectedCancelClick(object sender, EventArgs e)
        {
            SelecteDetailsLeave();
        }

        private void Search(string type, string search) {
            if (type.Equals("casher", StringComparison.CurrentCultureIgnoreCase))
            {
                var cashers = GetSelected(gridCasher,true);
                gridSelectedSearchResult.DataSource = cashers.FindAll(e => e.Fullname.ToLower().Contains(search.ToLower()));
            }
            else if (type.Equals("checker", StringComparison.CurrentCultureIgnoreCase)) {
                var checkers = GetSelected(gridChecker,true);
                gridSelectedSearchResult.DataSource = checkers.FindAll(e => e.Fullname.ToLower().Contains(search.ToLower()));
            }
        }

        private void NameSelectedTextChange(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSelectedName.Text))
            {
                gridSelectedSearchResult.DataSource = null;
            }
            else
            {
                if (gridCacherChecker.SelectedRows.Count > 0)
                {
                    Search(gridCacherChecker.SelectedRows[0].Cells[2].Value.ToString(), txtSelectedName.Text);
                }
            }
        }

        private void GridSearchResultKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gridSelectedSearchResult.SelectedRows[0].Index == 0)
                    txtSelectedName.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
                SelectedSearch();
            else if (e.KeyCode == Keys.Escape)
            {
                txtSelectedName.Text = string.Empty;
                SelecteDetailsLeave();
            }
        }

        private void SelectedSearch() {
            if (gridSelectedSearchResult.SelectedRows.Count > 0)
            {
                TimeKeepingCode.Code.CEmployee c = gridSelectedSearchResult.SelectedRows[0].DataBoundItem as TimeKeepingCode.Code.CEmployee;
                txtSelectedName.Text = c.Fullname;
                cmbSelectedRestday.Focus();
            }
        }

        private void Exchange(int pk) {
            DataGridViewRow row1 = gridCacherChecker.SelectedRows[0];
            DataGridViewRow row2 = null;

            int tmpId = Convert.ToInt32(row1.Cells[0].Value);
            string tmpName = row1.Cells[3].Value.ToString();

            for (int i = 0; i < gridCacherChecker.Rows.Count; i++)
            {
                if (Convert.ToInt32(gridCacherChecker.Rows[i].Cells[0].Value) == pk) {
                    row2 = gridCacherChecker.Rows[i];
                    break;
                }
            }

            if (row2 != null) {
                row1.Cells[0].Value = row2.Cells[0].Value;
                row1.Cells[3].Value = row2.Cells[3].Value;

                row2.Cells[0].Value = tmpId;
                row2.Cells[3].Value = tmpName;

                row1.Cells[4].Value = cmbSelectedRestday.Text;
            }
        }

        private void SelectedSubmitClick(object sender, EventArgs e)
        {
            //no selectedrows if visible = false;
            gridSelectedSearchResult.Visible = true;
            gridSelectedSearchResult.Visible = false;
            if (gridSelectedSearchResult.SelectedRows.Count > 0)
            {
                TimeKeepingCode.Code.CEmployee c = gridSelectedSearchResult.SelectedRows[0].DataBoundItem as TimeKeepingCode.Code.CEmployee;
                Exchange(c.Id);
            }

            DataGridViewRow row = gridCacherChecker.SelectedRows[0];

            row.Cells[5].Value = cmbMonday.SelectedIndex == 0 ? "UnAssigned" : cmbMonday.SelectedIndex.ToString();
            row.Cells[6].Value = cmbTuesday.SelectedIndex == 0 ? "UnAssigned" : cmbTuesday.SelectedIndex.ToString();
            row.Cells[7].Value = cmbWednesday.SelectedIndex == 0 ? "UnAssigned" : cmbWednesday.SelectedIndex.ToString();
            row.Cells[8].Value = cmbThursday.SelectedIndex == 0 ? "UnAssigned" : cmbThursday.SelectedIndex.ToString();
            row.Cells[9].Value = cmbFriday.SelectedIndex == 0 ? "UnAssigned" : cmbFriday.SelectedIndex.ToString();
            row.Cells[10].Value = cmbSaturday.SelectedIndex == 0 ? "UnAssigned" : cmbSaturday.SelectedIndex.ToString();
            row.Cells[11].Value = cmbSunday.SelectedIndex == 0 ? "UnAssigned" : cmbSunday.SelectedIndex.ToString();

            gridCacherChecker.Focus();
        }

        private void SelecteDetailsLeave() {
            cmbSelectedRestday.SelectedIndex = -1;
            pnlSelectedDetails.Visible = false;
            gridCacherChecker.Focus();
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            if (this.isGenerated) {
                MessageBox.Show("Shifting Schedule Already Generated.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (GetSelected(gridCasher,true).Count != this.posShifitng.FindAll(p => p.CType == 1).Count)
            {
                MessageBox.Show("Selected Cashers Not Equal to PoS-Shifting Count.\nMust Select " + this.posShifitng.Count + " Cashers.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                gridCasher.Focus();
                return;
            }

            if (GetSelected(gridChecker,true).Count != this.posShifitng.FindAll(p => p.CType == 2).Count)
            {
                MessageBox.Show("Selected Checkers Not Equal to PoS-Shifting Count.\nMust Select " + this.posShifitng.Count + " Checkers.",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                gridChecker.Focus();
                return;
            }

            GenerateCasherChecker();
            GenerateWarehouse();
            gridCasher.Enabled = false;
            gridChecker.Enabled = false;
        }

        private void Reset() {
            LoadPOS();
            gridCasher.Enabled = true;
            gridChecker.Enabled = true;
            this.isGenerated = false;
        }

        private void ResetClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Reset Generated Schedule?", "Reset", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Reset();
        }

        private void SelectSubmitKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                SelecteDetailsLeave();
        }

        private void SelectCancelKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                SelecteDetailsLeave();
        }

        private List<CasherCheckerAssignedEmployeeDetails> CreateEmployeeDetails() 
        {
            int casherCheckerAssignID = 0;

            if (this.action == TimeKeepingCode.UserAction.Update) {
                if (this.casherChekerSchedule != null)
                    casherCheckerAssignID = this.casherChekerSchedule.Id;
            }

            List<CasherCheckerAssignedEmployeeDetails> result = new List<CasherCheckerAssignedEmployeeDetails>();
            for (int i = 0; i < gridCasher.Rows.Count; i++)
            {
                TimeKeepingCode.Code.CEmployee e = gridCasher.Rows[i].DataBoundItem as TimeKeepingCode.Code.CEmployee;
                if (e != null)
                    result.Add(new CasherCheckerAssignedEmployeeDetails
                        (0, casherCheckerAssignID, "Casher", e.Id, Convert.ToBoolean(gridCasher.Rows[i].Cells[1].Value)));
            }

            for (int i = 0; i < gridChecker.Rows.Count; i++)
            {
                TimeKeepingCode.Code.CEmployee e = gridChecker.Rows[i].DataBoundItem as TimeKeepingCode.Code.CEmployee;
                if (e != null)
                    result.Add(new CasherCheckerAssignedEmployeeDetails
                        (0, casherCheckerAssignID, "Checker", e.Id, Convert.ToBoolean(gridChecker.Rows[i].Cells[1].Value)));
            }

            return result;
        }

        private List<CasherCheckerAssignedDetails> CreateDetails() 
        {
            int casherCheckerAssignID = 0;

            if (this.action == TimeKeepingCode.UserAction.Update)
            {
                if (this.casherChekerSchedule != null)
                    casherCheckerAssignID = this.casherChekerSchedule.Id;
            }

            List<CasherCheckerAssignedDetails> result = new List<CasherCheckerAssignedDetails>();
            for (int i = 0; i < gridCacherChecker.Rows.Count; i++)
            {
                DataGridViewRow row = gridCacherChecker.Rows[i];

                int intValue;
                int monday = int.TryParse(row.Cells[5].Value.ToString(), out intValue) ? intValue : 0;
                int tuesday = int.TryParse(row.Cells[6].Value.ToString(), out intValue) ? intValue : 0;
                int wednesday = int.TryParse(row.Cells[7].Value.ToString(), out intValue) ? intValue : 0;
                int thursday = int.TryParse(row.Cells[8].Value.ToString(), out intValue) ? intValue : 0;
                int friday = int.TryParse(row.Cells[9].Value.ToString(), out intValue) ? intValue : 0;
                int saturday = int.TryParse(row.Cells[10].Value.ToString(), out intValue) ? intValue : 0;
                int sunday = int.TryParse(row.Cells[11].Value.ToString(), out intValue) ? intValue : 0;

                result.Add(new CasherCheckerAssignedDetails(0,casherCheckerAssignID,row.Cells[2].Value.ToString(),
                    Convert.ToInt32(row.Cells[0].Value),row.Cells[1].Value.ToString(),row.Cells[4].Value.ToString(),
                    monday,tuesday,wednesday,thursday,friday,saturday,sunday, 
                    row.Cells[12].Value.ToString(), row.Cells[3].Value.ToString()));
            }
            return result;
        }

        private bool SaveCreated() 
        {
            CasherCheckerAssignSchedule c = CasherCheckerAssignSchedule.Empty;
            c.DateEffect = dtpDateEffect.Value;
            c.ApprovedBy = txtApprovedBy.Text;
            c.CreatedBy = TimeKeepingCode.Program.User.UserName;

            return CasherCheckerAssignSchedule.CreateCasherCheckerSchedule
                (TimeKeepingCode.Program.BiometricsConnection, c, CreateDetails(),CreateEmployeeDetails());
        }

        private bool SaveUpdated() 
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            this.casherChekerSchedule.DateEffect = dtpDateEffect.Value;
            this.casherChekerSchedule.ApprovedBy = txtApprovedBy.Text;
            this.casherChekerSchedule.LastModified = serverDate.ToString("MM/dd/yyyy hh:mm tt") + " - " + TimeKeepingCode.Program.User.UserName;

            return CasherCheckerAssignSchedule.UpdateCasherCheckerSchedule(TimeKeepingCode.Program.BiometricsConnection,
                this.casherChekerSchedule, CreateEmployeeDetails(), CreateDetails());
        }

        private bool IsDateEffectValid() 
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();

            if (serverDate >= dtpDateEffect.Value)
                return false;
            else if (serverDate.Month == dtpDateEffect.Value.Month &&
                serverDate.Year == dtpDateEffect.Value.Year && serverDate.Day == dtpDateEffect.Value.Day)
                return false;

            return true;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || this.action == TimeKeepingCode.UserAction.Update) {
                if (!IsDateEffectValid())
                {
                    MessageBox.Show("Invalid Selected Date.\nDate should be ahead of Time.",
                        "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!IsScheduleValid())
                {
                    MessageBox.Show("Some POS-Shifting Schedules have Empty Fields.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (this.action == TimeKeepingCode.UserAction.Create)
            {
                if (MessageBox.Show("Are you sure to Save Created Schedule?", "Save Created",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (SaveCreated())
                {
                    if (OnSaveSuccess != null)
                        OnSaveSuccess.Invoke(this, new TimeKeepingCode.Events.CasherCheckerEventArgs());

                    MessageBox.Show("Created Schedule Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Create Schedule Failed to Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Save Updated Schedule?", "Save Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (SaveUpdated())
                {
                    if (OnSaveSuccess != null)
                        OnSaveSuccess.Invoke(this, new TimeKeepingCode.Events.CasherCheckerEventArgs());
                    MessageBox.Show("Updated Schedule Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Updated Schedule Failed to Save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsScheduleValid() {
            for (int i = 0; i < gridCacherChecker.Rows.Count; i++)
            {
                if (gridCacherChecker.Rows[i].Cells[3].Value == null || string.IsNullOrWhiteSpace(gridCacherChecker.Rows[i].Cells[3].Value.ToString())
                    || gridCacherChecker.Rows[i].Cells[4].Value == null || string.IsNullOrWhiteSpace(gridCacherChecker.Rows[i].Cells[4].Value.ToString()))
                    return false;
            }

            return true;
        }

        public void Create() 
        {
            lblHeaderStatus.Text = "Creating Schedule";
            this.action = TimeKeepingCode.UserAction.Create;
            Task.Factory.StartNew(() =>
            {
                this.pos = CasherCheckerPOS.GetAllCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection);
                this.posShifitng = CasherCheckerPosShifting.GetAllCasherCheckerPosShifting
                    (TimeKeepingCode.Program.BiometricsConnection).OrderBy(e => e.PosId).ToList();
            }).ContinueWith(a =>
            {
                LoadPOS();
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

            LoadCreateCashers();
            LoadCreateChecker();
        }

        public void Update(CasherCheckerAssignSchedule casherCheckerSchedule) 
        {
            lblHeaderStatus.Text = "Updating Schedule";
            this.casherChekerSchedule = casherCheckerSchedule;
            this.action = TimeKeepingCode.UserAction.Update;

            LoadVIewUpdatePOS();
            LoadDetails();
            LoadEmployeeDetails();

            gridCasher.Enabled = false;
            gridChecker.Enabled = false;
            this.isGenerated = true;

            lblCasherlist.Text = "Casher List (Select only " + this.posShifitng.FindAll(e => e.CType ==1).Count  + " Cashers)";
            lblCheckerList.Text = "Checker List (Select only " + this.posShifitng.FindAll(e => e.CType == 2).Count + " Checkers)";
        }

        private void LoadDetails() 
        {
            gridCacherChecker.Rows.Clear();
            List<CasherCheckerAssignedDetails> details = new List<CasherCheckerAssignedDetails>();

            Task.Factory.StartNew(() =>
            {
                details = CasherCheckerAssignedDetails.GetallCasherCheckerDetails
                    (TimeKeepingCode.Program.BiometricsConnection, this.casherChekerSchedule.Id);
            }).ContinueWith(a => {
                details = (from de in details
                        orderby de.POS, de.CType
                        select de).ToList();

                for (int i = 0; i < details.Count; i++)
                {
                    var employee = TimeKeepingCode.Program.ActiveEmployees.Find(e => e.PkId == details[i].EmpId);
                    if (employee == null)
                        employee = TimeKeepingCode.Program.InactiveEmployees.Find(e => e.PkId == details[i].EmpId);

                    string monday = details[i].MondayShifitng == 0 ? "UnAssigned" : details[i].MondayShifitng.ToString();
                    string tuesday = details[i].TuesdayShifting == 0 ? "UnAssigned" : details[i].TuesdayShifting.ToString();
                    string wednesday = details[i].WednesdayShifting == 0 ? "UnAssigned" : details[i].WednesdayShifting.ToString();
                    string thursday = details[i].ThursdayShifting == 0 ? "UnAssigned" : details[i].ThursdayShifting.ToString();
                    string friday = details[i].FridayShifting == 0 ? "UnAssigned" : details[i].FridayShifting.ToString();
                    string saturday = details[i].SaturdayShifting == 0 ? "UnAssigned" : details[i].SaturdayShifting.ToString();
                    string sunday = details[i].SundayShifting == 0 ? "UnAssigned" : details[i].SundayShifting.ToString();

                    gridCacherChecker.Rows.Add(employee != null ? employee.PkId : 0, details[i].POS, details[i].CType,
                        employee!=null?employee.Fullname:string.Empty,details[i].Restday,monday,tuesday,
                        wednesday,thursday,friday,saturday,sunday,employee != null ? employee.IdNumber:string.Empty);
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());

            txtApprovedBy.Text = this.casherChekerSchedule.ApprovedBy;
            dtpDateEffect.Value = this.casherChekerSchedule.DateEffect;
        }

        private void LoadEmployeeDetails() 
        {
            List<CasherCheckerAssignedEmployeeDetails> employeeDetails = new List<CasherCheckerAssignedEmployeeDetails>();
            Task.Factory.StartNew(() =>
            {
                employeeDetails = CasherCheckerAssignedEmployeeDetails.GetAllCasherCheckerEmployeeDetails
                        (TimeKeepingCode.Program.BiometricsConnection, this.casherChekerSchedule.Id);
            }).ContinueWith(a => {
                List<TimeKeepingCode.Code.CEmployee> cashers = new List<TimeKeepingCode.Code.CEmployee>();
                List<TimeKeepingCode.Code.CEmployee> checkers = new List<TimeKeepingCode.Code.CEmployee>();
                int cashersSelected = 0;
                int checkersSelected = 0;

                for (int i = 0; i < employeeDetails.Count; i++)
                {
                    if (employeeDetails[i].CType.Equals("casher", StringComparison.CurrentCultureIgnoreCase))
                    {
                        BasicEmployeeInfo emp = TimeKeepingCode.Program.ActiveEmployees.Find(e => e.PkId == employeeDetails[i].EmpId);
                        if (emp == null)
                            emp = TimeKeepingCode.Program.InactiveEmployees.Find(e => e.PkId == employeeDetails[i].EmpId);
                        if (emp != null)
                            cashers.Add(new TimeKeepingCode.Code.CEmployee(emp,employeeDetails[i].IsAssigned));

                        if (employeeDetails[i].IsAssigned)
                            cashersSelected++;
                    }
                    else if (employeeDetails[i].CType.Equals("checker", StringComparison.CurrentCultureIgnoreCase))
                    {
                        BasicEmployeeInfo emp = TimeKeepingCode.Program.ActiveEmployees.Find(e => e.PkId == employeeDetails[i].EmpId);
                        if (emp == null)
                            emp = TimeKeepingCode.Program.InactiveEmployees.Find(e => e.PkId == employeeDetails[i].EmpId);
                        if (emp != null)
                            checkers.Add(new TimeKeepingCode.Code.CEmployee(emp,employeeDetails[i].IsAssigned));

                        if (employeeDetails[i].IsAssigned)
                            checkersSelected++;
                    }
                }

                gridCasher.DataSource = cashers;
                gridChecker.DataSource = checkers;

                lblSelectedCashers.Text = "SELECTED CASHERS: " + cashersSelected;
                lblSelectedCheckers.Text = "SELECTED CHECKERS: " + checkersSelected;
            },CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CancelClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created Schedule?", "Cancel Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Cancel Updated Schedule?", "Cancel Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            this.Dispose();
        }

        public void LoadView(CasherCheckerAssignSchedule casherCheckerSchedule)
        {
            lblHeaderStatus.Text = "Viewing Schedule";
            this.casherChekerSchedule = casherCheckerSchedule;
            this.action = TimeKeepingCode.UserAction.View;

            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnGenerate.Visible = false;
            btnReset.Visible = false;
            btnPrint.Text = "Print";
            //btnPrint.Image = global::TimeKeepingSystemUI.Properties.Resources.back15;

            txtApprovedBy.ReadOnly = true;
            dtpDateEffect.Enabled = false;

            LoadVIewUpdatePOS();
            LoadDetails();
            LoadEmployeeDetails();

            lblCasherlist.Text = "Cashers List.";
            lblCheckerList.Text = "Checkers List";

            gridCasher.Columns[1].ReadOnly = true;
            gridChecker.Columns[1].ReadOnly = true;
        }

        private void LoadVIewUpdatePOS() {
            Task.Factory.StartNew(() =>
            {
                this.pos = CasherCheckerPOS.GetAllCasherCheckerPOS(TimeKeepingCode.Program.BiometricsConnection);
                this.posShifitng = CasherCheckerPosShifting.GetAllCasherCheckerPosShifting(TimeKeepingCode.Program.BiometricsConnection);
            });
        }

        private System.Data.DataTable CreateReportDetails(string type) 
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            List<TimeKeepingCode.Code.CasherCheckerReportWrapper> list = new List<TimeKeepingCode.Code.CasherCheckerReportWrapper>();

            dt.Columns.Add("Id",typeof(Int32));
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Restday",typeof(string));
            dt.Columns.Add("Monday",typeof(string));
            dt.Columns.Add("Tuesday",typeof(string));
            dt.Columns.Add("Wednesday",typeof(string));
            dt.Columns.Add("Thursday",typeof(string));
            dt.Columns.Add("Friday",typeof(string));
            dt.Columns.Add("Saturday",typeof(string));
            dt.Columns.Add("Sunday",typeof(string));
            dt.Columns.Add("Type",typeof(string));
            dt.Columns.Add("IsWarehouse",typeof(Int32));

            for (int i = 0; i < gridCacherChecker.Rows.Count; i++)
            {
                DataGridViewRow row = gridCacherChecker.Rows[i];
                if (row.Cells[2].Value.ToString().Equals(type, StringComparison.CurrentCultureIgnoreCase)) 
                {
                    list.Add( new TimeKeepingCode.Code.CasherCheckerReportWrapper(Convert.ToInt32(row.Cells[0].Value),
                        row.Cells[3].Value.ToString(), 
                        row.Cells[4].Value.ToString().Equals("unassigned",StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[5].Value.ToString(),
                        row.Cells[6].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[6].Value.ToString(),
                        row.Cells[7].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[7].Value.ToString(),
                        row.Cells[8].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[8].Value.ToString(),
                        row.Cells[9].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[9].Value.ToString(),
                        row.Cells[10].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[10].Value.ToString(),
                        row.Cells[11].Value.ToString().Equals("unassigned", StringComparison.CurrentCultureIgnoreCase) ? string.Empty : row.Cells[4].Value.ToString(), 
                        row.Cells[2].Value.ToString(), false));
                }
            }

            list = (from e in list
                    orderby e.Name
                    select e).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                dt.Rows.Add(list[i].Id,list[i].Name,list[i].RestDay,
                    (list[i].RestDay.Equals("monday",StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Monday),
                    (list[i].RestDay.Equals("tuesday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Tuesday),
                    (list[i].RestDay.Equals("wednesday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Wednesday),
                    (list[i].RestDay.Equals("thursday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Thursday),
                    (list[i].RestDay.Equals("friday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Friday),
                    (list[i].RestDay.Equals("saturday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Saturday),
                    (list[i].RestDay.Equals("sunday", StringComparison.CurrentCultureIgnoreCase) ? "" : list[i].Sunday),
                    list[i].Type,Convert.ToInt32(list[i].IsWarehouse));
            }

            return dt;
        }

        private void PrintClick(object sender, EventArgs e)
        {
            if (this.casherChekerSchedule == null)
            {
                MessageBox.Show("Can't Print With No Selected Schedule.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var casherDetails = CreateReportDetails("casher");
            Reports.FormPreviewReport reportCasher = new Reports.FormPreviewReport();
            reportCasher.rptViewer.LocalReport.DataSources.Clear();
            reportCasher.rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("casherCheckerData",casherDetails));
            reportCasher.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportCasherCheckerSchedule.rdlc";
            reportCasher.rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dateApply","Date Effect: " + dtpDateEffect.Value.ToString("MM/dd/yyyy")));
            reportCasher.rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("type","CASHER"));
            reportCasher.rptViewer.RefreshReport();
            reportCasher.rptViewer.Refresh();
            reportCasher.ShowDialog();
            reportCasher.Dispose();
            reportCasher = null;

            var checkerDetails = CreateReportDetails("checker");
            Reports.FormPreviewReport reportChecker = new Reports.FormPreviewReport();
            reportChecker.rptViewer.LocalReport.DataSources.Clear();
            reportChecker.rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("casherCheckerData", checkerDetails));
            reportChecker.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportCasherCheckerSchedule.rdlc";
            reportChecker.rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dateApply", "Date Effect: " + dtpDateEffect.Value.ToString("MM/dd/yyyy")));
            reportChecker.rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("type", "CHECKER"));
            reportChecker.rptViewer.RefreshReport();
            reportChecker.rptViewer.Refresh();
            reportChecker.ShowDialog();
            reportChecker.Dispose();
            reportChecker = null;
        }

        private void BreadcumbOnMouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void BreadcumbOnMouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void OnBreadcumbScheduleClick(object sender, EventArgs e)
        {
            CancelClick(lblBreadcumbSchedule,e);
        }

        private void OnBreadcumbHomeClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Cancel Created Schedule?", "Cancel Created",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Cancel Updated Schedule?", "Cancel Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            UsrCntrlCasherCheckerWrapper.Instance.Dispose();
        }

        private void MondayKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbTuesday.Focus();
        }

        private void TuesdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbWednesday.Focus();
        }

        private void WednesdayKeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbThursday.Focus();
        }

        private void ThursdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbFriday.Focus();
        }

        private void FridayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSaturday.Focus();
        }

        private void SaturdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSunday.Focus();
        }

        private void SundayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSelectedSubmit.Focus();
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCacherChecker.SelectedRows.Count > 0 && this.action != TimeKeepingCode.UserAction.View)
            {
                pnlSelectedDetails.Visible = true;
                cmbSelectedRestday.Focus();
                SelectDetails();
            }
        }

        private TimeKeepingCode.Code.ShiftingScheduleWithType GetShift(int id) 
        {
             return this.shiftingType.Find(e => e.Shifting.Id == id);
        }

        private void SetImage() 
        {
            btnSave.Image = TimeKeepingSystemUI.Properties.Resources.save15;
            btnCancel.Image = TimeKeepingSystemUI.Properties.Resources.cancel15;
            btnGenerate.Image = TimeKeepingSystemUI.Properties.Resources.generate15;
            btnReset.Image = TimeKeepingSystemUI.Properties.Resources.reset15;
            btnPrint.Image = TimeKeepingSystemUI.Properties.Resources.print15;
        }

        private void RefreshWarehouseClick(object sender, EventArgs e)
        {
            GenerateWarehouse();
        }
    }
}
