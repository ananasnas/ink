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
    public partial class EquipForm : Form
    {
        public EquipForm()
        {
            InitializeComponent();
        }
        public int flag_;
        public int index;
        //public static bool isValid1(string str)
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
                Equipments equipm = (Equipments)new Equipments().findByID(index);
                Equipment equipm_ = new Equipment(equipm.ID, textBox1.Text, Convert.ToDecimal(textBox2.Text), 0, 1);
                equipm_.edit();
                this.Close();
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми.\nПоле 'Название' может содержать только символы кириллицы.\nПоле 'Стоимость' может содержать только цифры.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.None;
            }
        }

        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }

    }
}
