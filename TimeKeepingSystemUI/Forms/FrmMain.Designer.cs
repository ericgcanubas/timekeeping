namespace TimeKeepingSystemUI.Forms
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlNavLeft = new System.Windows.Forms.Panel();
            this.pnlTitleSeparator = new System.Windows.Forms.Panel();
            this.pnlNavLeftHeader = new System.Windows.Forms.Panel();
            this.picHamburger = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlWrapper = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblUserLogin = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.usrCntrlHeader = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.btnTools = new TimeKeepingSystemUI.UserControls.UsrCntrlMenuBtn();
            this.btnReport = new TimeKeepingSystemUI.UserControls.UsrCntrlMenuBtn();
            this.btnOtherForms = new TimeKeepingSystemUI.UserControls.UsrCntrlMenuBtn();
            this.btnForms = new TimeKeepingSystemUI.UserControls.UsrCntrlMenuBtn();
            this.btnEmployee = new TimeKeepingSystemUI.UserControls.UsrCntrlMenuBtn();
            this.pnlNavLeft.SuspendLayout();
            this.pnlNavLeftHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHamburger)).BeginInit();
            this.pnlWrapper.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNavLeft
            // 
            this.pnlNavLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.pnlNavLeft.Controls.Add(this.btnTools);
            this.pnlNavLeft.Controls.Add(this.btnReport);
            this.pnlNavLeft.Controls.Add(this.btnOtherForms);
            this.pnlNavLeft.Controls.Add(this.btnForms);
            this.pnlNavLeft.Controls.Add(this.btnEmployee);
            this.pnlNavLeft.Controls.Add(this.pnlTitleSeparator);
            this.pnlNavLeft.Controls.Add(this.pnlNavLeftHeader);
            this.pnlNavLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlNavLeft.Name = "pnlNavLeft";
            this.pnlNavLeft.Size = new System.Drawing.Size(180, 632);
            this.pnlNavLeft.TabIndex = 1;
            // 
            // pnlTitleSeparator
            // 
            this.pnlTitleSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.pnlTitleSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleSeparator.Location = new System.Drawing.Point(0, 30);
            this.pnlTitleSeparator.Name = "pnlTitleSeparator";
            this.pnlTitleSeparator.Size = new System.Drawing.Size(180, 2);
            this.pnlTitleSeparator.TabIndex = 1;
            // 
            // pnlNavLeftHeader
            // 
            this.pnlNavLeftHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavLeftHeader.Controls.Add(this.picHamburger);
            this.pnlNavLeftHeader.Controls.Add(this.lblTitle);
            this.pnlNavLeftHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlNavLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavLeftHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlNavLeftHeader.Name = "pnlNavLeftHeader";
            this.pnlNavLeftHeader.Size = new System.Drawing.Size(180, 30);
            this.pnlNavLeftHeader.TabIndex = 0;
            this.pnlNavLeftHeader.Click += new System.EventHandler(this.HeaderTitleClick);
            // 
            // picHamburger
            // 
            this.picHamburger.BackColor = System.Drawing.Color.Transparent;
            this.picHamburger.Image = global::TimeKeepingSystemUI.Properties.Resources.menu35;
            this.picHamburger.Location = new System.Drawing.Point(3, 3);
            this.picHamburger.Name = "picHamburger";
            this.picHamburger.Size = new System.Drawing.Size(40, 24);
            this.picHamburger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picHamburger.TabIndex = 1;
            this.picHamburger.TabStop = false;
            this.picHamburger.Click += new System.EventHandler(this.HeaderTitleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TimeKeeping System";
            this.lblTitle.Click += new System.EventHandler(this.HeaderTitleClick);
            // 
            // pnlWrapper
            // 
            this.pnlWrapper.Controls.Add(this.pnlFooter);
            this.pnlWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWrapper.Location = new System.Drawing.Point(180, 30);
            this.pnlWrapper.Name = "pnlWrapper";
            this.pnlWrapper.Size = new System.Drawing.Size(931, 602);
            this.pnlWrapper.TabIndex = 3;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.pnlFooter.Controls.Add(this.lblUserLogin);
            this.pnlFooter.Controls.Add(this.lblAutor);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 572);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(931, 30);
            this.pnlFooter.TabIndex = 0;
            // 
            // lblUserLogin
            // 
            this.lblUserLogin.AutoSize = true;
            this.lblUserLogin.Location = new System.Drawing.Point(6, 9);
            this.lblUserLogin.Name = "lblUserLogin";
            this.lblUserLogin.Size = new System.Drawing.Size(65, 13);
            this.lblUserLogin.TabIndex = 1;
            this.lblUserLogin.Text = "User Login:";
            // 
            // lblAutor
            // 
            this.lblAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAutor.AutoSize = true;
            this.lblAutor.Location = new System.Drawing.Point(761, 9);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(158, 13);
            this.lblAutor.TabIndex = 0;
            this.lblAutor.Text = "By: dechalico.dev@gmail.com";
            // 
            // usrCntrlHeader
            // 
            this.usrCntrlHeader.BackColor = System.Drawing.Color.White;
            this.usrCntrlHeader.CloseButton = true;
            this.usrCntrlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.usrCntrlHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlHeader.IsHeaderShown = false;
            this.usrCntrlHeader.Location = new System.Drawing.Point(180, 0);
            this.usrCntrlHeader.MaximizeButton = true;
            this.usrCntrlHeader.MinimizeButton = true;
            this.usrCntrlHeader.Name = "usrCntrlHeader";
            this.usrCntrlHeader.SetHeaderText = "Header Text";
            this.usrCntrlHeader.Size = new System.Drawing.Size(931, 30);
            this.usrCntrlHeader.TabIndex = 2;
            // 
            // btnTools
            // 
            this.btnTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.btnTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTools.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTools.Icon = ((System.Drawing.Image)(resources.GetObject("btnTools.Icon")));
            this.btnTools.LabelText = "Tools";
            this.btnTools.Location = new System.Drawing.Point(0, 192);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(180, 40);
            this.btnTools.TabIndex = 6;
            this.btnTools.Click += new System.EventHandler(this.ToolsOnClick);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Icon = ((System.Drawing.Image)(resources.GetObject("btnReport.Icon")));
            this.btnReport.LabelText = "Reports";
            this.btnReport.Location = new System.Drawing.Point(0, 152);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(180, 40);
            this.btnReport.TabIndex = 5;
            this.btnReport.Click += new System.EventHandler(this.ReportsOnClick);
            // 
            // btnOtherForms
            // 
            this.btnOtherForms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.btnOtherForms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtherForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOtherForms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtherForms.Icon = ((System.Drawing.Image)(resources.GetObject("btnOtherForms.Icon")));
            this.btnOtherForms.LabelText = "Other Forms";
            this.btnOtherForms.Location = new System.Drawing.Point(0, 112);
            this.btnOtherForms.Name = "btnOtherForms";
            this.btnOtherForms.Size = new System.Drawing.Size(180, 40);
            this.btnOtherForms.TabIndex = 4;
            this.btnOtherForms.Click += new System.EventHandler(this.OtherFormsOnClick);
            // 
            // btnForms
            // 
            this.btnForms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.btnForms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnForms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForms.Icon = ((System.Drawing.Image)(resources.GetObject("btnForms.Icon")));
            this.btnForms.LabelText = "Application Forms";
            this.btnForms.Location = new System.Drawing.Point(0, 72);
            this.btnForms.Name = "btnForms";
            this.btnForms.Size = new System.Drawing.Size(180, 40);
            this.btnForms.TabIndex = 3;
            this.btnForms.Click += new System.EventHandler(this.ApplicationFormsOnClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.btnEmployee.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Icon = ((System.Drawing.Image)(resources.GetObject("btnEmployee.Icon")));
            this.btnEmployee.LabelText = "Employee Profile";
            this.btnEmployee.Location = new System.Drawing.Point(0, 32);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(180, 40);
            this.btnEmployee.TabIndex = 2;
            this.btnEmployee.Click += new System.EventHandler(this.ProfileOnClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1111, 632);
            this.Controls.Add(this.pnlWrapper);
            this.Controls.Add(this.usrCntrlHeader);
            this.Controls.Add(this.pnlNavLeft);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlNavLeft.ResumeLayout(false);
            this.pnlNavLeftHeader.ResumeLayout(false);
            this.pnlNavLeftHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHamburger)).EndInit();
            this.pnlWrapper.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNavLeft;
        private System.Windows.Forms.Panel pnlNavLeftHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTitleSeparator;
        private UserControls.UsrCntrlMenuBtn btnEmployee;
        private UserControls.UsrCntrlMenuBtn btnForms;
        private UserControls.UsrCntrlMenuBtn btnReport;
        private UserControls.UsrCntrlMenuBtn btnOtherForms;
        private System.Windows.Forms.Panel pnlWrapper;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblUserLogin;
        private System.Windows.Forms.PictureBox picHamburger;
        private UserControls.UsrCntrlMenuBtn btnTools;
        private UserControls.UsrCntrlDragableHeader usrCntrlHeader;
    }
}