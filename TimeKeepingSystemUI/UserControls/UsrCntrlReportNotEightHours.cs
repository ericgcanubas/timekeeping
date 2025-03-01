using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlReportNotEightHours : UserControl
    {
        public UsrCntrlReportNotEightHours()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            gridResult.AutoGenerateColumns = false;
        }

        private static UsrCntrlReportNotEightHours instance;
        public static UsrCntrlReportNotEightHours Instance {
            get {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlReportNotEightHours();
                    instance.Name = "singletonReportNotEightHours";
                }
                return instance;
            }
        }

        private void FindClick(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            Task.Factory.StartNew(() =>
            {
                return TimeKeepingDataCode.Biometrics.AttendanceEmployee.NotEightHours(TimeKeepingCode.Program.BiometricsConnection, dtpDate.Value);
            }).ContinueWith(a => {
                gridResult.DataSource = a.Result;
                btnFind.Enabled = true;
            },CancellationToken.None,TaskContinuationOptions.None,TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetControls() 
        {
            gridResult.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridResult.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridResult.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            gridResult.DefaultCellStyle.SelectionForeColor = Code.Program.TextColor;

            btnFind.BackColor = Code.Program.MainColor;
            btnFind.ForeColor = Code.Program.TextColor;

            lblBreadcumbHome.ForeColor = Code.Program.MainColor;
            lblBreadcumbNotEightHours.ForeColor = Code.Program.MainColor;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            SetControls();
        }

        private void BreadCumbEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.HoverColor;
        }

        private void BreadCumbLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Code.Program.MainColor;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
