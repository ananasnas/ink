using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ink
{
    public partial class FieldForm : Form
    {
        public FieldForm()
        {
            InitializeComponent();
        }
        public int flag_;
        public int index;
        //public static bool isValid(string str)
        //{
        //    string pattern = "^[а-яА-Я]";
        //    Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}
        private void button2Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (insp.isValid1(textBox1.Text))
            {
                Fields field = (Fields)new Fields().findByID(index);
                Field field_ = new Field(field.ID, this.textBox1.Text, 0);
                field_.edit();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле не может быть пустым.\nПоле может содержать только символы кириллицы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.None;
            }
        }

        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }
    }
}
