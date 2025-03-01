namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlToolsSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsrCntrlToolsSelection));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.flowPnlCenter = new System.Windows.Forms.FlowLayoutPanel();
            this.ucMachineId = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.ucUserAccounts = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.ucTimeRecordTools = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrCntrlitem4 = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
            this.usrCntrlitem5 = new TimeKeepingSystemUI.UserControls.UsrCntrlitem();
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
            this.pnlTop.Size = new System.Drawing.Size(879, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // flowPnlCenter
            // 
            this.flowPnlCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.flowPnlCenter.Controls.Add(this.ucMachineId);
            this.flowPnlCenter.Controls.Add(this.ucUserAccounts);
            this.flowPnlCenter.Controls.Add(this.ucTimeRecordTools);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem4);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem5);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem6);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem7);
            this.flowPnlCenter.Controls.Add(this.usrCntrlitem8);
            this.flowPnlCenter.Location = new System.Drawing.Point(88, 52);
            this.flowPnlCenter.Name = "flowPnlCenter";
            this.flowPnlCenter.Size = new System.Drawing.Size(703, 549);
            this.flowPnlCenter.TabIndex = 2;
            // 
            // ucMachineId
            // 
            this.ucMachineId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucMachineId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucMachineId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucMachineId.Location = new System.Drawing.Point(10, 10);
            this.ucMachineId.Margin = new System.Windows.Forms.Padding(10);
            this.ucMachineId.Name = "ucMachineId";
            this.ucMachineId.SetImage = ((System.Drawing.Image)(resources.GetObject("ucMachineId.SetImage")));
            this.ucMachineId.SetText = "Machine ID\'s";
            this.ucMachineId.Size = new System.Drawing.Size(155, 155);
            this.ucMachineId.TabIndex = 0;
            this.ucMachineId.Click += new System.EventHandler(this.MachineIdClick);
            // 
            // ucUserAccounts
            // 
            this.ucUserAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucUserAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucUserAccounts.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucUserAccounts.Location = new System.Drawing.Point(185, 10);
            this.ucUserAccounts.Margin = new System.Windows.Forms.Padding(10);
            this.ucUserAccounts.Name = "ucUserAccounts";
            this.ucUserAccounts.SetImage = ((System.Drawing.Image)(resources.GetObject("ucUserAccounts.SetImage")));
            this.ucUserAccounts.SetText = "User Account";
            this.ucUserAccounts.Size = new System.Drawing.Size(155, 155);
            this.ucUserAccounts.TabIndex = 1;
            this.ucUserAccounts.Click += new System.EventHandler(this.UserAccountClick);
            // 
            // ucTimeRecordTools
            // 
            this.ucTimeRecordTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.ucTimeRecordTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucTimeRecordTools.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucTimeRecordTools.Location = new System.Drawing.Point(360, 10);
            this.ucTimeRecordTools.Margin = new System.Windows.Forms.Padding(10);
            this.ucTimeRecordTools.Name = "ucTimeRecordTools";
            this.ucTimeRecordTools.SetImage = ((System.Drawing.Image)(resources.GetObject("ucTimeRecordTools.SetImage")));
            this.ucTimeRecordTools.SetText = "Repost/Update Time";
            this.ucTimeRecordTools.Size = new System.Drawing.Size(155, 155);
            this.ucTimeRecordTools.TabIndex = 2;
            this.ucTimeRecordTools.Click += new System.EventHandler(this.RepostUpdateTimeClick);
            // 
            // usrCntrlitem4
            // 
            this.usrCntrlitem4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrCntrlitem4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrCntrlitem4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlitem4.Location = new System.Drawing.Point(535, 10);
            this.usrCntrlitem4.Margin = new System.Windows.Forms.Padding(10);
            this.usrCntrlitem4.Name = "usrCntrlitem4";
            this.usrCntrlitem4.SetImage = ((System.Drawing.Image)(resources.GetObject("usrCntrlitem4.SetImage")));
            this.usrCntrlitem4.SetText = "On Process . .";
            this.usrCntrlitem4.Size = new System.Drawing.Size(155, 155);
            this.usrCntrlitem4.TabIndex = 3;
            // 
            // usrCntrlitem5
            // 
            this.usrCntrlitem5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.usrCntrlitem5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usrCntrlitem5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlitem5.Location = new System.Drawing.Point(10, 185);
            this.usrCntrlitem5.Margin = new System.Windows.Forms.Padding(10);
            this.usrCntrlitem5.Name = "usrCntrlitem5";
            this.usrCntrlitem5.SetImage = ((System.Drawing.Image)(resources.GetObject("usrCntrlitem5.SetImage")));
            this.usrCntrlitem5.SetText = "On Process . .";
            this.usrCntrlitem5.Size = new System.Drawing.Size(155, 155);
            this.usrCntrlitem5.TabIndex = 4;
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
            // UsrCntrlToolsSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPnlCenter);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.Name = "UsrCntrlToolsSelection";
            this.Size = new System.Drawing.Size(879, 614);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.FormResize);
            this.flowPnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.FlowLayoutPanel flowPnlCenter;
        private UsrCntrlitem ucMachineId;
        private UsrCntrlitem ucUserAccounts;
        private UsrCntrlitem ucTimeRecordTools;
        private UsrCntrlitem usrCntrlitem4;
        private UsrCntrlitem usrCntrlitem5;
        private UsrCntrlitem usrCntrlitem6;
        private UsrCntrlitem usrCntrlitem7;
        private UsrCntrlitem usrCntrlitem8;
    }
}
