namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlReportsWrapper
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
            this.ucReportOptions = new TimeKeepingSystemUI.UserControls.UsrCntrlReportsOptions();
            this.SuspendLayout();
            // 
            // ucReportOptions
            // 
            this.ucReportOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucReportOptions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucReportOptions.Location = new System.Drawing.Point(0, 0);
            this.ucReportOptions.Name = "ucReportOptions";
            this.ucReportOptions.Size = new System.Drawing.Size(870, 499);
            this.ucReportOptions.TabIndex = 0;
            // 
            // UsrCntrlReportsWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucReportOptions);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlReportsWrapper";
            this.Size = new System.Drawing.Size(870, 499);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrCntrlReportsOptions ucReportOptions;
    }
}
