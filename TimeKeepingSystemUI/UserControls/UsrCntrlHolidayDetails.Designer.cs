namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlHolidayDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCancel = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnSave = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.pnlHeaderDetail = new System.Windows.Forms.Panel();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.btnDelete = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.btnAdd = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.tabSchedules = new TimeKeepingSystemUI.ModifiedControls.TabControl();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnCancel);
            this.pnlHeader.Controls.Add(this.btnSave);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(857, 44);
            this.pnlHeader.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(745, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(634, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.SaveClick);
            // 
            // pnlHeaderDetail
            // 
            this.pnlHeaderDetail.Controls.Add(this.txtRemarks);
            this.pnlHeaderDetail.Controls.Add(this.lblRemarks);
            this.pnlHeaderDetail.Controls.Add(this.btnDelete);
            this.pnlHeaderDetail.Controls.Add(this.btnAdd);
            this.pnlHeaderDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderDetail.Location = new System.Drawing.Point(0, 44);
            this.pnlHeaderDetail.Name = "pnlHeaderDetail";
            this.pnlHeaderDetail.Size = new System.Drawing.Size(857, 34);
            this.pnlHeaderDetail.TabIndex = 5;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(634, 6);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(216, 22);
            this.txtRemarks.TabIndex = 5;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(578, 11);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(50, 13);
            this.lblRemarks.TabIndex = 4;
            this.lblRemarks.Text = "Remarks";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(40, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 25);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "-";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeleteClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(5, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 25);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddScheduleClick);
            // 
            // tabSchedules
            // 
            this.tabSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSchedules.Location = new System.Drawing.Point(0, 78);
            this.tabSchedules.Name = "tabSchedules";
            this.tabSchedules.SelectedIndex = 0;
            this.tabSchedules.Size = new System.Drawing.Size(857, 544);
            this.tabSchedules.TabIndex = 6;
            // 
            // UsrCntrlHolidayDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSchedules);
            this.Controls.Add(this.pnlHeaderDetail);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlHolidayDetails";
            this.Size = new System.Drawing.Size(857, 622);
            this.Load += new System.EventHandler(this.OnLoad);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeaderDetail.ResumeLayout(false);
            this.pnlHeaderDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private ModifiedControls.Button btnCancel;
        private ModifiedControls.Button btnSave;
        private System.Windows.Forms.Panel pnlHeaderDetail;
        private ModifiedControls.Button btnDelete;
        private ModifiedControls.Button btnAdd;
        private ModifiedControls.TabControl tabSchedules;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
    }
}
