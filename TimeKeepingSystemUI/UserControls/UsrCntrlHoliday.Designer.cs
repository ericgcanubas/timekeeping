namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlHoliday
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHoliday = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.btnView = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnDelete = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnUpdate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCreate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.gridList = new System.Windows.Forms.DataGridView();
            this.colCntrlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEffectDates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHoliday);
            this.pnlHeader.Controls.Add(this.lblBreadcumbHome);
            this.pnlHeader.Controls.Add(this.btnView);
            this.pnlHeader.Controls.Add(this.btnDelete);
            this.pnlHeader.Controls.Add(this.btnUpdate);
            this.pnlHeader.Controls.Add(this.btnCreate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1018, 44);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblHoliday
            // 
            this.lblHoliday.AutoSize = true;
            this.lblHoliday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHoliday.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoliday.Location = new System.Drawing.Point(65, 14);
            this.lblHoliday.Name = "lblHoliday";
            this.lblHoliday.Size = new System.Drawing.Size(83, 17);
            this.lblHoliday.TabIndex = 13;
            this.lblHoliday.Text = "/ HOLIDAYS";
            this.lblHoliday.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblHoliday.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(12, 14);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 12;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.LinkHomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(573, 11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(105, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.ViewClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(906, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeleteClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(795, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.UpdateClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(684, 11);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.CreateClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 573);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1018, 42);
            this.pnlFooter.TabIndex = 4;
            // 
            // gridList
            // 
            this.gridList.AllowUserToAddRows = false;
            this.gridList.AllowUserToDeleteRows = false;
            this.gridList.AllowUserToResizeRows = false;
            this.gridList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridList.ColumnHeadersHeight = 25;
            this.gridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCntrlNo,
            this.colDateCreated,
            this.colCreatedBy,
            this.colEffectDates,
            this.colRemarks});
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.EnableHeadersVisualStyles = false;
            this.gridList.Location = new System.Drawing.Point(3, 44);
            this.gridList.MultiSelect = false;
            this.gridList.Name = "gridList";
            this.gridList.RowHeadersVisible = false;
            this.gridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridList.Size = new System.Drawing.Size(1015, 529);
            this.gridList.TabIndex = 5;
            // 
            // colCntrlNo
            // 
            this.colCntrlNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCntrlNo.DataPropertyName = "CntrlId";
            this.colCntrlNo.HeaderText = "Control No";
            this.colCntrlNo.Name = "colCntrlNo";
            this.colCntrlNo.ReadOnly = true;
            // 
            // colDateCreated
            // 
            this.colDateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCreatedBy.DataPropertyName = "CreatedBy";
            this.colCreatedBy.HeaderText = "Created By";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // colEffectDates
            // 
            this.colEffectDates.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEffectDates.DataPropertyName = "EffectDates";
            this.colEffectDates.HeaderText = "Date Effects";
            this.colEffectDates.Name = "colEffectDates";
            this.colEffectDates.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 529);
            this.panel1.TabIndex = 6;
            // 
            // UsrCntrlHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlHoliday";
            this.Size = new System.Drawing.Size(1018, 615);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnDelete;
        private ModifiedControls.Button btnUpdate;
        private ModifiedControls.Button btnCreate;
        private ModifiedControls.Button btnView;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView gridList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCntrlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffectDates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHoliday;
        private System.Windows.Forms.Label lblBreadcumbHome;
    }
}
