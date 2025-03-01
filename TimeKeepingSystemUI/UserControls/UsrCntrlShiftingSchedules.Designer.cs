namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlShiftingSchedules
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.cmbShiftingType = new System.Windows.Forms.ComboBox();
            this.cmbScheduleType = new System.Windows.Forms.ComboBox();
            this.txtLastModified = new System.Windows.Forms.TextBox();
            this.lblLastModified = new System.Windows.Forms.Label();
            this.chkIsFixed = new System.Windows.Forms.CheckBox();
            this.txtBreak = new System.Windows.Forms.TextBox();
            this.lblBreak = new System.Windows.Forms.Label();
            this.txtLunch = new System.Windows.Forms.TextBox();
            this.lblLunch = new System.Windows.Forms.Label();
            this.txtPmOut = new System.Windows.Forms.TextBox();
            this.lblPmOut = new System.Windows.Forms.Label();
            this.txtCoffeeIn = new System.Windows.Forms.TextBox();
            this.lblCoffeeIn = new System.Windows.Forms.Label();
            this.txtCoffeeOut = new System.Windows.Forms.TextBox();
            this.lblCoffeeOut = new System.Windows.Forms.Label();
            this.txtLunchIn = new System.Windows.Forms.TextBox();
            this.lblLunchIn = new System.Windows.Forms.Label();
            this.txtLunchOut = new System.Windows.Forms.TextBox();
            this.lblLunchOut = new System.Windows.Forms.Label();
            this.txtAmIn = new System.Windows.Forms.TextBox();
            this.lblAmIn = new System.Windows.Forms.Label();
            this.lblShiftingType = new System.Windows.Forms.Label();
            this.txtShiftingName = new System.Windows.Forms.TextBox();
            this.lblShifingName = new System.Windows.Forms.Label();
            this.lblScheduleType = new System.Windows.Forms.Label();
            this.gridScheduleList = new System.Windows.Forms.DataGridView();
            this.colShiftingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLunchOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coolLunchIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCofeeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCoffeeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPmOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.lblBreadcumbShifting = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.btnOne = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnTwo = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScheduleList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBreadcumbShifting);
            this.pnlTop.Controls.Add(this.lblBreadcumbHome);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.btnOne);
            this.pnlTop.Controls.Add(this.btnTwo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(879, 44);
            this.pnlTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(380, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(223, 22);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(330, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoScroll = true;
            this.pnlLeft.Controls.Add(this.cmbShiftingType);
            this.pnlLeft.Controls.Add(this.cmbScheduleType);
            this.pnlLeft.Controls.Add(this.txtLastModified);
            this.pnlLeft.Controls.Add(this.lblLastModified);
            this.pnlLeft.Controls.Add(this.chkIsFixed);
            this.pnlLeft.Controls.Add(this.txtBreak);
            this.pnlLeft.Controls.Add(this.lblBreak);
            this.pnlLeft.Controls.Add(this.txtLunch);
            this.pnlLeft.Controls.Add(this.lblLunch);
            this.pnlLeft.Controls.Add(this.txtPmOut);
            this.pnlLeft.Controls.Add(this.lblPmOut);
            this.pnlLeft.Controls.Add(this.txtCoffeeIn);
            this.pnlLeft.Controls.Add(this.lblCoffeeIn);
            this.pnlLeft.Controls.Add(this.txtCoffeeOut);
            this.pnlLeft.Controls.Add(this.lblCoffeeOut);
            this.pnlLeft.Controls.Add(this.txtLunchIn);
            this.pnlLeft.Controls.Add(this.lblLunchIn);
            this.pnlLeft.Controls.Add(this.txtLunchOut);
            this.pnlLeft.Controls.Add(this.lblLunchOut);
            this.pnlLeft.Controls.Add(this.txtAmIn);
            this.pnlLeft.Controls.Add(this.lblAmIn);
            this.pnlLeft.Controls.Add(this.lblShiftingType);
            this.pnlLeft.Controls.Add(this.txtShiftingName);
            this.pnlLeft.Controls.Add(this.lblShifingName);
            this.pnlLeft.Controls.Add(this.lblScheduleType);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLeft.Location = new System.Drawing.Point(603, 44);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(276, 559);
            this.pnlLeft.TabIndex = 1;
            // 
            // cmbShiftingType
            // 
            this.cmbShiftingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftingType.Enabled = false;
            this.cmbShiftingType.FormattingEnabled = true;
            this.cmbShiftingType.Location = new System.Drawing.Point(29, 105);
            this.cmbShiftingType.Name = "cmbShiftingType";
            this.cmbShiftingType.Size = new System.Drawing.Size(223, 21);
            this.cmbShiftingType.TabIndex = 2;
            this.cmbShiftingType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShiftingTypeKeyDown);
            // 
            // cmbScheduleType
            // 
            this.cmbScheduleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScheduleType.Enabled = false;
            this.cmbScheduleType.FormattingEnabled = true;
            this.cmbScheduleType.Location = new System.Drawing.Point(29, 30);
            this.cmbScheduleType.Name = "cmbScheduleType";
            this.cmbScheduleType.Size = new System.Drawing.Size(223, 21);
            this.cmbScheduleType.TabIndex = 0;
            this.cmbScheduleType.SelectedIndexChanged += new System.EventHandler(this.ScheduleTypeSelectedChanged);
            this.cmbScheduleType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScheduleTypeKeyDown);
            // 
            // txtLastModified
            // 
            this.txtLastModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastModified.Location = new System.Drawing.Point(29, 524);
            this.txtLastModified.Name = "txtLastModified";
            this.txtLastModified.ReadOnly = true;
            this.txtLastModified.Size = new System.Drawing.Size(223, 22);
            this.txtLastModified.TabIndex = 12;
            this.txtLastModified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastModifiedKeyDown);
            // 
            // lblLastModified
            // 
            this.lblLastModified.AutoSize = true;
            this.lblLastModified.Location = new System.Drawing.Point(26, 508);
            this.lblLastModified.Name = "lblLastModified";
            this.lblLastModified.Size = new System.Drawing.Size(77, 13);
            this.lblLastModified.TabIndex = 28;
            this.lblLastModified.Text = "Last Modified";
            // 
            // chkIsFixed
            // 
            this.chkIsFixed.AutoSize = true;
            this.chkIsFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsFixed.Enabled = false;
            this.chkIsFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsFixed.Location = new System.Drawing.Point(29, 444);
            this.chkIsFixed.Name = "chkIsFixed";
            this.chkIsFixed.Size = new System.Drawing.Size(61, 17);
            this.chkIsFixed.TabIndex = 11;
            this.chkIsFixed.Text = "Is Fixed";
            this.chkIsFixed.UseVisualStyleBackColor = true;
            this.chkIsFixed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsFixedKeyDown);
            // 
            // txtBreak
            // 
            this.txtBreak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBreak.Location = new System.Drawing.Point(29, 416);
            this.txtBreak.Name = "txtBreak";
            this.txtBreak.ReadOnly = true;
            this.txtBreak.Size = new System.Drawing.Size(223, 22);
            this.txtBreak.TabIndex = 10;
            this.txtBreak.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BreakKeyEvent);
            // 
            // lblBreak
            // 
            this.lblBreak.AutoSize = true;
            this.lblBreak.Location = new System.Drawing.Point(26, 400);
            this.lblBreak.Name = "lblBreak";
            this.lblBreak.Size = new System.Drawing.Size(36, 13);
            this.lblBreak.TabIndex = 25;
            this.lblBreak.Text = "Break";
            // 
            // txtLunch
            // 
            this.txtLunch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLunch.Location = new System.Drawing.Point(29, 377);
            this.txtLunch.Name = "txtLunch";
            this.txtLunch.ReadOnly = true;
            this.txtLunch.Size = new System.Drawing.Size(223, 22);
            this.txtLunch.TabIndex = 9;
            this.txtLunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LunchKeyDown);
            // 
            // lblLunch
            // 
            this.lblLunch.AutoSize = true;
            this.lblLunch.Location = new System.Drawing.Point(26, 361);
            this.lblLunch.Name = "lblLunch";
            this.lblLunch.Size = new System.Drawing.Size(38, 13);
            this.lblLunch.TabIndex = 23;
            this.lblLunch.Text = "Lunch";
            // 
            // txtPmOut
            // 
            this.txtPmOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPmOut.Location = new System.Drawing.Point(29, 338);
            this.txtPmOut.Name = "txtPmOut";
            this.txtPmOut.ReadOnly = true;
            this.txtPmOut.Size = new System.Drawing.Size(223, 22);
            this.txtPmOut.TabIndex = 8;
            this.txtPmOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PmOutKeyDown);
            this.txtPmOut.Validating += new System.ComponentModel.CancelEventHandler(this.PmOutValidating);
            // 
            // lblPmOut
            // 
            this.lblPmOut.AutoSize = true;
            this.lblPmOut.Location = new System.Drawing.Point(26, 322);
            this.lblPmOut.Name = "lblPmOut";
            this.lblPmOut.Size = new System.Drawing.Size(46, 13);
            this.lblPmOut.TabIndex = 21;
            this.lblPmOut.Text = "PM Out";
            // 
            // txtCoffeeIn
            // 
            this.txtCoffeeIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoffeeIn.Location = new System.Drawing.Point(29, 299);
            this.txtCoffeeIn.Name = "txtCoffeeIn";
            this.txtCoffeeIn.ReadOnly = true;
            this.txtCoffeeIn.Size = new System.Drawing.Size(223, 22);
            this.txtCoffeeIn.TabIndex = 7;
            this.txtCoffeeIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoffeeInKeyDown);
            this.txtCoffeeIn.Validating += new System.ComponentModel.CancelEventHandler(this.CoffeeInValidating);
            // 
            // lblCoffeeIn
            // 
            this.lblCoffeeIn.AutoSize = true;
            this.lblCoffeeIn.Location = new System.Drawing.Point(26, 283);
            this.lblCoffeeIn.Name = "lblCoffeeIn";
            this.lblCoffeeIn.Size = new System.Drawing.Size(54, 13);
            this.lblCoffeeIn.TabIndex = 19;
            this.lblCoffeeIn.Text = "Coffee In";
            // 
            // txtCoffeeOut
            // 
            this.txtCoffeeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoffeeOut.Location = new System.Drawing.Point(29, 260);
            this.txtCoffeeOut.Name = "txtCoffeeOut";
            this.txtCoffeeOut.ReadOnly = true;
            this.txtCoffeeOut.Size = new System.Drawing.Size(223, 22);
            this.txtCoffeeOut.TabIndex = 6;
            this.txtCoffeeOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoffeeOutKeyDown);
            this.txtCoffeeOut.Validating += new System.ComponentModel.CancelEventHandler(this.CoffeeOutValidating);
            // 
            // lblCoffeeOut
            // 
            this.lblCoffeeOut.AutoSize = true;
            this.lblCoffeeOut.Location = new System.Drawing.Point(26, 244);
            this.lblCoffeeOut.Name = "lblCoffeeOut";
            this.lblCoffeeOut.Size = new System.Drawing.Size(64, 13);
            this.lblCoffeeOut.TabIndex = 17;
            this.lblCoffeeOut.Text = "Coffee Out";
            // 
            // txtLunchIn
            // 
            this.txtLunchIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLunchIn.Location = new System.Drawing.Point(29, 222);
            this.txtLunchIn.Name = "txtLunchIn";
            this.txtLunchIn.ReadOnly = true;
            this.txtLunchIn.Size = new System.Drawing.Size(223, 22);
            this.txtLunchIn.TabIndex = 5;
            this.txtLunchIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LunchInKeyDown);
            this.txtLunchIn.Validating += new System.ComponentModel.CancelEventHandler(this.LunchInValidating);
            // 
            // lblLunchIn
            // 
            this.lblLunchIn.AutoSize = true;
            this.lblLunchIn.Location = new System.Drawing.Point(26, 206);
            this.lblLunchIn.Name = "lblLunchIn";
            this.lblLunchIn.Size = new System.Drawing.Size(51, 13);
            this.lblLunchIn.TabIndex = 15;
            this.lblLunchIn.Text = "Lunch In";
            // 
            // txtLunchOut
            // 
            this.txtLunchOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLunchOut.Location = new System.Drawing.Point(29, 183);
            this.txtLunchOut.Name = "txtLunchOut";
            this.txtLunchOut.ReadOnly = true;
            this.txtLunchOut.Size = new System.Drawing.Size(223, 22);
            this.txtLunchOut.TabIndex = 4;
            this.txtLunchOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LunchOutKeyDown);
            this.txtLunchOut.Validating += new System.ComponentModel.CancelEventHandler(this.LunchOutValidating);
            // 
            // lblLunchOut
            // 
            this.lblLunchOut.AutoSize = true;
            this.lblLunchOut.Location = new System.Drawing.Point(26, 167);
            this.lblLunchOut.Name = "lblLunchOut";
            this.lblLunchOut.Size = new System.Drawing.Size(61, 13);
            this.lblLunchOut.TabIndex = 13;
            this.lblLunchOut.Text = "Lunch Out";
            // 
            // txtAmIn
            // 
            this.txtAmIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmIn.Location = new System.Drawing.Point(29, 143);
            this.txtAmIn.Name = "txtAmIn";
            this.txtAmIn.ReadOnly = true;
            this.txtAmIn.Size = new System.Drawing.Size(223, 22);
            this.txtAmIn.TabIndex = 3;
            this.txtAmIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AMInKeyDown);
            this.txtAmIn.Validating += new System.ComponentModel.CancelEventHandler(this.AMInValidating);
            // 
            // lblAmIn
            // 
            this.lblAmIn.AutoSize = true;
            this.lblAmIn.Location = new System.Drawing.Point(26, 127);
            this.lblAmIn.Name = "lblAmIn";
            this.lblAmIn.Size = new System.Drawing.Size(37, 13);
            this.lblAmIn.TabIndex = 11;
            this.lblAmIn.Text = "AM In";
            // 
            // lblShiftingType
            // 
            this.lblShiftingType.AutoSize = true;
            this.lblShiftingType.Location = new System.Drawing.Point(26, 89);
            this.lblShiftingType.Name = "lblShiftingType";
            this.lblShiftingType.Size = new System.Drawing.Size(74, 13);
            this.lblShiftingType.TabIndex = 9;
            this.lblShiftingType.Text = "Shifting Type";
            // 
            // txtShiftingName
            // 
            this.txtShiftingName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShiftingName.Location = new System.Drawing.Point(29, 67);
            this.txtShiftingName.Name = "txtShiftingName";
            this.txtShiftingName.ReadOnly = true;
            this.txtShiftingName.Size = new System.Drawing.Size(223, 22);
            this.txtShiftingName.TabIndex = 1;
            this.txtShiftingName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShiftingNameKeyDown);
            // 
            // lblShifingName
            // 
            this.lblShifingName.AutoSize = true;
            this.lblShifingName.Location = new System.Drawing.Point(26, 51);
            this.lblShifingName.Name = "lblShifingName";
            this.lblShifingName.Size = new System.Drawing.Size(80, 13);
            this.lblShifingName.TabIndex = 7;
            this.lblShifingName.Text = "Shifting Name";
            // 
            // lblScheduleType
            // 
            this.lblScheduleType.AutoSize = true;
            this.lblScheduleType.Location = new System.Drawing.Point(26, 13);
            this.lblScheduleType.Name = "lblScheduleType";
            this.lblScheduleType.Size = new System.Drawing.Size(80, 13);
            this.lblScheduleType.TabIndex = 0;
            this.lblScheduleType.Text = "Schedule Type";
            // 
            // gridScheduleList
            // 
            this.gridScheduleList.AllowUserToAddRows = false;
            this.gridScheduleList.AllowUserToDeleteRows = false;
            this.gridScheduleList.AllowUserToResizeRows = false;
            this.gridScheduleList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridScheduleList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridScheduleList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridScheduleList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridScheduleList.ColumnHeadersHeight = 25;
            this.gridScheduleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridScheduleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShiftingName,
            this.colAMIN,
            this.colLunchOut,
            this.coolLunchIn,
            this.colCofeeOut,
            this.colCoffeeIn,
            this.colPmOut});
            this.gridScheduleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScheduleList.EnableHeadersVisualStyles = false;
            this.gridScheduleList.Location = new System.Drawing.Point(3, 44);
            this.gridScheduleList.MultiSelect = false;
            this.gridScheduleList.Name = "gridScheduleList";
            this.gridScheduleList.RowHeadersVisible = false;
            this.gridScheduleList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridScheduleList.Size = new System.Drawing.Size(600, 559);
            this.gridScheduleList.TabIndex = 2;
            this.gridScheduleList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridListKeyDown);
            // 
            // colShiftingName
            // 
            this.colShiftingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShiftingName.DataPropertyName = "ShiftingName";
            this.colShiftingName.HeaderText = "Shifting Name";
            this.colShiftingName.Name = "colShiftingName";
            this.colShiftingName.ReadOnly = true;
            // 
            // colAMIN
            // 
            this.colAMIN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAMIN.DataPropertyName = "StringAMIn";
            this.colAMIN.HeaderText = "AM In";
            this.colAMIN.Name = "colAMIN";
            this.colAMIN.ReadOnly = true;
            // 
            // colLunchOut
            // 
            this.colLunchOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLunchOut.DataPropertyName = "StringLunchOut";
            this.colLunchOut.HeaderText = "Lunch Out";
            this.colLunchOut.Name = "colLunchOut";
            this.colLunchOut.ReadOnly = true;
            // 
            // coolLunchIn
            // 
            this.coolLunchIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coolLunchIn.DataPropertyName = "StringLunchIn";
            this.coolLunchIn.HeaderText = "Lunch In";
            this.coolLunchIn.Name = "coolLunchIn";
            this.coolLunchIn.ReadOnly = true;
            // 
            // colCofeeOut
            // 
            this.colCofeeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCofeeOut.DataPropertyName = "StringCoffeeOut";
            this.colCofeeOut.HeaderText = "Coffee Out";
            this.colCofeeOut.Name = "colCofeeOut";
            this.colCofeeOut.ReadOnly = true;
            // 
            // colCoffeeIn
            // 
            this.colCoffeeIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCoffeeIn.DataPropertyName = "StringCoffeeIn";
            this.colCoffeeIn.HeaderText = "Coffee In";
            this.colCoffeeIn.Name = "colCoffeeIn";
            this.colCoffeeIn.ReadOnly = true;
            // 
            // colPmOut
            // 
            this.colPmOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPmOut.DataPropertyName = "StringPmOut";
            this.colPmOut.HeaderText = "PM Out";
            this.colPmOut.Name = "colPmOut";
            this.colPmOut.ReadOnly = true;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.White;
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 44);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(3, 559);
            this.pnlSeparator.TabIndex = 3;
            // 
            // lblBreadcumbShifting
            // 
            this.lblBreadcumbShifting.AutoSize = true;
            this.lblBreadcumbShifting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbShifting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbShifting.Location = new System.Drawing.Point(62, 19);
            this.lblBreadcumbShifting.Name = "lblBreadcumbShifting";
            this.lblBreadcumbShifting.Size = new System.Drawing.Size(84, 17);
            this.lblBreadcumbShifting.TabIndex = 9;
            this.lblBreadcumbShifting.Text = "/ SHIFTINGS";
            this.lblBreadcumbShifting.MouseEnter += new System.EventHandler(this.OnBreadcumbMouseEnter);
            this.lblBreadcumbShifting.MouseLeave += new System.EventHandler(this.OnBreadcumbMouseLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(9, 19);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 8;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.HomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.OnBreadcumbMouseEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.OnBreadcumbMouseLeave);
            // 
            // btnOne
            // 
            this.btnOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOne.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOne.Location = new System.Drawing.Point(639, 11);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(105, 23);
            this.btnOne.TabIndex = 3;
            this.btnOne.Text = "CREATE";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.ButtonOneClick);
            this.btnOne.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // btnTwo
            // 
            this.btnTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTwo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTwo.Location = new System.Drawing.Point(750, 11);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(105, 23);
            this.btnTwo.TabIndex = 2;
            this.btnTwo.Text = "UPDATE";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.ButtonTwoClick);
            this.btnTwo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // UsrCntrlShiftingSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridScheduleList);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlShiftingSchedules";
            this.Size = new System.Drawing.Size(879, 603);
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScheduleList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private ModifiedControls.Button btnOne;
        private ModifiedControls.Button btnTwo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView gridScheduleList;
        private System.Windows.Forms.Label lblShiftingType;
        private System.Windows.Forms.TextBox txtShiftingName;
        private System.Windows.Forms.Label lblShifingName;
        private System.Windows.Forms.Label lblScheduleType;
        private System.Windows.Forms.TextBox txtLastModified;
        private System.Windows.Forms.Label lblLastModified;
        private System.Windows.Forms.CheckBox chkIsFixed;
        private System.Windows.Forms.TextBox txtBreak;
        private System.Windows.Forms.Label lblBreak;
        private System.Windows.Forms.TextBox txtLunch;
        private System.Windows.Forms.Label lblLunch;
        private System.Windows.Forms.TextBox txtPmOut;
        private System.Windows.Forms.Label lblPmOut;
        private System.Windows.Forms.TextBox txtCoffeeIn;
        private System.Windows.Forms.Label lblCoffeeIn;
        private System.Windows.Forms.TextBox txtCoffeeOut;
        private System.Windows.Forms.Label lblCoffeeOut;
        private System.Windows.Forms.TextBox txtLunchIn;
        private System.Windows.Forms.Label lblLunchIn;
        private System.Windows.Forms.TextBox txtLunchOut;
        private System.Windows.Forms.Label lblLunchOut;
        private System.Windows.Forms.TextBox txtAmIn;
        private System.Windows.Forms.Label lblAmIn;
        private System.Windows.Forms.ComboBox cmbScheduleType;
        private System.Windows.Forms.ComboBox cmbShiftingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLunchOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn coolLunchIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCofeeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCoffeeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPmOut;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Label lblBreadcumbShifting;
        private System.Windows.Forms.Label lblBreadcumbHome;
    }
}
