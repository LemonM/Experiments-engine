namespace BouncingBall.Forms
{
    partial class ObjectExplorer
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
            this.lblName = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.lblXSpeed = new System.Windows.Forms.Label();
            this.XSpeedTextBox = new System.Windows.Forms.TextBox();
            this.YSpeedTextBox = new System.Windows.Forms.TextBox();
            this.lblYSpeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(12, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.Gray;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.Location = new System.Drawing.Point(99, 34);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(148, 19);
            this.NameTextBox.TabIndex = 1;
            // 
            // lblXSpeed
            // 
            this.lblXSpeed.AutoSize = true;
            this.lblXSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblXSpeed.Location = new System.Drawing.Point(12, 74);
            this.lblXSpeed.Name = "lblXSpeed";
            this.lblXSpeed.Size = new System.Drawing.Size(71, 20);
            this.lblXSpeed.TabIndex = 2;
            this.lblXSpeed.Text = "X Speed";
            // 
            // XSpeedTextBox
            // 
            this.XSpeedTextBox.BackColor = System.Drawing.Color.Gray;
            this.XSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.XSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XSpeedTextBox.Location = new System.Drawing.Point(99, 74);
            this.XSpeedTextBox.Name = "XSpeedTextBox";
            this.XSpeedTextBox.Size = new System.Drawing.Size(148, 19);
            this.XSpeedTextBox.TabIndex = 3;
            // 
            // YSpeedTextBox
            // 
            this.YSpeedTextBox.BackColor = System.Drawing.Color.Gray;
            this.YSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.YSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YSpeedTextBox.Location = new System.Drawing.Point(99, 113);
            this.YSpeedTextBox.Name = "YSpeedTextBox";
            this.YSpeedTextBox.Size = new System.Drawing.Size(148, 19);
            this.YSpeedTextBox.TabIndex = 5;
            // 
            // lblYSpeed
            // 
            this.lblYSpeed.AutoSize = true;
            this.lblYSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblYSpeed.Location = new System.Drawing.Point(12, 113);
            this.lblYSpeed.Name = "lblYSpeed";
            this.lblYSpeed.Size = new System.Drawing.Size(71, 20);
            this.lblYSpeed.TabIndex = 4;
            this.lblYSpeed.Text = "Y Speed";
            // 
            // ObjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(259, 412);
            this.ControlBox = false;
            this.Controls.Add(this.YSpeedTextBox);
            this.Controls.Add(this.lblYSpeed);
            this.Controls.Add(this.XSpeedTextBox);
            this.Controls.Add(this.lblXSpeed);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ObjectExplorer";
            this.Text = "ObjectExplorer";
            this.Load += new System.EventHandler(this.ObjectExplorer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblXSpeed;
        private System.Windows.Forms.Label lblYSpeed;
        public System.Windows.Forms.TextBox NameTextBox;
        public System.Windows.Forms.TextBox XSpeedTextBox;
        public System.Windows.Forms.TextBox YSpeedTextBox;
    }
}