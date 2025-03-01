using System.Drawing;
using System.Windows.Forms;

namespace TimeKeepingSystemUI.ModifiedControls
{
    public class TabControl : System.Windows.Forms.TabControl
    {
        public TabControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            TabPage currentTab = this.SelectedTab;
            for (int i = 0; i < TabPages.Count; i++)
            {
                TabPage tp = TabPages[i];
                Rectangle r = GetTabRect(i);
                Brush b = (tp == currentTab ? new SolidBrush(Code.Program.HoverColor) : new SolidBrush(Code.Program.MainColor));
                Font f = (tp == currentTab) ? new Font(tp.Font, FontStyle.Bold) : new Font(tp.Font,FontStyle.Regular);
                g.FillRectangle(b, r);
                TextRenderer.DrawText(g, tp.Text, f, r,Code.Program.TextColor);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }
    }
}
