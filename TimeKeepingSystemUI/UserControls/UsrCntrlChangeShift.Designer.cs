namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlChangeShift
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
            this.lblCntrlNo = new System.Windows.Forms.Label();
            this.txtCntrlNo = new System.Windows.Forms.TextBox();
            this.lblTimeFrom = new System.Windows.Forms.Label();
            this.txtTimeFrom = new System.Windows.Forms.TextBox();
            this.lblDateApply = new System.Windows.Forms.Label();
            this.txtDateApply = new System.Windows.Forms.TextBox();
            this.lblTimeTo = new System.Windows.Forms.Label();
            this.txtTimeTo = new System.Windows.Forms.TextBox();
            this.lblRefNo = new System.Windows.Forms.Label();
            this.txtDateEffect = new System.Windows.Forms.TextBox();
            this.lblNotedBy = new System.Windows.Forms.Label();
            this.txtNotedBy = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblDateEffect = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.lblApprovedBy = new System.Windows.Forms.Label();
            this.txtApprovedBy = new System.Windows.Forms.TextBox();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colDateApply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCntrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLastUpdated = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblChangeShiftHistory = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCntrlNo
            // 
            this.lblCntrlNo.AutoSize = true;
            this.lblCntrlNo.Location = new System.Drawing.Point(42, 114);
            this.lblCntrlNo.Name = "lblCntrlNo";
            this.lblCntrlNo.Size = new System.Drawing.Size(64, 13);
            this.lblCntrlNo.TabIndex = 4;
            this.lblCntrlNo.Text = "Control No";
            // 
            // txtCntrlNo
            // 
            this.txtCntrlNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtCntrlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCntrlNo.Location = new System.Drawing.Point(112, 112);
            this.txtCntrlNo.Name = "txtCntrlNo";
            this.txtCntrlNo.ReadOnly = true;
            this.txtCntrlNo.Size = new System.Drawing.Size(210, 22);
            this.txtCntrlNo.TabIndex = 0;
            this.txtCntrlNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlNoKeyDown);
            // 
            // lblTimeFrom
            // 
            this.lblTimeFrom.AutoSize = true;
            this.lblTimeFrom.Location = new System.Drawing.Point(47, 226);
            this.lblTimeFrom.Name = "lblTimeFrom";
            this.lblTimeFrom.Size = new System.Drawing.Size(59, 13);
            this.lblTimeFrom.TabIndex = 6;
            this.lblTimeFrom.Text = "Time From";
            // 
            // txtTimeFrom
            // 
            this.txtTimeFrom.BackColor = System.Drawing.Color.White;
            this.txtTimeFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeFrom.Location = new System.Drawing.Point(112, 224);
            this.txtTimeFrom.Name = "txtTimeFrom";
            this.txtTimeFrom.ReadOnly = true;
            this.txtTimeFrom.Size = new System.Drawing.Size(210, 22);
            this.txtTimeFrom.TabIndex = 4;
            this.txtTimeFrom.Enter += new System.EventHandler(this.TimeFromEnter);
            this.txtTimeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeFromKeyDowm);
            this.txtTimeFrom.Validating += new System.ComponentModel.CancelEventHandler(this.TimeFromValidating);
            // 
            // lblDateApply
            // 
            this.lblDateApply.AutoSize = true;
            this.lblDateApply.Location = new System.Drawing.Point(43, 142);
            this.lblDateApply.Name = "lblDateApply";
            this.lblDateApply.Size = new System.Drawing.Size(63, 13);
            this.lblDateApply.TabIndex = 8;
            this.lblDateApply.Text = "Date Apply";
            // 
            // txtDateApply
            // 
            this.txtDateApply.BackColor = System.Drawing.SystemColors.Control;
            this.txtDateApply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateApply.Location = new System.Drawing.Point(112, 140);
            this.txtDateApply.Name = "txtDateApply";
            this.txtDateApply.ReadOnly = true;
            this.txtDateApply.Size = new System.Drawing.Size(210, 22);
            this.txtDateApply.TabIndex = 1;
            this.txtDateApply.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateApplyKeyDown);
            // 
            // lblTimeTo
            // 
            this.lblTimeTo.AutoSize = true;
            this.lblTimeTo.Location = new System.Drawing.Point(61, 254);
            this.lblTimeTo.Name = "lblTimeTo";
            this.lblTimeTo.Size = new System.Drawing.Size(45, 13);
            this.lblTimeTo.TabIndex = 10;
            this.lblTimeTo.Text = "Time To";
            // 
            // txtTimeTo
            // 
            this.txtTimeTo.BackColor = System.Drawing.Color.White;
            this.txtTimeTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeTo.Location = new System.Drawing.Point(112, 252);
            this.txtTimeTo.Name = "txtTimeTo";
            this.txtTimeTo.ReadOnly = true;
            this.txtTimeTo.Size = new System.Drawing.Size(210, 22);
            this.txtTimeTo.TabIndex = 5;
            this.txtTimeTo.Enter += new System.EventHandler(this.TimeToEnter);
            this.txtTimeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeToKeyDown);
            this.txtTimeTo.Validating += new System.ComponentModel.CancelEventHandler(this.TimeToValidating);
            // 
            // lblRefNo
            // 
            this.lblRefNo.AutoSize = true;
            this.lblRefNo.Location = new System.Drawing.Point(64, 198);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(42, 13);
            this.lblRefNo.TabIndex = 12;
            this.lblRefNo.Text = "Ref No";
            // 
            // txtDateEffect
            // 
            this.txtDateEffect.BackColor = System.Drawing.Color.White;
            this.txtDateEffect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateEffect.Location = new System.Drawing.Point(112, 168);
            this.txtDateEffect.Name = "txtDateEffect";
            this.txtDateEffect.ReadOnly = true;
            this.txtDateEffect.Size = new System.Drawing.Size(210, 22);
            this.txtDateEffect.TabIndex = 2;
            this.txtDateEffect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateEffectKeyDown);
            this.txtDateEffect.Validating += new System.ComponentModel.CancelEventHandler(this.DateEffectValidating);
            // 
            // lblNotedBy
            // 
            this.lblNotedBy.AutoSize = true;
            this.lblNotedBy.Location = new System.Drawing.Point(52, 282);
            this.lblNotedBy.Name = "lblNotedBy";
            this.lblNotedBy.Size = new System.Drawing.Size(54, 13);
            this.lblNotedBy.TabIndex = 14;
            this.lblNotedBy.Text = "Noted By";
            // 
            // txtNotedBy
            // 
            this.txtNotedBy.BackColor = System.Drawing.Color.White;
            this.txtNotedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotedBy.Location = new System.Drawing.Point(112, 280);
            this.txtNotedBy.Name = "txtNotedBy";
            this.txtNotedBy.ReadOnly = true;
            this.txtNotedBy.Size = new System.Drawing.Size(210, 22);
            this.txtNotedBy.TabIndex = 6;
            this.txtNotedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotedByKeyDown);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(56, 340);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(50, 13);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(111, 338);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(590, 22);
            this.txtRemarks.TabIndex = 8;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemarksKeyDown);
            // 
            // lblDateEffect
            // 
            this.lblDateEffect.AutoSize = true;
            this.lblDateEffect.Location = new System.Drawing.Point(43, 170);
            this.lblDateEffect.Name = "lblDateEffect";
            this.lblDateEffect.Size = new System.Drawing.Size(63, 13);
            this.lblDateEffect.TabIndex = 18;
            this.lblDateEffect.Text = "Date Effect";
            // 
            // txtRefNo
            // 
            this.txtRefNo.BackColor = System.Drawing.Color.White;
            this.txtRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefNo.Location = new System.Drawing.Point(112, 196);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.ReadOnly = true;
            this.txtRefNo.Size = new System.Drawing.Size(210, 22);
            this.txtRefNo.TabIndex = 3;
            this.txtRefNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RefNoKeyDown);
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.AutoSize = true;
            this.lblApprovedBy.Location = new System.Drawing.Point(34, 312);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(72, 13);
            this.lblApprovedBy.TabIndex = 20;
            this.lblApprovedBy.Text = "Approved By";
            // 
            // txtApprovedBy
            // 
            this.txtApprovedBy.BackColor = System.Drawing.Color.White;
            this.txtApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApprovedBy.Location = new System.Drawing.Point(112, 310);
            this.txtApprovedBy.Name = "txtApprovedBy";
            this.txtApprovedBy.ReadOnly = true;
            this.txtApprovedBy.Size = new System.Drawing.Size(210, 22);
            this.txtApprovedBy.TabIndex = 7;
            this.txtApprovedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApprovedBykeyDown);
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
            this.gridHistory.Location = new System.Drawing.Point(361, 112);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(340, 220);
            this.gridHistory.TabIndex = 9;
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
            this.colDateEffect.DataPropertyName = "DateEffect";
            this.colDateEffect.HeaderText = "Date Effect";
            this.colDateEffect.Name = "colDateEffect";
            this.colDateEffect.ReadOnly = true;
            // 
            // colCntrlNo
            // 
            this.colCntrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCntrlNo.DataPropertyName = "CntrlNo";
            this.colCntrlNo.HeaderText = "Control No";
            this.colCntrlNo.Name = "colCntrlNo";
            this.colCntrlNo.ReadOnly = true;
            // 
            // lblLastUpdated
            // 
            this.lblLastUpdated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastUpdated.Location = new System.Drawing.Point(301, 44);
            this.lblLastUpdated.Name = "lblLastUpdated";
            this.lblLastUpdated.Size = new System.Drawing.Size(400, 13);
            this.lblLastUpdated.TabIndex = 38;
            this.lblLastUpdated.Text = "Last Updated:";
            this.lblLastUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(412, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(293, 32);
            this.lblStatus.TabIndex = 37;
            this.lblStatus.Text = "P O S T E D";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblChangeShiftHistory
            // 
            this.lblChangeShiftHistory.AutoSize = true;
            this.lblChangeShiftHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeShiftHistory.Location = new System.Drawing.Point(358, 87);
            this.lblChangeShiftHistory.Name = "lblChangeShiftHistory";
            this.lblChangeShiftHistory.Size = new System.Drawing.Size(114, 13);
            this.lblChangeShiftHistory.TabIndex = 39;
            this.lblChangeShiftHistory.Text = "Change Shift History";
            // 
            // UsrCntrlChangeShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblChangeShiftHistory);
            this.Controls.Add(this.lblLastUpdated);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.lblApprovedBy);
            this.Controls.Add(this.txtApprovedBy);
            this.Controls.Add(this.lblDateEffect);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblNotedBy);
            this.Controls.Add(this.txtNotedBy);
            this.Controls.Add(this.lblRefNo);
            this.Controls.Add(this.txtDateEffect);
            this.Controls.Add(this.lblTimeTo);
            this.Controls.Add(this.txtTimeTo);
            this.Controls.Add(this.lblDateApply);
            this.Controls.Add(this.txtDateApply);
            this.Controls.Add(this.lblTimeFrom);
            this.Controls.Add(this.txtTimeFrom);
            this.Controls.Add(this.lblCntrlNo);
            this.Controls.Add(this.txtCntrlNo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlChangeShift";
            this.Size = new System.Drawing.Size(708, 378);
            this.Load += new System.EventHandler(this.FormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCntrlNo;
        private System.Windows.Forms.TextBox txtCntrlNo;
        private System.Windows.Forms.Label lblTimeFrom;
        private System.Windows.Forms.TextBox txtTimeFrom;
        private System.Windows.Forms.Label lblDateApply;
        private System.Windows.Forms.TextBox txtDateApply;
        private System.Windows.Forms.Label lblTimeTo;
        private System.Windows.Forms.TextBox txtTimeTo;
        private System.Windows.Forms.Label lblRefNo;
        private System.Windows.Forms.TextBox txtDateEffect;
        private System.Windows.Forms.Label lblNotedBy;
        private System.Windows.Forms.TextBox txtNotedBy;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblDateEffect;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label lblApprovedBy;
        private System.Windows.Forms.TextBox txtApprovedBy;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.Label lblLastUpdated;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblChangeShiftHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCntrlNo;
    }
}
