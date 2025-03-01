using System;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingCode.Events
{
    public class BasicInfoOnSelectedEventArgs : EventArgs
    {
        public BasicEmployeeInfo Selected { get; private set; }

        public BasicInfoOnSelectedEventArgs(BasicEmployeeInfo selected)
        {
            this.Selected = selected;
        }
    }
}
