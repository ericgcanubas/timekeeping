namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlChangeRestday
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
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.lblDayFrom = new System.Windows.Forms.Label();
            this.txtDayFrom = new System.Windows.Forms.TextBox();
            this.lblDayTo = new System.Windows.Forms.Label();
            this.txtDayTo = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblExchangeDateTo = new System.Windows.Forms.Label();
            this.txtExchangeDateTo = new System.Windows.Forms.TextBox();
            this.lblExchangeDateFrom = new System.Windows.Forms.Label();
            this.txtExchangeDateFrom = new System.Windows.Forms.TextBox();
            this.lblExchangeDayTo = new System.Windows.Forms.Label();
            this.txtExchangeDayTo = new System.Windows.Forms.TextBox();
            this.lblExchangeDayFrom = new System.Windows.Forms.Label();
            this.txtExchangeDayFrom = new System.Windows.Forms.TextBox();
            this.lblCoordinated = new System.Windows.Forms.Label();
            this.txtCoordinated = new System.Windows.Forms.TextBox();
            this.lblRequestedDetails = new System.Windows.Forms.Label();
            this.lblExchangeWithDetails = new System.Windows.Forms.Label();
            this.lblRecommendedApproval = new System.Windows.Forms.Label();
            this.txtRecommendedApproval = new System.Windows.Forms.TextBox();
            this.lblNotedBy = new System.Windows.Forms.Label();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colDateApply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCntrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblChangeRestdayHistory = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.colDetailDesciption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCRId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridSearhExchange = new System.Windows.Forms.DataGridView();
            this.colExchangeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCancelled = new System.Windows.Forms.Panel();
            this.lblCancelledReason = new System.Windows.Forms.Label();
            this.btnCancelCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCancelSave = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.rTxtCancelledReason = new System.Windows.Forms.RichTextBox();
            this.pnlCancelHeader = new System.Windows.Forms.Panel();
            this.lblCancelHeader = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearhExchange)).BeginInit();
            this.pnlCancelled.SuspendLayout();
            this.pnlCancelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(7, 100);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(74, 13);
            this.lblDateCreated.TabIndex = 4;
            this.lblDateCreated.Text = "Date Created";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateCreated.Location = new System.Drawing.Point(83, 98);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(159, 22);
            this.txtDateCreated.TabIndex = 0;
            this.txtDateCreated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateCreatedKeyDown);
            // 
            // lblDayFrom
            // 
            this.lblDayFrom.AutoSize = true;
            this.lblDayFrom.Location = new System.Drawing.Point(26, 128);
            this.lblDayFrom.Name = "lblDayFrom";
            this.lblDayFrom.Size = new System.Drawing.Size(55, 13);
            this.lblDayFrom.TabIndex = 6;
            this.lblDayFrom.Text = "Day From";
            // 
            // txtDayFrom
            // 
            this.txtDayFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDayFrom.Location = new System.Drawing.Point(83, 126);
            this.txtDayFrom.Name = "txtDayFrom";
            this.txtDayFrom.ReadOnly = true;
            this.txtDayFrom.Size = new System.Drawing.Size(159, 22);
            this.txtDayFrom.TabIndex = 1;
            this.txtDayFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayFrom);
            // 
            // lblDayTo
            // 
            this.lblDayTo.AutoSize = true;
            this.lblDayTo.Location = new System.Drawing.Point(40, 154);
            this.lblDayTo.Name = "lblDayTo";
            this.lblDayTo.Size = new System.Drawing.Size(41, 13);
            this.lblDayTo.TabIndex = 8;
            this.lblDayTo.Text = "Day To";
            // 
            // txtDayTo
            // 
            this.txtDayTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDayTo.Location = new System.Drawing.Point(83, 154);
            this.txtDayTo.Name = "txtDayTo";
            this.txtDayTo.ReadOnly = true;
            this.txtDayTo.Size = new System.Drawing.Size(159, 22);
            this.txtDayTo.TabIndex = 2;
            this.txtDayTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DayToKeyDown);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(21, 184);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(60, 13);
            this.lblDateFrom.TabIndex = 10;
            this.lblDateFrom.Text = "Date From";
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateFrom.Location = new System.Drawing.Point(83, 182);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.ReadOnly = true;
            this.txtDateFrom.Size = new System.Drawing.Size(159, 22);
            this.txtDateFrom.TabIndex = 3;
            this.txtDateFrom.TextChanged += new System.EventHandler(this.DateFromTextChanged);
            this.txtDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateFromKeyDown);
            this.txtDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.DateFromValidating);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(35, 212);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblDateTo.TabIndex = 12;
            this.lblDateTo.Text = "Date To";
            // 
            // txtDateTo
            // 
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateTo.Location = new System.Drawing.Point(83, 210);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.ReadOnly = true;
            this.txtDateTo.Size = new System.Drawing.Size(159, 22);
            this.txtDateTo.TabIndex = 4;
            this.txtDateTo.TextChanged += new System.EventHandler(this.DateToTextChanged);
            this.txtDateTo.Enter += new System.EventHandler(this.DateToEnter);
            this.txtDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateToKeyDown);
            this.txtDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.DateToValidating);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(36, 240);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(45, 13);
            this.lblReason.TabIndex = 14;
            this.lblReason.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(83, 238);
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(401, 22);
            this.txtReason.TabIndex = 10;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReasonKeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(288, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(325, 98);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(159, 22);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.ExchangeNameChanged);
            this.txtName.Enter += new System.EventHandler(this.ExchangeNameEnter);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NamKeyDown);
            this.txtName.Leave += new System.EventHandler(this.ExchangeNameLeave);
            // 
            // lblExchangeDateTo
            // 
            this.lblExchangeDateTo.AutoSize = true;
            this.lblExchangeDateTo.Location = new System.Drawing.Point(278, 212);
            this.lblExchangeDateTo.Name = "lblExchangeDateTo";
            this.lblExchangeDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblExchangeDateTo.TabIndex = 24;
            this.lblExchangeDateTo.Text = "Date To";
            // 
            // txtExchangeDateTo
            // 
            this.txtExchangeDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeDateTo.Location = new System.Drawing.Point(325, 210);
            this.txtExchangeDateTo.Name = "txtExchangeDateTo";
            this.txtExchangeDateTo.ReadOnly = true;
            this.txtExchangeDateTo.Size = new System.Drawing.Size(159, 22);
            this.txtExchangeDateTo.TabIndex = 9;
            this.txtExchangeDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExchangeDateTo);
            // 
            // lblExchangeDateFrom
            // 
            this.lblExchangeDateFrom.AutoSize = true;
            this.lblExchangeDateFrom.Location = new System.Drawing.Point(264, 184);
            this.lblExchangeDateFrom.Name = "lblExchangeDateFrom";
            this.lblExchangeDateFrom.Size = new System.Drawing.Size(60, 13);
            this.lblExchangeDateFrom.TabIndex = 22;
            this.lblExchangeDateFrom.Text = "Date From";
            // 
            // txtExchangeDateFrom
            // 
            this.txtExchangeDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeDateFrom.Location = new System.Drawing.Point(325, 182);
            this.txtExchangeDateFrom.Name = "txtExchangeDateFrom";
            this.txtExchangeDateFrom.ReadOnly = true;
            this.txtExchangeDateFrom.Size = new System.Drawing.Size(159, 22);
            this.txtExchangeDateFrom.TabIndex = 8;
            this.txtExchangeDateFrom.Enter += new System.EventHandler(this.ExchangeDateFrom);
            this.txtExchangeDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExchangeDateFrom);
            this.txtExchangeDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.ExchangeDateFrom);
            // 
            // lblExchangeDayTo
            // 
            this.lblExchangeDayTo.AutoSize = true;
            this.lblExchangeDayTo.Location = new System.Drawing.Point(283, 156);
            this.lblExchangeDayTo.Name = "lblExchangeDayTo";
            this.lblExchangeDayTo.Size = new System.Drawing.Size(41, 13);
            this.lblExchangeDayTo.TabIndex = 20;
            this.lblExchangeDayTo.Text = "Day To";
            // 
            // txtExchangeDayTo
            // 
            this.txtExchangeDayTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeDayTo.Location = new System.Drawing.Point(325, 154);
            this.txtExchangeDayTo.Name = "txtExchangeDayTo";
            this.txtExchangeDayTo.ReadOnly = true;
            this.txtExchangeDayTo.Size = new System.Drawing.Size(159, 22);
            this.txtExchangeDayTo.TabIndex = 7;
            this.txtExchangeDayTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExchangeDayTo);
            // 
            // lblExchangeDayFrom
            // 
            this.lblExchangeDayFrom.AutoSize = true;
            this.lblExchangeDayFrom.Location = new System.Drawing.Point(269, 128);
            this.lblExchangeDayFrom.Name = "lblExchangeDayFrom";
            this.lblExchangeDayFrom.Size = new System.Drawing.Size(55, 13);
            this.lblExchangeDayFrom.TabIndex = 18;
            this.lblExchangeDayFrom.Text = "Day From";
            // 
            // txtExchangeDayFrom
            // 
            this.txtExchangeDayFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExchangeDayFrom.Location = new System.Drawing.Point(325, 126);
            this.txtExchangeDayFrom.Name = "txtExchangeDayFrom";
            this.txtExchangeDayFrom.ReadOnly = true;
            this.txtExchangeDayFrom.Size = new System.Drawing.Size(159, 22);
            this.txtExchangeDayFrom.TabIndex = 6;
            this.txtExchangeDayFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExchangeDayFrom);
            // 
            // lblCoordinated
            // 
            this.lblCoordinated.AutoSize = true;
            this.lblCoordinated.Location = new System.Drawing.Point(9, 268);
            this.lblCoordinated.Name = "lblCoordinated";
            this.lblCoordinated.Size = new System.Drawing.Size(72, 13);
            this.lblCoordinated.TabIndex = 26;
            this.lblCoordinated.Text = "Coordinated";
            // 
            // txtCoordinated
            // 
            this.txtCoordinated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoordinated.Location = new System.Drawing.Point(83, 266);
            this.txtCoordinated.Name = "txtCoordinated";
            this.txtCoordinated.ReadOnly = true;
            this.txtCoordinated.Size = new System.Drawing.Size(401, 22);
            this.txtCoordinated.TabIndex = 11;
            this.txtCoordinated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoordinatedKeyDown);
            // 
            // lblRequestedDetails
            // 
            this.lblRequestedDetails.AutoSize = true;
            this.lblRequestedDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedDetails.Location = new System.Drawing.Point(80, 73);
            this.lblRequestedDetails.Name = "lblRequestedDetails";
            this.lblRequestedDetails.Size = new System.Drawing.Size(100, 13);
            this.lblRequestedDetails.TabIndex = 28;
            this.lblRequestedDetails.Text = "Requested Details";
            // 
            // lblExchangeWithDetails
            // 
            this.lblExchangeWithDetails.AutoSize = true;
            this.lblExchangeWithDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExchangeWithDetails.Location = new System.Drawing.Point(322, 73);
            this.lblExchangeWithDetails.Name = "lblExchangeWithDetails";
            this.lblExchangeWithDetails.Size = new System.Drawing.Size(123, 13);
            this.lblExchangeWithDetails.TabIndex = 29;
            this.lblExchangeWithDetails.Text = "Exchange With Details";
            // 
            // lblRecommendedApproval
            // 
            this.lblRecommendedApproval.AutoSize = true;
            this.lblRecommendedApproval.Location = new System.Drawing.Point(80, 297);
            this.lblRecommendedApproval.Name = "lblRecommendedApproval";
            this.lblRecommendedApproval.Size = new System.Drawing.Size(136, 13);
            this.lblRecommendedApproval.TabIndex = 30;
            this.lblRecommendedApproval.Text = "Recommending Approval";
            // 
            // txtRecommendedApproval
            // 
            this.txtRecommendedApproval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecommendedApproval.Location = new System.Drawing.Point(83, 313);
            this.txtRecommendedApproval.Name = "txtRecommendedApproval";
            this.txtRecommendedApproval.ReadOnly = true;
            this.txtRecommendedApproval.Size = new System.Drawing.Size(116, 22);
            this.txtRecommendedApproval.TabIndex = 12;
            this.txtRecommendedApproval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecommendedApprovalKeyDown);
            // 
            // lblNotedBy
            // 
            this.lblNotedBy.AutoSize = true;
            this.lblNotedBy.Location = new System.Drawing.Point(235, 297);
            this.lblNotedBy.Name = "lblNotedBy";
            this.lblNotedBy.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy.TabIndex = 32;
            this.lblNotedBy.Text = "Noted By";
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy.Location = new System.Drawing.Point(238, 313);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.ReadOnly = true;
            this.txtNotedBy.Size = new System.Drawing.Size(107, 22);
            this.txtNotedBy.TabIndex = 13;
            this.txtNotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotedByKeyDown);
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(363, 297);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy.TabIndex = 34;
            this.lblApprovedBy.Text = "Approved By";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy.Location = new System.Drawing.Point(366, 313);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(118, 22);
            this.txtApprovedBy.TabIndex = 14;
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedByKeyDown);
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AllowUserToResizeRows = false;
            this.gridHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHistory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridHistory.ColumnHeadersHeight = 25;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateApply,
            this.colCntrlNo});
            this.gridHistory.Location = new System.Drawing.Point(510, 98);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(266, 237);
            this.gridHistory.TabIndex = 16;
            // 
            // colDateApply
            // 
            this.colDateApply.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateApply.DataPropertyName = "TrasactionDate";
            this.colDateApply.HeaderText = "Date Apply";
            this.colDateApply.Name = "colDateApply";
            this.colDateApply.ReadOnly = true;
            // 
            // colCntrlNo
            // 
            this.colCntrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCntrlNo.DataPropertyName = "CntrlNo";
            this.colCntrlNo.HeaderText = "Control No";
            this.colCntrlNo.Name = "colCntrlNo";
            this.colCntrlNo.ReadOnly = true;
            // 
            // lblChangeRestdayHistory
            // 
            this.lblChangeRestdayHistory.AutoSize = true;
            this.lblChangeRestdayHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeRestdayHistory.Location = new System.Drawing.Point(504, 73);
            this.lblChangeRestdayHistory.Name = "lblChangeRestdayHistory";
            this.lblChangeRestdayHistory.Size = new System.Drawing.Size(131, 13);
            this.lblChangeRestdayHistory.TabIndex = 37;
            this.lblChangeRestdayHistory.Text = "Change Restday History";
            // 
            // gridDetails
            // 
            this.gridDetails.AllowUserToAddRows = false;
            this.gridDetails.AllowUserToDeleteRows = false;
            this.gridDetails.AllowUserToResizeRows = false;
            this.gridDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridDetails.ColumnHeadersHeight = 25;
            this.gridDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDetailDesciption,
            this.colDetailTotal,
            this.colDetailCol1,
            this.colDetailCol2,
            this.colDetailCol3,
            this.colPk,
            this.colCRId});
            this.gridDetails.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridDetails.Location = new System.Drawing.Point(12, 360);
            this.gridDetails.MultiSelect = false;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.RowHeadersVisible = false;
            this.gridDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetails.Size = new System.Drawing.Size(764, 174);
            this.gridDetails.TabIndex = 15;
            // 
            // colDetailDesciption
            // 
            this.colDetailDesciption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailDesciption.HeaderText = "Description";
            this.colDetailDesciption.Name = "colDetailDesciption";
            this.colDetailDesciption.ReadOnly = true;
            // 
            // colDetailTotal
            // 
            this.colDetailTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailTotal.HeaderText = "Total";
            this.colDetailTotal.Name = "colDetailTotal";
            this.colDetailTotal.ReadOnly = true;
            // 
            // colDetailCol1
            // 
            this.colDetailCol1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailCol1.HeaderText = "Col 1";
            this.colDetailCol1.Name = "colDetailCol1";
            this.colDetailCol1.ReadOnly = true;
            // 
            // colDetailCol2
            // 
            this.colDetailCol2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailCol2.HeaderText = "Col 2";
            this.colDetailCol2.Name = "colDetailCol2";
            this.colDetailCol2.ReadOnly = true;
            // 
            // colDetailCol3
            // 
            this.colDetailCol3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailCol3.HeaderText = "Col 3";
            this.colDetailCol3.Name = "colDetailCol3";
            this.colDetailCol3.ReadOnly = true;
            // 
            // colPk
            // 
            this.colPk.Name = "colPk";
            this.colPk.ReadOnly = true;
            this.colPk.Visible = false;
            // 
            // colCRId
            // 
            this.colCRId.Name = "colCRId";
            this.colCRId.ReadOnly = true;
            this.colCRId.Visible = false;
            // 
            // gridSearhExchange
            // 
            this.gridSearhExchange.AllowUserToAddRows = false;
            this.gridSearhExchange.AllowUserToDeleteRows = false;
            this.gridSearhExchange.AllowUserToOrderColumns = true;
            this.gridSearhExchange.AllowUserToResizeRows = false;
            this.gridSearhExchange.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearhExchange.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSearhExchange.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridSearhExchange.ColumnHeadersHeight = 25;
            this.gridSearhExchange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSearhExchange.ColumnHeadersVisible = false;
            this.gridSearhExchange.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExchangeName});
            this.gridSearhExchange.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearhExchange.Location = new System.Drawing.Point(325, 120);
            this.gridSearhExchange.MultiSelect = false;
            this.gridSearhExchange.Name = "gridSearhExchange";
            this.gridSearhExchange.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridSearhExchange.RowHeadersVisible = false;
            this.gridSearhExchange.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSearhExchange.Size = new System.Drawing.Size(159, 150);
            this.gridSearhExchange.TabIndex = 38;
            this.gridSearhExchange.Visible = false;
            this.gridSearhExchange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridExchangeKeyDown);
            this.gridSearhExchange.Leave += new System.EventHandler(this.GridExchangeLeave);
            // 
            // colExchangeName
            // 
            this.colExchangeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colExchangeName.DataPropertyName = "Fullname";
            this.colExchangeName.HeaderText = "Name";
            this.colExchangeName.Name = "colExchangeName";
            this.colExchangeName.ReadOnly = true;
            // 
            // pnlCancelled
            // 
            this.pnlCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCancelled.Controls.Add(this.lblCancelledReason);
            this.pnlCancelled.Controls.Add(this.btnCancelCancel);
            this.pnlCancelled.Controls.Add(this.btnCancelSave);
            this.pnlCancelled.Controls.Add(this.rTxtCancelledReason);
            this.pnlCancelled.Controls.Add(this.pnlCancelHeader);
            this.pnlCancelled.Location = new System.Drawing.Point(208, 198);
            this.pnlCancelled.Name = "pnlCancelled";
            this.pnlCancelled.Size = new System.Drawing.Size(377, 165);
            this.pnlCancelled.TabIndex = 39;
            this.pnlCancelled.Visible = false;
            this.pnlCancelled.Leave += new System.EventHandler(this.LeaveResonCancel);
            // 
            // lblCancelledReason
            // 
            this.lblCancelledReason.AutoSize = true;
            this.lblCancelledReason.Location = new System.Drawing.Point(17, 38);
            this.lblCancelledReason.Name = "lblCancelledReason";
            this.lblCancelledReason.Size = new System.Drawing.Size(45, 13);
            this.lblCancelledReason.TabIndex = 21;
            this.lblCancelledReason.Text = "Reason";
            // 
            // btnCancelCancel
            // 
            this.btnCancelCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelCancel.Location = new System.Drawing.Point(196, 131);
            this.btnCancelCancel.Name = "btnCancelCancel";
            this.btnCancelCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancelCancel.TabIndex = 4;
            this.btnCancelCancel.Text = "CANCEL";
            this.btnCancelCancel.UseVisualStyleBackColor = true;
            this.btnCancelCancel.Click += new System.EventHandler(this.CancelCancelClick);
            // 
            // btnCancelSave
            // 
            this.btnCancelSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelSave.Location = new System.Drawing.Point(278, 131);
            this.btnCancelSave.Name = "btnCancelSave";
            this.btnCancelSave.Size = new System.Drawing.Size(76, 23);
            this.btnCancelSave.TabIndex = 3;
            this.btnCancelSave.Text = "SAVE";
            this.btnCancelSave.UseVisualStyleBackColor = true;
            this.btnCancelSave.Click += new System.EventHandler(this.SaveCancelClick);
            // 
            // rTxtCancelledReason
            // 
            this.rTxtCancelledReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtCancelledReason.Location = new System.Drawing.Point(20, 54);
            this.rTxtCancelledReason.Name = "rTxtCancelledReason";
            this.rTxtCancelledReason.Size = new System.Drawing.Size(334, 71);
            this.rTxtCancelledReason.TabIndex = 1;
            this.rTxtCancelledReason.Text = "";
            // 
            // pnlCancelHeader
            // 
            this.pnlCancelHeader.Controls.Add(this.lblCancelHeader);
            this.pnlCancelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCancelHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlCancelHeader.Name = "pnlCancelHeader";
            this.pnlCancelHeader.Size = new System.Drawing.Size(375, 26);
            this.pnlCancelHeader.TabIndex = 0;
            // 
            // lblCancelHeader
            // 
            this.lblCancelHeader.AutoSize = true;
            this.lblCancelHeader.Location = new System.Drawing.Point(114, 7);
            this.lblCancelHeader.Name = "lblCancelHeader";
            this.lblCancelHeader.Size = new System.Drawing.Size(147, 13);
            this.lblCancelHeader.TabIndex = 0;
            this.lblCancelHeader.Text = "DISCARD CHANGE RESTDAY";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(491, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 32);
            this.lblStatus.TabIndex = 40;
            this.lblStatus.Text = "P O S T E D";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(384, 43);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(400, 13);
            this.lblLastUpdated.TabIndex = 41;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsrCntrlChangeRestday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.pnlCancelled);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gridSearhExchange);
            this.Controls.Add(this.gridDetails);
            this.Controls.Add(this.lblChangeRestdayHistory);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblNotedBy);
            this.Controls.Add(this.txtNotedBy);
            this.Controls.Add(this.lblRecommendedApproval);
            this.Controls.Add(this.txtRecommendedApproval);
            this.Controls.Add(this.lblExchangeWithDetails);
            this.Controls.Add(this.lblRequestedDetails);
            this.Controls.Add(this.lblCoordinated);
            this.Controls.Add(this.txtCoordinated);
            this.Controls.Add(this.lblExchangeDateTo);
            this.Controls.Add(this.txtExchangeDateTo);
            this.Controls.Add(this.lblExchangeDateFrom);
            this.Controls.Add(this.txtExchangeDateFrom);
            this.Controls.Add(this.lblExchangeDayTo);
            this.Controls.Add(this.txtExchangeDayTo);
            this.Controls.Add(this.lblExchangeDayFrom);
            this.Controls.Add(this.txtExchangeDayFrom);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.lblDayTo);
            this.Controls.Add(this.txtDayTo);
            this.Controls.Add(this.lblDayFrom);
            this.Controls.Add(this.txtDayFrom);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.txtDateCreated);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlChangeRestday";
            this.Size = new System.Drawing.Size(792, 560);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearhExchange)).EndInit();
            this.pnlCancelled.ResumeLayout(false);
            this.pnlCancelled.PerformLayout();
            this.pnlCancelHeader.ResumeLayout(false);
            this.pnlCancelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.Label lblDayFrom;
        private System.Windows.Forms.TextBox txtDayFrom;
        private System.Windows.Forms.Label lblDayTo;
        private System.Windows.Forms.TextBox txtDayTo;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblExchangeDateTo;
        private System.Windows.Forms.TextBox txtExchangeDateTo;
        private System.Windows.Forms.Label lblExchangeDateFrom;
        private System.Windows.Forms.TextBox txtExchangeDateFrom;
        private System.Windows.Forms.Label lblExchangeDayTo;
        private System.Windows.Forms.TextBox txtExchangeDayTo;
        private System.Windows.Forms.Label lblExchangeDayFrom;
        private System.Windows.Forms.TextBox txtExchangeDayFrom;
        private System.Windows.Forms.Label lblCoordinated;
        private System.Windows.Forms.TextBox txtCoordinated;
        private System.Windows.Forms.Label lblRequestedDetails;
        private System.Windows.Forms.Label lblExchangeWithDetails;
        private System.Windows.Forms.Label lblRecommendedApproval;
        private System.Windows.Forms.TextBox txtRecommendedApproval;
        private System.Windows.Forms.Label lblNotedBy;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Label lblChangeRestdayHistory;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCntrlNo;
        private System.Windows.Forms.DataGridView gridSearhExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExchangeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailDesciption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCRId;
        private System.Windows.Forms.Panel pnlCancelled;
        private System.Windows.Forms.Label lblCancelledReason;
        private ModifiedControls.Button btnCancelCancel;
        private ModifiedControls.Button btnCancelSave;
        private System.Windows.Forms.RichTextBox rTxtCancelledReason;
        private System.Windows.Forms.Panel pnlCancelHeader;
        private System.Windows.Forms.Label lblCancelHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLastUpdated;
    }
}
