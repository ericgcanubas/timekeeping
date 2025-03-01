using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimeKeepingDataCode;
using System.Configuration;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            LoadConnection();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private void ConfigureClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpConnection.Top = 36;
            this.Height = 398;
        }

        private void LinkLoginClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grpConnection.Top = 250;
            this.Height = 230;
        }

        private void LoginClick(object sender, EventArgs e)
        {
            Login();
        }

        private void Login() 
        {
            Connection payrollConnection = new Connection(txtPayrollServer.Text,
                txtPayrollDatabase.Text, txtPayrollUsername.Text, txtPayrollPassword.Text);
            Connection biometricsConnection = new Connection(txtBiometricsServer.Text,
                txtBiometricsDatabase.Text, txtBiometricsUsername.Text, txtBiometricsPassword.Text);

            if (!payrollConnection.CheckConnection())
            {
                MessageBox.Show("Invalid Payroll Connection Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!biometricsConnection.CheckConnection())
            {
                MessageBox.Show("Invalid Biometrics Connection Settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            TimeKeepingCode.Program.PayrollConnection = payrollConnection;
            TimeKeepingCode.Program.BiometricsConnection = biometricsConnection;

            if (TimeKeepingDataCode.Biometrics.Users.IsAuthenticate(biometricsConnection, txtUsername.Text, txtPassword.Text))
            {
                TimeKeepingCode.Program.User = TimeKeepingDataCode.Biometrics.Users.GetUser(biometricsConnection, txtUsername.Text);

                if (chkRemember.Checked)
                    Properties.Settings.Default.LastLogin = txtUsername.Text;
                else
                    Properties.Settings.Default.LastLogin = string.Empty;

                Properties.Settings.Default.PayrollServer = txtPayrollServer.Text;
                Properties.Settings.Default.PayrollDatabase = txtPayrollDatabase.Text;
                Properties.Settings.Default.PayrollUsername = txtPayrollUsername.Text;
                Properties.Settings.Default.PayrollPassword = txtPayrollPassword.Text;

                Properties.Settings.Default.BiometricServer = txtBiometricsServer.Text;
                Properties.Settings.Default.BiometricDatabase = txtBiometricsDatabase.Text;
                Properties.Settings.Default.BiometricUsername = txtBiometricsUsername.Text;
                Properties.Settings.Default.BiometricPassword = txtBiometricsPassword.Text;

                Properties.Settings.Default.Save();

                this.Close();
            }
            else
                MessageBox.Show("Invalid Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadConnection() 
        {
            txtPayrollServer.Text = Properties.Settings.Default.PayrollServer;
            txtPayrollDatabase.Text = Properties.Settings.Default.PayrollDatabase;
            txtPayrollUsername.Text = Properties.Settings.Default.PayrollUsername;
            txtPayrollPassword.Text = Properties.Settings.Default.PayrollPassword;

            txtBiometricsServer.Text = Properties.Settings.Default.BiometricServer;
            txtBiometricsDatabase.Text = Properties.Settings.Default.BiometricDatabase;
            txtBiometricsUsername.Text = Properties.Settings.Default.BiometricUsername;
            txtBiometricsPassword.Text = Properties.Settings.Default.BiometricPassword;

            txtUsername.Text = Properties.Settings.Default.LastLogin;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            txtUsername.Focus();
            SetControls();
        }

        private void SetControls() 
        {
            btnCancel.BackColor = Code.Program.MainColor;
            btnCancel.ForeColor = Code.Program.TextColor;

            btnLogin.BackColor = Code.Program.MainColor;
            btnLogin.ForeColor = Code.Program.TextColor;
        }

        private void PasswordKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Login();
            }
        }

        private void UsernameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void ucHeaderDrag_Load(object sender, EventArgs e)
        {

        }
    }
}
