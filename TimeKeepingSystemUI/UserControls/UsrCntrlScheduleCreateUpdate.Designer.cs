namespace TimeKeepingSystemUI.UserControls
{
    partial class UsrCntrlScheduleCreateUpdate
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
            this.lblBreaktime = new System.Windows.Forms.Label();
            this.lblLunchtime = new System.Windows.Forms.Label();
            this.lblPmOut = new System.Windows.Forms.Label();
            this.lblCoffeeIn = new System.Windows.Forms.Label();
            this.lblCoffeeOut = new System.Windows.Forms.Label();
            this.lblLunchIn = new System.Windows.Forms.Label();
            this.lblLunchOut = new System.Windows.Forms.Label();
            this.lblAmIn = new System.Windows.Forms.Label();
            this.lblShiftingType = new System.Windows.Forms.Label();
            this.lblShiftingName = new System.Windows.Forms.Label();
            this.lblScheduleType = new System.Windows.Forms.Label();
            this.chkIsFixed = new System.Windows.Forms.CheckBox();
            this.btnHeader = new TimeKeepingSystemUI.ModifiedControls.Button();
            this.SuspendLayout();
            // 
            // lblBreaktime
            // 
            this.lblBreaktime.AutoSize = true;
            this.lblBreaktime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreaktime.Location = new System.Drawing.Point(31, 182);
            this.lblBreaktime.Name = "lblBreaktime";
            this.lblBreaktime.Size = new System.Drawing.Size(64, 13);
            this.lblBreaktime.TabIndex = 75;
            this.lblBreaktime.Text = "Breaktime: ";
            this.lblBreaktime.Click += new System.EventHandler(this.LabelClick);
            this.lblBreaktime.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblBreaktime.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblLunchtime
            // 
            this.lblLunchtime.AutoSize = true;
            this.lblLunchtime.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunchtime.Location = new System.Drawing.Point(29, 169);
            this.lblLunchtime.Name = "lblLunchtime";
            this.lblLunchtime.Size = new System.Drawing.Size(66, 13);
            this.lblLunchtime.TabIndex = 74;
            this.lblLunchtime.Text = "Lunchtime: ";
            this.lblLunchtime.Click += new System.EventHandler(this.LabelClick);
            this.lblLunchtime.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblLunchtime.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblPmOut
            // 
            this.lblPmOut.AutoSize = true;
            this.lblPmOut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPmOut.Location = new System.Drawing.Point(44, 156);
            this.lblPmOut.Name = "lblPmOut";
            this.lblPmOut.Size = new System.Drawing.Size(51, 13);
            this.lblPmOut.TabIndex = 73;
            this.lblPmOut.Text = "Pm Out: ";
            this.lblPmOut.Click += new System.EventHandler(this.LabelClick);
            this.lblPmOut.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblPmOut.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblCoffeeIn
            // 
            this.lblCoffeeIn.AutoSize = true;
            this.lblCoffeeIn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoffeeIn.Location = new System.Drawing.Point(35, 143);
            this.lblCoffeeIn.Name = "lblCoffeeIn";
            this.lblCoffeeIn.Size = new System.Drawing.Size(60, 13);
            this.lblCoffeeIn.TabIndex = 72;
            this.lblCoffeeIn.Text = "Coffee In: ";
            this.lblCoffeeIn.Click += new System.EventHandler(this.LabelClick);
            this.lblCoffeeIn.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblCoffeeIn.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblCoffeeOut
            // 
            this.lblCoffeeOut.AutoSize = true;
            this.lblCoffeeOut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoffeeOut.Location = new System.Drawing.Point(25, 130);
            this.lblCoffeeOut.Name = "lblCoffeeOut";
            this.lblCoffeeOut.Size = new System.Drawing.Size(70, 13);
            this.lblCoffeeOut.TabIndex = 71;
            this.lblCoffeeOut.Text = "Coffee Out: ";
            this.lblCoffeeOut.Click += new System.EventHandler(this.LabelClick);
            this.lblCoffeeOut.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblCoffeeOut.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblLunchIn
            // 
            this.lblLunchIn.AutoSize = true;
            this.lblLunchIn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunchIn.Location = new System.Drawing.Point(38, 117);
            this.lblLunchIn.Name = "lblLunchIn";
            this.lblLunchIn.Size = new System.Drawing.Size(57, 13);
            this.lblLunchIn.TabIndex = 70;
            this.lblLunchIn.Text = "Lunch In: ";
            this.lblLunchIn.Click += new System.EventHandler(this.LabelClick);
            this.lblLunchIn.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblLunchIn.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblLunchOut
            // 
            this.lblLunchOut.AutoSize = true;
            this.lblLunchOut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunchOut.Location = new System.Drawing.Point(28, 104);
            this.lblLunchOut.Name = "lblLunchOut";
            this.lblLunchOut.Size = new System.Drawing.Size(67, 13);
            this.lblLunchOut.TabIndex = 69;
            this.lblLunchOut.Text = "Lunch Out: ";
            this.lblLunchOut.Click += new System.EventHandler(this.LabelClick);
            this.lblLunchOut.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblLunchOut.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblAmIn
            // 
            this.lblAmIn.AutoSize = true;
            this.lblAmIn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmIn.Location = new System.Drawing.Point(53, 91);
            this.lblAmIn.Name = "lblAmIn";
            this.lblAmIn.Size = new System.Drawing.Size(42, 13);
            this.lblAmIn.TabIndex = 68;
            this.lblAmIn.Text = "Am In: ";
            this.lblAmIn.Click += new System.EventHandler(this.LabelClick);
            this.lblAmIn.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblAmIn.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblShiftingType
            // 
            this.lblShiftingType.AutoSize = true;
            this.lblShiftingType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftingType.Location = new System.Drawing.Point(15, 77);
            this.lblShiftingType.Name = "lblShiftingType";
            this.lblShiftingType.Size = new System.Drawing.Size(80, 13);
            this.lblShiftingType.TabIndex = 67;
            this.lblShiftingType.Text = "Shifting Type: ";
            this.lblShiftingType.Click += new System.EventHandler(this.LabelClick);
            this.lblShiftingType.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblShiftingType.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblShiftingName
            // 
            this.lblShiftingName.AutoSize = true;
            this.lblShiftingName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShiftingName.Location = new System.Drawing.Point(9, 64);
            this.lblShiftingName.Name = "lblShiftingName";
            this.lblShiftingName.Size = new System.Drawing.Size(86, 13);
            this.lblShiftingName.TabIndex = 66;
            this.lblShiftingName.Text = "Shifting Name: ";
            this.lblShiftingName.Click += new System.EventHandler(this.LabelClick);
            this.lblShiftingName.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblShiftingName.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // lblScheduleType
            // 
            this.lblScheduleType.AutoSize = true;
            this.lblScheduleType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleType.Location = new System.Drawing.Point(9, 51);
            this.lblScheduleType.Name = "lblScheduleType";
            this.lblScheduleType.Size = new System.Drawing.Size(86, 13);
            this.lblScheduleType.TabIndex = 65;
            this.lblScheduleType.Text = "Schedule Type: ";
            this.lblScheduleType.Click += new System.EventHandler(this.LabelClick);
            this.lblScheduleType.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.lblScheduleType.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // chkIsFixed
            // 
            this.chkIsFixed.AutoSize = true;
            this.chkIsFixed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsFixed.Enabled = false;
            this.chkIsFixed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsFixed.Location = new System.Drawing.Point(42, 195);
            this.chkIsFixed.Name = "chkIsFixed";
            this.chkIsFixed.Size = new System.Drawing.Size(64, 17);
            this.chkIsFixed.TabIndex = 76;
            this.chkIsFixed.Text = "Is Fixed:";
            this.chkIsFixed.UseVisualStyleBackColor = true;
            this.chkIsFixed.Click += new System.EventHandler(this.LabelClick);
            this.chkIsFixed.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.chkIsFixed.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // btnHeader
            // 
            this.btnHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHeader.FlatAppearance.BorderSize = 0;
            this.btnHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeader.Location = new System.Drawing.Point(0, 0);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(339, 40);
            this.btnHeader.TabIndex = 77;
            this.btnHeader.Text = "Schedule";
            this.btnHeader.UseVisualStyleBackColor = true;
            this.btnHeader.Click += new System.EventHandler(this.HeaderClick);
            this.btnHeader.Enter += new System.EventHandler(this.HeaderMouseEnter);
            this.btnHeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HeaderKeyevent);
            this.btnHeader.Leave += new System.EventHandler(this.HeaderLeave);
            // 
            // UsrCntrlScheduleCreateUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnHeader);
            this.Controls.Add(this.chkIsFixed);
            this.Controls.Add(this.lblBreaktime);
            this.Controls.Add(this.lblLunchIn);
            this.Controls.Add(this.lblLunchtime);
            this.Controls.Add(this.lblScheduleType);
            this.Controls.Add(this.lblPmOut);
            this.Controls.Add(this.lblShiftingName);
            this.Controls.Add(this.lblCoffeeIn);
            this.Controls.Add(this.lblShiftingType);
            this.Controls.Add(this.lblCoffeeOut);
            this.Controls.Add(this.lblAmIn);
            this.Controls.Add(this.lblLunchOut);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UsrCntrlScheduleCreateUpdate";
            this.Size = new System.Drawing.Size(339, 234);
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBreaktime;
        private System.Windows.Forms.Label lblLunchtime;
        private System.Windows.Forms.Label lblPmOut;
        private System.Windows.Forms.Label lblCoffeeIn;
        private System.Windows.Forms.Label lblCoffeeOut;
        private System.Windows.Forms.Label lblLunchIn;
        private System.Windows.Forms.Label lblLunchOut;
        private System.Windows.Forms.Label lblAmIn;
        private System.Windows.Forms.Label lblShiftingType;
        private System.Windows.Forms.Label lblShiftingName;
        private System.Windows.Forms.Label lblScheduleType;
        private System.Windows.Forms.CheckBox chkIsFixed;
        private ModifiedControls.Button btnHeader;

    }
}
