namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlOtherForms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrCntrlOtherForms));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.flowPnlCenter = new System.Windows.Forms.FlowLayoutPanel();
            this.ucItemShiftingSchedules = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.ucItemCheckerCasherSchedule = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.ucItemHoliday = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrExtendedMidNight = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.ucCntrlTimeRecord = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrCntrlitem6 = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrCntrlitem7 = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrCntrlitem8 = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.flowPnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(798, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // flowPnlCenter
            // 
            this.flowPnlCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPnlCenter.Controls.Add(this.ucItemShiftingSchedules);
            this.flowPnlCenter.Controls.Add(this.ucItemCheckerCasherSchedule);
            this.flowPnlCenter.Controls.Add(this.ucItemHoliday);
            this.flowPnlCenter.Controls.Add(this.usrExtendedMidNight);
            this.flowPnlCenter.Controls.Add(this.ucCntrlTimeRecord);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem6);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem7);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem8);
            this.flowPnlCenter.Location = new System.Drawing.Point(48, 52);
            this.flowPnlCenter.Name = "flowPnlCenter";
            this.flowPnlCenter.Size = new System.Drawing.Size(703, 544);
            this.flowPnlCenter.TabIndex = 1;
            // 
            // ucItemShiftingSchedules
            // 
            this.ucItemShiftingSchedules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucItemShiftingSchedules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucItemShiftingSchedules.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucItemShiftingSchedules.Location = new System.Drawing.Point(10, 10);
            this.ucItemShiftingSchedules.Margin = new System.Windows.Forms.Padding(10);
            this.ucItemShiftingSchedules.Name = "ucItemShiftingSchedules";
            this.ucItemShiftingSchedules.SetImage = ((System.Drawing.Image)(resources.GetObject("ucItemShiftingSchedules.SetImage")));
            this.ucItemShiftingSchedules.SetText = "Shifting Schedules";
            this.ucItemShiftingSchedules.Size = new System.Drawing.Size(155, 155);
            this.ucItemShiftingSchedules.TabIndex = 0;
            this.ucItemShiftingSchedules.Click += new System.EventHandler(this.ShiftingScheduleClick);
            // 
            // ucItemCheckerCasherSchedule
            // 
            this.ucItemCheckerCasherSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucItemCheckerCasherSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucItemCheckerCasherSchedule.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucItemCheckerCasherSchedule.Location = new System.Drawing.Point(185, 10);
            this.ucItemCheckerCasherSchedule.Margin = new System.Windows.Forms.Padding(10);
            this.ucItemCheckerCasherSchedule.Name = "ucItemCheckerCasherSchedule";
            this.ucItemCheckerCasherSchedule.SetImage = ((System.Drawing.Image)(resources.GetObject("ucItemCheckerCasherSchedule.SetImage")));
            this.ucItemCheckerCasherSchedule.SetText = "Chercker/Casher";
            this.ucItemCheckerCasherSchedule.Size = new System.Drawing.Size(155, 155);
            this.ucItemCheckerCasherSchedule.TabIndex = 1;
            this.ucItemCheckerCasherSchedule.Click += new System.EventHandler(this.CheckerCasherClick);
            // 
            // ucItemHoliday
            // 
            this.ucItemHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucItemHoliday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucItemHoliday.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucItemHoliday.Location = new System.Drawing.Point(360, 10);
            this.ucItemHoliday.Margin = new System.Windows.Forms.Padding(10);
            this.ucItemHoliday.Name = "ucItemHoliday";
            this.ucItemHoliday.SetImage = ((System.Drawing.Image)(resources.GetObject("ucItemHoliday.SetImage")));
            this.ucItemHoliday.SetText = "Holidays";
            this.ucItemHoliday.Size = new System.Drawing.Size(155, 155);
            this.ucItemHoliday.TabIndex = 2;
            this.ucItemHoliday.Click += new System.EventHandler(this.HolidayItemClick);
            // 
            // usrExtendedMidNight
            // 
            this.usrExtendedMidNight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrExtendedMidNight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrExtendedMidNight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrExtendedMidNight.Location = new System.Drawing.Point(535, 10);
            this.usrExtendedMidNight.Margin = new System.Windows.Forms.Padding(10);
            this.usrExtendedMidNight.Name = "usrExtendedMidNight";
            this.usrExtendedMidNight.SetImage = ((System.Drawing.Image)(resources.GetObject("usrExtendedMidNight.SetImage")));
            this.usrExtendedMidNight.SetText = "Exteded/MidNight";
            this.usrExtendedMidNight.Size = new System.Drawing.Size(155, 155);
            this.usrExtendedMidNight.TabIndex = 3;
            this.usrExtendedMidNight.Click += new System.EventHandler(this.ExtendedMidNightClick);
            // 
            // ucCntrlTimeRecord
            // 
            this.ucCntrlTimeRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucCntrlTimeRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucCntrlTimeRecord.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCntrlTimeRecord.Location = new System.Drawing.Point(10, 185);
            this.ucCntrlTimeRecord.Margin = new System.Windows.Forms.Padding(10);
            this.ucCntrlTimeRecord.Name = "ucCntrlTimeRecord";
            this.ucCntrlTimeRecord.SetImage = ((System.Drawing.Image)(resources.GetObject("ucCntrlTimeRecord.SetImage")));
            this.ucCntrlTimeRecord.SetText = "Time Record";
            this.ucCntrlTimeRecord.Size = new System.Drawing.Size(155, 155);
            this.ucCntrlTimeRecord.TabIndex = 4;
            this.ucCntrlTimeRecord.Click += new System.EventHandler(this.TimeRecordClick);
            // 
            // usrCntrlitem6
            // 
            this.usrCntrlitem6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrCntrlitem6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrCntrlitem6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlitem6.Location = new System.Drawing.Point(185, 185);
            this.usrCntrlitem6.Margin = new System.Windows.Forms.Padding(10);
            this.usrCntrlitem6.Name = "usrCntrlitem6";
            this.usrCntrlitem6.SetImage = ((System.Drawing.Image)(resources.GetObject("usrCntrlitem6.SetImage")));
            this.usrCntrlitem6.SetText = "On Process . .";
            this.usrCntrlitem6.Size = new System.Drawing.Size(155, 155);
            this.usrCntrlitem6.TabIndex = 5;
            // 
            // usrCntrlitem7
            // 
            this.usrCntrlitem7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrCntrlitem7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrCntrlitem7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlitem7.Location = new System.Drawing.Point(360, 185);
            this.usrCntrlitem7.Margin = new System.Windows.Forms.Padding(10);
            this.usrCntrlitem7.Name = "usrCntrlitem7";
            this.usrCntrlitem7.SetImage = ((System.Drawing.Image)(resources.GetObject("usrCntrlitem7.SetImage")));
            this.usrCntrlitem7.SetText = "On Process . .";
            this.usrCntrlitem7.Size = new System.Drawing.Size(155, 155);
            this.usrCntrlitem7.TabIndex = 6;
            // 
            // usrCntrlitem8
            // 
            this.usrCntrlitem8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrCntrlitem8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrCntrlitem8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlitem8.Location = new System.Drawing.Point(535, 185);
            this.usrCntrlitem8.Margin = new System.Windows.Forms.Padding(10);
            this.usrCntrlitem8.Name = "usrCntrlitem8";
            this.usrCntrlitem8.SetImage = ((System.Drawing.Image)(resources.GetObject("usrCntrlitem8.SetImage")));
            this.usrCntrlitem8.SetText = "On Process . .";
            this.usrCntrlitem8.Size = new System.Drawing.Size(155, 155);
            this.usrCntrlitem8.TabIndex = 7;
            // 
            // UsrCntrlOtherForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPnlCenter);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlOtherForms";
            this.Size = new System.Drawing.Size(798, 596);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.FormResize);
            this.flowPnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.FlowLayoutPanel flowPnlCenter;
        private UsrCntrlitem ucItemShiftingSchedules;
        private UsrCntrlitem ucItemCheckerCasherSchedule;
        private UsrCntrlitem ucItemHoliday;
        private UsrCntrlitem usrExtendedMidNight;
        private UsrCntrlitem ucCntrlTimeRecord;
        private UsrCntrlitem usrCntrlitem6;
        private UsrCntrlitem usrCntrlitem7;
        private UsrCntrlitem usrCntrlitem8;
    }
}
