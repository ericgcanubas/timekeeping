namespace TimeKeepingSystemUI.Reports
{
    partial class FormPreviewReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usrCntrlDragableHeader1 = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // usrCntrlDragableHeader1
            // 
            this.usrCntrlDragableHeader1.BackColor = System.Drawing.Color.White;
            this.usrCntrlDragableHeader1.CloseButton = true;
            this.usrCntrlDragableHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.usrCntrlDragableHeader1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrCntrlDragableHeader1.IsHeaderShown = false;
            this.usrCntrlDragableHeader1.Location = new System.Drawing.Point(0, 0);
            this.usrCntrlDragableHeader1.MaximizeButton = true;
            this.usrCntrlDragableHeader1.MinimizeButton = true;
            this.usrCntrlDragableHeader1.Name = "usrCntrlDragableHeader1";
            this.usrCntrlDragableHeader1.SetHeaderText = "Header Text";
            this.usrCntrlDragableHeader1.Size = new System.Drawing.Size(915, 30);
            this.usrCntrlDragableHeader1.TabIndex = 0;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 30);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Size = new System.Drawing.Size(915, 494);
            this.rptViewer.TabIndex = 1;
            // 
            // FormPreviewReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 524);
            this.Controls.Add(this.rptViewer);
            this.Controls.Add(this.usrCntrlDragableHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPreviewReport";
            this.Text = "Preview Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.FormPreviewReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UsrCntrlDragableHeader usrCntrlDragableHeader1;
        public Microsoft.Reporting.WinForms.ReportViewer rptViewer;



    }
}