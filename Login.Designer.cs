namespace Client
{
    partial class Login
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
            this.BTNAccept = new System.Windows.Forms.Button();
            this.BTNCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserId = new System.Windows.Forms.TextBox();
            this.ErrorLVL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTNAccept
            // 
            this.BTNAccept.Location = new System.Drawing.Point(25, 77);
            this.BTNAccept.Name = "BTNAccept";
            this.BTNAccept.Size = new System.Drawing.Size(75, 23);
            this.BTNAccept.TabIndex = 10;
            this.BTNAccept.Text = "Accept";
            this.BTNAccept.UseVisualStyleBackColor = true;
            this.BTNAccept.Click += new System.EventHandler(this.BTNAccept_Click);
            // 
            // BTNCancel
            // 
            this.BTNCancel.Location = new System.Drawing.Point(106, 77);
            this.BTNCancel.Name = "BTNCancel";
            this.BTNCancel.Size = new System.Drawing.Size(75, 23);
            this.BTNCancel.TabIndex = 9;
            this.BTNCancel.Text = "Cancel";
            this.BTNCancel.UseVisualStyleBackColor = true;
            this.BTNCancel.Click += new System.EventHandler(this.BTNCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuario:";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(74, 32);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(100, 20);
            this.Password.TabIndex = 6;
            this.Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_KeyPress);
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(74, 6);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(100, 20);
            this.UserId.TabIndex = 5;
            this.UserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserId_KeyPress);
            // 
            // ErrorLVL
            // 
            this.ErrorLVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrorLVL.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLVL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ErrorLVL.Location = new System.Drawing.Point(4, 55);
            this.ErrorLVL.Name = "ErrorLVL";
            this.ErrorLVL.Size = new System.Drawing.Size(190, 23);
            this.ErrorLVL.TabIndex = 11;
            this.ErrorLVL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 112);
            this.Controls.Add(this.ErrorLVL);
            this.Controls.Add(this.BTNAccept);
            this.Controls.Add(this.BTNCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.UserId);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNAccept;
        private System.Windows.Forms.Button BTNCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Label ErrorLVL;
    }
}