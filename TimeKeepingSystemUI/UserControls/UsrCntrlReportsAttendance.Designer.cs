namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlReportsAttendance
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.chkExcludeGuards = new System.Windows.Forms.CheckBox();
            this.btnPrintReport = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnGenerateReport = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.grpFilterOption = new System.Windows.Forms.GroupBox();
            this.chkAwol = new System.Windows.Forms.CheckBox();
            this.chkHoliday = new System.Windows.Forms.CheckBox();
            this.chkRestday = new System.Windows.Forms.CheckBox();
            this.chkSuspension = new System.Windows.Forms.CheckBox();
            this.chkAbsence = new System.Windows.Forms.CheckBox();
            this.chkMorningLate = new System.Windows.Forms.CheckBox();
            this.chkUndertime = new System.Windows.Forms.CheckBox();
            this.chkLeave = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnAdd = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.gridFilterAdd = new System.Windows.Forms.DataGridView();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAreaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSectionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.lblSection = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.colResName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResEffectivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblBreadcumbAttendance = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilterOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilterAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 40);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(352, 628);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.chkExcludeGuards);
            this.pnlFilter.Controls.Add(this.btnPrintReport);
            this.pnlFilter.Controls.Add(this.btnGenerateReport);
            this.pnlFilter.Controls.Add(this.grpFilterOption);
            this.pnlFilter.Controls.Add(this.btnAdd);
            this.pnlFilter.Controls.Add(this.gridFilterAdd);
            this.pnlFilter.Controls.Add(this.cmbPosition);
            this.pnlFilter.Controls.Add(this.lblPosition);
            this.pnlFilter.Controls.Add(this.cmbSection);
            this.pnlFilter.Controls.Add(this.lblSection);
            this.pnlFilter.Controls.Add(this.cmbDepartment);
            this.pnlFilter.Controls.Add(this.lblDepartment);
            this.pnlFilter.Controls.Add(this.cmbArea);
            this.pnlFilter.Controls.Add(this.lblArea);
            this.pnlFilter.Controls.Add(this.dtpDate);
            this.pnlFilter.Controls.Add(this.lblDate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(352, 628);
            this.pnlFilter.TabIndex = 0;
            // 
            // chkExcludeGuards
            // 
            this.chkExcludeGuards.AutoSize = true;
            this.chkExcludeGuards.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExcludeGuards.Location = new System.Drawing.Point(20, 541);
            this.chkExcludeGuards.Name = "chkExcludeGuards";
            this.chkExcludeGuards.Size = new System.Drawing.Size(158, 17);
            this.chkExcludeGuards.TabIndex = 32;
            this.chkExcludeGuards.Text = "Exclude Guards in Reports";
            this.chkExcludeGuards.UseVisualStyleBackColor = true;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Location = new System.Drawing.Point(20, 501);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(108, 23);
            this.btnPrintReport.TabIndex = 31;
            this.btnPrintReport.Text = "Print Report";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.PrintReportClick);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Location = new System.Drawing.Point(222, 501);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(108, 23);
            this.btnGenerateReport.TabIndex = 30;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.GenerateClick);
            // 
            // grpFilterOption
            // 
            this.grpFilterOption.Controls.Add(this.chkAwol);
            this.grpFilterOption.Controls.Add(this.chkHoliday);
            this.grpFilterOption.Controls.Add(this.chkRestday);
            this.grpFilterOption.Controls.Add(this.chkSuspension);
            this.grpFilterOption.Controls.Add(this.chkAbsence);
            this.grpFilterOption.Controls.Add(this.chkMorningLate);
            this.grpFilterOption.Controls.Add(this.chkUndertime);
            this.grpFilterOption.Controls.Add(this.chkLeave);
            this.grpFilterOption.Controls.Add(this.chkAll);
            this.grpFilterOption.Location = new System.Drawing.Point(3, 358);
            this.grpFilterOption.Name = "grpFilterOption";
            this.grpFilterOption.Size = new System.Drawing.Size(346, 137);
            this.grpFilterOption.TabIndex = 29;
            this.grpFilterOption.TabStop = false;
            this.grpFilterOption.Text = "Selected Filter";
            // 
            // chkAwol
            // 
            this.chkAwol.AutoSize = true;
            this.chkAwol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAwol.Location = new System.Drawing.Point(252, 34);
            this.chkAwol.Name = "chkAwol";
            this.chkAwol.Size = new System.Drawing.Size(49, 17);
            this.chkAwol.TabIndex = 8;
            this.chkAwol.Text = "Awol";
            this.chkAwol.UseVisualStyleBackColor = true;
            // 
            // chkHoliday
            // 
            this.chkHoliday.AutoSize = true;
            this.chkHoliday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkHoliday.Location = new System.Drawing.Point(134, 103);
            this.chkHoliday.Name = "chkHoliday";
            this.chkHoliday.Size = new System.Drawing.Size(62, 17);
            this.chkHoliday.TabIndex = 7;
            this.chkHoliday.Text = "Holiday";
            this.chkHoliday.UseVisualStyleBackColor = true;
            // 
            // chkRestday
            // 
            this.chkRestday.AutoSize = true;
            this.chkRestday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRestday.Location = new System.Drawing.Point(134, 80);
            this.chkRestday.Name = "chkRestday";
            this.chkRestday.Size = new System.Drawing.Size(63, 17);
            this.chkRestday.TabIndex = 6;
            this.chkRestday.Text = "Restday";
            this.chkRestday.UseVisualStyleBackColor = true;
            // 
            // chkSuspension
            // 
            this.chkSuspension.AutoSize = true;
            this.chkSuspension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSuspension.Location = new System.Drawing.Point(134, 57);
            this.chkSuspension.Name = "chkSuspension";
            this.chkSuspension.Size = new System.Drawing.Size(83, 17);
            this.chkSuspension.TabIndex = 5;
            this.chkSuspension.Text = "Suspension";
            this.chkSuspension.UseVisualStyleBackColor = true;
            // 
            // chkAbsence
            // 
            this.chkAbsence.AutoSize = true;
            this.chkAbsence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAbsence.Location = new System.Drawing.Point(134, 34);
            this.chkAbsence.Name = "chkAbsence";
            this.chkAbsence.Size = new System.Drawing.Size(66, 17);
            this.chkAbsence.TabIndex = 4;
            this.chkAbsence.Text = "Absence";
            this.chkAbsence.UseVisualStyleBackColor = true;
            // 
            // chkMorningLate
            // 
            this.chkMorningLate.AutoSize = true;
            this.chkMorningLate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkMorningLate.Location = new System.Drawing.Point(17, 103);
            this.chkMorningLate.Name = "chkMorningLate";
            this.chkMorningLate.Size = new System.Drawing.Size(92, 17);
            this.chkMorningLate.TabIndex = 3;
            this.chkMorningLate.Text = "Morning Late";
            this.chkMorningLate.UseVisualStyleBackColor = true;
            // 
            // chkUndertime
            // 
            this.chkUndertime.AutoSize = true;
            this.chkUndertime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUndertime.Location = new System.Drawing.Point(17, 80);
            this.chkUndertime.Name = "chkUndertime";
            this.chkUndertime.Size = new System.Drawing.Size(77, 17);
            this.chkUndertime.TabIndex = 2;
            this.chkUndertime.Text = "Undertime";
            this.chkUndertime.UseVisualStyleBackColor = true;
            // 
            // chkLeave
            // 
            this.chkLeave.AutoSize = true;
            this.chkLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLeave.Location = new System.Drawing.Point(16, 57);
            this.chkLeave.Name = "chkLeave";
            this.chkLeave.Size = new System.Drawing.Size(51, 17);
            this.chkLeave.TabIndex = 1;
            this.chkLeave.Text = "Leave";
            this.chkLeave.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAll.Location = new System.Drawing.Point(17, 34);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(69, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.CheckAllCheckChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(255, 162);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddClick);
            // 
            // gridFilterAdd
            // 
            this.gridFilterAdd.AllowUserToAddRows = false;
            this.gridFilterAdd.AllowUserToResizeRows = false;
            this.gridFilterAdd.BackgroundColor = System.Drawing.Color.White;
            this.gridFilterAdd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridFilterAdd.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridFilterAdd.ColumnHeadersHeight = 25;
            this.gridFilterAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridFilterAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArea,
            this.colDepartment,
            this.colSection,
            this.colPosition,
            this.colEmployee,
            this.colType,
            this.colAreaId,
            this.colDepartmentId,
            this.colSectionId,
            this.colPositionId,
            this.colEmployeeId});
            this.gridFilterAdd.EnableHeadersVisualStyles = false;
            this.gridFilterAdd.Location = new System.Drawing.Point(3, 216);
            this.gridFilterAdd.MultiSelect = false;
            this.gridFilterAdd.Name = "gridFilterAdd";
            this.gridFilterAdd.RowHeadersVisible = false;
            this.gridFilterAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFilterAdd.Size = new System.Drawing.Size(346, 117);
            this.gridFilterAdd.TabIndex = 24;
            // 
            // colArea
            // 
            this.colArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colArea.HeaderText = "Area";
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            // 
            // colDepartment
            // 
            this.colDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDepartment.HeaderText = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            // 
            // colSection
            // 
            this.colSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSection.HeaderText = "Section";
            this.colSection.Name = "colSection";
            this.colSection.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colEmployee
            // 
            this.colEmployee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEmployee.HeaderText = "Employee";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Visible = false;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Visible = false;
            // 
            // colAreaId
            // 
            this.colAreaId.HeaderText = "AreaId";
            this.colAreaId.Name = "colAreaId";
            this.colAreaId.ReadOnly = true;
            this.colAreaId.Visible = false;
            // 
            // colDepartmentId
            // 
            this.colDepartmentId.HeaderText = "DepartmentId";
            this.colDepartmentId.Name = "colDepartmentId";
            this.colDepartmentId.ReadOnly = true;
            this.colDepartmentId.Visible = false;
            // 
            // colSectionId
            // 
            this.colSectionId.HeaderText = "SectionId";
            this.colSectionId.Name = "colSectionId";
            this.colSectionId.ReadOnly = true;
            this.colSectionId.Visible = false;
            // 
            // colPositionId
            // 
            this.colPositionId.HeaderText = "PositionId";
            this.colPositionId.Name = "colPositionId";
            this.colPositionId.ReadOnly = true;
            this.colPositionId.Visible = false;
            // 
            // colEmployeeId
            // 
            this.colEmployeeId.HeaderText = "EmployeeId";
            this.colEmployeeId.Name = "colEmployeeId";
            this.colEmployeeId.ReadOnly = true;
            this.colEmployeeId.Visible = false;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(94, 135);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(236, 21);
            this.cmbPosition.TabIndex = 21;
            this.cmbPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PositionKeyDown);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(36, 138);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(52, 13);
            this.lblPosition.TabIndex = 20;
            this.lblPosition.Text = "Position:";
            // 
            // cmbSection
            // 
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(94, 108);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(236, 21);
            this.cmbSection.TabIndex = 19;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.SectionSelectedChanged);
            this.cmbSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionKeyDown);
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(40, 111);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(48, 13);
            this.lblSection.TabIndex = 18;
            this.lblSection.Text = "Section:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(94, 81);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(236, 21);
            this.cmbDepartment.TabIndex = 17;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.DepartmentChanged);
            this.cmbDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmentKeyDown);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(17, 84);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(71, 13);
            this.lblDepartment.TabIndex = 16;
            this.lblDepartment.Text = "Department:";
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(94, 54);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(236, 21);
            this.cmbArea.TabIndex = 15;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.AreaSelectedChanged);
            this.cmbArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AreaKeyDown);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(55, 57);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(33, 13);
            this.lblArea.TabIndex = 14;
            this.lblArea.Text = "Area:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(94, 26);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(236, 22);
            this.dtpDate.TabIndex = 13;
            this.dtpDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateKeyDown);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(54, 33);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Date:";
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AllowUserToDeleteRows = false;
            this.gridResult.AllowUserToResizeRows = false;
            this.gridResult.BackgroundColor = System.Drawing.Color.White;
            this.gridResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridResult.ColumnHeadersHeight = 25;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResName,
            this.colResPosition,
            this.colResSection,
            this.colResEffectivity,
            this.colReReason,
            this.colResApprovedBy,
            this.colResRemarks});
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.EnableHeadersVisualStyles = false;
            this.gridResult.GridColor = System.Drawing.Color.Gray;
            this.gridResult.Location = new System.Drawing.Point(352, 40);
            this.gridResult.MultiSelect = false;
            this.gridResult.Name = "gridResult";
            this.gridResult.RowHeadersVisible = false;
            this.gridResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResult.Size = new System.Drawing.Size(620, 628);
            this.gridResult.TabIndex = 1;
            // 
            // colResName
            // 
            this.colResName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResName.HeaderText = "Name";
            this.colResName.Name = "colResName";
            this.colResName.ReadOnly = true;
            // 
            // colResPosition
            // 
            this.colResPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResPosition.HeaderText = "Position";
            this.colResPosition.Name = "colResPosition";
            this.colResPosition.ReadOnly = true;
            // 
            // colResSection
            // 
            this.colResSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResSection.HeaderText = "Section";
            this.colResSection.Name = "colResSection";
            this.colResSection.ReadOnly = true;
            // 
            // colResEffectivity
            // 
            this.colResEffectivity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResEffectivity.HeaderText = "Effectivity";
            this.colResEffectivity.Name = "colResEffectivity";
            this.colResEffectivity.ReadOnly = true;
            // 
            // colReReason
            // 
            this.colReReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colReReason.HeaderText = "Reason";
            this.colReReason.Name = "colReReason";
            this.colReReason.ReadOnly = true;
            // 
            // colResApprovedBy
            // 
            this.colResApprovedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResApprovedBy.HeaderText = "Approved By";
            this.colResApprovedBy.Name = "colResApprovedBy";
            this.colResApprovedBy.ReadOnly = true;
            // 
            // colResRemarks
            // 
            this.colResRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colResRemarks.HeaderText = "Remarks";
            this.colResRemarks.Name = "colResRemarks";
            this.colResRemarks.ReadOnly = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBreadcumbAttendance);
            this.pnlTop.Controls.Add(this.lblBreadcumbHome);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(972, 40);
            this.pnlTop.TabIndex = 2;
            // 
            // lblBreadcumbAttendance
            // 
            this.lblBreadcumbAttendance.AutoSize = true;
            this.lblBreadcumbAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbAttendance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbAttendance.Location = new System.Drawing.Point(68, 11);
            this.lblBreadcumbAttendance.Name = "lblBreadcumbAttendance";
            this.lblBreadcumbAttendance.Size = new System.Drawing.Size(90, 17);
            this.lblBreadcumbAttendance.TabIndex = 11;
            this.lblBreadcumbAttendance.Text = "/ SCHEDULES";
            this.lblBreadcumbAttendance.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblBreadcumbAttendance.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(15, 11);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 10;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.HomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // UsrCntrlReportsAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlReportsAttendance";
            this.Size = new System.Drawing.Size(972, 668);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpFilterOption.ResumeLayout(false);
            this.grpFilterOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFilterAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private ModifiedControls.Button btnAdd;
        private System.Windows.Forms.DataGridView gridFilterAdd;
        private System.Windows.Forms.GroupBox grpFilterOption;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkAwol;
        private System.Windows.Forms.CheckBox chkHoliday;
        private System.Windows.Forms.CheckBox chkRestday;
        private System.Windows.Forms.CheckBox chkSuspension;
        private System.Windows.Forms.CheckBox chkAbsence;
        private System.Windows.Forms.CheckBox chkMorningLate;
        private System.Windows.Forms.CheckBox chkUndertime;
        private System.Windows.Forms.CheckBox chkLeave;
        private ModifiedControls.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResEffectivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResApprovedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResRemarks;
        private ModifiedControls.Button btnPrintReport;
        private System.Windows.Forms.CheckBox chkExcludeGuards;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAreaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSectionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployeeId;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBreadcumbAttendance;
        private System.Windows.Forms.Label lblBreadcumbHome;
    }
}
