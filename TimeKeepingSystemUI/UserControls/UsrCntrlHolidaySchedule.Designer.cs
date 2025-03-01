namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlHolidaySchedule
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
            this.lblHolidayType = new System.Windows.Forms.Label();
            this.cmbHolidayType = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblDateEffect = new System.Windows.Forms.Label();
            this.dtpDateEffect = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPayrollLocked = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotalDuty = new System.Windows.Forms.Label();
            this.lblTotalHoliday = new System.Windows.Forms.Label();
            this.gridList = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lnkUncheck = new System.Windows.Forms.LinkLabel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHolidayType
            // 
            this.lblHolidayType.AutoSize = true;
            this.lblHolidayType.Location = new System.Drawing.Point(16, 18);
            this.lblHolidayType.Name = "lblHolidayType";
            this.lblHolidayType.Size = new System.Drawing.Size(72, 13);
            this.lblHolidayType.TabIndex = 0;
            this.lblHolidayType.Text = "Holiday Type";
            // 
            // cmbHolidayType
            // 
            this.cmbHolidayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHolidayType.FormattingEnabled = true;
            this.cmbHolidayType.Items.AddRange(new object[] {
            "Regular",
            "Special"});
            this.cmbHolidayType.Location = new System.Drawing.Point(94, 15);
            this.cmbHolidayType.Name = "cmbHolidayType";
            this.cmbHolidayType.Size = new System.Drawing.Size(197, 21);
            this.cmbHolidayType.TabIndex = 1;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(58, 51);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(30, 13);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Area";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "Selling Area",
            "Back Office"});
            this.cmbArea.Location = new System.Drawing.Point(94, 48);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(197, 21);
            this.cmbArea.TabIndex = 3;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.SelectedAreadChanged);
            // 
            // lblDateEffect
            // 
            this.lblDateEffect.AutoSize = true;
            this.lblDateEffect.Location = new System.Drawing.Point(312, 18);
            this.lblDateEffect.Name = "lblDateEffect";
            this.lblDateEffect.Size = new System.Drawing.Size(63, 13);
            this.lblDateEffect.TabIndex = 4;
            this.lblDateEffect.Text = "Date Effect";
            // 
            // dtpDateEffect
            // 
            this.dtpDateEffect.Location = new System.Drawing.Point(381, 15);
            this.dtpDateEffect.Name = "dtpDateEffect";
            this.dtpDateEffect.Size = new System.Drawing.Size(196, 22);
            this.dtpDateEffect.TabIndex = 5;
            this.dtpDateEffect.ValueChanged += new System.EventHandler(this.DateEffectValueChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(309, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(381, 47);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(196, 22);
            this.txtDescription.TabIndex = 7;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblPayrollLocked);
            this.pnlHeader.Controls.Add(this.dtpDateEffect);
            this.pnlHeader.Controls.Add(this.txtDescription);
            this.pnlHeader.Controls.Add(this.lblHolidayType);
            this.pnlHeader.Controls.Add(this.lblDescription);
            this.pnlHeader.Controls.Add(this.cmbHolidayType);
            this.pnlHeader.Controls.Add(this.lblArea);
            this.pnlHeader.Controls.Add(this.lblDateEffect);
            this.pnlHeader.Controls.Add(this.cmbArea);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 81);
            this.pnlHeader.TabIndex = 8;
            // 
            // lblPayrollLocked
            // 
            this.lblPayrollLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPayrollLocked.AutoSize = true;
            this.lblPayrollLocked.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollLocked.ForeColor = System.Drawing.Color.Salmon;
            this.lblPayrollLocked.Location = new System.Drawing.Point(710, 37);
            this.lblPayrollLocked.Name = "lblPayrollLocked";
            this.lblPayrollLocked.Size = new System.Drawing.Size(173, 32);
            this.lblPayrollLocked.TabIndex = 8;
            this.lblPayrollLocked.Text = "Payroll Locked";
            this.lblPayrollLocked.Visible = false;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(634, 100);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(681, 91);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(216, 22);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChanged);
            // 
            // lblTotalDuty
            // 
            this.lblTotalDuty.AutoSize = true;
            this.lblTotalDuty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDuty.Location = new System.Drawing.Point(21, 14);
            this.lblTotalDuty.Name = "lblTotalDuty";
            this.lblTotalDuty.Size = new System.Drawing.Size(73, 13);
            this.lblTotalDuty.TabIndex = 11;
            this.lblTotalDuty.Text = "Total Duty: 0";
            this.lblTotalDuty.Visible = false;
            // 
            // lblTotalHoliday
            // 
            this.lblTotalHoliday.AutoSize = true;
            this.lblTotalHoliday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHoliday.Location = new System.Drawing.Point(138, 14);
            this.lblTotalHoliday.Name = "lblTotalHoliday";
            this.lblTotalHoliday.Size = new System.Drawing.Size(88, 13);
            this.lblTotalHoliday.TabIndex = 12;
            this.lblTotalHoliday.Text = "Total Holiday: 0";
            this.lblTotalHoliday.Visible = false;
            // 
            // gridList
            // 
            this.gridList.AllowUserToAddRows = false;
            this.gridList.AllowUserToDeleteRows = false;
            this.gridList.AllowUserToResizeRows = false;
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridList.ColumnHeadersHeight = 25;
            this.gridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colName,
            this.colDepartment,
            this.colSection,
            this.colPosition,
            this.colRemarks});
            this.gridList.EnableHeadersVisualStyles = false;
            this.gridList.Location = new System.Drawing.Point(0, 122);
            this.gridList.MultiSelect = false;
            this.gridList.Name = "gridList";
            this.gridList.RowHeadersVisible = false;
            this.gridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridList.Size = new System.Drawing.Size(900, 390);
            this.gridList.TabIndex = 13;
            this.gridList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CellMouseCheck);
            this.gridList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridKeyDown);
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "IsHolidayDuty";
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 50;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Fullname";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDepartment
            // 
            this.colDepartment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDepartment.DataPropertyName = "Department";
            this.colDepartment.HeaderText = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.ReadOnly = true;
            // 
            // colSection
            // 
            this.colSection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSection.DataPropertyName = "Section";
            this.colSection.HeaderText = "Section";
            this.colSection.Name = "colSection";
            this.colSection.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPosition.DataPropertyName = "Position";
            this.colPosition.HeaderText = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(19, 96);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(121, 17);
            this.chkAll.TabIndex = 14;
            this.chkAll.Text = "Check/Uncheck All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.CheckAllChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblTotalHoliday);
            this.pnlBottom.Controls.Add(this.lblTotalDuty);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(900, 34);
            this.pnlBottom.TabIndex = 15;
            // 
            // lnkUncheck
            // 
            this.lnkUncheck.AutoSize = true;
            this.lnkUncheck.LinkColor = System.Drawing.Color.Black;
            this.lnkUncheck.Location = new System.Drawing.Point(158, 97);
            this.lnkUncheck.Name = "lnkUncheck";
            this.lnkUncheck.Size = new System.Drawing.Size(126, 13);
            this.lnkUncheck.TabIndex = 16;
            this.lnkUncheck.TabStop = true;
            this.lnkUncheck.Text = "Uncheck Restday/Leave";
            this.lnkUncheck.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkUncheckAllRestdayLeave);
            // 
            // UsrCntrlHolidaySchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkUncheck);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.gridList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlHolidaySchedule";
            this.Size = new System.Drawing.Size(900, 547);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHolidayType;
        private System.Windows.Forms.ComboBox cmbHolidayType;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblDateEffect;
        private System.Windows.Forms.DateTimePicker dtpDateEffect;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTotalDuty;
        private System.Windows.Forms.Label lblTotalHoliday;
        private System.Windows.Forms.DataGridView gridList;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.LinkLabel lnkUncheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.Label lblPayrollLocked;
    }
}
