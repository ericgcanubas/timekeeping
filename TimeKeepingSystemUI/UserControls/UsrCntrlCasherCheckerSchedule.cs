using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlCasherCheckerSchedule : UserControl
    {
        private BindingSource sourceList;

        public UsrCntrlCasherCheckerSchedule()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridList.AutoGenerateColumns = false;

            this.sourceList = new BindingSource();
            gridList.DataSource = this.sourceList;

            UsrCntrlCasherCheckerScheduleDetails.Instance.OnSaveSuccess += OnDetailSave;
        }

        private static UsrCntrlCasherCheckerSchedule instance;
        public static UsrCntrlCasherCheckerSchedule Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlCasherCheckerSchedule();
                    instance.Name = "singletonUsrCntrlCasherCheckerSchedule";
                }
                return instance;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
            SetControls();
            LoadList();
        }

        private void LoadList() 
        {
            Task.Factory.StartNew(() =>
            {
                return CasherCheckerAssignSchedule.
                    GetAllCasherCheckerSchedule(TimeKeepingCode.Program.BiometricsConnection,1000);
            }).ContinueWith(a =>
            {
                this.sourceList.DataSource = a.Result;
                this.sourceList.ResetBindings(false);
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetControls() {
            btnCreate.BackColor = Code.Program.MainColor;
            btnCreate.ForeColor = Code.Program.TextColor;
            btnUpdate.BackColor = Code.Program.MainColor;
            btnUpdate.ForeColor = Code.Program.TextColor;
            btnDiscard.BackColor = Code.Program.MainColor;
            btnDiscard.ForeColor = Code.Program.TextColor;
            btnPost.BackColor = Code.Program.MainColor;
            btnPost.ForeColor = Code.Program.TextColor;
            btnSettings.BackColor = Code.Program.MainColor;
            btnSettings.ForeColor = Code.Program.TextColor;
            btnView.BackColor = Code.Program.MainColor;
            btnView.ForeColor = Code.Program.TextColor;

            gridList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridList.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridList.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbSchedule.ForeColor = Code.Program.MainColor;
        }

        private void GridListKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                UsrCntrlCasherCheckerWrapper.Instance.Dispose();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            Forms.FrmCasherCheckerSettings.Instance.ShowDialog(this);
            Forms.FrmCasherCheckerSettings.Instance.Dispose();
        }

        private void CreateClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.CasherCheckerSchedule, TimeKeepingCode.UserRoles.CanCreate))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsrCntrlCasherCheckerWrapper.Instance.Controls[UsrCntrlCasherCheckerScheduleDetails.Instance.Name] != null)
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            else {
                UsrCntrlCasherCheckerWrapper.Instance.Controls.Add(UsrCntrlCasherCheckerScheduleDetails.Instance);
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            }
            UsrCntrlCasherCheckerScheduleDetails.Instance.Create();
        }

        private void OnDetailSave(object sender,TimeKeepingCode.Events.CasherCheckerEventArgs e) 
        {
            LoadList();
        }

        public CasherCheckerAssignSchedule SelectedSchedule {
            get {
                CasherCheckerAssignSchedule result = null;
                if (gridList.SelectedRows.Count > 0)
                    result = gridList.SelectedRows[0].DataBoundItem as CasherCheckerAssignSchedule;
                return result;
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.CasherCheckerSchedule, TimeKeepingCode.UserRoles.CanUpdate))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CasherCheckerAssignSchedule schedule = this.sourceList.Current as CasherCheckerAssignSchedule;
            if (schedule.IsPosted || schedule.IsCancelled) {
                MessageBox.Show("Can't Update Posted or Cancelled Schedule.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (UsrCntrlCasherCheckerWrapper.Instance.Controls[UsrCntrlCasherCheckerScheduleDetails.Instance.Name] != null)
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            else
            {
                UsrCntrlCasherCheckerWrapper.Instance.Controls.Add(UsrCntrlCasherCheckerScheduleDetails.Instance);
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            }
            UsrCntrlCasherCheckerScheduleDetails.Instance.Update(schedule);
        }

        private void ViewClick(object sender, EventArgs e)
        {
            if (UsrCntrlCasherCheckerWrapper.Instance.Controls[UsrCntrlCasherCheckerScheduleDetails.Instance.Name] != null)
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            else
            {
                UsrCntrlCasherCheckerWrapper.Instance.Controls.Add(UsrCntrlCasherCheckerScheduleDetails.Instance);
                UsrCntrlCasherCheckerScheduleDetails.Instance.BringToFront();
            }
            UsrCntrlCasherCheckerScheduleDetails.Instance.LoadView(this.sourceList.Current as CasherCheckerAssignSchedule);
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            UsrCntrlCasherCheckerWrapper.Instance.Dispose();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.CasherCheckerSchedule, TimeKeepingCode.UserRoles.CanPost))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gridList.SelectedRows.Count > 0)
            {
                CasherCheckerAssignSchedule schedule = this.sourceList.Current as CasherCheckerAssignSchedule;
                if (schedule != null)
                {
                    if (schedule.IsPosted)
                        MessageBox.Show("Schedule Aready Posted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (schedule.IsCancelled)
                        MessageBox.Show("Can't Post Cancelled Schedule.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DateTime serveDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
                        if (serveDate >= schedule.DateEffect)
                        {
                            MessageBox.Show("Can't Post Previous or Ongoing Date Effect.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if (MessageBox.Show("Are you sure to Post this Schedule?", "Post Schedule",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;

                        if (CasherCheckerAssignSchedule.PostAssignedSchedule(TimeKeepingCode.Program.BiometricsConnection, schedule))
                        {
                            MessageBox.Show("Schedule Successfuly Posted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            schedule.IsPosted = true;
                        }
                        else
                            MessageBox.Show("Schedule Error in Posting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("No Selected Schedule.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("No Selected Schedule.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
        }

        private void DiscardSchedule(object sender, EventArgs e)
        {
            if (!IsAuthorized.IsHaveUserAccess(Roles.CasherCheckerSchedule, TimeKeepingCode.UserRoles.CanUnpost))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (gridList.SelectedRows.Count > 0)
            {
                CasherCheckerAssignSchedule schedule = this.sourceList.Current as CasherCheckerAssignSchedule;
                if (schedule != null)
                {
                    if (schedule.IsCancelled)
                        MessageBox.Show("Assigned Schedule Already Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (schedule.IsPosted) 
                        {
                            DateTime serveDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
                            if (serveDate >= schedule.DateEffect)
                            {
                                MessageBox.Show("Can't Cancel Posted Previous or Ongoing Date Effect.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }

                        if (MessageBox.Show("Are you sure to Cancel this Schedule?", "Cancel Schedule",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;

                        if (CasherCheckerAssignSchedule.CancelAssignedSchedule(TimeKeepingCode.Program.BiometricsConnection, schedule))
                        {
                            MessageBox.Show("Schedule Successfuly Cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            schedule.IsCancelled = true;
                        }
                        else
                            MessageBox.Show("Schedule Error in Cancelling.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("No Selected Schedule.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("No Selected Schedule.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void SetImage() 
        {
            btnView.Image = TimeKeepingSystemUI.Properties.Resources.view15;
            btnCreate.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
            btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            btnDiscard.Image = TimeKeepingSystemUI.Properties.Resources.discard15;
            btnPost.Image = TimeKeepingSystemUI.Properties.Resources.post15;
            btnSettings.Image = TimeKeepingSystemUI.Properties.Resources.setting15;
        }
    }
}
