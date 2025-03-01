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
    public partial class UsrCntrlHolidayDetails : UserControl
    {
        private TimeKeepingCode.UserAction action;
        private TimeKeepingDataCode.Biometrics.Holiday holiday;
        private int lastId;

        public UsrCntrlHolidayDetails()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.lastId = 0;
        }

        public void Create() 
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            this.holiday = new TimeKeepingDataCode.Biometrics.Holiday
                (0, serverDate, TimeKeepingCode.Program.User.UserName, string.Empty, string.Empty);
            this.action = TimeKeepingCode.UserAction.Create;
            this.lastId = 0;
            AddTabSchedule(new TimeKeepingDataCode.Biometrics.HolidayName
                (this.lastId,this.holiday.CntrlId,string.Empty,serverDate,"Regular"),TimeKeepingCode.UserAction.Create);
        }

        public void View(TimeKeepingDataCode.Biometrics.Holiday holiday) 
        {
            this.holiday = holiday;
            this.action = TimeKeepingCode.UserAction.View;
            this.lastId = TimeKeepingDataCode.Biometrics.HolidayName.GetLastId(TimeKeepingCode.Program.BiometricsConnection,this.holiday.CntrlId);

            var holidays = TimeKeepingDataCode.Biometrics.HolidayName.GetAllHolidayNames(TimeKeepingCode.Program.BiometricsConnection, this.holiday.CntrlId);
            for (int i = 0; i < holidays.Count; i++)
            {
                AddTabSchedule(holidays[i],TimeKeepingCode.UserAction.View);
            }
            txtRemarks.Text = this.holiday.Remarks;
            txtRemarks.ReadOnly = true;
            btnSave.Visible = false;
            btnCancel.Text = "Back";
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        public void Update(TimeKeepingDataCode.Biometrics.Holiday holiday) 
        {
            this.holiday = holiday;
            this.action = TimeKeepingCode.UserAction.Update;
            this.lastId = TimeKeepingDataCode.Biometrics.HolidayName.GetLastId(TimeKeepingCode.Program.BiometricsConnection, this.holiday.CntrlId);

            var holidays = TimeKeepingDataCode.Biometrics.HolidayName.GetAllHolidayNames(TimeKeepingCode.Program.BiometricsConnection, this.holiday.CntrlId);
            for (int i = 0; i < holidays.Count; i++)
            {
                AddTabSchedule(holidays[i],TimeKeepingCode.UserAction.Update);
            }
        }

        private static UsrCntrlHolidayDetails instance;
        public static UsrCntrlHolidayDetails Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlHolidayDetails();
                    instance.Name = "singletonUsrCntrlHolidayDetails";
                }
                return instance;
            }
        }

        private void AddScheduleClick(object sender, EventArgs e)
        {
            DateTime serverDate = TimeKeepingCode.Program.BiometricsConnection.ServerDate();
            this.lastId++;
            AddTabSchedule(new TimeKeepingDataCode.Biometrics.HolidayName
                (this.lastId,this.holiday.CntrlId,string.Empty,serverDate,"Regular"),TimeKeepingCode.UserAction.Create);
        }

        private void AddTabSchedule(TimeKeepingDataCode.Biometrics.HolidayName holidayName,TimeKeepingCode.UserAction action) 
        {
            TabPage page = new TabPage("Schedule");
            page.BackColor = Color.White;

            var h = new UsrCntrlHolidaySchedule();
            page.Controls.Add(h);
            tabSchedules.TabPages.Add(page);

            if (action == TimeKeepingCode.UserAction.Create)
                h.Create(holidayName);
            else if (action == TimeKeepingCode.UserAction.View || this.action == TimeKeepingCode.UserAction.Update)
                h.ViewUpdate(holidayName,action);
                
            tabSchedules.SelectedTab = page;
        }

        private void ViewTabSchedule() 
        {
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.HolidayName.GetAllHolidayNames
                    (TimeKeepingCode.Program.BiometricsConnection, this.holiday.CntrlId);
            }).ContinueWith(a => {
                if (a.Result != null) { 
                    
                }
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
            
        }

        private void SaveClick(object sender, EventArgs e)
        {
            if (tabSchedules.TabCount == 0) {
                MessageBox.Show("Can't Save with Empty Schedule.");
                return;
            }

            if (this.action == TimeKeepingCode.UserAction.Create) {
                if (MessageBox.Show("Are you sure to Save Created Holiday?", "Save Created", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                if (MessageBox.Show("Are you sure to Save Updated Holiday?", "Save Updated", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (this.action == TimeKeepingCode.UserAction.Create) {
                List<TimeKeepingDataCode.Biometrics.HolidayName> holidayName = new List<TimeKeepingDataCode.Biometrics.HolidayName>();
                List<TimeKeepingDataCode.Biometrics.HolidayEmployees> employees = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();

                this.holiday.Remarks = txtRemarks.Text;

                for (int i = 0; i < tabSchedules.TabPages.Count; i++)
                {
                    if (tabSchedules.TabPages[i].Controls[0] is UsrCntrlHolidaySchedule)
                    {
                        var schedule = tabSchedules.TabPages[i].Controls[0] as UsrCntrlHolidaySchedule;

                        holidayName.Add(schedule.HolidayName);
                        employees.AddRange(schedule.GetEmployees);
                        this.holiday.EffectDates += string.IsNullOrEmpty(this.holiday.EffectDates) ?
                            schedule.HolidayName.Date.ToShortDateString() : "," + schedule.HolidayName.Date.ToShortDateString();
                    }
                }
                if (TimeKeepingDataCode.Biometrics.Holiday.CreateHoliday(TimeKeepingCode.Program.BiometricsConnection,
                    this.holiday, holidayName, employees))
                {
                    MessageBox.Show("Holiday Successfuly Created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                    UsrCntrlHoliday.Instance.LoadHolidays();
                }
                else {
                    MessageBox.Show("Failed to Save Created Holiday.","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else if (this.action == TimeKeepingCode.UserAction.Update) {
                List<TimeKeepingDataCode.Biometrics.HolidayName> holidayName = new List<TimeKeepingDataCode.Biometrics.HolidayName>();
                List<TimeKeepingDataCode.Biometrics.HolidayEmployees> employees = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();
                List<TimeKeepingDataCode.Biometrics.HolidayName> newHolidayName = new List<TimeKeepingDataCode.Biometrics.HolidayName>();
                List<TimeKeepingDataCode.Biometrics.HolidayEmployees> newEmployees = new List<TimeKeepingDataCode.Biometrics.HolidayEmployees>();

                for (int i = 0; i < tabSchedules.TabPages.Count; i++)
                {
                    if (tabSchedules.TabPages[i].Controls[0] is UsrCntrlHolidaySchedule)
                    {
                        var schedule = tabSchedules.TabPages[i].Controls[0] as UsrCntrlHolidaySchedule;

                        if (schedule.IsNew)
                        {
                            newHolidayName.Add(schedule.HolidayName);
                            newEmployees.AddRange(schedule.GetEmployees);
                        }
                        else {
                            holidayName.Add(schedule.HolidayName);
                            employees.AddRange(schedule.GetEmployees);
                        }
                        this.holiday.EffectDates += string.IsNullOrEmpty(this.holiday.EffectDates) ?
                            schedule.HolidayName.Date.ToShortDateString() : "," + schedule.HolidayName.Date.ToShortDateString();
                    }
                }

                if (TimeKeepingDataCode.Biometrics.Holiday.UpdateHoliday(TimeKeepingCode.Program.BiometricsConnection,
                    this.holiday, holidayName, employees, newHolidayName, newEmployees))
                {
                    MessageBox.Show("Holiday Successfuly Updated.", "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Dispose();
                    UsrCntrlHoliday.Instance.LoadHolidays();
                }
                else {
                    MessageBox.Show("Holiday Failed to Save.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void CancelClick(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void SetControls() 
        {
            btnSave.BackColor = Code.Program.MainColor;
            btnSave.ForeColor = Code.Program.TextColor;
            btnCancel.BackColor = Code.Program.MainColor;
            btnCancel.ForeColor = Code.Program.TextColor;

            pnlHeaderDetail.BackColor = Code.Program.HoverColor;

            btnAdd.BackColor = Code.Program.TextColor;
            btnAdd.ForeColor = Code.Program.MainColor;
            btnDelete.BackColor = Code.Program.TextColor;
            btnDelete.ForeColor = Code.Program.MainColor;
            lblRemarks.ForeColor = Code.Program.TextColor;

            btnSave.Image = TimeKeepingSystemUI.Properties.Resources.save15;
            btnCancel.Image = TimeKeepingSystemUI.Properties.Resources.cancel15;
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            if (tabSchedules.TabCount > 0) {
                if(tabSchedules.SelectedTab.Controls.Count > 0)
                {
                    UsrCntrlHolidaySchedule holidaySched = tabSchedules.SelectedTab.Controls[0] as UsrCntrlHolidaySchedule;
                    if (holidaySched.IsPayrollLocked)
                    {
                        MessageBox.Show("Can't Delete Holiday Already Locked.","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else {
                        tabSchedules.TabPages.Remove(tabSchedules.SelectedTab);
                        tabSchedules.Refresh();
                    }
                }
            }
        }
    }
}
