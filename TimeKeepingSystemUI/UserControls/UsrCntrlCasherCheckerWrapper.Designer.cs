namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlCasherCheckerWrapper
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
            this.ucCheckerCasherSchedule = new TimeKeepingSystemUI.UserControls.UsrCntrlCasherCheckerSchedule();
            this.SuspendLayout();
            // 
            // ucCheckerCasherSchedule
            // 
            this.ucCheckerCasherSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCheckerCasherSchedule.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCheckerCasherSchedule.Location = new System.Drawing.Point(0, 0);
            this.ucCheckerCasherSchedule.Name = "ucCheckerCasherSchedule";
            this.ucCheckerCasherSchedule.Size = new System.Drawing.Size(914, 586);
            this.ucCheckerCasherSchedule.TabIndex = 0;
            // 
            // UsrCntrlCasherCheckerWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucCheckerCasherSchedule);
            this.DoubleBuffered = true;
            this.Name = "UsrCntrlCasherCheckerWrapper";
            this.Size = new System.Drawing.Size(914, 586);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrCntrlCasherCheckerSchedule ucCheckerCasherSchedule;
    }
}
