namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlEmployeeSchedule
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
            this.btnUpdateSchedule = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCreateSchedule = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlScheduleDetails = new System.Windows.Forms.Panel();
            this.txtLastModified = new System.Windows.Forms.TextBox();
            this.lblLastModified = new System.Windows.Forms.Label();
            this.txtRestday = new System.Windows.Forms.TextBox();
            this.lblRestday = new System.Windows.Forms.Label();
            this.txtBioId = new System.Windows.Forms.TextBox();
            this.lblBioId = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.txtEffectDate = new System.Windows.Forms.TextBox();
            this.lblEffectiveDate = new System.Windows.Forms.Label();
            this.flowPanelSchedules = new System.Windows.Forms.FlowLayoutPanel();
            this.gbHistory = new System.Windows.Forms.GroupBox();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.colDateEffect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucScheduleMonday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleTuesday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleWednesday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleThursday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleFriday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleSaturday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucScheduleSunday = new TimeKeepingSystemUI.UserControls.UsrCntrlScheduleView();
            this.ucBasicEmployeeProfile = new TimeKeepingSystemUI.UserControls.UsrCntrlEmployeeBasicProfile();
            this.pnlHeader.SuspendLayout();
            this.pnlScheduleDetails.SuspendLayout();
            this.flowPanelSchedules.SuspendLayout();
            this.gbHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnUpdateSchedule);
            this.pnlHeader.Controls.Add(this.btnCreateSchedule);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(935, 44);
            this.pnlHeader.TabIndex = 3;
            // 
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSchedule.Location = new System.Drawing.Point(827, 11);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateSchedule.TabIndex = 1;
            this.btnUpdateSchedule.Text = "UPDATE";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            this.btnUpdateSchedule.Click += new System.EventHandler(this.UpdateClick);
            this.btnUpdateSchedule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSchedule.Location = new System.Drawing.Point(716, 11);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(105, 23);
            this.btnCreateSchedule.TabIndex = 0;
            this.btnCreateSchedule.Text = "CREATE";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.CreateClick);
            this.btnCreateSchedule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // pnlScheduleDetails
            // 
            this.pnlScheduleDetails.AutoScroll = true;
            this.pnlScheduleDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlScheduleDetails.Controls.Add(this.txtLastModified);
            this.pnlScheduleDetails.Controls.Add(this.lblLastModified);
            this.pnlScheduleDetails.Controls.Add(this.txtRestday);
            this.pnlScheduleDetails.Controls.Add(this.lblRestday);
            this.pnlScheduleDetails.Controls.Add(this.txtBioId);
            this.pnlScheduleDetails.Controls.Add(this.lblBioId);
            this.pnlScheduleDetails.Controls.Add(this.txtFloor);
            this.pnlScheduleDetails.Controls.Add(this.lblFloor);
            this.pnlScheduleDetails.Controls.Add(this.txtEffectDate);
            this.pnlScheduleDetails.Controls.Add(this.lblEffectiveDate);
            this.pnlScheduleDetails.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlScheduleDetails.Location = new System.Drawing.Point(760, 44);
            this.pnlScheduleDetails.Name = "pnlScheduleDetails";
            this.pnlScheduleDetails.Size = new System.Drawing.Size(175, 496);
            this.pnlScheduleDetails.TabIndex = 2;
            // 
            // txtLastModified
            // 
            this.txtLastModified.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastModified.Location = new System.Drawing.Point(9, 208);
            this.txtLastModified.Name = "txtLastModified";
            this.txtLastModified.ReadOnly = true;
            this.txtLastModified.Size = new System.Drawing.Size(153, 22);
            this.txtLastModified.TabIndex = 13;
            this.txtLastModified.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastModifiedKeyEvent);
            // 
            // lblLastModified
            // 
            this.lblLastModified.AutoSize = true;
            this.lblLastModified.Location = new System.Drawing.Point(6, 192);
            this.lblLastModified.Name = "lblLastModified";
            this.lblLastModified.Size = new System.Drawing.Size(77, 13);
            this.lblLastModified.TabIndex = 12;
            this.lblLastModified.Text = "Last Modified";
            // 
            // txtRestday
            // 
            this.txtRestday.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRestday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRestday.Location = new System.Drawing.Point(9, 163);
            this.txtRestday.Name = "txtRestday";
            this.txtRestday.ReadOnly = true;
            this.txtRestday.Size = new System.Drawing.Size(153, 22);
            this.txtRestday.TabIndex = 7;
            this.txtRestday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RestdayKeyDown);
            // 
            // lblRestday
            // 
            this.lblRestday.AutoSize = true;
            this.lblRestday.Location = new System.Drawing.Point(6, 147);
            this.lblRestday.Name = "lblRestday";
            this.lblRestday.Size = new System.Drawing.Size(47, 13);
            this.lblRestday.TabIndex = 6;
            this.lblRestday.Text = "Restday";
            // 
            // txtBioId
            // 
            this.txtBioId.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBioId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBioId.Location = new System.Drawing.Point(9, 119);
            this.txtBioId.Name = "txtBioId";
            this.txtBioId.ReadOnly = true;
            this.txtBioId.Size = new System.Drawing.Size(153, 22);
            this.txtBioId.TabIndex = 5;
            this.txtBioId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BioIdKeyEvent);
            // 
            // lblBioId
            // 
            this.lblBioId.AutoSize = true;
            this.lblBioId.Location = new System.Drawing.Point(6, 103);
            this.lblBioId.Name = "lblBioId";
            this.lblBioId.Size = new System.Drawing.Size(37, 13);
            this.lblBioId.TabIndex = 4;
            this.lblBioId.Text = "Bio Id";
            // 
            // txtFloor
            // 
            this.txtFloor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFloor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFloor.Location = new System.Drawing.Point(9, 77);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.ReadOnly = true;
            this.txtFloor.Size = new System.Drawing.Size(153, 22);
            this.txtFloor.TabIndex = 3;
            this.txtFloor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FloorKeyEvent);
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(6, 61);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(34, 13);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "Floor";
            // 
            // txtEffectDate
            // 
            this.txtEffectDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEffectDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEffectDate.Location = new System.Drawing.Point(9, 35);
            this.txtEffectDate.Name = "txtEffectDate";
            this.txtEffectDate.ReadOnly = true;
            this.txtEffectDate.Size = new System.Drawing.Size(153, 22);
            this.txtEffectDate.TabIndex = 1;
            this.txtEffectDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EffectDateKeyDow);
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.AutoSize = true;
            this.lblEffectiveDate.Location = new System.Drawing.Point(6, 19);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(77, 13);
            this.lblEffectiveDate.TabIndex = 0;
            this.lblEffectiveDate.Text = "Effective Date";
            // 
            // flowPanelSchedules
            // 
            this.flowPanelSchedules.AutoScroll = true;
            this.flowPanelSchedules.Controls.Add(this.gbHistory);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleMonday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleTuesday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleWednesday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleThursday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleFriday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleSaturday);
            this.flowPanelSchedules.Controls.Add(this.ucScheduleSunday);
            this.flowPanelSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelSchedules.Location = new System.Drawing.Point(188, 44);
            this.flowPanelSchedules.Margin = new System.Windows.Forms.Padding(0);
            this.flowPanelSchedules.Name = "flowPanelSchedules";
            this.flowPanelSchedules.Size = new System.Drawing.Size(572, 496);
            this.flowPanelSchedules.TabIndex = 1;
            // 
            // gbHistory
            // 
            this.gbHistory.Controls.Add(this.gridHistory);
            this.gbHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHistory.Location = new System.Drawing.Point(3, 3);
            this.gbHistory.Name = "gbHistory";
            this.gbHistory.Size = new System.Drawing.Size(200, 199);
            this.gbHistory.TabIndex = 0;
            this.gbHistory.TabStop = false;
            this.gbHistory.Text = "Schedule History";
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AllowUserToResizeRows = false;
            this.gridHistory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gridHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridHistory.ColumnHeadersHeight = 25;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateEffect,
            this.colAdded});
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.EnableHeadersVisualStyles = false;
            this.gridHistory.GridColor = System.Drawing.Color.WhiteSmoke;
            this.gridHistory.Location = new System.Drawing.Point(3, 18);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(194, 178);
            this.gridHistory.TabIndex = 0;
            this.gridHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // colDateEffect
            // 
            this.colDateEffect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDateEffect.DataPropertyName = "EffectDate";
            this.colDateEffect.HeaderText = "Date Effect";
            this.colDateEffect.Name = "colDateEffect";
            this.colDateEffect.ReadOnly = true;
            // 
            // colAdded
            // 
            this.colAdded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAdded.DataPropertyName = "CreatedBy";
            this.colAdded.HeaderText = "Added By";
            this.colAdded.Name = "colAdded";
            this.colAdded.ReadOnly = true;
            // 
            // ucScheduleMonday
            // 
            this.ucScheduleMonday.HeaderText = "Monday";
            this.ucScheduleMonday.Location = new System.Drawing.Point(209, 3);
            this.ucScheduleMonday.Name = "ucScheduleMonday";
            this.ucScheduleMonday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleMonday.TabIndex = 1;
            // 
            // ucScheduleTuesday
            // 
            this.ucScheduleTuesday.HeaderText = "Tuesday";
            this.ucScheduleTuesday.Location = new System.Drawing.Point(3, 208);
            this.ucScheduleTuesday.Name = "ucScheduleTuesday";
            this.ucScheduleTuesday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleTuesday.TabIndex = 2;
            // 
            // ucScheduleWednesday
            // 
            this.ucScheduleWednesday.HeaderText = "Wednesday";
            this.ucScheduleWednesday.Location = new System.Drawing.Point(209, 208);
            this.ucScheduleWednesday.Name = "ucScheduleWednesday";
            this.ucScheduleWednesday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleWednesday.TabIndex = 3;
            // 
            // ucScheduleThursday
            // 
            this.ucScheduleThursday.HeaderText = "Thursday";
            this.ucScheduleThursday.Location = new System.Drawing.Point(3, 413);
            this.ucScheduleThursday.Name = "ucScheduleThursday";
            this.ucScheduleThursday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleThursday.TabIndex = 4;
            // 
            // ucScheduleFriday
            // 
            this.ucScheduleFriday.HeaderText = "Friday";
            this.ucScheduleFriday.Location = new System.Drawing.Point(209, 413);
            this.ucScheduleFriday.Name = "ucScheduleFriday";
            this.ucScheduleFriday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleFriday.TabIndex = 5;
            // 
            // ucScheduleSaturday
            // 
            this.ucScheduleSaturday.HeaderText = "Saturday";
            this.ucScheduleSaturday.Location = new System.Drawing.Point(3, 618);
            this.ucScheduleSaturday.Name = "ucScheduleSaturday";
            this.ucScheduleSaturday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleSaturday.TabIndex = 6;
            // 
            // ucScheduleSunday
            // 
            this.ucScheduleSunday.HeaderText = "Sunday";
            this.ucScheduleSunday.Location = new System.Drawing.Point(209, 618);
            this.ucScheduleSunday.Name = "ucScheduleSunday";
            this.ucScheduleSunday.Size = new System.Drawing.Size(200, 199);
            this.ucScheduleSunday.TabIndex = 7;
            // 
            // ucBasicEmployeeProfile
            // 
            this.ucBasicEmployeeProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBasicEmployeeProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBasicEmployeeProfile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBasicEmployeeProfile.ForeColor = System.Drawing.Color.Black;
            this.ucBasicEmployeeProfile.Location = new System.Drawing.Point(0, 44);
            this.ucBasicEmployeeProfile.Margin = new System.Windows.Forms.Padding(3, 3, 500, 3);
            this.ucBasicEmployeeProfile.Name = "ucBasicEmployeeProfile";
            this.ucBasicEmployeeProfile.Size = new System.Drawing.Size(188, 496);
            this.ucBasicEmployeeProfile.TabIndex = 0;
            this.ucBasicEmployeeProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            // 
            // UsrCntrlEmployeeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowPanelSchedules);
            this.Controls.Add(this.ucBasicEmployeeProfile);
            this.Controls.Add(this.pnlScheduleDetails);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlEmployeeSchedule";
            this.Size = new System.Drawing.Size(935, 540);
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlScheduleDetails.ResumeLayout(false);
            this.pnlScheduleDetails.PerformLayout();
            this.flowPanelSchedules.ResumeLayout(false);
            this.gbHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnUpdateSchedule;
        private ModifiedControls.Button btnCreateSchedule;
        private System.Windows.Forms.Panel pnlScheduleDetails;
        private System.Windows.Forms.FlowLayoutPanel flowPanelSchedules;
        private UsrCntrlEmployeeBasicProfile ucBasicEmployeeProfile;
        private System.Windows.Forms.GroupBox gbHistory;
        private UsrCntrlScheduleView ucScheduleMonday;
        private UsrCntrlScheduleView ucScheduleTuesday;
        private UsrCntrlScheduleView ucScheduleWednesday;
        private UsrCntrlScheduleView ucScheduleThursday;
        private UsrCntrlScheduleView ucScheduleFriday;
        private UsrCntrlScheduleView ucScheduleSaturday;
        private UsrCntrlScheduleView ucScheduleSunday;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateEffect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAdded;
        private System.Windows.Forms.TextBox txtEffectDate;
        private System.Windows.Forms.Label lblEffectiveDate;
        private System.Windows.Forms.TextBox txtRestday;
        private System.Windows.Forms.Label lblRestday;
        private System.Windows.Forms.TextBox txtBioId;
        private System.Windows.Forms.Label lblBioId;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtLastModified;
        private System.Windows.Forms.Label lblLastModified;

    }
}
