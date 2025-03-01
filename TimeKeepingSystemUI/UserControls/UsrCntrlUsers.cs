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
    public partial class UsrCntrlUsers : UserControl
    {
        private BindingSource source;

        public UsrCntrlUsers()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridUsers.AutoGenerateColumns = false;

            this.source = new BindingSource();
            gridUsers.DataSource = this.source;
        }

        private static UsrCntrlUsers instance;
        public static UsrCntrlUsers Instance {
            get { 
                if(instance ==  null || instance.IsDisposed){
                    instance = new UsrCntrlUsers();
                    instance.Name = "singletonUser";
                }
                return instance;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.Users.GetAllUsers(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a =>
            {
                this.source.DataSource = a.Result;
                this.source.ResetBindings(false);
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());

            SetControls();
        }

        private void SetControls() 
        {
            gridUsers.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridUsers.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridUsers.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridUsers.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            btnCreate.BackColor = Code.Program.MainColor;
            btnUpdate.BackColor = Code.Program.MainColor;
            btnCreate.ForeColor = Code.Program.TextColor;
            btnUpdate.ForeColor = Code.Program.TextColor;

            btnCreate.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
            btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            
        }

        private void CreateClick(object sender, EventArgs e)
        {
            this.Parent.Controls.Add(UsrCntrlUsersDetails.Instance);
            UsrCntrlUsersDetails.Instance.BringToFront();
            UsrCntrlUsersDetails.Instance.Create();
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count > 0)
            {
                var user = this.source.Current as TimeKeepingDataCode.Biometrics.Users;
                if (user != null)
                {
                    this.Parent.Controls.Add(UsrCntrlUsersDetails.Instance);
                    UsrCntrlUsersDetails.Instance.BringToFront();
                    UsrCntrlUsersDetails.Instance.Update(user.Id);
               
                }
                else
                    MessageBox.Show("No Selected User.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No Selected User.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
