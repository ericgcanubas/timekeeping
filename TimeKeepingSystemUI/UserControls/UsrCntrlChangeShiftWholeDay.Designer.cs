namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlChangeShiftWholeDay
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
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblControlNo = new System.Windows.Forms.Label();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.lblDateApply = new System.Windows.Forms.Label();
            this.txtDateApply = new System.Windows.Forms.TextBox();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.txtShift = new System.Windows.Forms.TextBox();
            this.lblDateEffective = new System.Windows.Forms.Label();
            this.txtDateEffective = new System.Windows.Forms.TextBox();
            this.lblNotedBy = new System.Windows.Forms.Label();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblChangeShiftHistory = new System.Windows.Forms.Label();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colDateApply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCntrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucScheduleShift = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(371, 44);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(400, 13);
            this.lblLastUpdated.TabIndex = 50;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(478, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 32);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.Text = "P O S T E D";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblControlNo
            // 
            this.lblControlNo.AutoSize = true;
            this.lblControlNo.Location = new System.Drawing.Point(41, 121);
            this.lblControlNo.Name = "lblControlNo";
            this.lblControlNo.Size = new System.Drawing.Size(64, 13);
            this.lblControlNo.TabIndex = 52;
            this.lblControlNo.Text = "Control No";
            // 
            // txtControlNo
            // 
            this.txtControlNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtControlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlNo.Location = new System.Drawing.Point(111, 119);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.ReadOnly = true;
            this.txtControlNo.Size = new System.Drawing.Size(237, 22);
            this.txtControlNo.TabIndex = 0;
            this.txtControlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlNoKeyDown);
            // 
            // lblDateApply
            // 
            this.lblDateApply.AutoSize = true;
            this.lblDateApply.Location = new System.Drawing.Point(41, 149);
            this.lblDateApply.Name = "lblDateApply";
            this.lblDateApply.Size = new System.Drawing.Size(63, 13);
            this.lblDateApply.TabIndex = 54;
            this.lblDateApply.Text = "Date Apply";
            // 
            // txtDateApply
            // 
            this.txtDateApply.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateApply.Location = new System.Drawing.Point(111, 147);
            this.txtDateApply.Name = "txtDateApply";
            this.txtDateApply.ReadOnly = true;
            this.txtDateApply.Size = new System.Drawing.Size(237, 22);
            this.txtDateApply.TabIndex = 1;
            this.txtDateApply.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateApplyKeyDown);
            // 
            // lblRefNo
            // 
            this.lblRefNo.AutoSize = true;
            this.lblRefNo.Location = new System.Drawing.Point(62, 177);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(42, 13);
            this.lblRefNo.TabIndex = 56;
            this.lblRefNo.Text = "Ref No";
            // 
            // txtRefNo
            // 
            this.txtRefNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.Location = new System.Drawing.Point(111, 175);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.ReadOnly = true;
            this.txtRefNo.Size = new System.Drawing.Size(237, 22);
            this.txtRefNo.TabIndex = 2;
            this.txtRefNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefNoKeyDown);
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(74, 205);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(31, 13);
            this.lblShift.TabIndex = 58;
            this.lblShift.Text = "Shift";
            // 
            // txtShift
            // 
            this.txtShift.BackColor = System.Drawing.SystemColors.Control;
            this.txtShift.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShift.Location = new System.Drawing.Point(111, 203);
            this.txtShift.Name = "txtShift";
            this.txtShift.ReadOnly = true;
            this.txtShift.Size = new System.Drawing.Size(237, 22);
            this.txtShift.TabIndex = 3;
            this.txtShift.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShiftKeyDown);
            // 
            // lblDateEffective
            // 
            this.lblDateEffective.AutoSize = true;
            this.lblDateEffective.Location = new System.Drawing.Point(27, 233);
            this.lblDateEffective.Name = "lblDateEffective";
            this.lblDateEffective.Size = new System.Drawing.Size(77, 13);
            this.lblDateEffective.TabIndex = 60;
            this.lblDateEffective.Text = "Date Effective";
            // 
            // txtDateEffective
            // 
            this.txtDateEffective.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateEffective.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateEffective.Location = new System.Drawing.Point(111, 231);
            this.txtDateEffective.Name = "txtDateEffective";
            this.txtDateEffective.ReadOnly = true;
            this.txtDateEffective.Size = new System.Drawing.Size(237, 22);
            this.txtDateEffective.TabIndex = 4;
            this.txtDateEffective.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateEffectiveKeyDown);
            this.txtDateEffective.Validating += new System.ComponentModel.CancelEventHandler(this.DateEffectiveValidating);
            // 
            // lblNotedBy
            // 
            this.lblNotedBy.AutoSize = true;
            this.lblNotedBy.Location = new System.Drawing.Point(51, 261);
            this.lblNotedBy.Name = "lblNotedBy";
            this.lblNotedBy.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy.TabIndex = 62;
            this.lblNotedBy.Text = "Noted By";
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtNotedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy.Location = new System.Drawing.Point(111, 259);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.ReadOnly = true;
            this.txtNotedBy.Size = new System.Drawing.Size(237, 22);
            this.txtNotedBy.TabIndex = 5;
            this.txtNotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteByKeyDown);
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(32, 289);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy.TabIndex = 64;
            this.lblApprovedBy.Text = "Approved By";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.SystemColors.Control;
            this.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy.Location = new System.Drawing.Point(111, 287);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(237, 22);
            this.txtApprovedBy.TabIndex = 6;
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedKeyDown);
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(59, 317);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(45, 13);
            this.lblReason.TabIndex = 66;
            this.lblReason.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.SystemColors.Control;
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Location = new System.Drawing.Point(111, 315);
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(237, 22);
            this.txtReason.TabIndex = 7;
            this.txtReason.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReasonKeyDown);
            // 
            // lblChangeShiftHistory
            // 
            this.lblChangeShiftHistory.AutoSize = true;
            this.lblChangeShiftHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeShiftHistory.Location = new System.Drawing.Point(404, 94);
            this.lblChangeShiftHistory.Name = "lblChangeShiftHistory";
            this.lblChangeShiftHistory.Size = new System.Drawing.Size(114, 13);
            this.lblChangeShiftHistory.TabIndex = 68;
            this.lblChangeShiftHistory.Text = "Change Shift History";
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
            this.colDateEffect,
            this.colCntrlNo});
            this.gridHistory.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridHistory.Location = new System.Drawing.Point(407, 119);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(340, 220);
            this.gridHistory.TabIndex = 8;
            // 
            // colDateApply
            // 
            this.colDateApply.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateApply.DataPropertyName = "DateApply";
            this.colDateApply.HeaderText = "Date Apply";
            this.colDateApply.Name = "colDateApply";
            this.colDateApply.ReadOnly = true;
            // 
            // colDateEffect
            // 
            this.colDateEffect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateEffect.DataPropertyName = "DateEffective";
            this.colDateEffect.HeaderText = "Date Effect";
            this.colDateEffect.Name = "colDateEffect";
            this.colDateEffect.ReadOnly = true;
            // 
            // colCntrlNo
            // 
            this.colCntrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCntrlNo.DataPropertyName = "ControlNo";
            this.colCntrlNo.HeaderText = "Control No";
            this.colCntrlNo.Name = "colCntrlNo";
            this.colCntrlNo.ReadOnly = true;
            // 
            // ucScheduleShift
            // 
            this.ucScheduleShift.HeaderText = "Shift Changed";
            this.ucScheduleShift.Location = new System.Drawing.Point(111, 343);
            this.ucScheduleShift.Name = "ucScheduleShift";
            this.ucScheduleShift.Size = new System.Drawing.Size(237, 199);
            this.ucScheduleShift.TabIndex = 69;
            // 
            // UsrCntrlChangeShiftWholeDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucScheduleShift);
            this.Controls.Add(this.lblChangeShiftHistory);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblNotedBy);
            this.Controls.Add(this.txtNotedBy);
            this.Controls.Add(this.lblDateEffective);
            this.Controls.Add(this.txtDateEffective);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.txtShift);
            this.Controls.Add(this.lblRefNo);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.lblDateApply);
            this.Controls.Add(this.txtDateApply);
            this.Controls.Add(this.lblControlNo);
            this.Controls.Add(this.txtControlNo);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblStatus);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlChangeShiftWholeDay";
            this.Size = new System.Drawing.Size(785, 555);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblControlNo;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label lblDateApply;
        private System.Windows.Forms.TextBox txtDateApply;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.TextBox txtShift;
        private System.Windows.Forms.Label lblDateEffective;
        private System.Windows.Forms.TextBox txtDateEffective;
        private System.Windows.Forms.Label lblNotedBy;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblChangeShiftHistory;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCntrlNo;
        private UsrCntrlScheduleView ucScheduleShift;
    }
}
