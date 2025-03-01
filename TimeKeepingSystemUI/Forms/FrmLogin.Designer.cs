namespace TimeKeepingSystemUI.Forms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lnkConfigure = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.lblBiometricsPassword = new System.Windows.Forms.Label();
            this.txtBiometricsPassword = new System.Windows.Forms.TextBox();
            this.lblBiometricsUsername = new System.Windows.Forms.Label();
            this.txtBiometricsUsername = new System.Windows.Forms.TextBox();
            this.lblBiometricsDatabase = new System.Windows.Forms.Label();
            this.txtBiometricsDatabase = new System.Windows.Forms.TextBox();
            this.lblBiometrics = new System.Windows.Forms.Label();
            this.lblBiometricsServer = new System.Windows.Forms.Label();
            this.txtBiometricsServer = new System.Windows.Forms.TextBox();
            this.lblPayrollPassword = new System.Windows.Forms.Label();
            this.txtPayrollPassword = new System.Windows.Forms.TextBox();
            this.lblPayrollUsername = new System.Windows.Forms.Label();
            this.txtPayrollUsername = new System.Windows.Forms.TextBox();
            this.lblPayrollDatabase = new System.Windows.Forms.Label();
            this.txtPayrollDatabase = new System.Windows.Forms.TextBox();
            this.lblPayroll = new System.Windows.Forms.Label();
            this.lblPayrollServer = new System.Windows.Forms.Label();
            this.txtPayrollServer = new System.Windows.Forms.TextBox();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.ucHeaderDrag = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.grpLogin.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(33, 57);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 15);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(99, 56);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(212, 22);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsernameKeyDown);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(99, 84);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(212, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordKeyDown);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(36, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemember.Location = new System.Drawing.Point(95, 112);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(109, 17);
            this.chkRemember.TabIndex = 9;
            this.chkRemember.Text = "Remember Login";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.lnkConfigure);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.chkRemember);
            this.grpLogin.Controls.Add(this.lblUsername);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtUsername);
            this.grpLogin.Controls.Add(this.btnCancel);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Location = new System.Drawing.Point(12, 36);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(343, 183);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Login";
            // 
            // lnkConfigure
            // 
            this.lnkConfigure.AutoSize = true;
            this.lnkConfigure.Location = new System.Drawing.Point(189, 18);
            this.lnkConfigure.Name = "lnkConfigure";
            this.lnkConfigure.Size = new System.Drawing.Size(122, 13);
            this.lnkConfigure.TabIndex = 10;
            this.lnkConfigure.TabStop = true;
            this.lnkConfigure.Text = "Configure Connection";
            this.lnkConfigure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ConfigureClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(249, 136);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(62, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.LoginClick);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(181, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.lnkLogin);
            this.grpConnection.Controls.Add(this.lblBiometricsPassword);
            this.grpConnection.Controls.Add(this.txtBiometricsPassword);
            this.grpConnection.Controls.Add(this.lblBiometricsUsername);
            this.grpConnection.Controls.Add(this.txtBiometricsUsername);
            this.grpConnection.Controls.Add(this.lblBiometricsDatabase);
            this.grpConnection.Controls.Add(this.txtBiometricsDatabase);
            this.grpConnection.Controls.Add(this.lblBiometrics);
            this.grpConnection.Controls.Add(this.lblBiometricsServer);
            this.grpConnection.Controls.Add(this.txtBiometricsServer);
            this.grpConnection.Controls.Add(this.lblPayrollPassword);
            this.grpConnection.Controls.Add(this.txtPayrollPassword);
            this.grpConnection.Controls.Add(this.lblPayrollUsername);
            this.grpConnection.Controls.Add(this.txtPayrollUsername);
            this.grpConnection.Controls.Add(this.lblPayrollDatabase);
            this.grpConnection.Controls.Add(this.txtPayrollDatabase);
            this.grpConnection.Controls.Add(this.lblPayroll);
            this.grpConnection.Controls.Add(this.lblPayrollServer);
            this.grpConnection.Controls.Add(this.txtPayrollServer);
            this.grpConnection.Location = new System.Drawing.Point(12, 250);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(343, 350);
            this.grpConnection.TabIndex = 11;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Connection Settings";
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Location = new System.Drawing.Point(275, 37);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(36, 13);
            this.lnkLogin.TabIndex = 20;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Login";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLoginClick);
            // 
            // lblBiometricsPassword
            // 
            this.lblBiometricsPassword.AutoSize = true;
            this.lblBiometricsPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometricsPassword.Location = new System.Drawing.Point(33, 312);
            this.lblBiometricsPassword.Name = "lblBiometricsPassword";
            this.lblBiometricsPassword.Size = new System.Drawing.Size(60, 15);
            this.lblBiometricsPassword.TabIndex = 19;
            this.lblBiometricsPassword.Text = "Password:";
            // 
            // txtBiometricsPassword
            // 
            this.txtBiometricsPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiometricsPassword.Location = new System.Drawing.Point(99, 311);
            this.txtBiometricsPassword.Name = "txtBiometricsPassword";
            this.txtBiometricsPassword.Size = new System.Drawing.Size(212, 22);
            this.txtBiometricsPassword.TabIndex = 8;
            this.txtBiometricsPassword.UseSystemPasswordChar = true;
            // 
            // lblBiometricsUsername
            // 
            this.lblBiometricsUsername.AutoSize = true;
            this.lblBiometricsUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometricsUsername.Location = new System.Drawing.Point(30, 284);
            this.lblBiometricsUsername.Name = "lblBiometricsUsername";
            this.lblBiometricsUsername.Size = new System.Drawing.Size(63, 15);
            this.lblBiometricsUsername.TabIndex = 17;
            this.lblBiometricsUsername.Text = "Username:";
            // 
            // txtBiometricsUsername
            // 
            this.txtBiometricsUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiometricsUsername.Location = new System.Drawing.Point(99, 283);
            this.txtBiometricsUsername.Name = "txtBiometricsUsername";
            this.txtBiometricsUsername.Size = new System.Drawing.Size(212, 22);
            this.txtBiometricsUsername.TabIndex = 7;
            // 
            // lblBiometricsDatabase
            // 
            this.lblBiometricsDatabase.AutoSize = true;
            this.lblBiometricsDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometricsDatabase.Location = new System.Drawing.Point(35, 256);
            this.lblBiometricsDatabase.Name = "lblBiometricsDatabase";
            this.lblBiometricsDatabase.Size = new System.Drawing.Size(58, 15);
            this.lblBiometricsDatabase.TabIndex = 15;
            this.lblBiometricsDatabase.Text = "Database:";
            // 
            // txtBiometricsDatabase
            // 
            this.txtBiometricsDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiometricsDatabase.Location = new System.Drawing.Point(99, 255);
            this.txtBiometricsDatabase.Name = "txtBiometricsDatabase";
            this.txtBiometricsDatabase.Size = new System.Drawing.Size(212, 22);
            this.txtBiometricsDatabase.TabIndex = 6;
            // 
            // lblBiometrics
            // 
            this.lblBiometrics.AutoSize = true;
            this.lblBiometrics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometrics.Location = new System.Drawing.Point(24, 194);
            this.lblBiometrics.Name = "lblBiometrics";
            this.lblBiometrics.Size = new System.Drawing.Size(169, 13);
            this.lblBiometrics.TabIndex = 14;
            this.lblBiometrics.Text = "Biometrics Connection Settings";
            // 
            // lblBiometricsServer
            // 
            this.lblBiometricsServer.AutoSize = true;
            this.lblBiometricsServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBiometricsServer.Location = new System.Drawing.Point(51, 228);
            this.lblBiometricsServer.Name = "lblBiometricsServer";
            this.lblBiometricsServer.Size = new System.Drawing.Size(42, 15);
            this.lblBiometricsServer.TabIndex = 12;
            this.lblBiometricsServer.Text = "Server:";
            // 
            // txtBiometricsServer
            // 
            this.txtBiometricsServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiometricsServer.Location = new System.Drawing.Point(99, 227);
            this.txtBiometricsServer.Name = "txtBiometricsServer";
            this.txtBiometricsServer.Size = new System.Drawing.Size(212, 22);
            this.txtBiometricsServer.TabIndex = 5;
            // 
            // lblPayrollPassword
            // 
            this.lblPayrollPassword.AutoSize = true;
            this.lblPayrollPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollPassword.Location = new System.Drawing.Point(33, 155);
            this.lblPayrollPassword.Name = "lblPayrollPassword";
            this.lblPayrollPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPayrollPassword.TabIndex = 10;
            this.lblPayrollPassword.Text = "Password:";
            // 
            // txtPayrollPassword
            // 
            this.txtPayrollPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayrollPassword.Location = new System.Drawing.Point(99, 154);
            this.txtPayrollPassword.Name = "txtPayrollPassword";
            this.txtPayrollPassword.Size = new System.Drawing.Size(212, 22);
            this.txtPayrollPassword.TabIndex = 4;
            this.txtPayrollPassword.UseSystemPasswordChar = true;
            // 
            // lblPayrollUsername
            // 
            this.lblPayrollUsername.AutoSize = true;
            this.lblPayrollUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollUsername.Location = new System.Drawing.Point(30, 127);
            this.lblPayrollUsername.Name = "lblPayrollUsername";
            this.lblPayrollUsername.Size = new System.Drawing.Size(63, 15);
            this.lblPayrollUsername.TabIndex = 8;
            this.lblPayrollUsername.Text = "Username:";
            // 
            // txtPayrollUsername
            // 
            this.txtPayrollUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayrollUsername.Location = new System.Drawing.Point(99, 126);
            this.txtPayrollUsername.Name = "txtPayrollUsername";
            this.txtPayrollUsername.Size = new System.Drawing.Size(212, 22);
            this.txtPayrollUsername.TabIndex = 3;
            // 
            // lblPayrollDatabase
            // 
            this.lblPayrollDatabase.AutoSize = true;
            this.lblPayrollDatabase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollDatabase.Location = new System.Drawing.Point(35, 99);
            this.lblPayrollDatabase.Name = "lblPayrollDatabase";
            this.lblPayrollDatabase.Size = new System.Drawing.Size(58, 15);
            this.lblPayrollDatabase.TabIndex = 6;
            this.lblPayrollDatabase.Text = "Database:";
            // 
            // txtPayrollDatabase
            // 
            this.txtPayrollDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayrollDatabase.Location = new System.Drawing.Point(99, 98);
            this.txtPayrollDatabase.Name = "txtPayrollDatabase";
            this.txtPayrollDatabase.Size = new System.Drawing.Size(212, 22);
            this.txtPayrollDatabase.TabIndex = 2;
            // 
            // lblPayroll
            // 
            this.lblPayroll.AutoSize = true;
            this.lblPayroll.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayroll.Location = new System.Drawing.Point(24, 37);
            this.lblPayroll.Name = "lblPayroll";
            this.lblPayroll.Size = new System.Drawing.Size(151, 13);
            this.lblPayroll.TabIndex = 5;
            this.lblPayroll.Text = "Payroll Connection Settings";
            // 
            // lblPayrollServer
            // 
            this.lblPayrollServer.AutoSize = true;
            this.lblPayrollServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayrollServer.Location = new System.Drawing.Point(51, 71);
            this.lblPayrollServer.Name = "lblPayrollServer";
            this.lblPayrollServer.Size = new System.Drawing.Size(42, 15);
            this.lblPayrollServer.TabIndex = 3;
            this.lblPayrollServer.Text = "Server:";
            // 
            // txtPayrollServer
            // 
            this.txtPayrollServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayrollServer.Location = new System.Drawing.Point(99, 70);
            this.txtPayrollServer.Name = "txtPayrollServer";
            this.txtPayrollServer.Size = new System.Drawing.Size(212, 22);
            this.txtPayrollServer.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Controls.Add(this.grpConnection);
            this.pnlCenter.Controls.Add(this.grpLogin);
            this.pnlCenter.Controls.Add(this.ucHeaderDrag);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(366, 234);
            this.pnlCenter.TabIndex = 12;
            // 
            // ucHeaderDrag
            // 
            this.ucHeaderDrag.BackColor = System.Drawing.Color.White;
            this.ucHeaderDrag.CloseButton = true;
            this.ucHeaderDrag.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeaderDrag.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucHeaderDrag.IsHeaderShown = false;
            this.ucHeaderDrag.Location = new System.Drawing.Point(0, 0);
            this.ucHeaderDrag.MaximizeButton = false;
            this.ucHeaderDrag.MinimizeButton = false;
            this.ucHeaderDrag.Name = "ucHeaderDrag";
            this.ucHeaderDrag.SetHeaderText = "Header Text";
            this.ucHeaderDrag.Size = new System.Drawing.Size(364, 30);
            this.ucHeaderDrag.TabIndex = 1;
            this.ucHeaderDrag.Load += new System.EventHandler(this.ucHeaderDrag_Load);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 234);
            this.Controls.Add(this.pnlCenter);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.OnLoad);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UsrCntrlDragableHeader ucHeaderDrag;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private ModifiedControls.Button btnCancel;
        private ModifiedControls.Button btnLogin;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblPayrollServer;
        private System.Windows.Forms.TextBox txtPayrollServer;
        private System.Windows.Forms.Label lblPayroll;
        private System.Windows.Forms.Label lblBiometricsPassword;
        private System.Windows.Forms.TextBox txtBiometricsPassword;
        private System.Windows.Forms.Label lblBiometricsUsername;
        private System.Windows.Forms.TextBox txtBiometricsUsername;
        private System.Windows.Forms.Label lblBiometricsDatabase;
        private System.Windows.Forms.TextBox txtBiometricsDatabase;
        private System.Windows.Forms.Label lblBiometrics;
        private System.Windows.Forms.Label lblBiometricsServer;
        private System.Windows.Forms.TextBox txtBiometricsServer;
        private System.Windows.Forms.Label lblPayrollPassword;
        private System.Windows.Forms.TextBox txtPayrollPassword;
        private System.Windows.Forms.Label lblPayrollUsername;
        private System.Windows.Forms.TextBox txtPayrollUsername;
        private System.Windows.Forms.Label lblPayrollDatabase;
        private System.Windows.Forms.TextBox txtPayrollDatabase;
        private System.Windows.Forms.LinkLabel lnkConfigure;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.LinkLabel lnkLogin;
    }
}