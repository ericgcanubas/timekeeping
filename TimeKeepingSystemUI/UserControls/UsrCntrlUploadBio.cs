using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using TimeKeepingDataCode.PayrollSystem;
namespace TimeKeepingSystemUI.UserControls
{
    public partial class UsrCntrlUploadBio : UserControl
    {


        public UsrCntrlUploadBio()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private static UsrCntrlUploadBio instance;
        public static UsrCntrlUploadBio Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UsrCntrlUploadBio();
                    instance.Name = "singletonUsrCntrlUploadBio";
                }
                return instance;
            }
        }
        private void UsrCntrlUploadBio_Load(object sender, EventArgs e)
        {

          
        }

        private void LoadData()
        {
            string filePath = txtSource.Text; // Change to your actual file path

            if (File.Exists(filePath))
            {
                lvDTR.Items.Clear(); // Clear existing items before loading new data

                foreach (string line in File.ReadLines(filePath))
                {
                    var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length == 7) // Ensure correct format
                    {
                        ListViewItem item = new ListViewItem(parts[0]); // ID
                        item.SubItems.Add(parts[1]); // DateTime
                        item.SubItems.Add(parts[2]); // Time
                        string status = parts[4].ToString() ==  "0" ? "IN" : "OUT";
                        item.SubItems.Add(status); // Col1

                        item.SubItems.Add("0");
                        item.SubItems.Add("B");
                        item.SubItems.Add("1");
                        item.SubItems.Add("JUAN DELA CRUZ");
                    
                        lvDTR.Items.Add(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("File not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "DAT files (*.dat)|*.dat|All files (*.*)|*.*";
                openFileDialog.Title = "Select a DAT file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = openFileDialog.FileName; // Set the selected file path in the TextBox
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDTR.Items)
            {


               // item.SubItems[columnIndex].Text
            }
        }
    }
}
