namespace ink
{
    partial class Entr
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
            this.button2Ok = new System.Windows.Forms.Button();
            this.adminCheckBox1 = new System.Windows.Forms.CheckBox();
            this.passwordTextBox1 = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2Ok
            // 
            this.button2Ok.Location = new System.Drawing.Point(144, 225);
            this.button2Ok.Name = "button2Ok";
            this.button2Ok.Size = new System.Drawing.Size(113, 44);
            this.button2Ok.TabIndex = 16;
            this.button2Ok.Text = "Ok";
            this.button2Ok.UseVisualStyleBackColor = true;
            this.button2Ok.Click += new System.EventHandler(this.button2Ok_Click);
            // 
            // adminCheckBox1
            // 
            this.adminCheckBox1.AutoSize = true;
            this.adminCheckBox1.Location = new System.Drawing.Point(85, 187);
            this.adminCheckBox1.Name = "adminCheckBox1";
            this.adminCheckBox1.Size = new System.Drawing.Size(248, 21);
            this.adminCheckBox1.TabIndex = 15;
            this.adminCheckBox1.Text = "Зайти от имени администратора";
            this.adminCheckBox1.UseVisualStyleBackColor = true;
            this.adminCheckBox1.CheckedChanged += new System.EventHandler(this.adminCheckBox1_CheckedChanged);
            // 
            // passwordTextBox1
            // 
            this.passwordTextBox1.Location = new System.Drawing.Point(119, 145);
            this.passwordTextBox1.Name = "passwordTextBox1";
            this.passwordTextBox1.Size = new System.Drawing.Size(179, 22);
            this.passwordTextBox1.TabIndex = 14;
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(119, 98);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(179, 22);
            this.loginTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(339, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Для входа в систему введите свой логин и пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Добро пожаловать!";
            // 
            // Entr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 291);
            this.Controls.Add(this.button2Ok);
            this.Controls.Add(this.adminCheckBox1);
            this.Controls.Add(this.passwordTextBox1);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Entr";
            this.Text = "Вход в систему";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2Ok;
        private System.Windows.Forms.CheckBox adminCheckBox1;
        private System.Windows.Forms.TextBox passwordTextBox1;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}