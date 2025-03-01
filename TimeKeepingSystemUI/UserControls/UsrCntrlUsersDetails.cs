using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlUsersDetails : UserControl
    {
        private BindingSource source;
        private TimeKeepingCode.UserAction action;
        private TimeKeepingDataCode.Biometrics.Users user;

        public UsrCntrlUsersDetails()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridUserRoles.AutoGenerateColumns = false;
            this.action = TimeKeepingCode.UserAction.View;

            this.source = new BindingSource();
            gridUserRoles.DataSource = this.source;
        }

        private static UsrCntrlUsersDetails instance;
        public static UsrCntrlUsersDetails Instance {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlUsersDetails();
                    instance.Name = "singletonUsrCntrlUserDetails";
                }
                return instance;
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SetControls() 
        {
            gridUserRoles.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridUserRoles.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridUserRoles.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridUserRoles.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
  
         

            btnSave.BackColor = Code.Program.MainColor;
            btnCancel.BackColor = Code.Program.MainColor;
            btnSave.ForeColor = Code.Program.TextColor;
            btnCancel.ForeColor = Code.Program.TextColor;

            btnSave.Image = TimeKeepingSystemUI.Properties.Resources.save15;
            btnCancel.Image = TimeKeepingSystemUI.Properties.Resources.cancel15;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
        }

        public void Create() 
        {
            this.action = TimeKeepingCode.UserAction.Create;
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.UserRoles.EmptyUserRoles(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a =>
            {
                this.source.DataSource = a.Result;
                this.source.ResetBindings(false);
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void Update(int userId) 
        {
            this.action = TimeKeepingCode.UserAction.Update;
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.UserRoles.GetAllUserRoles(TimeKeepingCode.Program.BiometricsConnection, userId);
            }).ContinueWith(a => {
                this.source.DataSource = a.Result;
                this.source.ResetBindings(false);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
            LoadUserDetails(userId);
        }

        private void LoadUserDetails(int userId) 
        {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.Users.GetUser(TimeKeepingCode.Program.BiometricsConnection, userId);
            }).ContinueWith(a => {
                if (a.Result != null) {
                    this.user = a.Result;
                    txtFirstname.Text = a.Result.FirstName;
                    txtMiddleName.Text = a.Result.MiddleName;
                    txtLastname.Text = a.Result.LastName;
                    txtUsername.Text = a.Result.UserName;
                    txtPassword.Text = a.Result.Password;
                    txtRetypePassword.Text = a.Result.Password;
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private TimeKeepingDataCode.Biometrics.Users CreateUser() 
        {
            TimeKeepingDataCode.Biometrics.Users result = null;

            int id = this.action == TimeKeepingCode.UserAction.Update ? this.user.Id : 0;

            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate(); 
            result = new TimeKeepingDataCode.Biometrics.Users(id,txtFirstname.Text,txtMiddleName.Text,
                txtLastname.Text, txtUsername.Text, txtPassword.Text, serverDate, TimeKeepingCode.Program.User.UserName);

            return result;
        }

        private List<TimeKeepingDataCode.Biometrics.UserRoles> CreateUserRoles() 
        {
            List<TimeKeepingDataCode.Biometrics.UserRoles> result = new List<TimeKeepingDataCode.Biometrics.UserRoles>();
            result.AddRange(this.source.DataSource as List<TimeKeepingDataCode.Biometrics.UserRoles>);
            return result;
        }

        private bool IsPasswordMatch() 
        {
            return txtPassword.Text.Equals(txtRetypePassword.Text);
        }

        private bool IsFieldsValid() 
        {
            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
            {
                MessageBox.Show("Fill Valid First Name.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtFirstname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMiddleName.Text)) {
                MessageBox.Show("Fill Valid Middle Name","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtMiddleName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastname.Text)) {
                MessageBox.Show("Fill Valid Last Name","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtLastname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text)) {
                MessageBox.Show("Fill Valid Password.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRetypePassword.Text)) {
                MessageBox.Show("Fill Retype Password.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtRetypePassword.Focus();
                return false;
            }

            return true;
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (!IsFieldsValid())
                return;

            if (!IsPasswordMatch())
            {
                MessageBox.Show("Password not Match", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRetypePassword.Focus();
                return;
            }

            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (TimeKeepingDataCode.Biometrics.Users.IsUsernameAlreadtExist
                (TimeKeepingCode.Program.BiometricsConnection, txtUsername.Text))
                {
                    MessageBox.Show("Username already Exist.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Are sure to save Created User?", "Save Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (TimeKeepingDataCode.Biometrics.Users.SaveCreatedUser
                    (TimeKeepingCode.Program.BiometricsConnection, CreateUser(), CreateUserRoles()))
                {
                    MessageBox.Show("Created User Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                    MessageBox.Show("Created User Failed to Saved.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are sure to save Updated User?", "Save Updated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                if (TimeKeepingDataCode.Biometrics.Users.SaveUpdatedUser
                    (TimeKeepingCode.Program.BiometricsConnection, CreateUser(), CreateUserRoles()))
                {
                    MessageBox.Show("Updated User Successfuly Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                    MessageBox.Show("Updated User Failed to Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
        
        }
    }
}
