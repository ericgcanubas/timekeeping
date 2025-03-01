using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlToolsWrapper : UserControl
    {
        public UsrCntrlToolsWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlToolsWrapper instance;
        public static UsrCntrlToolsWrapper Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new UsrCntrlToolsWrapper();
                    instance.Name = "singletonUsrCntrlToolWrapper";
                }
                return instance;
            }
        }
    }
}
