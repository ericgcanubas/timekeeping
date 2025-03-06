using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlHolidayWrapper : UserControl
    {
        public UsrCntrlHolidayWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlHolidayWrapper instance;
        public static UsrCntrlHolidayWrapper Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlHolidayWrapper();
                    instance.Name = "singletonHolidayWrapper";
                }
                return instance;
            }
        }

        private void usrCntrlHoliday1_Load(object sender, EventArgs e)
        {

        }
    }
}
