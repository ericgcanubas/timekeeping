namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlUsersDetails
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
            this.btnCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnSave = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtRetypePassword = new System.Windows.Forms.TextBox();
            this.lblReTypePassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.gridUserRoles = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCanView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanCreate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanPost = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanUnpost = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCanGenerateReport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Controls.Add(this.btnSave);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(843, 44);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(727, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(616, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.txtRetypePassword);
            this.pnlLeft.Controls.Add(this.lblReTypePassword);
            this.pnlLeft.Controls.Add(this.txtPassword);
            this.pnlLeft.Controls.Add(this.lblPassword);
            this.pnlLeft.Controls.Add(this.txtUsername);
            this.pnlLeft.Controls.Add(this.lblUsername);
            this.pnlLeft.Controls.Add(this.txtLastname);
            this.pnlLeft.Controls.Add(this.lblLastname);
            this.pnlLeft.Controls.Add(this.txtMiddleName);
            this.pnlLeft.Controls.Add(this.lblMiddleName);
            this.pnlLeft.Controls.Add(this.txtFirstname);
            this.pnlLeft.Controls.Add(this.lblFirstname);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 44);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(236, 481);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetypePassword.Location = new System.Drawing.Point(20, 284);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.Size = new System.Drawing.Size(193, 22);
            this.txtRetypePassword.TabIndex = 6;
            this.txtRetypePassword.UseSystemPasswordChar = true;
            // 
            // lblReTypePassword
            // 
            this.lblReTypePassword.AutoSize = true;
            this.lblReTypePassword.Location = new System.Drawing.Point(17, 268);
            this.lblReTypePassword.Name = "lblReTypePassword";
            this.lblReTypePassword.Size = new System.Drawing.Size(94, 13);
            this.lblReTypePassword.TabIndex = 10;
            this.lblReTypePassword.Text = "Retype Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(20, 239);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(193, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(17, 223);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(20, 194);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(193, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(17, 178);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "Username";
            // 
            // txtLastname
            // 
            this.txtLastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastname.Location = new System.Drawing.Point(20, 148);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(193, 22);
            this.txtLastname.TabIndex = 3;
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(17, 132);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(59, 13);
            this.lblLastname.TabIndex = 4;
            this.lblLastname.Text = "Last Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Location = new System.Drawing.Point(20, 103);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(193, 22);
            this.txtMiddleName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(17, 87);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(75, 13);
            this.lblMiddleName.TabIndex = 2;
            this.lblMiddleName.Text = "Middle Name";
            // 
            // txtFirstname
            // 
            this.txtFirstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstname.Location = new System.Drawing.Point(20, 59);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(193, 22);
            this.txtFirstname.TabIndex = 1;
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Location = new System.Drawing.Point(17, 43);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(61, 13);
            this.lblFirstname.TabIndex = 0;
            this.lblFirstname.Text = "First Name";
            // 
            // gridUserRoles
            // 
            this.gridUserRoles.AllowUserToAddRows = false;
            this.gridUserRoles.AllowUserToDeleteRows = false;
            this.gridUserRoles.AllowUserToResizeRows = false;
            this.gridUserRoles.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridUserRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridUserRoles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridUserRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colRoleName,
            this.colCanView,
            this.colCanCreate,
            this.colCanUpdate,
            this.colCanDelete,
            this.colCanPost,
            this.colCanUnpost,
            this.colCanGenerateReport,
            this.colUserId});
            this.gridUserRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUserRoles.EnableHeadersVisualStyles = false;
            this.gridUserRoles.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridUserRoles.Location = new System.Drawing.Point(236, 44);
            this.gridUserRoles.MultiSelect = false;
            this.gridUserRoles.Name = "gridUserRoles";
            this.gridUserRoles.RowHeadersVisible = false;
            this.gridUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUserRoles.Size = new System.Drawing.Size(607, 481);
            this.gridUserRoles.TabIndex = 2;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "RoleId";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colRoleName
            // 
            this.colRoleName.DataPropertyName = "Name";
            this.colRoleName.HeaderText = "Role Name";
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            this.colRoleName.Width = 200;
            // 
            // colCanView
            // 
            this.colCanView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanView.DataPropertyName = "CanView";
            this.colCanView.HeaderText = "Can View";
            this.colCanView.Name = "colCanView";
            this.colCanView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanCreate
            // 
            this.colCanCreate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanCreate.DataPropertyName = "CanCreate";
            this.colCanCreate.HeaderText = "Can Create";
            this.colCanCreate.Name = "colCanCreate";
            this.colCanCreate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanCreate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanUpdate
            // 
            this.colCanUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanUpdate.DataPropertyName = "CanUpdate";
            this.colCanUpdate.HeaderText = "Can Update";
            this.colCanUpdate.Name = "colCanUpdate";
            this.colCanUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanDelete
            // 
            this.colCanDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanDelete.DataPropertyName = "CanDelete";
            this.colCanDelete.HeaderText = "Can Delete";
            this.colCanDelete.Name = "colCanDelete";
            this.colCanDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanPost
            // 
            this.colCanPost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanPost.DataPropertyName = "CanPost";
            this.colCanPost.HeaderText = "Can Post";
            this.colCanPost.Name = "colCanPost";
            this.colCanPost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanPost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanUnpost
            // 
            this.colCanUnpost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanUnpost.DataPropertyName = "CanUnPost";
            this.colCanUnpost.HeaderText = "Can Unpost";
            this.colCanUnpost.Name = "colCanUnpost";
            this.colCanUnpost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanUnpost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colCanGenerateReport
            // 
            this.colCanGenerateReport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCanGenerateReport.DataPropertyName = "CanGenerateReport";
            this.colCanGenerateReport.HeaderText = "Can Generate Report";
            this.colCanGenerateReport.Name = "colCanGenerateReport";
            this.colCanGenerateReport.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCanGenerateReport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colUserId
            // 
            this.colUserId.DataPropertyName = "UserId";
            this.colUserId.HeaderText = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = false;
            // 
            // UsrCntrlUsersDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gridUserRoles);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlUsersDetails";
            this.Size = new System.Drawing.Size(843, 525);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUserRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnCancel;
        private ModifiedControls.Button btnSave;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.DataGridView gridUserRoles;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.TextBox txtRetypePassword;
        private System.Windows.Forms.Label lblReTypePassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanCreate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanUpdate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanPost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanUnpost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCanGenerateReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserId;
    }
}
