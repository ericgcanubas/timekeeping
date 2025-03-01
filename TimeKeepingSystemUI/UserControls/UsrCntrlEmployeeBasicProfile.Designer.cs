namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlEmployeeBasicProfile
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtBirthday = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblSeaction = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblIdNumber = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picEmployee = new System.Windows.Forms.PictureBox();
            this.gridSearchResult = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(3, 496);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(166, 82);
            this.txtAddress.TabIndex = 8;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressKeyDown);
            // 
            // txtBirthday
            // 
            this.txtBirthday.BackColor = System.Drawing.Color.White;
            this.txtBirthday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBirthday.Location = new System.Drawing.Point(3, 451);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.ReadOnly = true;
            this.txtBirthday.Size = new System.Drawing.Size(166, 22);
            this.txtBirthday.TabIndex = 7;
            this.txtBirthday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BirthdayKeyDown);
            // 
            // txtDepartment
            // 
            this.txtDepartment.BackColor = System.Drawing.Color.White;
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.Location = new System.Drawing.Point(3, 406);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(166, 22);
            this.txtDepartment.TabIndex = 6;
            this.txtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmentKeyDown);
            // 
            // txtSection
            // 
            this.txtSection.BackColor = System.Drawing.Color.White;
            this.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSection.Location = new System.Drawing.Point(3, 361);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(166, 22);
            this.txtSection.TabIndex = 5;
            this.txtSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SectionKeyDown);
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.Color.White;
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Location = new System.Drawing.Point(3, 316);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(166, 22);
            this.txtPosition.TabIndex = 4;
            this.txtPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PositionKeyDown);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(3, 271);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(166, 22);
            this.txtName.TabIndex = 3;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameKeyDown);
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.BackColor = System.Drawing.Color.White;
            this.txtIdNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdNumber.Location = new System.Drawing.Point(3, 226);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.ReadOnly = true;
            this.txtIdNumber.Size = new System.Drawing.Size(166, 22);
            this.txtIdNumber.TabIndex = 2;
            this.txtIdNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IdNumberKeyDown);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(5, 480);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 27;
            this.lblAddress.Text = "Address";
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthday.ForeColor = System.Drawing.Color.Black;
            this.lblBirthday.Location = new System.Drawing.Point(3, 435);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(50, 13);
            this.lblBirthday.TabIndex = 26;
            this.lblBirthday.Text = "Birthday";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Black;
            this.lblDepartment.Location = new System.Drawing.Point(3, 390);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(68, 13);
            this.lblDepartment.TabIndex = 25;
            this.lblDepartment.Text = "Department";
            // 
            // lblSeaction
            // 
            this.lblSeaction.AutoSize = true;
            this.lblSeaction.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeaction.ForeColor = System.Drawing.Color.Black;
            this.lblSeaction.Location = new System.Drawing.Point(3, 345);
            this.lblSeaction.Name = "lblSeaction";
            this.lblSeaction.Size = new System.Drawing.Size(44, 13);
            this.lblSeaction.TabIndex = 24;
            this.lblSeaction.Text = "Section";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.Black;
            this.lblPosition.Location = new System.Drawing.Point(3, 300);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(48, 13);
            this.lblPosition.TabIndex = 23;
            this.lblPosition.Text = "Position";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(3, 255);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 13);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "Name";
            // 
            // lblIdNumber
            // 
            this.lblIdNumber.AutoSize = true;
            this.lblIdNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdNumber.ForeColor = System.Drawing.Color.Black;
            this.lblIdNumber.Location = new System.Drawing.Point(1, 210);
            this.lblIdNumber.Name = "lblIdNumber";
            this.lblIdNumber.Size = new System.Drawing.Size(62, 13);
            this.lblIdNumber.TabIndex = 21;
            this.lblIdNumber.Text = "ID Number";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.ForeColor = System.Drawing.Color.Black;
            this.chkIsActive.Location = new System.Drawing.Point(4, 5);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(90, 17);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Search Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.CheckStatusChanged);
            this.chkIsActive.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IsActiveKeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(4, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchChange);
            this.txtSearch.Enter += new System.EventHandler(this.SearchEnter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKey);
            this.txtSearch.Leave += new System.EventHandler(this.SearchLeave);
            // 
            // picEmployee
            // 
            this.picEmployee.Location = new System.Drawing.Point(3, 56);
            this.picEmployee.Name = "picEmployee";
            this.picEmployee.Size = new System.Drawing.Size(166, 147);
            this.picEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmployee.TabIndex = 18;
            this.picEmployee.TabStop = false;
            // 
            // gridSearchResult
            // 
            this.gridSearchResult.AllowUserToAddRows = false;
            this.gridSearchResult.AllowUserToDeleteRows = false;
            this.gridSearchResult.AllowUserToResizeRows = false;
            this.gridSearchResult.BackgroundColor = System.Drawing.Color.White;
            this.gridSearchResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridSearchResult.ColumnHeadersHeight = 24;
            this.gridSearchResult.ColumnHeadersVisible = false;
            this.gridSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFullname});
            this.gridSearchResult.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridSearchResult.Location = new System.Drawing.Point(4, 49);
            this.gridSearchResult.MultiSelect = false;
            this.gridSearchResult.Name = "gridSearchResult";
            this.gridSearchResult.RowHeadersVisible = false;
            this.gridSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSearchResult.Size = new System.Drawing.Size(165, 150);
            this.gridSearchResult.TabIndex = 1;
            this.gridSearchResult.Visible = false;
            this.gridSearchResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GridSearchResultKey);
            this.gridSearchResult.Leave += new System.EventHandler(this.GridSearchResultLeave);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colFullname
            // 
            this.colFullname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFullname.DataPropertyName = "Fullname";
            this.colFullname.HeaderText = "Full Name";
            this.colFullname.Name = "colFullname";
            // 
            // UsrCntrlEmployeeBasicProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gridSearchResult);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtBirthday);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtIdNumber);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblBirthday);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblSeaction);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblIdNumber);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.picEmployee);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "UsrCntrlEmployeeBasicProfile";
            this.Size = new System.Drawing.Size(180, 599);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.picEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSearchResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtBirthday;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblSeaction;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox picEmployee;
        private System.Windows.Forms.DataGridView gridSearchResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullname;

    }
}
