using System.Windows.Forms;
using TimeKeepingCode;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlForms : UserControl
    {
        public UsrCntrlForms()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            ucBasicProfileEmployee.SelectedEmployee += SelectedEmployee;
        }

        public void FirstFocus() 
        {
            ucBasicProfileEmployee.Focus();
        }

        private static UsrCntrlForms instance;
        public static UsrCntrlForms Instance {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlForms();
                    instance.Name = "singletonUsrCntrlForms";
                    return instance;
                }

                return instance;
            }
        }

        private void SelectedEmployee(object sender,TimeKeepingCode.Events.BasicInfoOnSelectedEventArgs e) 
        {
            LoadAllData(e.Selected);
        }

        private void LoadAllData(TimeKeepingDataCode.PayrollSystem.BasicEmployeeInfo employee) 
        {
            for (int i = 0; i < tabForms.TabPages.Count; i++)
            {
                for (int a = 0; a < tabForms.TabPages[i].Controls.Count; a++)
                {
                    if (tabForms.TabPages[i].Controls[a] is TimeKeepingCode.Code.IForms) 
                    {
                        TimeKeepingCode.Code.IForms form = tabForms.TabPages[i].Controls[a] as TimeKeepingCode.Code.IForms;
                        form.LoadData(employee);
                    }
                }
            }
        }

        private void CreateClick(object sender, System.EventArgs e)
        {
            Roles role = Roles.LeaveUndertime;
            if (tabForms.SelectedIndex == 0)
                role = Roles.LeaveUndertime;
            else if (tabForms.SelectedIndex == 1)
                role = Roles.ChangeRestday;
            else if (tabForms.SelectedIndex == 2)
                role = Roles.PRW;
            else if (tabForms.SelectedIndex == 3)
                role = Roles.ChangeShift;

            if (!IsAuthorized.IsHaveUserAccess(role, UserRoles.CanCreate))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IForms)
                {
                    TimeKeepingCode.Code.IForms form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IForms;
                    if (form.Action == TimeKeepingCode.UserAction.View)
                    {
                        if (form.Create())
                        {
                            Viewable(false);
                            lblAction.Text = "Creating " + form.FormText;
                        }
                    }
                    else
                    {
                        if (form.Save())
                        {
                            Viewable(true);
                            lblAction.Text = "Viewing " + form.FormText;
                        }
                    }
                }
            }
        }

        private void SetButtons() 
        {
            btnCreateSchedule.BackColor = Code.Program.MainColor;
            btnUpdateSchedule.BackColor = Code.Program.MainColor;
            btnPost.BackColor = Code.Program.MainColor;
            btnCancel.BackColor = Code.Program.MainColor;

            btnCreateSchedule.ForeColor = Code.Program.TextColor;
            btnUpdateSchedule.ForeColor = Code.Program.TextColor;
            btnCancel.ForeColor = Code.Program.TextColor;
            btnPost.ForeColor = Code.Program.TextColor;

            btnPrint.BackColor = Code.Program.MainColor;
            btnPrint.ForeColor = Code.Program.TextColor;

            lblAction.ForeColor = Code.Program.MainColor;
        }

        private void FormLoad(object sender, System.EventArgs e)
        {
            SetImage();
            SetButtons();
            ucBasicProfileEmployee.Focus();
        }

        private void TabFormSelectedIndexChanged(object sender, System.EventArgs e)
        {
            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IForms) 
                {
                    TimeKeepingCode.Code.IForms form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IForms;
                    if (form.Action == TimeKeepingCode.UserAction.View)
                    {
                        Viewable(true);
                        lblAction.Text = "Viewing " + form.FormText;
                    }
                    else if (form.Action == TimeKeepingCode.UserAction.Create || form.Action == TimeKeepingCode.UserAction.Update)
                    {
                        Viewable(false);
                        if (form.Action == TimeKeepingCode.UserAction.Create)
                            lblAction.Text = "Creating " + form.FormText;
                        else
                            lblAction.Text = "Updating " + form.FormText;
                    }
                }
            }
        }

        private void Viewable(bool b) 
        {
            if (b)
            {
                btnCreateSchedule.Text = "CREATE";
                btnUpdateSchedule.Text = "UPDATE";

                btnCreateSchedule.Image = global::TimeKeepingSystemUI.Properties.Resources.addNew15;
                btnUpdateSchedule.Image = global::TimeKeepingSystemUI.Properties.Resources.edit15;
            }
            else {
                btnCreateSchedule.Text = "SAVE";
                btnUpdateSchedule.Text = "CANCEL";

                btnCreateSchedule.Image = global::TimeKeepingSystemUI.Properties.Resources.save15;
                btnUpdateSchedule.Image = global::TimeKeepingSystemUI.Properties.Resources.cancel15;
            }

            btnCancel.Enabled = b;
            btnPost.Enabled = b;
        }

        private void UpdateClick(object sender, System.EventArgs e)
        {
            Roles role = Roles.LeaveUndertime;
            if (tabForms.SelectedIndex == 0)
                role = Roles.LeaveUndertime;
            else if (tabForms.SelectedIndex == 1)
                role = Roles.ChangeRestday;
            else if (tabForms.SelectedIndex == 2)
                role = Roles.PRW;
            else if (tabForms.SelectedIndex == 3)
                role = Roles.ChangeShift;

            if (!IsAuthorized.IsHaveUserAccess(role, UserRoles.CanUpdate))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IForms)
                {
                    TimeKeepingCode.Code.IForms form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IForms;
                    if (form.Action == TimeKeepingCode.UserAction.View)
                    {
                        if (form.Edit())
                        {
                            Viewable(false);
                            lblAction.Text = "Updating " + form.FormText ;
                        }
                    }
                    else
                    {
                        if (form.Cancel())
                        {
                            Viewable(true);
                            lblAction.Text = "Viewing " + form.FormText;
                        }
                    }
                }
            }
        }

        private void CancelClick(object sender, System.EventArgs e)
        {
            Roles role = Roles.LeaveUndertime;
            if (tabForms.SelectedIndex == 0)
                role = Roles.LeaveUndertime;
            else if (tabForms.SelectedIndex == 1)
                role = Roles.ChangeRestday;
            else if (tabForms.SelectedIndex == 2)
                role = Roles.PRW;
            else if (tabForms.SelectedIndex == 3)
                role = Roles.ChangeShift;

            if (!IsAuthorized.IsHaveUserAccess(role, UserRoles.CanUnpost))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.ICancellable)
                {
                    TimeKeepingCode.Code.ICancellable form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.ICancellable;
                    form.CancelTransaction();
                }
                else {
                    MessageBox.Show("Can't allow Discard Action.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
            }
        }

        private void PostClick(object sender, System.EventArgs e)
        {
            Roles role = Roles.LeaveUndertime;
            if (tabForms.SelectedIndex == 0)
                role = Roles.LeaveUndertime;
            else if (tabForms.SelectedIndex == 1)
                role = Roles.ChangeRestday;
            else if (tabForms.SelectedIndex == 2)
                role = Roles.PRW;
            else if (tabForms.SelectedIndex == 3)
                role = Roles.ChangeShift;

            if (!IsAuthorized.IsHaveUserAccess(role, UserRoles.CanPost))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IPost)
                {
                    TimeKeepingCode.Code.IPost form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IPost;
                    form.PostTransaction();
                }
                else
                {
                    MessageBox.Show("Can't allow Post Action.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void PrintClick(object sender, System.EventArgs e)
        {
            Roles role = Roles.LeaveUndertime;
            if (tabForms.SelectedIndex == 0)
                role = Roles.LeaveUndertime;
            else if (tabForms.SelectedIndex == 1)
                role = Roles.ChangeRestday;
            else if (tabForms.SelectedIndex == 2)
                role = Roles.PRW;
            else if (tabForms.SelectedIndex == 3)
                role = Roles.ChangeShift;

            if (!IsAuthorized.IsHaveUserAccess(role, UserRoles.CanGenerateReport))
            {
                MessageBox.Show("You don't have rights to access this section.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IPrint)
                {
                    TimeKeepingCode.Code.IPrint form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IPrint;
                    form.Print();
                }
                else
                {
                    MessageBox.Show("Can't allow Print Action.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void KeyEvents(object sender,KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.F1)
            {
                if (GetAction() == TimeKeepingCode.UserAction.View)
                    CreateClick(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (GetAction() == TimeKeepingCode.UserAction.View)
                    UpdateClick(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                TimeKeepingCode.UserAction action = GetAction();
                if (action == TimeKeepingCode.UserAction.Update || action == TimeKeepingCode.UserAction.Create)
                    CreateClick(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TimeKeepingCode.UserAction action = GetAction();
                if (action == TimeKeepingCode.UserAction.Update || action == TimeKeepingCode.UserAction.Create)
                    UpdateClick(sender, e);
                else if (action == TimeKeepingCode.UserAction.View)
                    Dispose();
            }
            else if (e.KeyCode == Keys.F10)
            {
                TimeKeepingCode.UserAction action = GetAction();
                if (action == TimeKeepingCode.UserAction.View)
                    PostClick(sender, e);
            }
            else if (e.KeyCode == Keys.F11)
            {
                TimeKeepingCode.UserAction action = GetAction();
                if (action == TimeKeepingCode.UserAction.View)
                    CancelClick(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                TimeKeepingCode.UserAction action = GetAction();
                if (action == TimeKeepingCode.UserAction.View)
                    PrintClick(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
                ucBasicProfileEmployee.Focus();
        }

        private TimeKeepingCode.UserAction GetAction() 
        {
            TimeKeepingCode.UserAction result = TimeKeepingCode.UserAction.NoAction;

            for (int i = 0; i < tabForms.SelectedTab.Controls.Count; i++)
            {
                if (tabForms.SelectedTab.Controls[i] is TimeKeepingCode.Code.IForms)
                {
                    TimeKeepingCode.Code.IForms form = tabForms.SelectedTab.Controls[i] as TimeKeepingCode.Code.IForms;
                    return form.Action;
                }
            }

            return result;
        }

        private void SetImage() 
        {
            this.btnPrint.Image = TimeKeepingSystemUI.Properties.Resources.print15;
            this.btnCancel.Image = TimeKeepingSystemUI.Properties.Resources.discard15;
            this.btnPost.Image = TimeKeepingSystemUI.Properties.Resources.post15;
            this.btnUpdateSchedule.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            this.btnCreateSchedule.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
        }
    }
}
