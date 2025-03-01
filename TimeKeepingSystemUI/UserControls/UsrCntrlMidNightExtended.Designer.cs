namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlMidNightExtended
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
            this.lblExtendedMidNight = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtLastModified = new System.Windows.Forms.TextBox();
            this.lblLastModified = new System.Windows.Forms.Label();
            this.txtTimeOut = new System.Windows.Forms.TextBox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.dtpDateEffect = new System.Windows.Forms.DateTimePicker();
            this.lblDateEffect = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.gridList = new System.Windows.Forms.DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEffectDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpDateSearch = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnDelete = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnUpdate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCreate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblExtendedMidNight);
            this.pnlHeader.Controls.Add(this.lblBreadcumbHome);
            this.pnlHeader.Controls.Add(this.btnDelete);
            this.pnlHeader.Controls.Add(this.btnUpdate);
            this.pnlHeader.Controls.Add(this.btnCreate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1045, 44);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblExtendedMidNight
            // 
            this.lblExtendedMidNight.AutoSize = true;
            this.lblExtendedMidNight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExtendedMidNight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtendedMidNight.Location = new System.Drawing.Point(65, 16);
            this.lblExtendedMidNight.Name = "lblExtendedMidNight";
            this.lblExtendedMidNight.Size = new System.Drawing.Size(177, 17);
            this.lblExtendedMidNight.TabIndex = 15;
            this.lblExtendedMidNight.Text = "/ MID-NIGHT && EXTENDED";
            this.lblExtendedMidNight.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblExtendedMidNight.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(12, 16);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 14;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.HomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.BreadCumbEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.BreadCumbLeave);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.txtLastModified);
            this.pnlLeft.Controls.Add(this.lblLastModified);
            this.pnlLeft.Controls.Add(this.txtTimeOut);
            this.pnlLeft.Controls.Add(this.lblTimeOut);
            this.pnlLeft.Controls.Add(this.dtpDateEffect);
            this.pnlLeft.Controls.Add(this.lblDateEffect);
            this.pnlLeft.Controls.Add(this.txtDescription);
            this.pnlLeft.Controls.Add(this.lblDescription);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 44);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(259, 511);
            this.pnlLeft.TabIndex = 2;
            // 
            // txtLastModified
            // 
            this.txtLastModified.BackColor = System.Drawing.Color.White;
            this.txtLastModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastModified.Location = new System.Drawing.Point(12, 226);
            this.txtLastModified.Name = "txtLastModified";
            this.txtLastModified.ReadOnly = true;
            this.txtLastModified.Size = new System.Drawing.Size(224, 22);
            this.txtLastModified.TabIndex = 7;
            // 
            // lblLastModified
            // 
            this.lblLastModified.AutoSize = true;
            this.lblLastModified.Location = new System.Drawing.Point(9, 210);
            this.lblLastModified.Name = "lblLastModified";
            this.lblLastModified.Size = new System.Drawing.Size(77, 13);
            this.lblLastModified.TabIndex = 6;
            this.lblLastModified.Text = "Last Modified";
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.BackColor = System.Drawing.Color.White;
            this.txtTimeOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeOut.Location = new System.Drawing.Point(12, 175);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Size = new System.Drawing.Size(224, 22);
            this.txtTimeOut.TabIndex = 5;
            this.txtTimeOut.Validating += new System.ComponentModel.CancelEventHandler(this.TimeOutValidating);
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(9, 159);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(53, 13);
            this.lblTimeOut.TabIndex = 4;
            this.lblTimeOut.Text = "Time Out";
            // 
            // dtpDateEffect
            // 
            this.dtpDateEffect.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEffect.Location = new System.Drawing.Point(12, 124);
            this.dtpDateEffect.Name = "dtpDateEffect";
            this.dtpDateEffect.Size = new System.Drawing.Size(224, 22);
            this.dtpDateEffect.TabIndex = 3;
            // 
            // lblDateEffect
            // 
            this.lblDateEffect.AutoSize = true;
            this.lblDateEffect.Location = new System.Drawing.Point(9, 108);
            this.lblDateEffect.Name = "lblDateEffect";
            this.lblDateEffect.Size = new System.Drawing.Size(63, 13);
            this.lblDateEffect.TabIndex = 2;
            this.lblDateEffect.Text = "Date Effect";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(12, 73);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(224, 22);
            this.txtDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 57);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // gridList
            // 
            this.gridList.AllowUserToDeleteRows = false;
            this.gridList.AllowUserToResizeRows = false;
            this.gridList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridList.ColumnHeadersHeight = 25;
            this.gridList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colEffectDate,
            this.colTimeOut,
            this.colLastModified});
            this.gridList.EnableHeadersVisualStyles = false;
            this.gridList.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridList.Location = new System.Drawing.Point(262, 86);
            this.gridList.MultiSelect = false;
            this.gridList.Name = "gridList";
            this.gridList.RowHeadersVisible = false;
            this.gridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridList.Size = new System.Drawing.Size(780, 469);
            this.gridList.TabIndex = 3;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colEffectDate
            // 
            this.colEffectDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEffectDate.DataPropertyName = "EffectDate";
            this.colEffectDate.HeaderText = "Effect Date";
            this.colEffectDate.Name = "colEffectDate";
            this.colEffectDate.ReadOnly = true;
            // 
            // colTimeOut
            // 
            this.colTimeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTimeOut.DataPropertyName = "TimeOutString";
            this.colTimeOut.HeaderText = "Time Out";
            this.colTimeOut.Name = "colTimeOut";
            this.colTimeOut.ReadOnly = true;
            // 
            // colLastModified
            // 
            this.colLastModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastModified.DataPropertyName = "LastModified";
            this.colLastModified.HeaderText = "Last Modified";
            this.colLastModified.Name = "colLastModified";
            this.colLastModified.ReadOnly = true;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Mid Night",
            "Extended"});
            this.cmbType.Location = new System.Drawing.Point(345, 56);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(175, 21);
            this.cmbType.TabIndex = 4;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.SelectedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(573, 57);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(182, 22);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChanged);
            // 
            // dtpDateSearch
            // 
            this.dtpDateSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSearch.Location = new System.Drawing.Point(761, 57);
            this.dtpDateSearch.Name = "dtpDateSearch";
            this.dtpDateSearch.Size = new System.Drawing.Size(160, 22);
            this.dtpDateSearch.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(309, 63);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(30, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(526, 62);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 9;
            this.lblSearch.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(927, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search by Date";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.SearchClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(937, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 23);
            this.btnDelete.TabIndex = 8;
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
            this.btnUpdate.Location = new System.Drawing.Point(826, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 23);
            this.btnUpdate.TabIndex = 7;
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
            this.btnCreate.Location = new System.Drawing.Point(715, 10);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.CreateClick);
            // 
            // UsrCntrlMidNightExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpDateSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.gridList);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlMidNightExtended";
            this.Size = new System.Drawing.Size(1045, 555);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TextBox txtLastModified;
        private System.Windows.Forms.Label lblLastModified;
        private System.Windows.Forms.TextBox txtTimeOut;
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.DateTimePicker dtpDateEffect;
        private System.Windows.Forms.Label lblDateEffect;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DataGridView gridList;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DateTimePicker dtpDateSearch;
        private ModifiedControls.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastModified;
        private ModifiedControls.Button btnDelete;
        private ModifiedControls.Button btnUpdate;
        private ModifiedControls.Button btnCreate;
        private System.Windows.Forms.Label lblExtendedMidNight;
        private System.Windows.Forms.Label lblBreadcumbHome;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblSearch;
    }
}
