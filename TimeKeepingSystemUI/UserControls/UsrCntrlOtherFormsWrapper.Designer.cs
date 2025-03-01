namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlOtherFormsWrapper
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
            this.ucOtherForms = new TimeKeepingSystemUI.UserControls.UsrCntrlOtherForms();
            this.SuspendLayout();
            // 
            // ucOtherForms
            // 
            this.ucOtherForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOtherForms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucOtherForms.Location = new System.Drawing.Point(0, 0);
            this.ucOtherForms.Name = "ucOtherForms";
            this.ucOtherForms.Size = new System.Drawing.Size(811, 487);
            this.ucOtherForms.TabIndex = 0;
            // 
            // UsrCntrlOtherFormsWrapper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucOtherForms);
            this.DoubleBuffered = true;
            this.Name = "UsrCntrlOtherFormsWrapper";
            this.Size = new System.Drawing.Size(811, 487);
            this.ResumeLayout(false);

        }

        #endregion

        private UsrCntrlOtherForms ucOtherForms;
    }
}
