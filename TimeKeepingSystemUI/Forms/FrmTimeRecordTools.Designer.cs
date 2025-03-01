namespace TimeKeepingSystemUI.Forms
{
    partial class FrmTimeRecordTools
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimeRecordTools));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dtpTimeSummaryTo = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeSummaryFrom = new System.Windows.Forms.DateTimePicker();
            this.listResult = new System.Windows.Forms.ListBox();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.lblRepostDateTo = new System.Windows.Forms.Label();
            this.lblRepostDateFrom = new System.Windows.Forms.Label();
            this.dtpRepostFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpRepostTo = new System.Windows.Forms.DateTimePicker();
            this.lblUpdateTimeSummary = new System.Windows.Forms.Label();
            this.lblRepostTimeRecord = new System.Windows.Forms.Label();
            this.btnUpdateTimeSummary = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnRepost = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.ucHeader = new TimeKeepingSystemUI.UserControls.UsrCntrlDragableHeader();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnUpdateTimeSummary);
            this.pnlMain.Controls.Add(this.dtpTimeSummaryTo);
            this.pnlMain.Controls.Add(this.dtpTimeSummaryFrom);
            this.pnlMain.Controls.Add(this.listResult);
            this.pnlMain.Controls.Add(this.txtSearchEmployee);
            this.pnlMain.Controls.Add(this.cmbCategory);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Controls.Add(this.pnlSeparator);
            this.pnlMain.Controls.Add(this.btnRepost);
            this.pnlMain.Controls.Add(this.lblRepostDateTo);
            this.pnlMain.Controls.Add(this.lblRepostDateFrom);
            this.pnlMain.Controls.Add(this.dtpRepostFrom);
            this.pnlMain.Controls.Add(this.dtpRepostTo);
            this.pnlMain.Controls.Add(this.lblUpdateTimeSummary);
            this.pnlMain.Controls.Add(this.lblRepostTimeRecord);
            this.pnlMain.Controls.Add(this.ucHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(602, 390);
            this.pnlMain.TabIndex = 0;
            // 
            // dtpTimeSummaryTo
            // 
            this.dtpTimeSummaryTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeSummaryTo.Location = new System.Drawing.Point(438, 312);
            this.dtpTimeSummaryTo.Name = "dtpTimeSummaryTo";
            this.dtpTimeSummaryTo.Size = new System.Drawing.Size(92, 22);
            this.dtpTimeSummaryTo.TabIndex = 18;
            // 
            // dtpTimeSummaryFrom
            // 
            this.dtpTimeSummaryFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTimeSummaryFrom.Location = new System.Drawing.Point(321, 312);
            this.dtpTimeSummaryFrom.Name = "dtpTimeSummaryFrom";
            this.dtpTimeSummaryFrom.Size = new System.Drawing.Size(92, 22);
            this.dtpTimeSummaryFrom.TabIndex = 15;
            // 
            // listResult
            // 
            this.listResult.FormattingEnabled = true;
            this.listResult.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.listResult.Location = new System.Drawing.Point(321, 172);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(209, 134);
            this.listResult.TabIndex = 12;
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchEmployee.Location = new System.Drawing.Point(321, 144);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(209, 22);
            this.txtSearchEmployee.TabIndex = 13;
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.SearchChange);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "All",
            "Employment Status",
            "Per Employee",
            "Agency Guard"});
            this.cmbCategory.Location = new System.Drawing.Point(321, 117);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(209, 21);
            this.cmbCategory.TabIndex = 11;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.CategorySelectedIndex);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(318, 101);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(61, 13);
            this.lblCategory.TabIndex = 10;
            this.lblCategory.Text = "CATEGORY";
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.Location = new System.Drawing.Point(266, 64);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(5, 299);
            this.pnlSeparator.TabIndex = 9;
            // 
            // lblRepostDateTo
            // 
            this.lblRepostDateTo.AutoSize = true;
            this.lblRepostDateTo.Location = new System.Drawing.Point(11, 161);
            this.lblRepostDateTo.Name = "lblRepostDateTo";
            this.lblRepostDateTo.Size = new System.Drawing.Size(50, 13);
            this.lblRepostDateTo.TabIndex = 7;
            this.lblRepostDateTo.Text = "DATE TO";
            // 
            // lblRepostDateFrom
            // 
            this.lblRepostDateFrom.AutoSize = true;
            this.lblRepostDateFrom.Location = new System.Drawing.Point(11, 101);
            this.lblRepostDateFrom.Name = "lblRepostDateFrom";
            this.lblRepostDateFrom.Size = new System.Drawing.Size(68, 13);
            this.lblRepostDateFrom.TabIndex = 6;
            this.lblRepostDateFrom.Text = "DATE FROM";
            // 
            // dtpRepostFrom
            // 
            this.dtpRepostFrom.Location = new System.Drawing.Point(14, 117);
            this.dtpRepostFrom.Name = "dtpRepostFrom";
            this.dtpRepostFrom.Size = new System.Drawing.Size(200, 22);
            this.dtpRepostFrom.TabIndex = 5;
            // 
            // dtpRepostTo
            // 
            this.dtpRepostTo.Location = new System.Drawing.Point(14, 177);
            this.dtpRepostTo.Name = "dtpRepostTo";
            this.dtpRepostTo.Size = new System.Drawing.Size(200, 22);
            this.dtpRepostTo.TabIndex = 4;
            // 
            // lblUpdateTimeSummary
            // 
            this.lblUpdateTimeSummary.AutoSize = true;
            this.lblUpdateTimeSummary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTimeSummary.Location = new System.Drawing.Point(318, 64);
            this.lblUpdateTimeSummary.Name = "lblUpdateTimeSummary";
            this.lblUpdateTimeSummary.Size = new System.Drawing.Size(149, 17);
            this.lblUpdateTimeSummary.TabIndex = 3;
            this.lblUpdateTimeSummary.Text = "Update Time Summary";
            // 
            // lblRepostTimeRecord
            // 
            this.lblRepostTimeRecord.AutoSize = true;
            this.lblRepostTimeRecord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepostTimeRecord.Location = new System.Drawing.Point(11, 64);
            this.lblRepostTimeRecord.Name = "lblRepostTimeRecord";
            this.lblRepostTimeRecord.Size = new System.Drawing.Size(137, 17);
            this.lblRepostTimeRecord.TabIndex = 1;
            this.lblRepostTimeRecord.Text = "Repost Time Records";
            // 
            // btnUpdateTimeSummary
            // 
            this.btnUpdateTimeSummary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateTimeSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTimeSummary.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTimeSummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateTimeSummary.Location = new System.Drawing.Point(321, 340);
            this.btnUpdateTimeSummary.Name = "btnUpdateTimeSummary";
            this.btnUpdateTimeSummary.Size = new System.Drawing.Size(209, 23);
            this.btnUpdateTimeSummary.TabIndex = 19;
            this.btnUpdateTimeSummary.Text = "Update Time Summary";
            this.btnUpdateTimeSummary.UseVisualStyleBackColor = true;
            this.btnUpdateTimeSummary.Click += new System.EventHandler(this.UpdateTimeSummaryClicked);
            // 
            // btnRepost
            // 
            this.btnRepost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepost.Location = new System.Drawing.Point(109, 242);
            this.btnRepost.Name = "btnRepost";
            this.btnRepost.Size = new System.Drawing.Size(105, 23);
            this.btnRepost.TabIndex = 8;
            this.btnRepost.Text = "Repost";
            this.btnRepost.UseVisualStyleBackColor = true;
            this.btnRepost.Click += new System.EventHandler(this.RepostClick);
            // 
            // ucHeader
            // 
            this.ucHeader.BackColor = System.Drawing.Color.White;
            this.ucHeader.CloseButton = true;
            this.ucHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucHeader.IsHeaderShown = true;
            this.ucHeader.Location = new System.Drawing.Point(0, 0);
            this.ucHeader.MaximizeButton = false;
            this.ucHeader.MinimizeButton = true;
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.SetHeaderText = "Time Record Tools";
            this.ucHeader.Size = new System.Drawing.Size(600, 31);
            this.ucHeader.TabIndex = 0;
            // 
            // tmr
            // 
            this.tmr.Interval = 500;
            this.tmr.Tick += new System.EventHandler(this.TimerTick);
            // 
            // FrmTimeRecordTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 390);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimeRecordTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Record Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private UserControls.UsrCntrlDragableHeader ucHeader;
        private System.Windows.Forms.Label lblUpdateTimeSummary;
        private System.Windows.Forms.Label lblRepostTimeRecord;
        private System.Windows.Forms.Label lblRepostDateTo;
        private System.Windows.Forms.Label lblRepostDateFrom;
        private System.Windows.Forms.DateTimePicker dtpRepostFrom;
        private System.Windows.Forms.DateTimePicker dtpRepostTo;
        private System.Windows.Forms.Panel pnlSeparator;
        private ModifiedControls.Button btnRepost;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.ListBox listResult;
        private ModifiedControls.Button btnUpdateTimeSummary;
        private System.Windows.Forms.DateTimePicker dtpTimeSummaryTo;
        private System.Windows.Forms.DateTimePicker dtpTimeSummaryFrom;
        private System.Windows.Forms.Timer tmr;
    }
}