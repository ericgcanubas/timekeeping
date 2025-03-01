using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlAssignScheduleWrapper : UserControl
    {
        public UsrCntrlAssignScheduleWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlAssignScheduleWrapper instance;
        public static UsrCntrlAssignScheduleWrapper Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlAssignScheduleWrapper();
                    instance.Name = "singletonUsrCntrlAssignScheduleWrapper";
                }
                return instance;
            }
        }
    }
}
