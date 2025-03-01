namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlCasherCheckerSchedule
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
            this.lblBreadcumbSchedule = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.btnView = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnSettings = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnDiscard = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnPost = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnUpdate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCreate = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.gridList = new System.Windows.Forms.DataGridView();
            this.colTransactionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApprovedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsPosted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsCancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCancelledReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblBreadcumbSchedule);
            this.pnlHeader.Controls.Add(this.lblBreadcumbHome);
            this.pnlHeader.Controls.Add(this.btnView);
            this.pnlHeader.Controls.Add(this.btnSettings);
            this.pnlHeader.Controls.Add(this.btnDiscard);
            this.pnlHeader.Controls.Add(this.btnPost);
            this.pnlHeader.Controls.Add(this.btnUpdate);
            this.pnlHeader.Controls.Add(this.btnCreate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(979, 44);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblBreadcumbSchedule
            // 
            this.lblBreadcumbSchedule.AutoSize = true;
            this.lblBreadcumbSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbSchedule.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbSchedule.Location = new System.Drawing.Point(67, 20);
            this.lblBreadcumbSchedule.Name = "lblBreadcumbSchedule";
            this.lblBreadcumbSchedule.Size = new System.Drawing.Size(90, 17);
            this.lblBreadcumbSchedule.TabIndex = 7;
            this.lblBreadcumbSchedule.Text = "/ SCHEDULES";
            this.lblBreadcumbSchedule.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lblBreadcumbSchedule.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(14, 20);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 6;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.HomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(312, 11);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(105, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "VIEW";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.ViewClick);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(867, 11);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(105, 23);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.SettingsClick);
            // 
            // btnDiscard
            // 
            this.btnDiscard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscard.Enabled = false;
            this.btnDiscard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscard.Location = new System.Drawing.Point(645, 11);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(105, 23);
            this.btnDiscard.TabIndex = 3;
            this.btnDiscard.Text = "DISCARD";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.DiscardSchedule);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.Enabled = false;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPost.Location = new System.Drawing.Point(756, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(105, 23);
            this.btnPost.TabIndex = 2;
            this.btnPost.Text = "POST";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(534, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.UpdateClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(423, 11);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(105, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "CREATE";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.CreateClick);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 561);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(979, 40);
            this.pnlFooter.TabIndex = 5;
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
            this.colTransactionNo,
            this.colDateCreated,
            this.colDateEffect,
            this.colApprovedBy,
            this.colIsPosted,
            this.colIsCancelled,
            this.colCancelledReason,
            this.colCreatedBy,
            this.colLastModified});
            this.gridList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridList.EnableHeadersVisualStyles = false;
            this.gridList.Location = new System.Drawing.Point(3, 44);
            this.gridList.MultiSelect = false;
            this.gridList.Name = "gridList";
            this.gridList.RowHeadersVisible = false;
            this.gridList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridList.Size = new System.Drawing.Size(976, 517);
            this.gridList.TabIndex = 6;
            this.gridList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridListKeyDown);
            // 
            // colTransactionNo
            // 
            this.colTransactionNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTransactionNo.DataPropertyName = "TransactionNo";
            this.colTransactionNo.HeaderText = "Tranaction No";
            this.colTransactionNo.Name = "colTransactionNo";
            this.colTransactionNo.ReadOnly = true;
            // 
            // colDateCreated
            // 
            this.colDateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateCreated.DataPropertyName = "DateCreated";
            this.colDateCreated.HeaderText = "Date Created";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            // 
            // colDateEffect
            // 
            this.colDateEffect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateEffect.DataPropertyName = "DateEffect";
            this.colDateEffect.HeaderText = "Date Effect";
            this.colDateEffect.Name = "colDateEffect";
            this.colDateEffect.ReadOnly = true;
            // 
            // colApprovedBy
            // 
            this.colApprovedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colApprovedBy.DataPropertyName = "ApprovedBy";
            this.colApprovedBy.HeaderText = "Approved By";
            this.colApprovedBy.Name = "colApprovedBy";
            this.colApprovedBy.ReadOnly = true;
            // 
            // colIsPosted
            // 
            this.colIsPosted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsPosted.DataPropertyName = "IsPosted";
            this.colIsPosted.HeaderText = "Posted";
            this.colIsPosted.Name = "colIsPosted";
            this.colIsPosted.ReadOnly = true;
            this.colIsPosted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsPosted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsPosted.Width = 66;
            // 
            // colIsCancelled
            // 
            this.colIsCancelled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colIsCancelled.DataPropertyName = "IsCancelled";
            this.colIsCancelled.HeaderText = "Cancelled";
            this.colIsCancelled.Name = "colIsCancelled";
            this.colIsCancelled.ReadOnly = true;
            this.colIsCancelled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsCancelled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsCancelled.Width = 81;
            // 
            // colCancelledReason
            // 
            this.colCancelledReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCancelledReason.DataPropertyName = "CancelledReason";
            this.colCancelledReason.HeaderText = "Cancel Reason";
            this.colCancelledReason.Name = "colCancelledReason";
            this.colCancelledReason.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCreatedBy.DataPropertyName = "CreatedBy";
            this.colCreatedBy.HeaderText = "Created By";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // colLastModified
            // 
            this.colLastModified.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastModified.DataPropertyName = "LastModified";
            this.colLastModified.HeaderText = "Last Modified";
            this.colLastModified.Name = "colLastModified";
            this.colLastModified.ReadOnly = true;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.White;
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparator.Location = new System.Drawing.Point(0, 44);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(3, 517);
            this.pnlSeparator.TabIndex = 7;
            // 
            // UsrCntrlCasherCheckerSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridList);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlCasherCheckerSchedule";
            this.Size = new System.Drawing.Size(979, 601);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnSettings;
        private ModifiedControls.Button btnDiscard;
        private ModifiedControls.Button btnPost;
        private ModifiedControls.Button btnUpdate;
        private ModifiedControls.Button btnCreate;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView gridList;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransactionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApprovedBy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsPosted;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsCancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCancelledReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastModified;
        private ModifiedControls.Button btnView;
        private System.Windows.Forms.Label lblBreadcumbHome;
        private System.Windows.Forms.Label lblBreadcumbSchedule;
    }
}
