namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlToolsWrapper
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
            this.usrCntrlToolsSelection1 = new TimeKeepingSystemUI.UserControls.UsrCntrlToolsSelection();
            this.SuspendLayout();
            // 
            // usrCntrlToolsSelection1
            // 
            this.usrCntrlToolsSelection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrCntrlToolsSelection1.Location = new System.Drawing.Point(0, 0);
            this.usrCntrlToolsSelection1.Name = "usrCntrlToolsSelection1";
            this.usrCntrlToolsSelection1.Size = new System.Drawing.Size(824, 542);
            this.usrCntrlToolsSelection1.TabIndex = 0;
            this.usrCntrlToolsSelection1.Load += new System.EventHandler(this.usrCntrlToolsSelection1_Load);
            // 
            // UsrCntrlToolsWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usrCntrlToolsSelection1);
            this.DoubleBuffered = true;
            this.Name = "UsrCntrlToolsWrapper";
            this.Size = new System.Drawing.Size(824, 542);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrCntrlToolsSelection usrCntrlToolsSelection1;
    }
}
