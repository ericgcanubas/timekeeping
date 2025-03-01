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

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlHolidaySchedule : UserControl
    {
        private List<TimeKeepingDataCode.Biometrics.HolidayEmployees> sellingArea;
        private List<TimeKeepingDataCode.Biometrics.HolidayEmployees> backOffice;
        private TimeKeepingCode.UserAction action;

        private List<int> restdays;
        private List<int> leaves;

        public bool IsNew { get; private set; }

        private TimeKeepingDataCode.Biometrics.HolidayName holidayName;

        public TimeKeepingDataCode.Biometrics.HolidayName HolidayName {
            get {
                this.holidayName.Description = txtDescription.Text;
                this.holidayName.Date = dtpDateEffect.Value;
                this.holidayName.Type = cmbHolidayType.Text;

                return this.holidayName;
            }
        }

        public bool IsPayrollLocked { get; private set; }

        public UsrCntrlHolidaySchedule()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridList.AutoGenerateColumns = false;
            this.IsPayrollLocked = false;

            this.sellingArea = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();
            this.backOffice = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();

            this.restdays = new List<int>();
            this.leaves = new List<int>();
        }

        public void Create(TimeKeepingDataCode.Biometrics.HolidayName holidayName) 
        {
            this.IsNew = true;
            this.holidayName = holidayName;
            this.action = TimeKeepingCode.UserAction.Create;
            Task.Factory.StartNew(() =>
            {
                var employees = TimeKeepingCode.Program.ActiveEmployees.FindAll(m => m.DivisionId == 2);
                employees = (from m in employees
                             orderby m.DepartmentId, m.SectionId, m.PositionId, m.LastName, m.FirstName
                             select m).ToList();
                this.sellingArea.AddRange(TimeKeepingDataCode.Biometrics.HolidayEmployees.Convert(employees));
            });

            Task.Factory.StartNew(() =>
            {
                var employees = TimeKeepingCode.Program.ActiveEmployees.FindAll(m => m.DivisionId == 1);
                employees = (from m in employees
                             orderby m.DepartmentId, m.SectionId, m.PositionId, m.LastName, m.FirstName
                             select m).ToList();
                this.backOffice.AddRange(TimeKeepingDataCode.Biometrics.HolidayEmployees.Convert(employees));
            });

            cmbHolidayType.SelectedIndex = 0;
            SetRestdayLeaves();
        }

        public void ViewUpdate(TimeKeepingDataCode.Biometrics.HolidayName holidayName,TimeKeepingCode.UserAction action) 
        {
            this.holidayName = holidayName;
            this.action = action;

            cmbHolidayType.Text = this.holidayName.Type;
            dtpDateEffect.Value = this.holidayName.Date;
            txtDescription.Text = this.holidayName.Description;

            Task.Factory.StartNew(() =>
            {
                this.IsPayrollLocked = TimeKeepingDataCode.PayrollSystem.StaticHelper.
                    IsPayrollLocked(TimeKeepingCode.Program.PayrollConnection, this.holidayName.Date);
            }).ContinueWith(a => 
            {
                if (this.IsPayrollLocked)
                {
                    lblPayrollLocked.Visible = true;
                    cmbHolidayType.Enabled = false;
                    dtpDateEffect.Enabled = false;
                    txtDescription.ReadOnly = true;
                    chkAll.Enabled = false;
                    lnkUncheck.Enabled = false;
                    gridList.Columns[0].ReadOnly = true;
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());


            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.HolidayEmployees.
                    GetAllHolidayEmployeesByHolidayName(TimeKeepingCode.Program.BiometricsConnection, this.holidayName.Pk);
            }).ContinueWith(a => {
                if (a.Result != null) {
                    for (int i = 0; i < a.Result.Count; i++)
                    {
                        if (a.Result[i].DivisionId == 1)
                            this.backOffice.Add(a.Result[i]);
                        else if (a.Result[i].DivisionId == 2)
                            this.sellingArea.Add(a.Result[i]);
                    }
                    this.sellingArea = (from s in this.sellingArea
                                        orderby s.DepartmentId, s.SectionId, s.PositionId, s.Fullname
                                        select s).ToList();
                    this.backOffice = (from b in this.backOffice
                                       orderby b.DepartmentId, b.SectionId, b.PositionId, b.Fullname
                                       select b).ToList();
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());

            if (this.action == TimeKeepingCode.UserAction.View)
            {
                cmbHolidayType.Enabled = false;
                dtpDateEffect.Enabled = false;
                txtDescription.ReadOnly = true;
                chkAll.Enabled = false;
                lnkUncheck.Enabled = false;
                gridList.Columns[0].ReadOnly = true;
            }
        }

        public List<TimeKeepingDataCode.Biometrics.HolidayEmployees> GetEmployees {
            get {
                List<TimeKeepingDataCode.Biometrics.HolidayEmployees> result = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();
                for (int i = 0; i < this.sellingArea.Count; i++)
                {
                    result.Add(new TimeKeepingDataCode.Biometrics.
                        HolidayEmployees(this.sellingArea[i],this.holidayName.Pk,this.sellingArea[i].IsHolidayDuty));
                }

                for (int i = 0; i < this.backOffice.Count; i++)
                {
                    result.Add(new TimeKeepingDataCode.Biometrics.
                        HolidayEmployees(this.backOffice[i], this.holidayName.Pk, this.backOffice[i].IsHolidayDuty));
                }
                return result;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
        }

        private void LoadEmployee() 
        {
            if (cmbArea.SelectedIndex == 0) 
                LoadGrid(this.sellingArea);
            else if (cmbArea.SelectedIndex == 1) 
                LoadGrid(this.backOffice);
        }

        private void LoadGrid(List<TimeKeepingDataCode.Biometrics.HolidayEmployees> employees) 
        {
            gridList.DataSource = null;
            gridList.DataSource = employees;
        }

        private void SelectedAreadChanged(object sender, EventArgs e)
        {
            LoadEmployee();
            CheckRestDaysLeaves();
        }

        private void CellMouseCheck(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || this.action == TimeKeepingCode.UserAction.Update)
            {
                DataGridView grid = sender as DataGridView;
                if (e.ColumnIndex == 1 && e.RowIndex != -1)
                {
                    grid.EndEdit();
                }
            }
        }

        private void GridKeyDown(object sender, KeyEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create || this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (gridList.SelectedRows.Count > 0)
                    {
                        gridList.SelectedRows[0].Cells[0].Value = !Convert.ToBoolean(gridList.SelectedRows[0].Cells[0].Value);
                    }
                }
            }
        }

        private void CheckAllChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                if (MessageBox.Show("Are you sure to Check all Employees?", "Check All",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    chkAll.CheckState = CheckState.Unchecked;
                    return;
                }
            }

            for (int i = 0; i < gridList.Rows.Count; i++)
            {
                gridList.Rows[i].Cells[0].Value = chkAll.Checked;
            }
        }

        private void Search(string search) 
        {
            if (cmbArea.SelectedIndex == 0)
                LoadGrid(this.sellingArea.FindAll(e => e.Fullname.Trim().ToLower().Contains(search.Trim().ToLower())));
            else if (cmbArea.SelectedIndex == 1)
                LoadGrid(this.backOffice.FindAll(e => e.Fullname.Trim().ToLower().Contains(search.Trim().ToLower())));
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void SetRestdayLeaves() 
        {
            Forms.FrmLoading loading = new Forms.FrmLoading("Getting Restdays/Leave Please Wait");
            BeginInvoke((Action)(() => loading.ShowDialog(this)));
            Task.Factory.StartNew(() =>
            {
                this.restdays = TimeKeepingDataCode.Biometrics.EmployeeShifting.
                    GetRestdaysEmpId(TimeKeepingCode.Program.BiometricsConnection, dtpDateEffect.Value);

                this.leaves = TimeKeepingDataCode.Biometrics.LeaveUndertime.
                    GetLeaveEmpIds(TimeKeepingCode.Program.BiometricsConnection, dtpDateEffect.Value);
            }).ContinueWith(a => {
                loading.Close();
                CheckRestDaysLeaves();
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CheckRestDaysLeaves() 
        {
            for (int i = 0; i < gridList.Rows.Count; i++)
            {
                var employee = gridList.Rows[i].DataBoundItem as TimeKeepingDataCode.Biometrics.HolidayEmployees;
                if (this.restdays.Exists(r => employee.EmployeeId == r))
                    gridList.Rows[i].Cells[5].Value = "Restday";
                else if(this.leaves.Exists(l => employee.EmployeeId == l))
                    gridList.Rows[i].Cells[5].Value = "Leave";
                else
                    gridList.Rows[i].Cells[5].Value = string.Empty;
            }
        }

        private void DateEffectValueChanged(object sender, EventArgs e)
        {
            SetRestdayLeaves();
        }

        private bool IsCheckAll() 
        {
            bool result = true;
            for (int i = 0; i < gridList.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(gridList.Rows[i].Cells[0].Value)) {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private void UncheckAllHaveRestdayLeave() 
        {
            for (int i = 0; i < gridList.Rows.Count; i++)
            {
                if (gridList.Rows[i].Cells[5].Value != null && !string.IsNullOrWhiteSpace(gridList.Rows[i].Cells[5].Value.ToString()))
                    gridList.Rows[i].Cells[0].Value = false;
            }
        }

        private void LinkUncheckAllRestdayLeave(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to uncheck employees have Restday/Leave?", "Uncheck", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            UncheckAllHaveRestdayLeave();
        }

        private void SetControls() 
        {
            gridList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridList.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridList.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
        }
    }
}
