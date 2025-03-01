namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlMenuBtn
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
            this.lblText = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.lblText.Location = new System.Drawing.Point(50, 12);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(106, 17);
            this.lblText.TabIndex = 1;
            this.lblText.Text = "Employee Profile";
            this.lblText.Click += new System.EventHandler(this.OnClick);
            this.lblText.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lblText.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(10, 5);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(40, 30);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.OnClick);
            this.picIcon.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.picIcon.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // UsrCntrlMenuBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(126)))));
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.picIcon);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlMenuBtn";
            this.Size = new System.Drawing.Size(208, 40);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblText;
    }
}
