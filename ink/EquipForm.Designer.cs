namespace ink
{
    partial class EquipForm
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
            this.button1Canc = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2Ok
            // 
            this.button2Ok.Location = new System.Drawing.Point(232, 125);
            this.button2Ok.Name = "button2Ok";
            this.button2Ok.Size = new System.Drawing.Size(94, 28);
            this.button2Ok.TabIndex = 11;
            this.button2Ok.Text = "Ok";
            this.button2Ok.UseVisualStyleBackColor = true;
            this.button2Ok.Click += new System.EventHandler(this.button2Ok_Click);
            // 
            // button1Canc
            // 
            this.button1Canc.Location = new System.Drawing.Point(91, 125);
            this.button1Canc.Name = "button1Canc";
            this.button1Canc.Size = new System.Drawing.Size(94, 28);
            this.button1Canc.TabIndex = 10;
            this.button1Canc.Text = "Отмена";
            this.button1Canc.UseVisualStyleBackColor = true;
            this.button1Canc.Click += new System.EventHandler(this.button1Canc_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 22);
            this.textBox2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Стоимость";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Название";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 22);
            this.textBox1.TabIndex = 6;
            // 
            // EquipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 177);
            this.Controls.Add(this.button2Ok);
            this.Controls.Add(this.button1Canc);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "EquipForm";
            this.Text = "Оборудование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2Ok;
        private System.Windows.Forms.Button button1Canc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
    }
}