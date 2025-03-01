namespace TimeKeepingSystemUI.Forms
{
    partial class FrmActiveMachineId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActiveMachineId));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.gridList = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsAvailable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUsedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucDragableHeader = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.pnlWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkActive);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 30);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(514, 62);
            this.pnlTop.TabIndex = 1;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(435, 35);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(69, 17);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active Id";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.CheckActiveChange);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(61, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(208, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(14, 36);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search";
            // 
            // gridList
            // 
            this.gridList.AllowUserToAddRows = false;
            this.gridList.AllowUserToDeleteRows = false;
            this.gridList.AllowUserToResizeRows = false;
            this.gridList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridList.ColumnHeadersHeight = 25;
            this.gridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colIsAvailable,
            this.colUsedBy});
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.Location = new System.Drawing.Point(0, 92);
            this.gridList.MultiSelect = false;
            this.gridList.Name = "gridList";
            this.gridList.RowHeadersVisible = false;
            this.gridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridList.Size = new System.Drawing.Size(514, 362);
            this.gridList.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colIsAvailable
            // 
            this.colIsAvailable.HeaderText = "Available";
            this.colIsAvailable.Name = "colIsAvailable";
            this.colIsAvailable.ReadOnly = true;
            this.colIsAvailable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsAvailable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsAvailable.Width = 60;
            // 
            // colUsedBy
            // 
            this.colUsedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUsedBy.HeaderText = "Used By";
            this.colUsedBy.Name = "colUsedBy";
            this.colUsedBy.ReadOnly = true;
            // 
            // ucDragableHeader
            // 
            this.ucDragableHeader.BackColor = System.Drawing.Color.White;
            this.ucDragableHeader.CloseButton = true;
            this.ucDragableHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucDragableHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDragableHeader.IsHeaderShown = true;
            this.ucDragableHeader.Location = new System.Drawing.Point(0, 0);
            this.ucDragableHeader.MaximizeButton = false;
            this.ucDragableHeader.MinimizeButton = true;
            this.ucDragableHeader.Name = "ucDragableHeader";
            this.ucDragableHeader.SetHeaderText = "Available Machine Id";
            this.ucDragableHeader.Size = new System.Drawing.Size(514, 30);
            this.ucDragableHeader.TabIndex = 0;
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWrapper.Controls.Add(this.gridList);
            this.pnlWrapper.Controls.Add(this.pnlTop);
            this.pnlWrapper.Controls.Add(this.ucDragableHeader);
            this.pnlWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(516, 456);
            this.pnlWrapper.TabIndex = 3;
            // 
            // FrmActiveMachineId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 456);
            this.Controls.Add(this.pnlWrapper);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmActiveMachineId";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Available Machine Id";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.pnlWrapper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UsrCntrlDragableHeader ucDragableHeader;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView gridList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsedBy;
        private System.Windows.Forms.Panel pnlWrapper;
    }
}