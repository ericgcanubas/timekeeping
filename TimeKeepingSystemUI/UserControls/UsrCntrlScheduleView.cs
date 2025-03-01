using System;
using System.Windows.Forms;
using TimeKeepingCode.Code;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlScheduleView : UserControl
    {
        public UsrCntrlScheduleView()
        {
            InitializeComponent();
        }

        public string HeaderText {
            get { return this.gbSchedule.Text; }
            set { this.gbSchedule.Text = value; }
        }

        public void LoadSchedule(Schedule schedule) 
        {
            if (!Schedule.IsEmptyNull(schedule))
            {
                lblScheduleType.Text = "Schedule Type: " + schedule.ScheduleType;
                lblShiftingName.Text = "Shifting Name: " + schedule.ShiftingName;
                lblShiftingType.Text = "Shifting Type: " + schedule.ShiftingType;
                lblAmIn.Text = "Am In: " + (schedule.AmIn.IsFilter ? DateTime.Today.Add(schedule.AmIn.Value).ToString("hh:mm tt") : string.Empty);
                lblLunchOut.Text = "Lunch Out: " + (schedule.LunchOut.IsFilter ? DateTime.Today.Add(schedule.LunchOut.Value).ToString("hh:mm tt") : string.Empty);
                lblLunchIn.Text = "Lunch In: " + (schedule.LunchIn.IsFilter ? DateTime.Today.Add(schedule.LunchIn.Value).ToString("hh:mm tt") : string.Empty);
                lblCoffeeOut.Text = "Coffee Out: " + (schedule.CoffeeOut.IsFilter ? DateTime.Today.Add(schedule.CoffeeOut.Value).ToString("hh:mm tt") : string.Empty);
                lblCoffeeIn.Text = "Coffee In: " + (schedule.CoffeeIn.IsFilter ? DateTime.Today.Add(schedule.CoffeeIn.Value).ToString("hh:mm tt") : string.Empty);
                lblPmOut.Text = "Pm Out: " + (schedule.PmOut.IsFilter ? DateTime.Today.Add(schedule.PmOut.Value).ToString("hh:mm tt") : string.Empty);
                lblLunchtime.Text = "Lunchtime: " + schedule.Lunchtime + " mins";
                lblBreaktime.Text = "Breaktime: " + schedule.Breaktime + " mins";
                chkIsFixed.Checked = schedule.IsFixed;
            }
            else {
                ClearText();
            }
        }

        public void ClearText() 
        {
            lblScheduleType.Text = "Schedule Type: ";
            lblShiftingName.Text = "Shifting Name: ";
            lblShiftingType.Text = "Shifting Type: ";
            lblAmIn.Text = "Am In: ";
            lblLunchOut.Text = "Lunch Out: ";
            lblLunchIn.Text = "Lunch In: ";
            lblCoffeeOut.Text = "Coffee Out: ";
            lblCoffeeIn.Text = "Coffee In: ";
            lblPmOut.Text = "Pm Out: ";
            lblLunchtime.Text = "Lunchtime: 0 mins";
            lblBreaktime.Text = "Breaktime: 0 mins";
            chkIsFixed.Checked = false;
        }

        private void SetControls() {
            gbSchedule.BackColor = Code.Program.MainColor;
            lblScheduleType.ForeColor = Code.Program.TextColor;
            lblShiftingName.ForeColor = Code.Program.TextColor;
            lblShiftingType.ForeColor = Code.Program.TextColor;
            lblAmIn.ForeColor = Code.Program.TextColor;
            lblLunchOut.ForeColor = Code.Program.TextColor;
            lblLunchIn.ForeColor = Code.Program.TextColor;
            lblCoffeeOut.ForeColor = Code.Program.TextColor;
            lblCoffeeIn.ForeColor = Code.Program.TextColor;
            lblPmOut.ForeColor = Code.Program.TextColor;
            lblLunchtime.ForeColor = Code.Program.TextColor;
            lblBreaktime.ForeColor = Code.Program.TextColor;
            chkIsFixed.ForeColor = Code.Program.TextColor;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //SetControls();
        }
    }
}
