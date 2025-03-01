namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlEmployeeScheduleCreateUpdate
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
            this.pnlNavLeft = new System.Windows.Forms.Panel();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtBioId = new System.Windows.Forms.TextBox();
            this.lblBioId = new System.Windows.Forms.Label();
            this.cmbRestday = new System.Windows.Forms.ComboBox();
            this.lblRestday = new System.Windows.Forms.Label();
            this.cmbFloor = new System.Windows.Forms.ComboBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.dtpDateEffect = new System.Windows.Forms.DateTimePicker();
            this.lblDateEffect = new System.Windows.Forms.Label();
            this.pnlWrapper = new System.Windows.Forms.FlowLayoutPanel();
            this.lblBreadcumbSchedule = new System.Windows.Forms.Label();
            this.lblBreadcumbHome = new System.Windows.Forms.Label();
            this.ucMonday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucTuesday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucWednesday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucThursday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucFriday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucSaturday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.ucSunday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleCreateUpdate();
            this.btnGenerateId = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnSave = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlNavLeft.SuspendLayout();
            this.pnlWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblBreadcumbSchedule);
            this.pnlHeader.Controls.Add(this.lblBreadcumbHome);
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Controls.Add(this.btnSave);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(908, 44);
            this.pnlHeader.TabIndex = 2;
            // 
            // pnlNavLeft
            // 
            this.pnlNavLeft.Controls.Add(this.btnGenerateId);
            this.pnlNavLeft.Controls.Add(this.txtCreatedBy);
            this.pnlNavLeft.Controls.Add(this.lblCreatedBy);
            this.pnlNavLeft.Controls.Add(this.txtDateCreated);
            this.pnlNavLeft.Controls.Add(this.lblDateCreated);
            this.pnlNavLeft.Controls.Add(this.txtBioId);
            this.pnlNavLeft.Controls.Add(this.lblBioId);
            this.pnlNavLeft.Controls.Add(this.cmbRestday);
            this.pnlNavLeft.Controls.Add(this.lblRestday);
            this.pnlNavLeft.Controls.Add(this.cmbFloor);
            this.pnlNavLeft.Controls.Add(this.lblFloor);
            this.pnlNavLeft.Controls.Add(this.dtpDateEffect);
            this.pnlNavLeft.Controls.Add(this.lblDateEffect);
            this.pnlNavLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavLeft.Location = new System.Drawing.Point(0, 44);
            this.pnlNavLeft.Name = "pnlNavLeft";
            this.pnlNavLeft.Size = new System.Drawing.Size(246, 548);
            this.pnlNavLeft.TabIndex = 0;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreatedBy.Location = new System.Drawing.Point(10, 269);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(223, 22);
            this.txtCreatedBy.TabIndex = 5;
            this.txtCreatedBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreatedByKeyDown);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(10, 253);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(62, 13);
            this.lblCreatedBy.TabIndex = 21;
            this.lblCreatedBy.Text = "Created By";
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDateCreated.Location = new System.Drawing.Point(10, 222);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.ReadOnly = true;
            this.txtDateCreated.Size = new System.Drawing.Size(223, 22);
            this.txtDateCreated.TabIndex = 4;
            this.txtDateCreated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateCreatedKeyDown);
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(10, 206);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(74, 13);
            this.lblDateCreated.TabIndex = 19;
            this.lblDateCreated.Text = "Date Created";
            // 
            // txtBioId
            // 
            this.txtBioId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBioId.Location = new System.Drawing.Point(10, 176);
            this.txtBioId.Name = "txtBioId";
            this.txtBioId.ReadOnly = true;
            this.txtBioId.Size = new System.Drawing.Size(223, 22);
            this.txtBioId.TabIndex = 3;
            this.txtBioId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BioIdKeyDown);
            // 
            // lblBioId
            // 
            this.lblBioId.AutoSize = true;
            this.lblBioId.Location = new System.Drawing.Point(10, 160);
            this.lblBioId.Name = "lblBioId";
            this.lblBioId.Size = new System.Drawing.Size(37, 13);
            this.lblBioId.TabIndex = 17;
            this.lblBioId.Text = "Bio Id";
            // 
            // cmbRestday
            // 
            this.cmbRestday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRestday.FormattingEnabled = true;
            this.cmbRestday.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cmbRestday.Location = new System.Drawing.Point(10, 131);
            this.cmbRestday.Name = "cmbRestday";
            this.cmbRestday.Size = new System.Drawing.Size(223, 21);
            this.cmbRestday.TabIndex = 2;
            this.cmbRestday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RestdayKeyDown);
            // 
            // lblRestday
            // 
            this.lblRestday.AutoSize = true;
            this.lblRestday.Location = new System.Drawing.Point(10, 115);
            this.lblRestday.Name = "lblRestday";
            this.lblRestday.Size = new System.Drawing.Size(47, 13);
            this.lblRestday.TabIndex = 15;
            this.lblRestday.Text = "Restday";
            // 
            // cmbFloor
            // 
            this.cmbFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.Items.AddRange(new object[] {
            "First Floor",
            "Second Floor",
            "Third Floor",
            "Manila"});
            this.cmbFloor.Location = new System.Drawing.Point(10, 81);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Size = new System.Drawing.Size(223, 21);
            this.cmbFloor.TabIndex = 1;
            this.cmbFloor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FloorKeyDown);
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(10, 65);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(34, 13);
            this.lblFloor.TabIndex = 13;
            this.lblFloor.Text = "Floor";
            // 
            // dtpDateEffect
            // 
            this.dtpDateEffect.Location = new System.Drawing.Point(10, 32);
            this.dtpDateEffect.Name = "dtpDateEffect";
            this.dtpDateEffect.Size = new System.Drawing.Size(223, 22);
            this.dtpDateEffect.TabIndex = 0;
            this.dtpDateEffect.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateEffectKeyDown);
            // 
            // lblDateEffect
            // 
            this.lblDateEffect.AutoSize = true;
            this.lblDateEffect.Location = new System.Drawing.Point(10, 16);
            this.lblDateEffect.Name = "lblDateEffect";
            this.lblDateEffect.Size = new System.Drawing.Size(63, 13);
            this.lblDateEffect.TabIndex = 11;
            this.lblDateEffect.Text = "Date Effect";
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.AutoScroll = true;
            this.pnlWrapper.Controls.Add(this.ucMonday);
            this.pnlWrapper.Controls.Add(this.ucTuesday);
            this.pnlWrapper.Controls.Add(this.ucWednesday);
            this.pnlWrapper.Controls.Add(this.ucThursday);
            this.pnlWrapper.Controls.Add(this.ucFriday);
            this.pnlWrapper.Controls.Add(this.ucSaturday);
            this.pnlWrapper.Controls.Add(this.ucSunday);
            this.pnlWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrapper.Location = new System.Drawing.Point(246, 44);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(662, 548);
            this.pnlWrapper.TabIndex = 1;
            // 
            // lblBreadcumbSchedule
            // 
            this.lblBreadcumbSchedule.AutoSize = true;
            this.lblBreadcumbSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbSchedule.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbSchedule.Location = new System.Drawing.Point(62, 13);
            this.lblBreadcumbSchedule.Name = "lblBreadcumbSchedule";
            this.lblBreadcumbSchedule.Size = new System.Drawing.Size(70, 17);
            this.lblBreadcumbSchedule.TabIndex = 9;
            this.lblBreadcumbSchedule.Text = "/ DETAILS";
            this.lblBreadcumbSchedule.MouseEnter += new System.EventHandler(this.OnBreadcumbEnter);
            this.lblBreadcumbSchedule.MouseLeave += new System.EventHandler(this.OnBreadcumbLeave);
            // 
            // lblBreadcumbHome
            // 
            this.lblBreadcumbHome.AutoSize = true;
            this.lblBreadcumbHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBreadcumbHome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreadcumbHome.Location = new System.Drawing.Point(9, 13);
            this.lblBreadcumbHome.Name = "lblBreadcumbHome";
            this.lblBreadcumbHome.Size = new System.Drawing.Size(57, 17);
            this.lblBreadcumbHome.TabIndex = 8;
            this.lblBreadcumbHome.Text = "/ HOME";
            this.lblBreadcumbHome.Click += new System.EventHandler(this.HomeClick);
            this.lblBreadcumbHome.MouseEnter += new System.EventHandler(this.OnBreadcumbEnter);
            this.lblBreadcumbHome.MouseLeave += new System.EventHandler(this.OnBreadcumbLeave);
            // 
            // ucMonday
            // 
            this.ucMonday.BackColor = System.Drawing.Color.White;
            this.ucMonday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucMonday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMonday.HeaderText = "Monday";
            this.ucMonday.Location = new System.Drawing.Point(3, 3);
            this.ucMonday.Name = "ucMonday";
            this.ucMonday.Size = new System.Drawing.Size(270, 230);
            this.ucMonday.TabIndex = 0;
            this.ucMonday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucTuesday
            // 
            this.ucTuesday.BackColor = System.Drawing.Color.White;
            this.ucTuesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucTuesday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTuesday.HeaderText = "Tuesday";
            this.ucTuesday.Location = new System.Drawing.Point(279, 3);
            this.ucTuesday.Name = "ucTuesday";
            this.ucTuesday.Size = new System.Drawing.Size(270, 230);
            this.ucTuesday.TabIndex = 1;
            this.ucTuesday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucWednesday
            // 
            this.ucWednesday.BackColor = System.Drawing.Color.White;
            this.ucWednesday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucWednesday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucWednesday.HeaderText = "Wednesday";
            this.ucWednesday.Location = new System.Drawing.Point(3, 239);
            this.ucWednesday.Name = "ucWednesday";
            this.ucWednesday.Size = new System.Drawing.Size(270, 230);
            this.ucWednesday.TabIndex = 2;
            this.ucWednesday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucThursday
            // 
            this.ucThursday.BackColor = System.Drawing.Color.White;
            this.ucThursday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucThursday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucThursday.HeaderText = "Thursday";
            this.ucThursday.Location = new System.Drawing.Point(279, 239);
            this.ucThursday.Name = "ucThursday";
            this.ucThursday.Size = new System.Drawing.Size(270, 230);
            this.ucThursday.TabIndex = 3;
            this.ucThursday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucFriday
            // 
            this.ucFriday.BackColor = System.Drawing.Color.White;
            this.ucFriday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFriday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFriday.HeaderText = "Friday";
            this.ucFriday.Location = new System.Drawing.Point(3, 475);
            this.ucFriday.Name = "ucFriday";
            this.ucFriday.Size = new System.Drawing.Size(270, 230);
            this.ucFriday.TabIndex = 4;
            this.ucFriday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucSaturday
            // 
            this.ucSaturday.BackColor = System.Drawing.Color.White;
            this.ucSaturday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSaturday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSaturday.HeaderText = "Saturday";
            this.ucSaturday.Location = new System.Drawing.Point(279, 475);
            this.ucSaturday.Name = "ucSaturday";
            this.ucSaturday.Size = new System.Drawing.Size(270, 230);
            this.ucSaturday.TabIndex = 5;
            this.ucSaturday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // ucSunday
            // 
            this.ucSunday.BackColor = System.Drawing.Color.White;
            this.ucSunday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSunday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucSunday.HeaderText = "Sunday";
            this.ucSunday.Location = new System.Drawing.Point(3, 711);
            this.ucSunday.Name = "ucSunday";
            this.ucSunday.Size = new System.Drawing.Size(270, 230);
            this.ucSunday.TabIndex = 6;
            this.ucSunday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // btnGenerateId
            // 
            this.btnGenerateId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateId.Location = new System.Drawing.Point(10, 297);
            this.btnGenerateId.Name = "btnGenerateId";
            this.btnGenerateId.Size = new System.Drawing.Size(105, 23);
            this.btnGenerateId.TabIndex = 6;
            this.btnGenerateId.Text = "Generate Bio Id";
            this.btnGenerateId.UseVisualStyleBackColor = true;
            this.btnGenerateId.Click += new System.EventHandler(this.GenerateId);
            this.btnGenerateId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenerateIdKeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(800, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(689, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveClick);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // UsrCntrlEmployeeScheduleCreateUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWrapper);
            this.Controls.Add(this.pnlNavLeft);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlEmployeeScheduleCreateUpdate";
            this.Size = new System.Drawing.Size(908, 592);
            this.Load += new System.EventHandler(this.UCLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNavLeft.ResumeLayout(false);
            this.pnlNavLeft.PerformLayout();
            this.pnlWrapper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnCancel;
        private ModifiedControls.Button btnSave;
        private System.Windows.Forms.Panel pnlNavLeft;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.TextBox txtBioId;
        private System.Windows.Forms.Label lblBioId;
        private System.Windows.Forms.ComboBox cmbRestday;
        private System.Windows.Forms.Label lblRestday;
        private System.Windows.Forms.ComboBox cmbFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.DateTimePicker dtpDateEffect;
        private System.Windows.Forms.Label lblDateEffect;
        private System.Windows.Forms.FlowLayoutPanel pnlWrapper;
        private UsrCntrlScheduleCreateUpdate ucMonday;
        private UsrCntrlScheduleCreateUpdate ucTuesday;
        private UsrCntrlScheduleCreateUpdate ucWednesday;
        private UsrCntrlScheduleCreateUpdate ucThursday;
        private UsrCntrlScheduleCreateUpdate ucFriday;
        private UsrCntrlScheduleCreateUpdate ucSaturday;
        private UsrCntrlScheduleCreateUpdate ucSunday;
        private ModifiedControls.Button btnGenerateId;
        private System.Windows.Forms.Label lblBreadcumbSchedule;
        private System.Windows.Forms.Label lblBreadcumbHome;
    }
}
