namespace TimeKeepingSystemUI.Forms
{
    partial class FrmShiftingSchedules
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShiftingSchedules));
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.ucSchedule = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.gridSearchResult = new System.Windows.Forms.DataGridView();
            this.colShiftingName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ucHeader = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.pnlWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWrapper.Controls.Add(this.ucSchedule);
            this.pnlWrapper.Controls.Add(this.gridSearchResult);
            this.pnlWrapper.Controls.Add(this.lblSearch);
            this.pnlWrapper.Controls.Add(this.txtSearch);
            this.pnlWrapper.Controls.Add(this.ucHeader);
            this.pnlWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(753, 361);
            this.pnlWrapper.TabIndex = 0;
            // 
            // ucSchedule
            // 
            this.ucSchedule.BackColor = System.Drawing.Color.White;
            this.ucSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSchedule.HeaderText = "Schedule";
            this.ucSchedule.Location = new System.Drawing.Point(447, 60);
            this.ucSchedule.Name = "ucSchedule";
            this.ucSchedule.Size = new System.Drawing.Size(293, 276);
            this.ucSchedule.TabIndex = 2;
            // 
            // gridSearchResult
            // 
            this.gridSearchResult.AllowUserToAddRows = false;
            this.gridSearchResult.AllowUserToDeleteRows = false;
            this.gridSearchResult.AllowUserToResizeRows = false;
            this.gridSearchResult.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearchResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSearchResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridSearchResult.ColumnHeadersHeight = 25;
            this.gridSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShiftingName,
            this.colAddedBy,
            this.colLastModified});
            this.gridSearchResult.EnableHeadersVisualStyles = false;
            this.gridSearchResult.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearchResult.Location = new System.Drawing.Point(11, 60);
            this.gridSearchResult.MultiSelect = false;
            this.gridSearchResult.Name = "gridSearchResult";
            this.gridSearchResult.RowHeadersVisible = false;
            this.gridSearchResult.RowHeadersWidth = 30;
            this.gridSearchResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSearchResult.Size = new System.Drawing.Size(430, 276);
            this.gridSearchResult.TabIndex = 1;
            this.gridSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridKeyDown);
            // 
            // colShiftingName
            // 
            this.colShiftingName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShiftingName.DataPropertyName = "ShiftingName";
            this.colShiftingName.HeaderText = "Shifting Name";
            this.colShiftingName.Name = "colShiftingName";
            this.colShiftingName.ReadOnly = true;
            // 
            // colAddedBy
            // 
            this.colAddedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAddedBy.DataPropertyName = "CreatedBy";
            this.colAddedBy.HeaderText = "Added By";
            this.colAddedBy.Name = "colAddedBy";
            this.colAddedBy.ReadOnly = true;
            // 
            // colLastModified
            // 
            this.colLastModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastModified.DataPropertyName = "LastModified";
            this.colLastModified.HeaderText = "Last Modified";
            this.colLastModified.Name = "colLastModified";
            this.colLastModified.ReadOnly = true;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(11, 34);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(61, 32);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(261, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChange);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKeyDown);
            // 
            // ucHeader
            // 
            this.ucHeader.BackColor = System.Drawing.Color.White;
            this.ucHeader.CloseButton = true;
            this.ucHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucHeader.IsHeaderShown = true;
            this.ucHeader.Location = new System.Drawing.Point(0, 0);
            this.ucHeader.MaximizeButton = false;
            this.ucHeader.MinimizeButton = false;
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.SetHeaderText = "Shifting Schedules";
            this.ucHeader.Size = new System.Drawing.Size(751, 26);
            this.ucHeader.TabIndex = 3;
            // 
            // FrmShiftingSchedules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(753, 361);
            this.Controls.Add(this.pnlWrapper);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmShiftingSchedules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecte Shifting Schedule";
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnlWrapper.ResumeLayout(false);
            this.pnlWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWrapper;
        private UserControls.UsrCntrlDragableHeader ucHeader;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView gridSearchResult;
        private UserControls.UsrCntrlScheduleView ucSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShiftingName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastModified;

    }
}