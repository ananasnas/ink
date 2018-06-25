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
    public partial class RepairForm : Form
    {
        public RepairForm()
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
        //public static bool isValid2(string str)
        //{
        //    string pattern = @"^[\s+,+\d]*$";
        //    Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}

        private void button2Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (insp.isValid1(textBox1.Text) && insp.isValid2(textBox2.Text))
            {
                Repairs repair = (Repairs)new Repairs().findByID(index);
                Repair repair_ = new Repair(Convert.ToDecimal(this.textBox2.Text), repair.ID, this.textBox1.Text, 0);
                repair_.edit();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми.\nПоле 'Название' должно содержать только символы кириллицы.\nПоле 'Номинальная стоимость' должно содержать только цифры.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.None;
            }
        }

        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }
    }
}
