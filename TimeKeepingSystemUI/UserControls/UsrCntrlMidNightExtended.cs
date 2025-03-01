using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlMidNightExtended : UserControl
    {
        private List<ExtendedHour> extended;
        private List<MidNight> midNight;
        private BindingSource source;
        private TimeKeepingCode.UserAction action;

        public UsrCntrlMidNightExtended()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            gridList.AutoGenerateColumns = false;

            this.extended = new List<ExtendedHour>();
            this.midNight = new List<MidNight>();

            this.source = new BindingSource();
            this.source.CurrentChanged += OnSourceCurrentChanged;

            gridList.DataSource = this.source;
            this.action = TimeKeepingCode.UserAction.View;
        }

        private void OnSourceCurrentChanged(object sender,EventArgs e) 
        {
            if (cmbType.SelectedIndex == 0) {
                var midNight = this.source.Current as MidNight;

                if (midNight != null)
                {
                    txtDescription.Text = midNight.Description;
                    dtpDateEffect.Value = midNight.EffectDate;
                    txtTimeOut.Text = midNight.TimeOutString;
                    txtLastModified.Text = midNight.LastModified;
                }
                else {
                    ClearField();
                }
                
            }
            else if (cmbType.SelectedIndex == 1) {
                var extended = this.source.Current as ExtendedHour;
                if (extended != null)
                {
                    txtDescription.Text = extended.Description;
                    dtpDateEffect.Value = extended.EffectDate;
                    txtTimeOut.Text = extended.TimeOutString;
                    txtLastModified.Text = extended.LastModified;
                }
                else {
                    ClearField();
                }
            }
        }

        private static UsrCntrlMidNightExtended instance;
        public static UsrCntrlMidNightExtended Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlMidNightExtended();
                    instance.Name = "singletonUsrCntrlMidNightExtended";
                }

                return instance;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.midNight = MidNight.GetAllMidNight(TimeKeepingCode.Program.BiometricsConnection).OrderByDescending(m => m.EffectDate).ToList();
                this.extended = ExtendedHour.GetExtendedHours(TimeKeepingCode.Program.BiometricsConnection).OrderByDescending(x => x.EffectDate).ToList();
            }).ContinueWith(a => {
                cmbType.SelectedIndex = 0;
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
            ReadOnly(true);
            EditCreate(false);
            SetControls();
        }

        private void SelectedChanged(object sender, EventArgs e)
        {
            if (this.action != TimeKeepingCode.UserAction.View)
                return;

            if(cmbType.SelectedIndex == 0){
                this.source.DataSource = this.midNight;
            }
            else if (cmbType.SelectedIndex == 1) {
                this.source.DataSource = this.extended;
            }
            this.source.ResetBindings(false);
        }

        private void ReadOnly(bool isReadOnly) 
        {
            txtDescription.ReadOnly = isReadOnly;
            dtpDateEffect.Enabled = !isReadOnly;
            txtTimeOut.ReadOnly = isReadOnly;
            gridList.Enabled = isReadOnly;
            txtSearch.ReadOnly = !isReadOnly;
            dtpDateSearch.Enabled = isReadOnly;
            btnSearch.Enabled = isReadOnly;
        }

        private void ClearField() 
        {
            txtDescription.Text = string.Empty;
            dtpDateEffect.Value = DateTime.Now;
            txtTimeOut.Text = string.Empty;
            txtLastModified.Text = string.Empty;
        }

        private void Search(string search) 
        {
            if (cmbType.SelectedIndex == 0) {
                var result = this.midNight.FindAll(m => m.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
                this.source.DataSource = result;
            }
            else if (cmbType.SelectedIndex == 1) {
                var result = this.extended.FindAll(e => e.Description.Trim().ToLower().Contains(search.Trim().ToLower()));
                this.source.DataSource = result;
            }
            this.source.ResetBindings(false);
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void SearchClick(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0) {
                var result = this.midNight.FindAll(m => m.EffectDate.Year == dtpDateSearch.Value.Year && 
                    m.EffectDate.Month == dtpDateSearch.Value.Month && m.EffectDate.Day == dtpDateSearch.Value.Day);
                this.source.DataSource = result;
            }
            else if (cmbType.SelectedIndex == 1) {
                var result = this.extended.FindAll(x => x.EffectDate.Year == dtpDateSearch.Value.Year && 
                    x.EffectDate.Month == dtpDateSearch.Value.Month && x.EffectDate.Day == dtpDateSearch.Value.Day);
                this.source.DataSource = result;
            }

            this.source.ResetBindings(false);
        }

        private void CreateClick(object sender, EventArgs e)
        {
            this.action = TimeKeepingCode.UserAction.Create;
            ReadOnly(false);
            EditCreate(true);
            ClearField();
            txtDescription.Focus();
            txtLastModified.Text = TimeKeepingCode.Program.BiometricsConnection.ServerDate() + " - " + TimeKeepingCode.Program.User.UserName; 
        }

        private void TimeOutValidating(object sender, CancelEventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.Create ||
                this.action == TimeKeepingCode.UserAction.Update) 
            {
                if (string.IsNullOrWhiteSpace(txtTimeOut.Text))
                    return;

                DateTime date;
                if (!DateTime.TryParse(txtTimeOut.Text.Trim(), out date))
                {
                    MessageBox.Show("Invalid Time Out Time. Time must Ex. (12:00 AM) ", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                }
                else
                {
                    txtTimeOut.Text = date.ToString("hh:mm tt");
                }
            }
        }

        private void EditCreate(bool isEditCreate) 
        {
            if (!isEditCreate)
            {
                btnUpdate.Text = "Update";
                btnDelete.Text = "Delete";

                btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
                btnDelete.Image = TimeKeepingSystemUI.Properties.Resources.discard15;
            }
            else {
                btnUpdate.Text = "Save";
                btnDelete.Text = "Cancel";

                btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.save15;
                btnDelete.Image = TimeKeepingSystemUI.Properties.Resources.cancel15;
            }

            btnCreate.Visible = !isEditCreate;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.View)
            {
                if (gridList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Can't Delete With Empty List.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                //Delete
                if (cmbType.SelectedIndex == 0) {
                    if (MessageBox.Show("Are you sure to Delete Selected Mid-Night?", "Delete Selected", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    var midNight = this.source.Current as MidNight;
                    if (midNight != null)
                    {
                        if (MidNight.DeleteMidNight(TimeKeepingCode.Program.BiometricsConnection, midNight))
                        {
                            this.midNight.Remove(midNight);
                            MessageBox.Show("Mid-Night Successfully Delete.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error When Deleting Mid-Night.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("Can't Delete Empty Mid-Night.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else if (cmbType.SelectedIndex == 1) {
                    if (MessageBox.Show("Are you sure to Delete Selected Extended Hour?", "Delete Selected", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    var extended = this.source.Current as ExtendedHour;
                    if (extended != null)
                    {
                        if (ExtendedHour.DeleteExtended(TimeKeepingCode.Program.BiometricsConnection, extended))
                        {
                            this.extended.Remove(extended);
                            MessageBox.Show("Extended Hour Successfully Delete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            MessageBox.Show("Error When Deleting Extended Hour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't Delete Empty Extended Hour.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else {
                //Cancel Created or Updated
                string type = cmbType.SelectedIndex == 0 ? "Mid Night" : "Extended";
                if (this.action == TimeKeepingCode.UserAction.Create) {
                    if (MessageBox.Show("Are you sure to Cancel Created " + type + "?", "Cancel Created", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
                else if (this.action == TimeKeepingCode.UserAction.Update) {
                    if (MessageBox.Show("Are you sure to Cancel Updated " + type + "?", "Cancel Updated", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                this.action = TimeKeepingCode.UserAction.View;
                ReadOnly(true);
                EditCreate(false);
                gridList.Focus();
                cmbType.Enabled = true;
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            if (this.action == TimeKeepingCode.UserAction.View)
            {
                this.action = TimeKeepingCode.UserAction.Update;
                ReadOnly(false);
                EditCreate(true);
                txtDescription.Focus();
                txtLastModified.Text = TimeKeepingCode.Program.BiometricsConnection.ServerDate() + " - " + TimeKeepingCode.Program.User.UserName;
                cmbType.Enabled = false;
            }
            else {
                string type = cmbType.SelectedIndex == 0 ? "Mid Night" : "Extended";
                if (IsFieldsValid()) {
                    if (this.action == TimeKeepingCode.UserAction.Create) {
                        if (MessageBox.Show("Are you sure to Save Created " + type + "?", "Save Created", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;

                        if (cmbType.SelectedIndex == 0) {
                            DateTime timeOut = new DateTime(dtpDateEffect.Value.Year, dtpDateEffect.Value.Month, 
                                dtpDateEffect.Value.Day).Add(Convert.ToDateTime(txtTimeOut.Text).TimeOfDay);
                            var m = new MidNight(0, txtDescription.Text, dtpDateEffect.Value, timeOut, 0, txtLastModified.Text);
                            if (MidNight.CreateMidNight(TimeKeepingCode.Program.BiometricsConnection, m))
                            {
                                MessageBox.Show("Mid Night Successfully Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Task.Factory.StartNew(() => {
                                    this.midNight = MidNight.GetAllMidNight(TimeKeepingCode.Program.BiometricsConnection).OrderByDescending(s => s.EffectDate).ToList();
                                });
                                this.action = TimeKeepingCode.UserAction.View;
                                ReadOnly(true);
                                EditCreate(false);
                                gridList.Focus();
                            }
                            else {
                                MessageBox.Show("Mid Night Failed to Create.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        else if (cmbType.SelectedIndex == 1) {
                            DateTime timeOut = new DateTime(dtpDateEffect.Value.Year, dtpDateEffect.Value.Month,
                                dtpDateEffect.Value.Day).Add(Convert.ToDateTime(txtTimeOut.Text).TimeOfDay);
                            var x = new ExtendedHour(0, txtDescription.Text, dtpDateEffect.Value, timeOut, txtLastModified.Text);
                            if (ExtendedHour.CreateExtended(TimeKeepingCode.Program.BiometricsConnection, x))
                            {
                                MessageBox.Show("Extended Successfully Created.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Task.Factory.StartNew(() => {
                                    this.extended = ExtendedHour.GetExtendedHours(TimeKeepingCode.Program.BiometricsConnection).OrderByDescending(s => s.EffectDate).ToList();
                                });
                                this.action = TimeKeepingCode.UserAction.View;
                                ReadOnly(true);
                                EditCreate(false);
                                gridList.Focus();
                            }
                            else {
                                MessageBox.Show("Extended Failed to Create.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (this.action == TimeKeepingCode.UserAction.Update) {
                        if (MessageBox.Show("Are you sure to Save Updated " + type + "?", "Save Updated", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;

                        if (cmbType.SelectedIndex == 0) {
                            var m = this.source.Current as MidNight;
                            if (m != null)
                            {
                                m.Description = txtDescription.Text;
                                m.EffectDate = dtpDateEffect.Value;
                                m.TimeOut = dtpDateEffect.Value.Add(Convert.ToDateTime(txtTimeOut.Text).TimeOfDay);
                                m.LastModified = TimeKeepingCode.Program.BiometricsConnection.ServerDate() + " - " + TimeKeepingCode.Program.User.UserName;

                                if (MidNight.UpdateMidNight(TimeKeepingCode.Program.BiometricsConnection, m))
                                {
                                    MessageBox.Show("Mid Night Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.action = TimeKeepingCode.UserAction.View;
                                    ReadOnly(true);
                                    EditCreate(false);
                                    gridList.Focus();
                                    cmbType.Enabled = true;
                                }
                                else {
                                    MessageBox.Show("Mid Night Failed to Update.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                            }
                            else {
                                MessageBox.Show("Error When Saving Mid Night","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                        else if (cmbType.SelectedIndex == 1) {
                            var x = this.source.Current as ExtendedHour;
                            if (x != null)
                            {
                                x.Description = txtDescription.Text;
                                x.EffectDate = dtpDateEffect.Value;
                                x.TimeOut = dtpDateEffect.Value.Add(Convert.ToDateTime(txtTimeOut.Text).TimeOfDay);
                                x.LastModified = TimeKeepingCode.Program.BiometricsConnection.ServerDate() + " - " + TimeKeepingCode.Program.User.UserName;

                                if (ExtendedHour.UpdateExtended(TimeKeepingCode.Program.BiometricsConnection, x))
                                {
                                    MessageBox.Show("Extended Hour Successfully Updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.action = TimeKeepingCode.UserAction.View;
                                    ReadOnly(true);
                                    EditCreate(false);
                                    gridList.Focus();
                                    cmbType.Enabled = true;
                                }
                                else {
                                    MessageBox.Show("Extended Hour Failed to Update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else {
                                MessageBox.Show("Error When Saving Extended","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private bool IsFieldsValid() 
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text)) {
                MessageBox.Show("Description Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTimeOut.Text)) {
                MessageBox.Show("Time Out Field is Empty.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtTimeOut.Focus();
                return false;
            }

            return true;
        }

        private void SetControls() 
        {
            btnCreate.BackColor = Code.Program.MainColor;
            btnCreate.ForeColor = Code.Program.TextColor;
            btnUpdate.BackColor = Code.Program.MainColor;
            btnUpdate.ForeColor = Code.Program.TextColor;
            btnDelete.BackColor = Code.Program.MainColor;
            btnDelete.ForeColor = Code.Program.TextColor;
            btnSearch.BackColor = Code.Program.MainColor;
            btnSearch.ForeColor = Code.Program.TextColor;

            gridList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;
            gridList.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridList.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;

            btnCreate.Image = TimeKeepingSystemUI.Properties.Resources.addNew15;
            btnUpdate.Image = TimeKeepingSystemUI.Properties.Resources.edit15;
            btnDelete.Image = TimeKeepingSystemUI.Properties.Resources.discard15;
        }

        private void BreadCumbEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void BreadCumbLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
