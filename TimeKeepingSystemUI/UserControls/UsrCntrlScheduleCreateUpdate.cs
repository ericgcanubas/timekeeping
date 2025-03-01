using System;
using System.Drawing;
using System.Windows.Forms;
using TimeKeepingCode.Code;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlScheduleCreateUpdate : UserControl
    {
        private Color headerColor;

        public delegate void OnLoadedSchedule(object sender, TimeKeepingCode.Events.ShiftingScheduleOnSelectedEventArgs e);
        public event OnLoadedSchedule SelectedSchedule;

        public delegate void OnInnerKeyEvent(object sender, KeyEventArgs e);
        public event OnInnerKeyEvent InnerKeyEvent;

        public UsrCntrlScheduleCreateUpdate()
        {
            InitializeComponent();
            this.headerColor = btnHeader.BackColor;
        }

        public string HeaderText {
            get { return btnHeader.Text; }
            set {
                btnHeader.Text = value;
            }
        }

        public void LoadData(Schedule schedule) 
        {
            if (schedule != null)
            {
                if (SelectedSchedule != null)
                    SelectedSchedule.Invoke(this,new TimeKeepingCode.Events.
                        ShiftingScheduleOnSelectedEventArgs(schedule.LoadedShifting));

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
        }

        private void HeaderClick(object sender, EventArgs e)
        {
            Forms.FrmShiftingSchedules shiftings = new Forms.FrmShiftingSchedules();
            shiftings.ShowDialog();
            shiftings.Dispose();

            if (Forms.FrmShiftingSchedules.LastSelected != null)
                LoadData(new Schedule(Forms.FrmShiftingSchedules.LastSelected));
        }

        private void HeaderMouseEnter(object sender, EventArgs e)
        {
            btnHeader.BackColor = Code.Program.HoverColor;
        }

        private void HeaderLeave(object sender, EventArgs e)
        {
            btnHeader.BackColor = Code.Program.MainColor;
        }

        private void HeaderKeyevent(object sender, KeyEventArgs e)
        {
            if (InnerKeyEvent != null)
                InnerKeyEvent.Invoke(sender,e);
        }

        private void SetControls() {
            btnHeader.BackColor = Code.Program.MainColor;
            btnHeader.ForeColor = Code.Program.TextColor;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            HeaderMouseEnter(btnHeader,e);
        }

        private void LabelClick(object sender, EventArgs e)
        {
            btnHeader.Focus();
        }
    }
}
