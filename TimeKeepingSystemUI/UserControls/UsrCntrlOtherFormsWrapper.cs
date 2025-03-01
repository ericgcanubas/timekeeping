using System.Windows.Forms;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlOtherFormsWrapper : UserControl
    {
        public UsrCntrlOtherFormsWrapper()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlOtherFormsWrapper instance;
        public static UsrCntrlOtherFormsWrapper Instance {
            get { 
                if(instance == null || instance.IsDisposed){
                    instance = new UsrCntrlOtherFormsWrapper();
                    instance.Name = "singletonUsrCntrlOtherFormsWrapper";
                }
                return instance;
            }
        }
    }
}
