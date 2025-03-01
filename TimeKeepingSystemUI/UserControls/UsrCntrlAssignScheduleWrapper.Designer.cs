namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlAssignScheduleWrapper
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
            this.ucEmployeeSchedule = new TimeKeepingSystemUI.UserControls.UsrCntrlEmployeeSchedule();
            this.SuspendLayout();
            // 
            // ucEmployeeSchedule
            // 
            this.ucEmployeeSchedule.BackColor = System.Drawing.Color.White;
            this.ucEmployeeSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEmployeeSchedule.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEmployeeSchedule.Location = new System.Drawing.Point(0, 0);
            this.ucEmployeeSchedule.Name = "ucEmployeeSchedule";
            this.ucEmployeeSchedule.Size = new System.Drawing.Size(944, 599);
            this.ucEmployeeSchedule.TabIndex = 0;
            // 
            // UsrCntrlAssignScheduleWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucEmployeeSchedule);
            this.DoubleBuffered = true;
            this.Name = "UsrCntrlAssignScheduleWrapper";
            this.Size = new System.Drawing.Size(944, 599);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrCntrlEmployeeSchedule ucEmployeeSchedule;
    }
}
