using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlEmployeeBasicProfile : UserControl
    {
        private BindingSource searchSource;

        public delegate void OnSelectedEmployee(object sender,TimeKeepingCode.Events.BasicInfoOnSelectedEventArgs e);
        public event OnSelectedEmployee SelectedEmployee;

        public delegate void OnInnerKeyEvent(object sender, KeyEventArgs e);
        public event OnInnerKeyEvent InnerKeyEvent;

        public UsrCntrlEmployeeBasicProfile()
        {
            InitializeComponent();
            gridSearchResult.AutoGenerateColumns = false;

            this.searchSource = new BindingSource();
            this.gridSearchResult.DataSource = this.searchSource;
        }

        private void Search(string search) 
        {
            Task.Factory.StartNew(() =>
            {
                if (chkIsActive.Checked)
                    return TimeKeepingCode.Program.ActiveEmployees.FindAll(e => e.Fullname.ToUpper().Contains(search.ToUpper()));
                else
                    return TimeKeepingCode.Program.InactiveEmployees.FindAll(e => e.Fullname.ToUpper().Contains(search.ToUpper()));
            }).ContinueWith(a => {
                this.searchSource.DataSource = a.Result;
                this.searchSource.ResetBindings(false);
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SearchLeave(object sender, EventArgs e)
        {
            if (!gridSearchResult.Focused)
                gridSearchResult.Visible = false;
        }

        private void SearchKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectEmployee();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.searchSource.MoveNext();
                gridSearchResult.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
                txtIdNumber.Focus();
        }

        private void SearchEnter(object sender, EventArgs e)
        {
            gridSearchResult.Visible = true;
        }

        private void GridSearchResultKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectEmployee();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (gridSearchResult.SelectedRows.Count > 0)
                {
                    if (gridSearchResult.SelectedRows[0].Index == 0)
                        txtSearch.Focus();
                }
            }
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void LoadEmployeeDetails(BasicEmployeeInfo info) 
        {
            txtIdNumber.Text = info.IdNumber;
            txtName.Text = info.ToString();
            txtPosition.Text = info.Position;
            txtSection.Text = info.Section;
            txtDepartment.Text = info.Department;
            txtBirthday.Text = info.BirthDate.ToString("MMMM dd, yyyy");
            txtAddress.Text = info.CurrentAddress;
        }

        private void Clean() 
        {
            this.searchSource.DataSource = null;
            this.searchSource.ResetBindings(false);
        }

        private void GridSearchResultLeave(object sender, EventArgs e)
        {
            if (!txtSearch.Focused)
                gridSearchResult.Visible = false;
        }

        public void SearchFocus() 
        {
            txtSearch.Focus();
        }

        private void SearchChange(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtSearch.Text))
                Search(txtSearch.Text);
        }

        private void SelectEmployee() 
        {
            if (gridSearchResult.SelectedRows.Count > 0)
            {
                BasicEmployeeInfo info = this.searchSource.Current as BasicEmployeeInfo;
                if (info != null)
                {
                    LoadEmployeeDetails(info);
                    LoadImage(info);
                    if (SelectedEmployee != null)
                        SelectedEmployee.Invoke(this, new TimeKeepingCode.Events.BasicInfoOnSelectedEventArgs(info));
                    txtSearch.Text = string.Empty;
                    Clean();
                    txtIdNumber.Focus();
                }
            }
        }

        private void IdNumberKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtName.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void NameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPosition.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void PositionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSection.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void SectionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDepartment.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void DepartmentKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBirthday.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void BirthdayKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddress.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void AddressKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIdNumber.Focus();
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else
            {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void IsActiveKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else {
                if (InnerKeyEvent != null)
                    InnerKeyEvent.Invoke(searchSource, e);
            }
        }

        private void CheckStatusChanged(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void LoadImage(BasicEmployeeInfo employee) {

            Bitmap photo = null;
            object image = BasicEmployeeInfo.GetImage(TimeKeepingCode.Program.PayrollConnection,employee.ProfileId);
            if (image != null)
            {
                byte[] bytes = (byte[])image;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes))
                {
                    photo = new Bitmap(stream);
                }
            }
            picEmployee.Image = photo; 
        }

        private void SetImage() 
        {
            this.picEmployee.Image = TimeKeepingSystemUI.Properties.Resources.avatar80;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetImage();
        }
    }
}
