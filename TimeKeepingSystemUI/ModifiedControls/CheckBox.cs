
using System.Drawing;

namespace TimeKeepingSystemUI.ModifiedControls
{
    public class CheckBox : System.Windows.Forms.CheckBox
    {
        public CheckBox()
        {
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.Black;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.CheckedBackColor = Code.Program.MainColor;
            FlatAppearance.MouseOverBackColor = Code.Program.HoverColor;
            FlatAppearance.MouseDownBackColor = Code.Program.MainColor;
        }
    }
}
