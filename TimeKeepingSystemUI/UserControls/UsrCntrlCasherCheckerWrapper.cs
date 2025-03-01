using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlCasherCheckerWrapper : UserControl
    {
        public UsrCntrlCasherCheckerWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlCasherCheckerWrapper instance;
        public static UsrCntrlCasherCheckerWrapper Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlCasherCheckerWrapper();
                    instance.Name = "singletonUsrCntrlCasherCheckerWrapper";
                }
                return instance;
            }
        }
    }
}
