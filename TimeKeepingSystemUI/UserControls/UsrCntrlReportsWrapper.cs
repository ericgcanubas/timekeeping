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
    public partial class UsrCntrlReportsWrapper : UserControl
    {
        public UsrCntrlReportsWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlReportsWrapper instance;
        public static UsrCntrlReportsWrapper Instance {
            get {
                if(instance == null || instance.IsDisposed){
                    instance = new UsrCntrlReportsWrapper();
                    instance.Name = "singletonReportsWrapper";
                }
                return instance;
            }
        }
    }
}
