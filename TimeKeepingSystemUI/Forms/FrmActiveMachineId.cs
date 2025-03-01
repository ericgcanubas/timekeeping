using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using TimeKeepingDataCode.PayrollSystem;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmActiveMachineId : Form
    {
        private CancellationTokenSource tokenSouce;
        private CancellationToken token;
        private List<ActiveEmployeeBioId> list;
        private System.Windows.Forms.Timer t;

        public FrmActiveMachineId()
        {
            InitializeComponent();
            this.list = new List<ActiveEmployeeBioId>();
            t = new System.Windows.Forms.Timer();

            this.tokenSouce = new CancellationTokenSource();
            this.token = this.tokenSouce.Token;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x2000000;
                return cp;
            }
        }

        private static FrmActiveMachineId instance;
        public static FrmActiveMachineId Instance {
            get {
                if (instance == null || instance.IsDisposed) {
                    instance = new FrmActiveMachineId();
                    instance.Name = "singletonFrmActiveMachineId";
                }
                return instance;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            t.Interval = 10;
            t.Tick += new EventHandler(FadeIn);
            this.Opacity = 0;
            t.Start();

            SetControl();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                this.list = ActiveEmployeeBioId.GetAllActiveEmployeeBioId(TimeKeepingCode.Program.BiometricsConnection);
            }).ContinueWith(a => {
                LoadAll();
            },this.token,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void LoadAll() {
            gridList.Rows.Clear();
            for (int i = 100; i < 1000; i++)
            {
                var e = this.list.FindAll(c => c.MachineId == i);
                if (e.Count > 0)
                {
                    for (int a = 0; a < e.Count; a++)
                    {
                        gridList.Rows.Add(i, false, e[a].Lastname + ", " + e[a].Firstname + " " + e[a].Lastname);
                    }
                }
                else {
                    gridList.Rows.Add(i,true,string.Empty);
                }
            }
        }

        private void SetControl() {
            gridList.BackgroundColor = Code.Program.MainColor;
            gridList.DefaultCellStyle.BackColor = Code.Program.MainColor;
            gridList.DefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridList.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridList.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

        }

        private void FadeIn(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
                t.Stop();
            else
                Opacity += 0.05;
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            this.tokenSouce.Cancel();
            e.Cancel = true;
            t.Tick -= FadeIn;
            t.Tick += new EventHandler(FadeOut);
            t.Start();

            if (Opacity == 0)
                e.Cancel = false;
        }

        private void FadeOut(object sender, EventArgs e)
        {
            if (this.Opacity <= 0)
            {
                t.Stop();
                Close();
            }
            else
                this.Opacity -= 0.05;
        }

        private void LoadAll(bool isActive)
        {
            gridList.Rows.Clear();
            for (int i = 100; i < 1000; i++)
            {
                var e = this.list.FindAll(c => c.MachineId == i);
                if (e.Count > 0)
                {
                    if (!isActive)
                        continue;
                    for (int a = 0; a < e.Count; a++)
                    {
                        gridList.Rows.Add(i, false, e[a].Lastname + ", " + e[a].Firstname + " " + e[a].Lastname);
                    }
                }
                else
                {
                    if (isActive)
                        continue;
                    gridList.Rows.Add(i, true, string.Empty);
                }
            }
        }

        private void CheckActiveChange(object sender, EventArgs e)
        {
            if (chkActive.Checked)
                LoadAll(true);
            else
                LoadAll(false);
        }

        private void Search(string search) {
            var s = this.list.FindAll(a => a.Lastname.ToLower().Contains(search.ToLower()) ||
                a.Firstname.ToLower().Contains(search.ToLower()));

            gridList.Rows.Clear();
            for (int i = 0; i < s.Count; i++)
            {
                gridList.Rows.Add(s[i].MachineId, false, s[i].Lastname + ", " + s[i].Firstname + " " + s[i].Lastname);
            }
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                LoadAll();
            else
                Search(txtSearch.Text);
        }
    }
}
