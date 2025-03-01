using System;
using System.Windows.Forms;
using TimeKeepingCode.Code;
using TimeKeepingDataCode.Biometrics;

namespace TimeKeepingSystemUI.Forms
{
    public partial class FrmShiftingSchedules : Form
    {
        private BindingSource searchSource;

        public FrmShiftingSchedules()
        {
            InitializeComponent();
            gridSearchResult.AutoGenerateColumns = false;

            this.searchSource = new BindingSource();
            gridSearchResult.DataSource = this.searchSource;

            this.searchSource.CurrentChanged += SelectedChange;
            this.ucHeader.OnCloseClick += CloseClick;
        }

        private void SelectedChange(object sender,EventArgs e) 
        {
            ucSchedule.LoadSchedule(new Schedule(this.searchSource.Current as ShiftingSchedule));
        }

        private void SearchChange(object sender, EventArgs e)
        {
            LoadSearch(txtSearch.Text);
        }

        private void LoadSearch(string search) 
        {
            this.searchSource.DataSource = TimeKeepingCode.Program.ShiftingSchedule.
                FindAll(s => s.IsActive == true && s.ShiftingName.ToLower().Contains(search.ToLower()));
            this.searchSource.ResetBindings(false);
        }

        private void SearchKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                gridSearchResult.Focus();
                this.searchSource.MoveNext();
            }
            else if (e.KeyCode == Keys.Enter)
                SelectShifting();
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void GridKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (gridSearchResult.SelectedRows[0].Index == 0)
                    txtSearch.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SelectShifting();
            }
            else if (e.KeyCode == Keys.F6)
                txtSearch.Focus();
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public static ShiftingSchedule LastSelected { get; private set; }

        private void FormLoad(object sender, EventArgs e)
        {
            txtSearch.Text = LastSelected != null ? LastSelected.ShiftingName : string.Empty;
            SetControls();
        }

        private void SelectShifting() 
        {
            if (gridSearchResult.SelectedRows.Count > 0)
            {
                this.Close();
                LastSelected = (this.searchSource.Current as ShiftingSchedule);
            }
        }

        private void CloseClick(object sender,EventArgs e)
        {
            LastSelected = null;
        }

        private void SetControls() {
            gridSearchResult.ColumnHeadersDefaultCellStyle.BackColor = Code.Program.MainColor;
            gridSearchResult.ColumnHeadersDefaultCellStyle.ForeColor = Code.Program.TextColor;
            gridSearchResult.DefaultCellStyle.SelectionBackColor = Code.Program.HoverColor;
            ucHeader.BackColor = Code.Program.MainColor;
            ucHeader.ForeColor = Code.Program.TextColor;
        }
    }
}
