namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlLeaveUndertime
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
            this.txtDateFrom = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.txtDateTo = new System.Windows.Forms.TextBox();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.txtNoDaysMins = new System.Windows.Forms.TextBox();
            this.lblNoDaysMins = new System.Windows.Forms.Label();
            this.txtResumeDate = new System.Windows.Forms.TextBox();
            this.lblResumeDate = new System.Windows.Forms.Label();
            this.txtCoordinatedWith = new System.Windows.Forms.TextBox();
            this.lblCoordinatedWith = new System.Windows.Forms.Label();
            this.txtFilledBy = new System.Windows.Forms.TextBox();
            this.lblFilledBy = new System.Windows.Forms.Label();
            this.txtRecommendedBy = new System.Windows.Forms.TextBox();
            this.lblRecommendedBy = new System.Windows.Forms.Label();
            this.txtVerifiedBy = new System.Windows.Forms.TextBox();
            this.lblVerifiedBy = new System.Windows.Forms.Label();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.lblNotedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtDateEffect = new System.Windows.Forms.TextBox();
            this.lblDateEffect = new System.Windows.Forms.Label();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colCntrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateApply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLeaveUndertimeHistory = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.colDetailDesciption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailLuId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridOtherDetails = new System.Windows.Forms.DataGridView();
            this.colOtherDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherRestday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherHoliday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOtherLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPastLeaveUndertime = new System.Windows.Forms.Label();
            this.lblOtherDetails = new System.Windows.Forms.Label();
            this.pnlCancelled = new System.Windows.Forms.Panel();
            this.lblCancelledReason = new System.Windows.Forms.Label();
            this.btnCancelCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCancelSave = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.rTxtCancelledReason = new System.Windows.Forms.RichTextBox();
            this.pnlCancelHeader = new System.Windows.Forms.Panel();
            this.lblCancelHeader = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.chkLeave = new TimeKeepingSystemUI.ModifiedControls.CheckBox();
            this.chkUndertime = new TimeKeepingSystemUI.ModifiedControls.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherDetails)).BeginInit();
            this.pnlCancelled.SuspendLayout();
            this.pnlCancelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(29, 112);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(74, 13);
            this.lblDateCreated.TabIndex = 2;
            this.lblDateCreated.Text = "Date Created";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BackColor = System.Drawing.Color.White;
            this.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateCreated.Location = new System.Drawing.Point(109, 110);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(159, 22);
            this.txtDateCreated.TabIndex = 2;
            this.txtDateCreated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateCreatedKeyDown);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateFrom.Location = new System.Drawing.Point(109, 138);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(159, 22);
            this.txtDateFrom.TabIndex = 4;
            this.txtDateFrom.Enter += new System.EventHandler(this.DateFromEnter);
            this.txtDateFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateFromKeyDown);
            this.txtDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.DateFromValidating);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(43, 140);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(60, 13);
            this.lblDateFrom.TabIndex = 4;
            this.lblDateFrom.Text = "Date From";
            // 
            // txtDateTo
            // 
            this.txtDateTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateTo.Location = new System.Drawing.Point(357, 140);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(159, 22);
            this.txtDateTo.TabIndex = 5;
            this.txtDateTo.Enter += new System.EventHandler(this.DateToEnter);
            this.txtDateTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateToKeyDown);
            this.txtDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.DateToValidating);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(305, 142);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(46, 13);
            this.lblDateTo.TabIndex = 6;
            this.lblDateTo.Text = "Date To";
            // 
            // txtNoDaysMins
            // 
            this.txtNoDaysMins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoDaysMins.Location = new System.Drawing.Point(109, 166);
            this.txtNoDaysMins.Name = "txtNoDaysMins";
            this.txtNoDaysMins.ReadOnly = true;
            this.txtNoDaysMins.Size = new System.Drawing.Size(159, 22);
            this.txtNoDaysMins.TabIndex = 6;
            this.txtNoDaysMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoDaysMinsKeyDown);
            // 
            // lblNoDaysMins
            // 
            this.lblNoDaysMins.AutoSize = true;
            this.lblNoDaysMins.Location = new System.Drawing.Point(25, 168);
            this.lblNoDaysMins.Name = "lblNoDaysMins";
            this.lblNoDaysMins.Size = new System.Drawing.Size(78, 13);
            this.lblNoDaysMins.TabIndex = 8;
            this.lblNoDaysMins.Text = "No Days/Mins";
            // 
            // txtResumeDate
            // 
            this.txtResumeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResumeDate.Location = new System.Drawing.Point(357, 166);
            this.txtResumeDate.Name = "txtResumeDate";
            this.txtResumeDate.ReadOnly = true;
            this.txtResumeDate.Size = new System.Drawing.Size(159, 22);
            this.txtResumeDate.TabIndex = 7;
            this.txtResumeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResumeDateKeyDown);
            // 
            // lblResumeDate
            // 
            this.lblResumeDate.AutoSize = true;
            this.lblResumeDate.Location = new System.Drawing.Point(277, 168);
            this.lblResumeDate.Name = "lblResumeDate";
            this.lblResumeDate.Size = new System.Drawing.Size(74, 13);
            this.lblResumeDate.TabIndex = 10;
            this.lblResumeDate.Text = "Resume Date";
            // 
            // txtCoordinatedWith
            // 
            this.txtCoordinatedWith.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoordinatedWith.Location = new System.Drawing.Point(109, 194);
            this.txtCoordinatedWith.Name = "txtCoordinatedWith";
            this.txtCoordinatedWith.Size = new System.Drawing.Size(159, 22);
            this.txtCoordinatedWith.TabIndex = 8;
            this.txtCoordinatedWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoordinatedWithKeyDown);
            // 
            // lblCoordinatedWith
            // 
            this.lblCoordinatedWith.AutoSize = true;
            this.lblCoordinatedWith.Location = new System.Drawing.Point(3, 196);
            this.lblCoordinatedWith.Name = "lblCoordinatedWith";
            this.lblCoordinatedWith.Size = new System.Drawing.Size(100, 13);
            this.lblCoordinatedWith.TabIndex = 12;
            this.lblCoordinatedWith.Text = "Coordinated With";
            // 
            // txtFilledBy
            // 
            this.txtFilledBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilledBy.Location = new System.Drawing.Point(357, 194);
            this.txtFilledBy.Name = "txtFilledBy";
            this.txtFilledBy.Size = new System.Drawing.Size(159, 22);
            this.txtFilledBy.TabIndex = 9;
            this.txtFilledBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilledByKeyDown);
            // 
            // lblFilledBy
            // 
            this.lblFilledBy.AutoSize = true;
            this.lblFilledBy.Location = new System.Drawing.Point(301, 196);
            this.lblFilledBy.Name = "lblFilledBy";
            this.lblFilledBy.Size = new System.Drawing.Size(50, 13);
            this.lblFilledBy.TabIndex = 14;
            this.lblFilledBy.Text = "Filled By";
            // 
            // txtRecommendedBy
            // 
            this.txtRecommendedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecommendedBy.Location = new System.Drawing.Point(109, 222);
            this.txtRecommendedBy.Name = "txtRecommendedBy";
            this.txtRecommendedBy.Size = new System.Drawing.Size(159, 22);
            this.txtRecommendedBy.TabIndex = 10;
            this.txtRecommendedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecommendedByKeyDown);
            // 
            // lblRecommendedBy
            // 
            this.lblRecommendedBy.AutoSize = true;
            this.lblRecommendedBy.Location = new System.Drawing.Point(5, 226);
            this.lblRecommendedBy.Name = "lblRecommendedBy";
            this.lblRecommendedBy.Size = new System.Drawing.Size(98, 13);
            this.lblRecommendedBy.TabIndex = 16;
            this.lblRecommendedBy.Text = "Recommended By";
            // 
            // txtVerifiedBy
            // 
            this.txtVerifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerifiedBy.Location = new System.Drawing.Point(357, 222);
            this.txtVerifiedBy.Name = "txtVerifiedBy";
            this.txtVerifiedBy.ReadOnly = true;
            this.txtVerifiedBy.Size = new System.Drawing.Size(159, 22);
            this.txtVerifiedBy.TabIndex = 11;
            this.txtVerifiedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VerifiedByKeyDown);
            // 
            // lblVerifiedBy
            // 
            this.lblVerifiedBy.AutoSize = true;
            this.lblVerifiedBy.Location = new System.Drawing.Point(289, 226);
            this.lblVerifiedBy.Name = "lblVerifiedBy";
            this.lblVerifiedBy.Size = new System.Drawing.Size(62, 13);
            this.lblVerifiedBy.TabIndex = 18;
            this.lblVerifiedBy.Text = "Verified By";
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy.Location = new System.Drawing.Point(109, 250);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.Size = new System.Drawing.Size(159, 22);
            this.txtNotedBy.TabIndex = 12;
            this.txtNotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotedByKeyDown);
            // 
            // lblNotedBy
            // 
            this.lblNotedBy.AutoSize = true;
            this.lblNotedBy.Location = new System.Drawing.Point(49, 252);
            this.lblNotedBy.Name = "lblNotedBy";
            this.lblNotedBy.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy.TabIndex = 20;
            this.lblNotedBy.Text = "Noted By";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy.Location = new System.Drawing.Point(357, 250);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.Size = new System.Drawing.Size(159, 22);
            this.txtApprovedBy.TabIndex = 13;
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedByKeyDown);
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(279, 252);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy.TabIndex = 22;
            this.lblApprovedBy.Text = "Approved By";
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(109, 278);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(407, 22);
            this.txtReason.TabIndex = 14;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReasonKeyDown);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(58, 280);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(45, 13);
            this.lblReason.TabIndex = 24;
            this.lblReason.Text = "Reason";
            // 
            // txtDateEffect
            // 
            this.txtDateEffect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateEffect.Location = new System.Drawing.Point(357, 112);
            this.txtDateEffect.Name = "txtDateEffect";
            this.txtDateEffect.Size = new System.Drawing.Size(159, 22);
            this.txtDateEffect.TabIndex = 3;
            this.txtDateEffect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateEffectKeyDown);
            this.txtDateEffect.Validating += new System.ComponentModel.CancelEventHandler(this.DateEffectValidating);
            // 
            // lblDateEffect
            // 
            this.lblDateEffect.AutoSize = true;
            this.lblDateEffect.Location = new System.Drawing.Point(289, 114);
            this.lblDateEffect.Name = "lblDateEffect";
            this.lblDateEffect.Size = new System.Drawing.Size(63, 13);
            this.lblDateEffect.TabIndex = 26;
            this.lblDateEffect.Text = "Date Effect";
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
            this.colCntrlNo,
            this.colDateApply,
            this.colDateEffect});
            this.gridHistory.Location = new System.Drawing.Point(531, 110);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(239, 188);
            this.gridHistory.TabIndex = 15;
            // 
            // colCntrlNo
            // 
            this.colCntrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCntrlNo.DataPropertyName = "CntrlNo";
            this.colCntrlNo.HeaderText = "Control No";
            this.colCntrlNo.Name = "colCntrlNo";
            this.colCntrlNo.ReadOnly = true;
            // 
            // colDateApply
            // 
            this.colDateApply.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateApply.DataPropertyName = "TransactionDate";
            this.colDateApply.HeaderText = "Date Apply";
            this.colDateApply.Name = "colDateApply";
            this.colDateApply.ReadOnly = true;
            // 
            // colDateEffect
            // 
            this.colDateEffect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateEffect.DataPropertyName = "EffectiveDate";
            this.colDateEffect.HeaderText = "Date Effect";
            this.colDateEffect.Name = "colDateEffect";
            this.colDateEffect.ReadOnly = true;
            // 
            // lblLeaveUndertimeHistory
            // 
            this.lblLeaveUndertimeHistory.AutoSize = true;
            this.lblLeaveUndertimeHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveUndertimeHistory.Location = new System.Drawing.Point(528, 81);
            this.lblLeaveUndertimeHistory.Name = "lblLeaveUndertimeHistory";
            this.lblLeaveUndertimeHistory.Size = new System.Drawing.Size(137, 13);
            this.lblLeaveUndertimeHistory.TabIndex = 29;
            this.lblLeaveUndertimeHistory.Text = "Leave/Undertime History";
            // 
            // gridDetails
            // 
            this.gridDetails.AllowUserToAddRows = false;
            this.gridDetails.AllowUserToDeleteRows = false;
            this.gridDetails.AllowUserToResizeRows = false;
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
            this.colDetailPk,
            this.colDetailLuId});
            this.gridDetails.Location = new System.Drawing.Point(6, 354);
            this.gridDetails.MultiSelect = false;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.RowHeadersVisible = false;
            this.gridDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetails.Size = new System.Drawing.Size(379, 242);
            this.gridDetails.TabIndex = 16;
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
            // colDetailPk
            // 
            this.colDetailPk.HeaderText = "Pk";
            this.colDetailPk.Name = "colDetailPk";
            this.colDetailPk.ReadOnly = true;
            this.colDetailPk.Visible = false;
            // 
            // colDetailLuId
            // 
            this.colDetailLuId.HeaderText = "LUId";
            this.colDetailLuId.Name = "colDetailLuId";
            this.colDetailLuId.ReadOnly = true;
            this.colDetailLuId.Visible = false;
            // 
            // gridOtherDetails
            // 
            this.gridOtherDetails.AllowUserToAddRows = false;
            this.gridOtherDetails.AllowUserToDeleteRows = false;
            this.gridOtherDetails.AllowUserToResizeRows = false;
            this.gridOtherDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridOtherDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridOtherDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridOtherDetails.ColumnHeadersHeight = 25;
            this.gridOtherDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridOtherDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOtherDescription,
            this.colOtherRestday,
            this.colOtherHoliday,
            this.colOtherLeave});
            this.gridOtherDetails.Location = new System.Drawing.Point(394, 354);
            this.gridOtherDetails.MultiSelect = false;
            this.gridOtherDetails.Name = "gridOtherDetails";
            this.gridOtherDetails.RowHeadersVisible = false;
            this.gridOtherDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridOtherDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOtherDetails.Size = new System.Drawing.Size(379, 242);
            this.gridOtherDetails.TabIndex = 17;
            // 
            // colOtherDescription
            // 
            this.colOtherDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOtherDescription.DataPropertyName = "Description";
            this.colOtherDescription.HeaderText = "Description ";
            this.colOtherDescription.Name = "colOtherDescription";
            this.colOtherDescription.ReadOnly = true;
            // 
            // colOtherRestday
            // 
            this.colOtherRestday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOtherRestday.DataPropertyName = "Restday";
            this.colOtherRestday.HeaderText = "Restday";
            this.colOtherRestday.Name = "colOtherRestday";
            this.colOtherRestday.ReadOnly = true;
            // 
            // colOtherHoliday
            // 
            this.colOtherHoliday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOtherHoliday.DataPropertyName = "Holiday";
            this.colOtherHoliday.HeaderText = "Holiday";
            this.colOtherHoliday.Name = "colOtherHoliday";
            this.colOtherHoliday.ReadOnly = true;
            // 
            // colOtherLeave
            // 
            this.colOtherLeave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOtherLeave.DataPropertyName = "Leave";
            this.colOtherLeave.HeaderText = "Leave";
            this.colOtherLeave.Name = "colOtherLeave";
            this.colOtherLeave.ReadOnly = true;
            // 
            // lblPastLeaveUndertime
            // 
            this.lblPastLeaveUndertime.AutoSize = true;
            this.lblPastLeaveUndertime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPastLeaveUndertime.Location = new System.Drawing.Point(5, 329);
            this.lblPastLeaveUndertime.Name = "lblPastLeaveUndertime";
            this.lblPastLeaveUndertime.Size = new System.Drawing.Size(122, 13);
            this.lblPastLeaveUndertime.TabIndex = 32;
            this.lblPastLeaveUndertime.Text = "Past Leave/Undertime";
            // 
            // lblOtherDetails
            // 
            this.lblOtherDetails.AutoSize = true;
            this.lblOtherDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherDetails.Location = new System.Drawing.Point(391, 329);
            this.lblOtherDetails.Name = "lblOtherDetails";
            this.lblOtherDetails.Size = new System.Drawing.Size(217, 13);
            this.lblOtherDetails.TabIndex = 33;
            this.lblOtherDetails.Text = "Other Details (Previous/Upcoming Days)";
            // 
            // pnlCancelled
            // 
            this.pnlCancelled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCancelled.Controls.Add(this.lblCancelledReason);
            this.pnlCancelled.Controls.Add(this.btnCancelCancel);
            this.pnlCancelled.Controls.Add(this.btnCancelSave);
            this.pnlCancelled.Controls.Add(this.rTxtCancelledReason);
            this.pnlCancelled.Controls.Add(this.pnlCancelHeader);
            this.pnlCancelled.Location = new System.Drawing.Point(206, 235);
            this.pnlCancelled.Name = "pnlCancelled";
            this.pnlCancelled.Size = new System.Drawing.Size(377, 165);
            this.pnlCancelled.TabIndex = 34;
            this.pnlCancelled.Visible = false;
            this.pnlCancelled.Leave += new System.EventHandler(this.CancelledLeave);
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
            this.btnCancelCancel.Click += new System.EventHandler(this.ReasonCancelClick);
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
            this.btnCancelSave.Click += new System.EventHandler(this.CancelReasonSaveClick);
            // 
            // rTxtCancelledReason
            // 
            this.rTxtCancelledReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rTxtCancelledReason.Location = new System.Drawing.Point(20, 54);
            this.rTxtCancelledReason.Name = "rTxtCancelledReason";
            this.rTxtCancelledReason.Size = new System.Drawing.Size(334, 71);
            this.rTxtCancelledReason.TabIndex = 1;
            //this.rTxtCancelledReason.Text = global::TimeKeepingSystemUI.Properties.Resources.PayrollPassword;
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
            this.lblCancelHeader.Location = new System.Drawing.Point(111, 7);
            this.lblCancelHeader.Name = "lblCancelHeader";
            this.lblCancelHeader.Size = new System.Drawing.Size(152, 13);
            this.lblCancelHeader.TabIndex = 0;
            this.lblCancelHeader.Text = "DISCARD LEAVE/UNDERTIME";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(481, 13);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 32);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "P O S T E D";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(374, 45);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(400, 13);
            this.lblLastUpdated.TabIndex = 36;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLeave
            // 
            this.chkLeave.AutoSize = true;
            this.chkLeave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkLeave.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkLeave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkLeave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(178)))), ((int)(((byte)(185)))));
            this.chkLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLeave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLeave.Location = new System.Drawing.Point(111, 77);
            this.chkLeave.Margin = new System.Windows.Forms.Padding(2);
            this.chkLeave.Name = "chkLeave";
            this.chkLeave.Size = new System.Drawing.Size(56, 19);
            this.chkLeave.TabIndex = 0;
            this.chkLeave.Text = "Leave";
            this.chkLeave.UseVisualStyleBackColor = true;
            this.chkLeave.CheckedChanged += new System.EventHandler(this.LeaveCheckChanged);
            // 
            // chkUndertime
            // 
            this.chkUndertime.AutoSize = true;
            this.chkUndertime.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkUndertime.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkUndertime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkUndertime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(178)))), ((int)(((byte)(185)))));
            this.chkUndertime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUndertime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUndertime.Location = new System.Drawing.Point(171, 77);
            this.chkUndertime.Margin = new System.Windows.Forms.Padding(2);
            this.chkUndertime.Name = "chkUndertime";
            this.chkUndertime.Size = new System.Drawing.Size(84, 19);
            this.chkUndertime.TabIndex = 1;
            this.chkUndertime.Text = "Undertime";
            this.chkUndertime.UseVisualStyleBackColor = true;
            this.chkUndertime.CheckedChanged += new System.EventHandler(this.UndertimeCheckedChanged);
            // 
            // UsrCntrlLeaveUndertime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlCancelled);
            this.Controls.Add(this.chkLeave);
            this.Controls.Add(this.chkUndertime);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.txtDateFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.txtDateTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.txtNoDaysMins);
            this.Controls.Add(this.lblNoDaysMins);
            this.Controls.Add(this.txtResumeDate);
            this.Controls.Add(this.lblResumeDate);
            this.Controls.Add(this.txtCoordinatedWith);
            this.Controls.Add(this.lblCoordinatedWith);
            this.Controls.Add(this.txtFilledBy);
            this.Controls.Add(this.lblFilledBy);
            this.Controls.Add(this.txtRecommendedBy);
            this.Controls.Add(this.lblRecommendedBy);
            this.Controls.Add(this.txtVerifiedBy);
            this.Controls.Add(this.lblVerifiedBy);
            this.Controls.Add(this.txtNotedBy);
            this.Controls.Add(this.lblNotedBy);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtDateEffect);
            this.Controls.Add(this.lblDateEffect);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.lblLeaveUndertimeHistory);
            this.Controls.Add(this.gridDetails);
            this.Controls.Add(this.gridOtherDetails);
            this.Controls.Add(this.lblPastLeaveUndertime);
            this.Controls.Add(this.lblOtherDetails);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlLeaveUndertime";
            this.Size = new System.Drawing.Size(788, 635);
            this.Resize += new System.EventHandler(this.FormResize);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOtherDetails)).EndInit();
            this.pnlCancelled.ResumeLayout(false);
            this.pnlCancelled.PerformLayout();
            this.pnlCancelHeader.ResumeLayout(false);
            this.pnlCancelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModifiedControls.CheckBox chkLeave;
        private ModifiedControls.CheckBox chkUndertime;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.TextBox txtDateFrom;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.TextBox txtDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.TextBox txtNoDaysMins;
        private System.Windows.Forms.Label lblNoDaysMins;
        private System.Windows.Forms.TextBox txtResumeDate;
        private System.Windows.Forms.Label lblResumeDate;
        private System.Windows.Forms.TextBox txtCoordinatedWith;
        private System.Windows.Forms.Label lblCoordinatedWith;
        private System.Windows.Forms.TextBox txtFilledBy;
        private System.Windows.Forms.Label lblFilledBy;
        private System.Windows.Forms.TextBox txtRecommendedBy;
        private System.Windows.Forms.Label lblRecommendedBy;
        private System.Windows.Forms.TextBox txtVerifiedBy;
        private System.Windows.Forms.Label lblVerifiedBy;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label lblNotedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtDateEffect;
        private System.Windows.Forms.Label lblDateEffect;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Label lblLeaveUndertimeHistory;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.DataGridView gridOtherDetails;
        private System.Windows.Forms.Label lblPastLeaveUndertime;
        private System.Windows.Forms.Label lblOtherDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCntrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherRestday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOtherLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailDesciption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailLuId;
        private System.Windows.Forms.Panel pnlCancelled;
        private System.Windows.Forms.Panel pnlCancelHeader;
        private System.Windows.Forms.Label lblCancelHeader;
        private System.Windows.Forms.RichTextBox rTxtCancelledReason;
        private ModifiedControls.Button btnCancelCancel;
        private ModifiedControls.Button btnCancelSave;
        private System.Windows.Forms.Label lblCancelledReason;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLastUpdated;




    }
}
