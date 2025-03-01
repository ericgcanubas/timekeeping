namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlitem
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
            this.lblItemName = new System.Windows.Forms.Label();
            this.picItem = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(3, 120);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(149, 24);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item Name";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblItemName.Click += new System.EventHandler(this.OnClick);
            this.lblItemName.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lblItemName.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // picItem
            // 
            this.picItem.Location = new System.Drawing.Point(27, 15);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(100, 100);
            this.picItem.TabIndex = 0;
            this.picItem.TabStop = false;
            this.picItem.Click += new System.EventHandler(this.OnClick);
            this.picItem.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.picItem.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            // 
            // UsrCntrlitem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.picItem);
            this.Controls.Add(this.lblItemName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UsrCntrlitem";
            this.Size = new System.Drawing.Size(155, 155);
            this.Load += new System.EventHandler(this.FormLoad);
            this.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label lblItemName;
    }
}
