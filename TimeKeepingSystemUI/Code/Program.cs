using System.Drawing;

namespace TimeKeepingSystemUI.Code
{
    public static class Program
    {
        public static Color MainColor { get { return Color.FromArgb(93, 109, 126); } }
        public static Color HoverColor { get { return Color.FromArgb(171, 178, 185); } }
        public static Color SeparatorColor { get { return Color.FromArgb(213, 216, 220); } }
        public static Color TextColor { get { return Color.FromArgb(251, 252, 252); } }

        public static void RunProgram() 
        {
            Forms.FrmLogin login = new Forms.FrmLogin();
            login.ShowDialog();
            login.Dispose();

            if (TimeKeepingCode.Program.User != null) {
                System.Windows.Forms.Application.Run(new Forms.FrmMain());
            }
        }
    }
}
