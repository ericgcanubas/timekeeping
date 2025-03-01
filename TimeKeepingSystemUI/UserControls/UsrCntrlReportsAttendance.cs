using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.PayrollSystem;
using System.Data;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlReportsAttendance : UserControl
    {
        private List<Area> areas;
        private List<Department> departments;
        private List<Section> sections;
        private List<Position> positions;
        private List<Branch> branches;

        private List<TimeKeepingDataCode.Biometrics.AttendanceEmployee> result;

        public UsrCntrlReportsAttendance()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            cmbArea.DisplayMember = "Description";
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbSection.DisplayMember = "SectionName";
            cmbPosition.DisplayMember = "PositionName";

            this.result = new List<TimeKeepingDataCode.Biometrics.AttendanceEmployee>();
        }

        private static UsrCntrlReportsAttendance instance;
        public static UsrCntrlReportsAttendance Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlReportsAttendance();
                    instance.Name = "singletonReportsAttendance";
                }
                return instance;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
            Task.Factory.StartNew(() =>
            {
                this.areas = Area.GetAllArea(TimeKeepingCode.Program.PayrollConnection);
                this.departments = Department.GetAllDepartments(TimeKeepingCode.Program.PayrollConnection);
                this.sections = Section.GetAllSections(TimeKeepingCode.Program.PayrollConnection);
                this.positions = Position.GetAllPosition(TimeKeepingCode.Program.PayrollConnection);
                this.branches = Branch.GetBranch(TimeKeepingCode.Program.PayrollConnection);
            }).ContinueWith(a => {
                var b = new List<Area>();
                b.Add(new Area(0,"ALL"));
                b.AddRange(this.areas);

                cmbArea.DataSource = b;
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void AreaKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                cmbDepartment.Focus();
            }
        }

        private void AreaSelectedChanged(object sender, EventArgs e)
        {
            var b = this.branches.FindAll(br => br.Area.ToLower().Trim() == cmbArea.Text.Trim().ToLower());
            var d = new List<Department>();
            if (cmbArea.Text.ToLower().Trim() == "all")
            {
                d.Add(new Department(0,"ALL",0));
                d.AddRange(this.departments);
            }
            else {
                d.Add(new Department(0, "ALL", 0));
                d.AddRange(this.departments.FindAll(de => b.Exists(br => br.DepartmentId == de.Id)));
            }
            cmbDepartment.DataSource = d;
        }

        private void DepartmentChanged(object sender, EventArgs e)
        {
            var b = this.branches.FindAll(br => br.Department.ToLower().Trim() == cmbDepartment.Text.Trim().ToLower());
            var d = new List<Section>();
            if (cmbDepartment.Text.ToLower().Trim() == "all")
            {
                d.Add(new Section(0,"ALL",string.Empty,0,0,0,0,0,0,string.Empty,string.Empty,string.Empty));
                d.AddRange(this.sections);
            }
            else
            {
                d.Add(new Section(0, "ALL", string.Empty, 0, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty));
                d.AddRange(this.sections.FindAll(de => b.Exists(br => br.SectionId == de.Id)));
            }
            cmbSection.DataSource = d;
        }

        private void SectionSelectedChanged(object sender, EventArgs e)
        {
            var p = new List<Position>();
            if (cmbSection.Text.ToLower().Trim() == "all")
            {
                p.Add(new Position(0, "ALL", 0, 0, 0, 0, 0, 0, 0, 0, 0, string.Empty, 0, 0, string.Empty, new DateTime(), 0));
                p.AddRange(this.positions);
            }
            else {
                Section s = cmbSection.SelectedItem as Section;
                if (s != null)
                {
                    p.Add(new Position(0, "ALL", 0, 0, 0, 0, 0, 0, 0, 0, 0, string.Empty, 0, 0, string.Empty, new DateTime(), 0));
                    p.AddRange(this.positions.FindAll(ps => ps.SectionId == s.Id));
                }
            }
            cmbPosition.DataSource = p;
        }

        private void DateKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbArea.Focus();
        }

        private void TypeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbArea.Focus();
        }

        private void DepartmentKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSection.Focus();
        }

        private void SectionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPosition.Focus();
        }

        private void PositionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAdd.Focus();
        }

        private void SelectFilter() 
        {
            var a = cmbArea.SelectedItem as Area;
            var d = cmbDepartment.SelectedItem as Department;
            var s = cmbSection.SelectedItem as Section;
            var p = cmbPosition.SelectedItem as Position;

            gridFilterAdd.Rows.Add(a.Description,d.DepartmentName,s.SectionName,p.PositionName,
                string.Empty,string.Empty,a.Pk,d.Id,s.Id,p.Id,0);
        }

        private void AddClick(object sender, EventArgs e)
        {
            SelectFilter();
        }

        private List<TimeKeepingDataCode.FilterAttendanceReport> CreateReportFilter() 
        {
            List<TimeKeepingDataCode.FilterAttendanceReport> result = new List<TimeKeepingDataCode.FilterAttendanceReport>();
            for (int i = 0; i < gridFilterAdd.Rows.Count; i++)
            {
                DataGridViewRow row = gridFilterAdd.Rows[i];
                result.Add(new TimeKeepingDataCode.FilterAttendanceReport(row.Cells[5].Value.ToString(),
                    Convert.ToInt32(row.Cells[6].Value),Convert.ToInt32(row.Cells[7].Value),
                    Convert.ToInt32(row.Cells[8].Value),Convert.ToInt32(row.Cells[9].Value),
                    Convert.ToInt32(row.Cells[10].Value)));
            }
            return result;
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            Generate(chkLeave.Checked,chkUndertime.Checked,chkMorningLate.Checked,chkAbsence.Checked,
                chkSuspension.Checked,chkRestday.Checked,chkHoliday.Checked,chkAwol.Checked,dtpDate.Value);
        }

        private bool IsPrint(int areaId, int departmentId, int sectionId, int positionId)
        {
            bool result = false;
            for (int i = 0; i < gridFilterAdd.Rows.Count; i++)
            {
                //if all position selected
                DataGridViewRow row = gridFilterAdd.Rows[i];
                if (Convert.ToInt32(row.Cells[9].Value) == 0)
                {
                    //if all section selected
                    if (Convert.ToInt32(row.Cells[8].Value) == 0)
                    {
                        //if all department selected
                        if (Convert.ToInt32(row.Cells[7].Value) == 0)
                        {
                            //if all area selected
                            if (Convert.ToInt32(row.Cells[6].Value) == 0)
                            {
                                result = true;
                                break;
                            }
                            else
                            {
                                if (areaId == Convert.ToInt32(row.Cells[6].Value))
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (departmentId == Convert.ToInt32(row.Cells[7].Value))
                            {
                                result = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (sectionId == Convert.ToInt32(row.Cells[8].Value))
                        {
                            result = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (positionId == Convert.ToInt32(row.Cells[9].Value))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public void Generate(bool isLeave, bool isUndertime, bool isMorningLate, bool isAbsence,
            bool isSuspension, bool isRestday, bool isHoliday, bool isAwol, DateTime dateEffect)
        {
            this.result.Clear();

            btnGenerateReport.Enabled = false;
            btnPrintReport.Enabled = false;

            btnGenerateReport.Text = "Please Wait ..";
            btnPrintReport.Text = "Please Wait ..";

            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.AttendanceEmployee.GetAttendanceEmployees(TimeKeepingCode.Program.BiometricsConnection, dateEffect);
            }).ContinueWith(a => {
                var resultData = a.Result;
                for (int i = 0; i < resultData.Count; i++)
                {
                    if (IsPrint(resultData[i].AreaID, resultData[i].DepartmentNo,
                            resultData[i].SectionID, resultData[i].PositionID))
                    {
                        if (resultData[i].DescriptionType.Equals("awol", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isAwol)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("suspension", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isSuspension)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("absent", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isAbsence)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("holiday", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isHoliday)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("restday", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isRestday)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("leave", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isLeave)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("undertime", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isUndertime)
                                this.result.Add(resultData[i]);
                        }
                        else if (resultData[i].DescriptionType.Equals("late", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (isMorningLate)
                                this.result.Add(resultData[i]);
                        }
                    }
                }

                var r = from s in this.result
                        orderby s.DescriptionType, s.AreaID, s.DepartmentNo, s.SectionID, s.PositionID, s.Lastname
                        select s;

                this.result = r.ToList();
                LoadResult();

                btnGenerateReport.Enabled = !false;
                btnPrintReport.Enabled = !false;

                btnGenerateReport.Text = "Generate Report";
                btnPrintReport.Text = "Print Report";

            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadResult() {
            gridResult.Rows.Clear();
            for (int i = 0; i < this.result.Count; i++)
            {
                if (i == 0)
                {
                    gridResult.Rows.Add(this.result[i].DescriptionType);
                    gridResult.Rows.Add("    " + this.result[i].ToString(), this.result[i].Position, this.result[i].Section,
                        this.result[i].Effectivity, this.result[i].Reason, this.result[i].ApprovedBy, this.result[i].Remarks);
                }
                else
                {
                    if (this.result[i - 1].DescriptionType.Equals(this.result[i].DescriptionType))
                        gridResult.Rows.Add("    " + this.result[i].ToString(), this.result[i].Position, this.result[i].Section,
                            this.result[i].Effectivity, this.result[i].Reason, this.result[i].ApprovedBy, this.result[i].Remarks);
                    else
                    {
                        gridResult.Rows.Add(this.result[i].DescriptionType);
                        gridResult.Rows.Add("    " + this.result[i].ToString(), this.result[i].Position, this.result[i].Section,
                            this.result[i].Effectivity, this.result[i].Reason, this.result[i].ApprovedBy, this.result[i].Remarks);
                    }
                }
            }
        }

        private void CheckAllCheckChanged(object sender, EventArgs e)
        {
            chkLeave.Checked = chkAll.Checked;
            chkUndertime.Checked = chkAll.Checked;
            chkMorningLate.Checked = chkAll.Checked;
            chkAbsence.Checked = chkAll.Checked;
            chkSuspension.Checked = chkAll.Checked;
            chkRestday.Checked = chkAll.Checked;
            chkHoliday.Checked = chkAll.Checked;
            chkAwol.Checked = chkAll.Checked;
        }

        private void SetControls() {
            gridResult.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridResult.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridResult.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridResult.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            gridFilterAdd.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridFilterAdd.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridFilterAdd.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridFilterAdd.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            lblBreadcumbAttendance.ForeColor = Code.Program.MainColor;
            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
        }

        private void GeneratePrintReport() 
        {
            if (gridResult.Rows.Count == 0)
            {
                MessageBox.Show("Can't print with empty list.", "Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            System.Data.DataTable table = new DataTable();
            table.Columns.Add("EmpName", typeof(string));
            table.Columns.Add("Position", typeof(string));
            table.Columns.Add("Section", typeof(string));
            table.Columns.Add("EffectivityDate", typeof(string));
            table.Columns.Add("Reason", typeof(string));
            table.Columns.Add("ApprovedBy", typeof(string));
            table.Columns.Add("Remarks", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("PositionId", typeof(int));
            table.Columns.Add("SectionId", typeof(int));
            table.Columns.Add("DepartmentId", typeof(int));
            table.Columns.Add("AreaId", typeof(int));

            for (int i = 0; i < this.result.Count; i++)
            {
                if (chkExcludeGuards.Checked)
                {
                    if ( this.result[i].SectionID == 29)
                        continue;
                }
                table.Rows.Add( this.result[i].ToString(),  this.result[i].Position,  this.result[i].Section,  this.result[i].Effectivity,
                     this.result[i].Reason,  this.result[i].ApprovedBy,  this.result[i].Remarks,  this.result[i].DescriptionType, Convert.ToInt32( this.result[i].PositionID),
                    Convert.ToInt32( this.result[i].SectionID), Convert.ToInt32( this.result[i].DepartmentNo), Convert.ToInt32( this.result[i].AreaID));
            }

            Reports.FormPreviewReport report = new Reports.FormPreviewReport();
            report.rptViewer.LocalReport.DataSources.Clear();
            report.rptViewer.LocalReport.DataSources.Add(new
                Microsoft.Reporting.WinForms.ReportDataSource("AttendanceDataReport", table));
            report.rptViewer.LocalReport.ReportEmbeddedResource = "TimeKeepingSystemUI.Reports.ReportAttendance.rdlc";
            report.rptViewer.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter
                ("attendanceDate", dtpDate.Value.ToString("MMMM dd, yyyy")));
            report.rptViewer.RefreshReport();
            report.rptViewer.Refresh();
            report.ShowDialog();
            report.Dispose();
            report = null;
        }

        private void PrintReportClick(object sender, EventArgs e)
        {
            GeneratePrintReport();
        }

        private void HomeClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BreadCumbEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void BreadCumbLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }
    }
}
