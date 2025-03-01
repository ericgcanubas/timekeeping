namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlPRW
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
            this.lblDateAbsenceLate = new System.Windows.Forms.Label();
            this.txtDateAbsenceLate = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblRecommendedBy = new System.Windows.Forms.Label();
            this.txtRecommendedBy = new System.Windows.Forms.TextBox();
            this.lblNotedBy = new System.Windows.Forms.Label();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.lblNoDaysMins = new System.Windows.Forms.Label();
            this.txtNoDaysMins = new System.Windows.Forms.TextBox();
            this.lblVerifiedBy = new System.Windows.Forms.Label();
            this.txtVerifiedBy = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.lblReleasedBy = new System.Windows.Forms.Label();
            this.txtReleaseBy = new System.Windows.Forms.TextBox();
            this.lblDisciplinaryAction = new System.Windows.Forms.Label();
            this.lblInViewOfYourRecords = new System.Windows.Forms.Label();
            this.rBtnCounsilingWarning = new System.Windows.Forms.RadioButton();
            this.rBtnReprimand = new System.Windows.Forms.RadioButton();
            this.rBtnSuspensionFor = new System.Windows.Forms.RadioButton();
            this.txtSuspensionFor = new System.Windows.Forms.TextBox();
            this.lblScheduledOn = new System.Windows.Forms.Label();
            this.txtScheduledOn = new System.Windows.Forms.TextBox();
            this.rBtnWarningForTermination = new System.Windows.Forms.RadioButton();
            this.txtTerminationEffect = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblPreparedBy = new System.Windows.Forms.Label();
            this.txtPreparedBy2 = new System.Windows.Forms.TextBox();
            this.lblNotedBy2 = new System.Windows.Forms.Label();
            this.txtNotedBy2 = new System.Windows.Forms.TextBox();
            this.lblApprovedBy2 = new System.Windows.Forms.Label();
            this.txtApprovedBy2 = new System.Windows.Forms.TextBox();
            this.lblConformeBy = new System.Windows.Forms.Label();
            this.txtConformeBy = new System.Windows.Forms.TextBox();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblPRWHistory = new System.Windows.Forms.Label();
            this.gridDetails = new System.Windows.Forms.DataGridView();
            this.colDetailDesciption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetailCol3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPRWId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colDateApplied = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkLate = new TimeKeepingSystemUI.ModifiedControls.CheckBox();
            this.chkAbsent = new TimeKeepingSystemUI.ModifiedControls.CheckBox();
            this.rBtnTerminationEffectOn = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(39, 101);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(74, 13);
            this.lblDateCreated.TabIndex = 4;
            this.lblDateCreated.Text = "Date Created";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateCreated.Location = new System.Drawing.Point(119, 99);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(159, 22);
            this.txtDateCreated.TabIndex = 2;
            this.txtDateCreated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateCreatedKeyDown);
            // 
            // lblDateAbsenceLate
            // 
            this.lblDateAbsenceLate.AutoSize = true;
            this.lblDateAbsenceLate.Location = new System.Drawing.Point(11, 129);
            this.lblDateAbsenceLate.Name = "lblDateAbsenceLate";
            this.lblDateAbsenceLate.Size = new System.Drawing.Size(102, 13);
            this.lblDateAbsenceLate.TabIndex = 6;
            this.lblDateAbsenceLate.Text = "Date Absence/Late";
            // 
            // txtDateAbsenceLate
            // 
            this.txtDateAbsenceLate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateAbsenceLate.Location = new System.Drawing.Point(119, 127);
            this.txtDateAbsenceLate.Name = "txtDateAbsenceLate";
            this.txtDateAbsenceLate.ReadOnly = true;
            this.txtDateAbsenceLate.Size = new System.Drawing.Size(159, 22);
            this.txtDateAbsenceLate.TabIndex = 3;
            this.txtDateAbsenceLate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateAbsenceLateKeyDown);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(68, 157);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(45, 13);
            this.lblReason.TabIndex = 8;
            this.lblReason.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(119, 155);
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(159, 22);
            this.txtReason.TabIndex = 5;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReasonKeyDown);
            // 
            // lblRecommendedBy
            // 
            this.lblRecommendedBy.AutoSize = true;
            this.lblRecommendedBy.Location = new System.Drawing.Point(15, 185);
            this.lblRecommendedBy.Name = "lblRecommendedBy";
            this.lblRecommendedBy.Size = new System.Drawing.Size(98, 13);
            this.lblRecommendedBy.TabIndex = 10;
            this.lblRecommendedBy.Text = "Recommended By";
            // 
            // txtRecommendedBy
            // 
            this.txtRecommendedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecommendedBy.Location = new System.Drawing.Point(119, 183);
            this.txtRecommendedBy.Name = "txtRecommendedBy";
            this.txtRecommendedBy.ReadOnly = true;
            this.txtRecommendedBy.Size = new System.Drawing.Size(159, 22);
            this.txtRecommendedBy.TabIndex = 7;
            this.txtRecommendedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RecommendedByKeyDown);
            // 
            // lblNotedBy
            // 
            this.lblNotedBy.AutoSize = true;
            this.lblNotedBy.Location = new System.Drawing.Point(59, 213);
            this.lblNotedBy.Name = "lblNotedBy";
            this.lblNotedBy.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy.TabIndex = 12;
            this.lblNotedBy.Text = "Noted By";
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy.Location = new System.Drawing.Point(119, 211);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.ReadOnly = true;
            this.txtNotedBy.Size = new System.Drawing.Size(159, 22);
            this.txtNotedBy.TabIndex = 9;
            this.txtNotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotedByKeyDown);
            // 
            // lblNoDaysMins
            // 
            this.lblNoDaysMins.AutoSize = true;
            this.lblNoDaysMins.Location = new System.Drawing.Point(291, 129);
            this.lblNoDaysMins.Name = "lblNoDaysMins";
            this.lblNoDaysMins.Size = new System.Drawing.Size(78, 13);
            this.lblNoDaysMins.TabIndex = 14;
            this.lblNoDaysMins.Text = "No Days/Mins";
            // 
            // txtNoDaysMins
            // 
            this.txtNoDaysMins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoDaysMins.Location = new System.Drawing.Point(375, 127);
            this.txtNoDaysMins.Name = "txtNoDaysMins";
            this.txtNoDaysMins.ReadOnly = true;
            this.txtNoDaysMins.Size = new System.Drawing.Size(210, 22);
            this.txtNoDaysMins.TabIndex = 4;
            this.txtNoDaysMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoDaysMinsKeyDown);
            // 
            // lblVerifiedBy
            // 
            this.lblVerifiedBy.AutoSize = true;
            this.lblVerifiedBy.Location = new System.Drawing.Point(307, 157);
            this.lblVerifiedBy.Name = "lblVerifiedBy";
            this.lblVerifiedBy.Size = new System.Drawing.Size(62, 13);
            this.lblVerifiedBy.TabIndex = 16;
            this.lblVerifiedBy.Text = "Verified By";
            // 
            // txtVerifiedBy
            // 
            this.txtVerifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerifiedBy.Enabled = false;
            this.txtVerifiedBy.Location = new System.Drawing.Point(375, 155);
            this.txtVerifiedBy.Name = "txtVerifiedBy";
            this.txtVerifiedBy.ReadOnly = true;
            this.txtVerifiedBy.Size = new System.Drawing.Size(210, 22);
            this.txtVerifiedBy.TabIndex = 6;
            this.txtVerifiedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VerifiedByKeyDown);
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(291, 185);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy.TabIndex = 18;
            this.lblApprovedBy.Text = "Approved By";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy.Location = new System.Drawing.Point(375, 183);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(210, 22);
            this.txtApprovedBy.TabIndex = 8;
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedByKeyDown);
            // 
            // lblReleasedBy
            // 
            this.lblReleasedBy.AutoSize = true;
            this.lblReleasedBy.Location = new System.Drawing.Point(301, 213);
            this.lblReleasedBy.Name = "lblReleasedBy";
            this.lblReleasedBy.Size = new System.Drawing.Size(68, 13);
            this.lblReleasedBy.TabIndex = 20;
            this.lblReleasedBy.Text = "Released By";
            // 
            // txtReleaseBy
            // 
            this.txtReleaseBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReleaseBy.Location = new System.Drawing.Point(375, 211);
            this.txtReleaseBy.Name = "txtReleaseBy";
            this.txtReleaseBy.ReadOnly = true;
            this.txtReleaseBy.Size = new System.Drawing.Size(210, 22);
            this.txtReleaseBy.TabIndex = 10;
            this.txtReleaseBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReleaseByKeyDown);
            // 
            // lblDisciplinaryAction
            // 
            this.lblDisciplinaryAction.AutoSize = true;
            this.lblDisciplinaryAction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisciplinaryAction.Location = new System.Drawing.Point(11, 268);
            this.lblDisciplinaryAction.Name = "lblDisciplinaryAction";
            this.lblDisciplinaryAction.Size = new System.Drawing.Size(104, 13);
            this.lblDisciplinaryAction.TabIndex = 22;
            this.lblDisciplinaryAction.Text = "Disciplinary Action";
            // 
            // lblInViewOfYourRecords
            // 
            this.lblInViewOfYourRecords.AutoSize = true;
            this.lblInViewOfYourRecords.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInViewOfYourRecords.Location = new System.Drawing.Point(11, 281);
            this.lblInViewOfYourRecords.Name = "lblInViewOfYourRecords";
            this.lblInViewOfYourRecords.Size = new System.Drawing.Size(527, 12);
            this.lblInViewOfYourRecords.TabIndex = 23;
            this.lblInViewOfYourRecords.Text = "IN VIEW OF YOUR RECORDS OF YOUR ATTENDANCE YOU ARE HEREBY SANCTIONED WITH THE FOL" +
                "LOWING DISCIPLINARY ACTION";
            // 
            // rBtnCounsilingWarning
            // 
            this.rBtnCounsilingWarning.AutoSize = true;
            this.rBtnCounsilingWarning.Enabled = false;
            this.rBtnCounsilingWarning.ForeColor = System.Drawing.Color.Black;
            this.rBtnCounsilingWarning.Location = new System.Drawing.Point(10, 296);
            this.rBtnCounsilingWarning.Name = "rBtnCounsilingWarning";
            this.rBtnCounsilingWarning.Size = new System.Drawing.Size(146, 17);
            this.rBtnCounsilingWarning.TabIndex = 11;
            this.rBtnCounsilingWarning.TabStop = true;
            this.rBtnCounsilingWarning.Text = "COUNSILING/WARNING";
            this.rBtnCounsilingWarning.UseVisualStyleBackColor = true;
            this.rBtnCounsilingWarning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CounsilingWarningKeyDown);
            // 
            // rBtnReprimand
            // 
            this.rBtnReprimand.AutoSize = true;
            this.rBtnReprimand.Enabled = false;
            this.rBtnReprimand.ForeColor = System.Drawing.Color.Black;
            this.rBtnReprimand.Location = new System.Drawing.Point(10, 319);
            this.rBtnReprimand.Name = "rBtnReprimand";
            this.rBtnReprimand.Size = new System.Drawing.Size(272, 17);
            this.rBtnReprimand.TabIndex = 12;
            this.rBtnReprimand.TabStop = true;
            this.rBtnReprimand.Text = "REPRIMAND WITH WARNINGS FOR SUSPENSION";
            this.rBtnReprimand.UseVisualStyleBackColor = true;
            this.rBtnReprimand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReprimandKeyDown);
            // 
            // rBtnSuspensionFor
            // 
            this.rBtnSuspensionFor.AutoSize = true;
            this.rBtnSuspensionFor.Enabled = false;
            this.rBtnSuspensionFor.ForeColor = System.Drawing.Color.Black;
            this.rBtnSuspensionFor.Location = new System.Drawing.Point(10, 342);
            this.rBtnSuspensionFor.Name = "rBtnSuspensionFor";
            this.rBtnSuspensionFor.Size = new System.Drawing.Size(116, 17);
            this.rBtnSuspensionFor.TabIndex = 13;
            this.rBtnSuspensionFor.TabStop = true;
            this.rBtnSuspensionFor.Text = "SUSPENSION FOR";
            this.rBtnSuspensionFor.UseVisualStyleBackColor = true;
            this.rBtnSuspensionFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuspensionForKeyDown);
            // 
            // txtSuspensionFor
            // 
            this.txtSuspensionFor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSuspensionFor.Location = new System.Drawing.Point(132, 337);
            this.txtSuspensionFor.Name = "txtSuspensionFor";
            this.txtSuspensionFor.ReadOnly = true;
            this.txtSuspensionFor.Size = new System.Drawing.Size(48, 22);
            this.txtSuspensionFor.TabIndex = 14;
            this.txtSuspensionFor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuspensionTextKeyDown);
            // 
            // lblScheduledOn
            // 
            this.lblScheduledOn.AutoSize = true;
            this.lblScheduledOn.Location = new System.Drawing.Point(198, 342);
            this.lblScheduledOn.Name = "lblScheduledOn";
            this.lblScheduledOn.Size = new System.Drawing.Size(89, 13);
            this.lblScheduledOn.TabIndex = 28;
            this.lblScheduledOn.Text = "SCHEDULED ON";
            // 
            // txtScheduledOn
            // 
            this.txtScheduledOn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScheduledOn.Location = new System.Drawing.Point(302, 337);
            this.txtScheduledOn.Name = "txtScheduledOn";
            this.txtScheduledOn.ReadOnly = true;
            this.txtScheduledOn.Size = new System.Drawing.Size(186, 22);
            this.txtScheduledOn.TabIndex = 15;
            this.txtScheduledOn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScheduledOnKeyDown);
            // 
            // rBtnWarningForTermination
            // 
            this.rBtnWarningForTermination.AutoSize = true;
            this.rBtnWarningForTermination.Enabled = false;
            this.rBtnWarningForTermination.ForeColor = System.Drawing.Color.Black;
            this.rBtnWarningForTermination.Location = new System.Drawing.Point(10, 365);
            this.rBtnWarningForTermination.Name = "rBtnWarningForTermination";
            this.rBtnWarningForTermination.Size = new System.Drawing.Size(169, 17);
            this.rBtnWarningForTermination.TabIndex = 16;
            this.rBtnWarningForTermination.TabStop = true;
            this.rBtnWarningForTermination.Text = "WARNING FOR TEMINATION";
            this.rBtnWarningForTermination.UseVisualStyleBackColor = true;
            this.rBtnWarningForTermination.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WarningForTerminationKeyDown);
            // 
            // txtTerminationEffect
            // 
            this.txtTerminationEffect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTerminationEffect.Location = new System.Drawing.Point(171, 383);
            this.txtTerminationEffect.Name = "txtTerminationEffect";
            this.txtTerminationEffect.ReadOnly = true;
            this.txtTerminationEffect.Size = new System.Drawing.Size(186, 22);
            this.txtTerminationEffect.TabIndex = 18;
            this.txtTerminationEffect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TerminationEffectKeyDown);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(11, 419);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(50, 13);
            this.lblRemarks.TabIndex = 33;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(67, 417);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(421, 22);
            this.txtRemarks.TabIndex = 19;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemarksKeyDown);
            // 
            // lblPreparedBy
            // 
            this.lblPreparedBy.AutoSize = true;
            this.lblPreparedBy.Location = new System.Drawing.Point(554, 339);
            this.lblPreparedBy.Name = "lblPreparedBy";
            this.lblPreparedBy.Size = new System.Drawing.Size(68, 13);
            this.lblPreparedBy.TabIndex = 35;
            this.lblPreparedBy.Text = "Prepared By";
            // 
            // txtPreparedBy2
            // 
            this.txtPreparedBy2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreparedBy2.Location = new System.Drawing.Point(628, 337);
            this.txtPreparedBy2.Name = "txtPreparedBy2";
            this.txtPreparedBy2.ReadOnly = true;
            this.txtPreparedBy2.Size = new System.Drawing.Size(210, 22);
            this.txtPreparedBy2.TabIndex = 20;
            this.txtPreparedBy2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PreparedBy2KeyDown);
            // 
            // lblNotedBy2
            // 
            this.lblNotedBy2.AutoSize = true;
            this.lblNotedBy2.Location = new System.Drawing.Point(568, 367);
            this.lblNotedBy2.Name = "lblNotedBy2";
            this.lblNotedBy2.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy2.TabIndex = 37;
            this.lblNotedBy2.Text = "Noted By";
            // 
            // txtNotedBy2
            // 
            this.txtNotedBy2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy2.Location = new System.Drawing.Point(628, 365);
            this.txtNotedBy2.Name = "txtNotedBy2";
            this.txtNotedBy2.ReadOnly = true;
            this.txtNotedBy2.Size = new System.Drawing.Size(210, 22);
            this.txtNotedBy2.TabIndex = 21;
            this.txtNotedBy2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotedBy2Focus);
            // 
            // lblApprovedBy2
            // 
            this.lblApprovedBy2.AutoSize = true;
            this.lblApprovedBy2.Location = new System.Drawing.Point(550, 395);
            this.lblApprovedBy2.Name = "lblApprovedBy2";
            this.lblApprovedBy2.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy2.TabIndex = 39;
            this.lblApprovedBy2.Text = "Approved By";
            // 
            // txtApprovedBy2
            // 
            this.txtApprovedBy2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy2.Location = new System.Drawing.Point(628, 393);
            this.txtApprovedBy2.Name = "txtApprovedBy2";
            this.txtApprovedBy2.ReadOnly = true;
            this.txtApprovedBy2.Size = new System.Drawing.Size(210, 22);
            this.txtApprovedBy2.TabIndex = 22;
            this.txtApprovedBy2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedBy2KeyDown);
            // 
            // lblConformeBy
            // 
            this.lblConformeBy.AutoSize = true;
            this.lblConformeBy.Location = new System.Drawing.Point(549, 423);
            this.lblConformeBy.Name = "lblConformeBy";
            this.lblConformeBy.Size = new System.Drawing.Size(73, 13);
            this.lblConformeBy.TabIndex = 41;
            this.lblConformeBy.Text = "Conforme By";
            // 
            // txtConformeBy
            // 
            this.txtConformeBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConformeBy.Location = new System.Drawing.Point(628, 421);
            this.txtConformeBy.Name = "txtConformeBy";
            this.txtConformeBy.ReadOnly = true;
            this.txtConformeBy.Size = new System.Drawing.Size(210, 22);
            this.txtConformeBy.TabIndex = 23;
            this.txtConformeBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConformeByKeyDown);
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlLine.Location = new System.Drawing.Point(3, 243);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(846, 3);
            this.pnlLine.TabIndex = 44;
            // 
            // lblPRWHistory
            // 
            this.lblPRWHistory.AutoSize = true;
            this.lblPRWHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPRWHistory.Location = new System.Drawing.Point(588, 78);
            this.lblPRWHistory.Name = "lblPRWHistory";
            this.lblPRWHistory.Size = new System.Drawing.Size(72, 13);
            this.lblPRWHistory.TabIndex = 46;
            this.lblPRWHistory.Text = "PRW History";
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
            this.colDetailCol1,
            this.colDetailCol2,
            this.colDetailCol3,
            this.col4,
            this.col5,
            this.col6,
            this.colTotal,
            this.colPk,
            this.colPRWId});
            this.gridDetails.Location = new System.Drawing.Point(0, 449);
            this.gridDetails.MultiSelect = false;
            this.gridDetails.Name = "gridDetails";
            this.gridDetails.RowHeadersVisible = false;
            this.gridDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetails.Size = new System.Drawing.Size(848, 168);
            this.gridDetails.TabIndex = 24;
            // 
            // colDetailDesciption
            // 
            this.colDetailDesciption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDetailDesciption.HeaderText = "Description";
            this.colDetailDesciption.Name = "colDetailDesciption";
            this.colDetailDesciption.ReadOnly = true;
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
            // col4
            // 
            this.col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col4.HeaderText = "Col 4";
            this.col4.Name = "col4";
            // 
            // col5
            // 
            this.col5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col5.HeaderText = "Col 5";
            this.col5.Name = "col5";
            // 
            // col6
            // 
            this.col6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col6.HeaderText = "Col 6";
            this.col6.Name = "col6";
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colPk
            // 
            this.colPk.HeaderText = "0";
            this.colPk.Name = "colPk";
            this.colPk.ReadOnly = true;
            this.colPk.Visible = false;
            // 
            // colPRWId
            // 
            this.colPRWId.HeaderText = "0";
            this.colPRWId.Name = "colPRWId";
            this.colPRWId.ReadOnly = true;
            this.colPRWId.Visible = false;
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
            this.colDateApplied,
            this.colContrlNo});
            this.gridHistory.Location = new System.Drawing.Point(591, 94);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(257, 139);
            this.gridHistory.TabIndex = 25;
            // 
            // colDateApplied
            // 
            this.colDateApplied.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateApplied.DataPropertyName = "TransactionDate";
            this.colDateApplied.HeaderText = "Date Applied";
            this.colDateApplied.Name = "colDateApplied";
            this.colDateApplied.ReadOnly = true;
            // 
            // colContrlNo
            // 
            this.colContrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colContrlNo.DataPropertyName = "CntrlNo";
            this.colContrlNo.HeaderText = "Control No";
            this.colContrlNo.Name = "colContrlNo";
            this.colContrlNo.ReadOnly = true;
            // 
            // chkLate
            // 
            this.chkLate.AutoSize = true;
            this.chkLate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkLate.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkLate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkLate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(178)))), ((int)(((byte)(185)))));
            this.chkLate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLate.Location = new System.Drawing.Point(123, 58);
            this.chkLate.Name = "chkLate";
            this.chkLate.Size = new System.Drawing.Size(44, 17);
            this.chkLate.TabIndex = 1;
            this.chkLate.Text = "Late";
            this.chkLate.UseVisualStyleBackColor = true;
            this.chkLate.CheckedChanged += new System.EventHandler(this.CheckLate);
            // 
            // chkAbsent
            // 
            this.chkAbsent.AutoSize = true;
            this.chkAbsent.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.chkAbsent.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkAbsent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.chkAbsent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(178)))), ((int)(((byte)(185)))));
            this.chkAbsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAbsent.Location = new System.Drawing.Point(46, 58);
            this.chkAbsent.Name = "chkAbsent";
            this.chkAbsent.Size = new System.Drawing.Size(59, 17);
            this.chkAbsent.TabIndex = 0;
            this.chkAbsent.Text = "Absent";
            this.chkAbsent.UseVisualStyleBackColor = true;
            this.chkAbsent.CheckedChanged += new System.EventHandler(this.CheckAbsent);
            // 
            // rBtnTerminationEffectOn
            // 
            this.rBtnTerminationEffectOn.AutoSize = true;
            this.rBtnTerminationEffectOn.Enabled = false;
            this.rBtnTerminationEffectOn.ForeColor = System.Drawing.Color.Black;
            this.rBtnTerminationEffectOn.Location = new System.Drawing.Point(10, 388);
            this.rBtnTerminationEffectOn.Name = "rBtnTerminationEffectOn";
            this.rBtnTerminationEffectOn.Size = new System.Drawing.Size(155, 17);
            this.rBtnTerminationEffectOn.TabIndex = 17;
            this.rBtnTerminationEffectOn.TabStop = true;
            this.rBtnTerminationEffectOn.Text = "TERMINATION EFFECT ON";
            this.rBtnTerminationEffectOn.UseVisualStyleBackColor = true;
            this.rBtnTerminationEffectOn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TerminationEffectOnKeyDown);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(564, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 32);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "P O S T E D";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(457, 41);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(400, 13);
            this.lblLastUpdated.TabIndex = 48;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UsrCntrlPRW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.lblPRWHistory);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.gridDetails);
            this.Controls.Add(this.lblConformeBy);
            this.Controls.Add(this.txtConformeBy);
            this.Controls.Add(this.lblApprovedBy2);
            this.Controls.Add(this.txtApprovedBy2);
            this.Controls.Add(this.lblNotedBy2);
            this.Controls.Add(this.txtNotedBy2);
            this.Controls.Add(this.lblPreparedBy);
            this.Controls.Add(this.txtPreparedBy2);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtTerminationEffect);
            this.Controls.Add(this.rBtnTerminationEffectOn);
            this.Controls.Add(this.rBtnWarningForTermination);
            this.Controls.Add(this.txtScheduledOn);
            this.Controls.Add(this.lblScheduledOn);
            this.Controls.Add(this.txtSuspensionFor);
            this.Controls.Add(this.rBtnSuspensionFor);
            this.Controls.Add(this.rBtnReprimand);
            this.Controls.Add(this.rBtnCounsilingWarning);
            this.Controls.Add(this.lblInViewOfYourRecords);
            this.Controls.Add(this.lblDisciplinaryAction);
            this.Controls.Add(this.lblReleasedBy);
            this.Controls.Add(this.txtReleaseBy);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblVerifiedBy);
            this.Controls.Add(this.txtVerifiedBy);
            this.Controls.Add(this.lblNoDaysMins);
            this.Controls.Add(this.txtNoDaysMins);
            this.Controls.Add(this.lblNotedBy);
            this.Controls.Add(this.txtNotedBy);
            this.Controls.Add(this.lblRecommendedBy);
            this.Controls.Add(this.txtRecommendedBy);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblDateAbsenceLate);
            this.Controls.Add(this.txtDateAbsenceLate);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.chkLate);
            this.Controls.Add(this.chkAbsent);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlPRW";
            this.Size = new System.Drawing.Size(860, 656);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ModifiedControls.CheckBox chkAbsent;
        private ModifiedControls.CheckBox chkLate;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.Label lblDateAbsenceLate;
        private System.Windows.Forms.TextBox txtDateAbsenceLate;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblRecommendedBy;
        private System.Windows.Forms.TextBox txtRecommendedBy;
        private System.Windows.Forms.Label lblNotedBy;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label lblNoDaysMins;
        private System.Windows.Forms.TextBox txtNoDaysMins;
        private System.Windows.Forms.Label lblVerifiedBy;
        private System.Windows.Forms.TextBox txtVerifiedBy;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label lblReleasedBy;
        private System.Windows.Forms.TextBox txtReleaseBy;
        private System.Windows.Forms.Label lblDisciplinaryAction;
        private System.Windows.Forms.Label lblInViewOfYourRecords;
        private System.Windows.Forms.RadioButton rBtnCounsilingWarning;
        private System.Windows.Forms.RadioButton rBtnReprimand;
        private System.Windows.Forms.RadioButton rBtnSuspensionFor;
        private System.Windows.Forms.TextBox txtSuspensionFor;
        private System.Windows.Forms.Label lblScheduledOn;
        private System.Windows.Forms.TextBox txtScheduledOn;
        private System.Windows.Forms.RadioButton rBtnWarningForTermination;
        private System.Windows.Forms.TextBox txtTerminationEffect;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblPreparedBy;
        private System.Windows.Forms.TextBox txtPreparedBy2;
        private System.Windows.Forms.Label lblNotedBy2;
        private System.Windows.Forms.TextBox txtNotedBy2;
        private System.Windows.Forms.Label lblApprovedBy2;
        private System.Windows.Forms.TextBox txtApprovedBy2;
        private System.Windows.Forms.Label lblConformeBy;
        private System.Windows.Forms.TextBox txtConformeBy;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblPRWHistory;
        private System.Windows.Forms.DataGridView gridDetails;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApplied;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContrlNo;
        private System.Windows.Forms.RadioButton rBtnTerminationEffectOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailDesciption;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetailCol3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPk;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPRWId;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblLastUpdated;
    }
}
