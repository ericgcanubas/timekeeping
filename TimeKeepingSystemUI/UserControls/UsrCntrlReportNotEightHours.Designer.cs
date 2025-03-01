namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlReportNotEightHours
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
            this.lblBreadcumbNotEightHours = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.gridResult = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalUndertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustmentCntrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdjustmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFind = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlTop.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblBreadcumbNotEightHours);
            this.pnlTop.Controls.Add(this.lblBreadcumbHome);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(859, 40);
            this.pnlTop.TabIndex = 3;
            // 
            // lblBreadcumbNotEightHours
            // 
            this.lblBreadcumbNotEightHours.AutoSize = true;
            this.lblBreadcumbNotEightHours.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbNotEightHours.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbNotEightHours.Location = new System.Drawing.Point(68, 11);
            this.lblBreadcumbNotEightHours.Name = "lblBreadcumbNotEightHours";
            this.lblBreadcumbNotEightHours.Size = new System.Drawing.Size(136, 17);
            this.lblBreadcumbNotEightHours.TabIndex = 11;
            this.lblBreadcumbNotEightHours.Text = "/ NOT EIGHT HOURS";
            this.lblBreadcumbNotEightHours.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblBreadcumbNotEightHours.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
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
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnFind);
            this.pnlHeader.Controls.Add(this.dtpDate);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 40);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(859, 48);
            this.pnlHeader.TabIndex = 4;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(55, 14);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(15, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 526);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(859, 33);
            this.pnlFooter.TabIndex = 5;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.White;
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 88);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(3, 438);
            this.pnlSeparator.TabIndex = 6;
            // 
            // gridResult
            // 
            this.gridResult.AllowUserToAddRows = false;
            this.gridResult.AllowUserToDeleteRows = false;
            this.gridResult.AllowUserToResizeRows = false;
            this.gridResult.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridResult.ColumnHeadersHeight = 25;
            this.gridResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colTotalLate,
            this.colTotalUndertime,
            this.colAdjustmentCntrl,
            this.colAdjustmentTime,
            this.colNetHours});
            this.gridResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridResult.EnableHeadersVisualStyles = false;
            this.gridResult.Location = new System.Drawing.Point(3, 88);
            this.gridResult.MultiSelect = false;
            this.gridResult.Name = "gridResult";
            this.gridResult.RowHeadersVisible = false;
            this.gridResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridResult.Size = new System.Drawing.Size(856, 438);
            this.gridResult.TabIndex = 7;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colTotalLate
            // 
            this.colTotalLate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalLate.DataPropertyName = "TotalLate";
            this.colTotalLate.HeaderText = "Total Late";
            this.colTotalLate.Name = "colTotalLate";
            this.colTotalLate.ReadOnly = true;
            // 
            // colTotalUndertime
            // 
            this.colTotalUndertime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalUndertime.DataPropertyName = "TotalUndertime";
            this.colTotalUndertime.HeaderText = "Total Undertime";
            this.colTotalUndertime.Name = "colTotalUndertime";
            this.colTotalUndertime.ReadOnly = true;
            // 
            // colAdjustmentCntrl
            // 
            this.colAdjustmentCntrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAdjustmentCntrl.DataPropertyName = "AdjustmentCtrl";
            this.colAdjustmentCntrl.HeaderText = "Adjustment Cntrl";
            this.colAdjustmentCntrl.Name = "colAdjustmentCntrl";
            this.colAdjustmentCntrl.ReadOnly = true;
            // 
            // colAdjustmentTime
            // 
            this.colAdjustmentTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAdjustmentTime.DataPropertyName = "AdjustedTime";
            this.colAdjustmentTime.HeaderText = "Adjustment Time";
            this.colAdjustmentTime.Name = "colAdjustmentTime";
            this.colAdjustmentTime.ReadOnly = true;
            // 
            // colNetHours
            // 
            this.colNetHours.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNetHours.DataPropertyName = "NetHours";
            this.colNetHours.HeaderText = "Net Hours";
            this.colNetHours.Name = "colNetHours";
            this.colNetHours.ReadOnly = true;
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Location = new System.Drawing.Point(261, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.FindClick);
            // 
            // UsrCntrlReportNotEightHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridResult);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlReportNotEightHours";
            this.Size = new System.Drawing.Size(859, 559);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBreadcumbNotEightHours;
        private System.Windows.Forms.Label lblBreadcumbHome;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private ModifiedControls.Button btnFind;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.DataGridView gridResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalUndertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustmentCntrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdjustmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetHours;
    }
}
