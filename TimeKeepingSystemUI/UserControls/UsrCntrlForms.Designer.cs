namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlForms
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
            this.lblAction = new System.Windows.Forms.Label();
            this.tabForms = new TimeKeepingSystemUI.ModifiedControls.TabControl();
            this.tpLeaveUndertime = new System.Windows.Forms.TabPage();
            this.ucLeaveUndertime = new TimeKeepingSystemUI.UserControls.UsrCntrlLeaveUndertime();
            this.tpChangeRestday = new System.Windows.Forms.TabPage();
            this.ucChangeRestday = new TimeKeepingSystemUI.UserControls.UsrCntrlChangeRestday();
            this.tpPRW = new System.Windows.Forms.TabPage();
            this.ucPRW = new TimeKeepingSystemUI.UserControls.UsrCntrlPRW();
            this.tpChangeShift = new System.Windows.Forms.TabPage();
            this.ucChangeShift = new TimeKeepingSystemUI.UserControls.UsrCntrlChangeShift();
            this.tabWholeDayChangeShift = new System.Windows.Forms.TabPage();
            this.usrCntrlChangeShiftWholeDay1 = new TimeKeepingSystemUI.UserControls.UsrCntrlChangeShiftWholeDay();
            this.ucBasicProfileEmployee = new TimeKeepingSystemUI.UserControls.UsrCntrlEmployeeBasicProfile();
            this.btnPrint = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnPost = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnUpdateSchedule = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCreateSchedule = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlHeader.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.tpLeaveUndertime.SuspendLayout();
            this.tpChangeRestday.SuspendLayout();
            this.tpPRW.SuspendLayout();
            this.tpChangeShift.SuspendLayout();
            this.tabWholeDayChangeShift.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblAction);
            this.pnlHeader.Controls.Add(this.btnPrint);
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Controls.Add(this.btnPost);
            this.pnlHeader.Controls.Add(this.btnUpdateSchedule);
            this.pnlHeader.Controls.Add(this.btnCreateSchedule);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1058, 44);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(9, 5);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(249, 30);
            this.lblAction.TabIndex = 3;
            this.lblAction.Text = "Create Leave/Undertime";
            // 
            // tabForms
            // 
            this.tabForms.Controls.Add(this.tpLeaveUndertime);
            this.tabForms.Controls.Add(this.tpChangeRestday);
            this.tabForms.Controls.Add(this.tpPRW);
            this.tabForms.Controls.Add(this.tpChangeShift);
            this.tabForms.Controls.Add(this.tabWholeDayChangeShift);
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForms.ItemSize = new System.Drawing.Size(120, 30);
            this.tabForms.Location = new System.Drawing.Point(183, 44);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(875, 549);
            this.tabForms.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabForms.TabIndex = 1;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.TabFormSelectedIndexChanged);
            this.tabForms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // tpLeaveUndertime
            // 
            this.tpLeaveUndertime.Controls.Add(this.ucLeaveUndertime);
            this.tpLeaveUndertime.ForeColor = System.Drawing.Color.Black;
            this.tpLeaveUndertime.Location = new System.Drawing.Point(4, 34);
            this.tpLeaveUndertime.Name = "tpLeaveUndertime";
            this.tpLeaveUndertime.Padding = new System.Windows.Forms.Padding(3);
            this.tpLeaveUndertime.Size = new System.Drawing.Size(867, 511);
            this.tpLeaveUndertime.TabIndex = 0;
            this.tpLeaveUndertime.Text = "Leave/Undertime";
            this.tpLeaveUndertime.UseVisualStyleBackColor = true;
            // 
            // ucLeaveUndertime
            // 
            this.ucLeaveUndertime.BackColor = System.Drawing.Color.White;
            this.ucLeaveUndertime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLeaveUndertime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLeaveUndertime.Location = new System.Drawing.Point(3, 3);
            this.ucLeaveUndertime.Name = "ucLeaveUndertime";
            this.ucLeaveUndertime.Size = new System.Drawing.Size(861, 505);
            this.ucLeaveUndertime.TabIndex = 0;
            this.ucLeaveUndertime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // tpChangeRestday
            // 
            this.tpChangeRestday.Controls.Add(this.ucChangeRestday);
            this.tpChangeRestday.Location = new System.Drawing.Point(4, 34);
            this.tpChangeRestday.Name = "tpChangeRestday";
            this.tpChangeRestday.Padding = new System.Windows.Forms.Padding(3);
            this.tpChangeRestday.Size = new System.Drawing.Size(867, 511);
            this.tpChangeRestday.TabIndex = 1;
            this.tpChangeRestday.Text = "Change Restday";
            this.tpChangeRestday.UseVisualStyleBackColor = true;
            // 
            // ucChangeRestday
            // 
            this.ucChangeRestday.BackColor = System.Drawing.Color.White;
            this.ucChangeRestday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChangeRestday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChangeRestday.Location = new System.Drawing.Point(3, 3);
            this.ucChangeRestday.Name = "ucChangeRestday";
            this.ucChangeRestday.Size = new System.Drawing.Size(861, 505);
            this.ucChangeRestday.TabIndex = 0;
            this.ucChangeRestday.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // tpPRW
            // 
            this.tpPRW.Controls.Add(this.ucPRW);
            this.tpPRW.Location = new System.Drawing.Point(4, 34);
            this.tpPRW.Name = "tpPRW";
            this.tpPRW.Padding = new System.Windows.Forms.Padding(3);
            this.tpPRW.Size = new System.Drawing.Size(867, 511);
            this.tpPRW.TabIndex = 2;
            this.tpPRW.Text = "PRW";
            this.tpPRW.UseVisualStyleBackColor = true;
            // 
            // ucPRW
            // 
            this.ucPRW.BackColor = System.Drawing.Color.White;
            this.ucPRW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPRW.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPRW.Location = new System.Drawing.Point(3, 3);
            this.ucPRW.Name = "ucPRW";
            this.ucPRW.Size = new System.Drawing.Size(861, 505);
            this.ucPRW.TabIndex = 0;
            this.ucPRW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // tpChangeShift
            // 
            this.tpChangeShift.Controls.Add(this.ucChangeShift);
            this.tpChangeShift.Location = new System.Drawing.Point(4, 34);
            this.tpChangeShift.Name = "tpChangeShift";
            this.tpChangeShift.Padding = new System.Windows.Forms.Padding(3);
            this.tpChangeShift.Size = new System.Drawing.Size(867, 511);
            this.tpChangeShift.TabIndex = 3;
            this.tpChangeShift.Text = "Change Shift";
            this.tpChangeShift.UseVisualStyleBackColor = true;
            // 
            // ucChangeShift
            // 
            this.ucChangeShift.BackColor = System.Drawing.Color.White;
            this.ucChangeShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucChangeShift.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucChangeShift.Location = new System.Drawing.Point(3, 3);
            this.ucChangeShift.Name = "ucChangeShift";
            this.ucChangeShift.Size = new System.Drawing.Size(861, 505);
            this.ucChangeShift.TabIndex = 0;
            // 
            // tabWholeDayChangeShift
            // 
            this.tabWholeDayChangeShift.Controls.Add(this.usrCntrlChangeShiftWholeDay1);
            this.tabWholeDayChangeShift.Location = new System.Drawing.Point(4, 34);
            this.tabWholeDayChangeShift.Name = "tabWholeDayChangeShift";
            this.tabWholeDayChangeShift.Padding = new System.Windows.Forms.Padding(3);
            this.tabWholeDayChangeShift.Size = new System.Drawing.Size(867, 511);
            this.tabWholeDayChangeShift.TabIndex = 4;
            this.tabWholeDayChangeShift.Text = "Change Shift (WD)";
            this.tabWholeDayChangeShift.UseVisualStyleBackColor = true;
            // 
            // usrCntrlChangeShiftWholeDay1
            // 
            this.usrCntrlChangeShiftWholeDay1.BackColor = System.Drawing.Color.White;
            this.usrCntrlChangeShiftWholeDay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrCntrlChangeShiftWholeDay1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlChangeShiftWholeDay1.Location = new System.Drawing.Point(3, 3);
            this.usrCntrlChangeShiftWholeDay1.Name = "usrCntrlChangeShiftWholeDay1";
            this.usrCntrlChangeShiftWholeDay1.Size = new System.Drawing.Size(861, 505);
            this.usrCntrlChangeShiftWholeDay1.TabIndex = 0;
            // 
            // ucBasicProfileEmployee
            // 
            this.ucBasicProfileEmployee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBasicProfileEmployee.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucBasicProfileEmployee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucBasicProfileEmployee.ForeColor = System.Drawing.Color.Black;
            this.ucBasicProfileEmployee.Location = new System.Drawing.Point(0, 44);
            this.ucBasicProfileEmployee.Name = "ucBasicProfileEmployee";
            this.ucBasicProfileEmployee.Size = new System.Drawing.Size(183, 549);
            this.ucBasicProfileEmployee.TabIndex = 0;
            this.ucBasicProfileEmployee.InnerKeyEvent += new TimeKeepingSystemUI.UserControls.UsrCntrlEmployeeBasicProfile.OnInnerKeyEvent(this.KeyEvents);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(946, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.PrintClick);
            this.btnPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(724, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "DISCARD";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            this.btnCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // btnPost
            // 
            this.btnPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPost.Location = new System.Drawing.Point(835, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(105, 23);
            this.btnPost.TabIndex = 2;
            this.btnPost.Text = "POST";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.PostClick);
            this.btnPost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // btnUpdateSchedule
            // 
            this.btnUpdateSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateSchedule.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSchedule.Location = new System.Drawing.Point(613, 11);
            this.btnUpdateSchedule.Name = "btnUpdateSchedule";
            this.btnUpdateSchedule.Size = new System.Drawing.Size(105, 23);
            this.btnUpdateSchedule.TabIndex = 1;
            this.btnUpdateSchedule.Text = "UPDATE";
            this.btnUpdateSchedule.UseVisualStyleBackColor = true;
            this.btnUpdateSchedule.Click += new System.EventHandler(this.UpdateClick);
            this.btnUpdateSchedule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSchedule.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSchedule.Location = new System.Drawing.Point(502, 11);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(105, 23);
            this.btnCreateSchedule.TabIndex = 0;
            this.btnCreateSchedule.Text = "CREATE";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            this.btnCreateSchedule.Click += new System.EventHandler(this.CreateClick);
            this.btnCreateSchedule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvents);
            // 
            // UsrCntrlForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.ucBasicProfileEmployee);
            this.Controls.Add(this.pnlHeader);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlForms";
            this.Size = new System.Drawing.Size(1058, 593);
            this.Load += new System.EventHandler(this.FormLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabForms.ResumeLayout(false);
            this.tpLeaveUndertime.ResumeLayout(false);
            this.tpChangeRestday.ResumeLayout(false);
            this.tpPRW.ResumeLayout(false);
            this.tpChangeShift.ResumeLayout(false);
            this.tabWholeDayChangeShift.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnUpdateSchedule;
        private ModifiedControls.Button btnCreateSchedule;
        private UsrCntrlEmployeeBasicProfile ucBasicProfileEmployee;
        private ModifiedControls.TabControl tabForms;
        private System.Windows.Forms.TabPage tpChangeRestday;
        private System.Windows.Forms.TabPage tpPRW;
        private System.Windows.Forms.TabPage tpChangeShift;
        private System.Windows.Forms.TabPage tpLeaveUndertime;
        private UsrCntrlLeaveUndertime ucLeaveUndertime;
        private UsrCntrlChangeRestday ucChangeRestday;
        private UsrCntrlPRW ucPRW;
        private ModifiedControls.Button btnCancel;
        private ModifiedControls.Button btnPost;
        private ModifiedControls.Button btnPrint;
        private System.Windows.Forms.Label lblAction;
        private UsrCntrlChangeShift ucChangeShift;
        private System.Windows.Forms.TabPage tabWholeDayChangeShift;
        private UsrCntrlChangeShiftWholeDay usrCntrlChangeShiftWholeDay1;
    }
}
