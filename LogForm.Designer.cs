namespace Client
{
    partial class LogForm
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
            this.LogTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogTXT2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BTN_CLEAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogTXT
            // 
            this.LogTXT.Location = new System.Drawing.Point(12, 25);
            this.LogTXT.Multiline = true;
            this.LogTXT.Name = "LogTXT";
            this.LogTXT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTXT.Size = new System.Drawing.Size(452, 151);
            this.LogTXT.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Server";
            // 
            // LogTXT2
            // 
            this.LogTXT2.Location = new System.Drawing.Point(12, 199);
            this.LogTXT2.Multiline = true;
            this.LogTXT2.Name = "LogTXT2";
            this.LogTXT2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTXT2.Size = new System.Drawing.Size(452, 151);
            this.LogTXT2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Client";
            // 
            // BTN_CLEAR
            // 
            this.BTN_CLEAR.Location = new System.Drawing.Point(188, 356);
            this.BTN_CLEAR.Name = "BTN_CLEAR";
            this.BTN_CLEAR.Size = new System.Drawing.Size(75, 23);
            this.BTN_CLEAR.TabIndex = 10;
            this.BTN_CLEAR.Text = "Clear";
            this.BTN_CLEAR.UseVisualStyleBackColor = true;
            this.BTN_CLEAR.Click += new System.EventHandler(this.BTN_CLEAR_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 387);
            this.Controls.Add(this.BTN_CLEAR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LogTXT2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogTXT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LogForm";
            this.Text = "Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LogTXT2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTN_CLEAR;
    }
}