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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
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
        //    string pattern = @"\d{2}-\d{2}-\d{2}";
        //    Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}
        public Employee e;

        private void button2Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (insp.isValid3(textBox4.Text) && insp.isValid1(textBox1.Text) && insp.isValid1(textBox2.Text) && insp.isValid1(textBox3.Text) )
            {
                Employees emp = (Employees)new Employees().findByID(index);
                if (radioButton1.Checked) { emp.financier = 1; emp.technician = 0;}
                if (radioButton2.Checked) { emp.technician = 1; emp.financier = 0;}
                Employee emp_ = new Employee(this.index, textBox2.Text, 0, emp.financier, textBox5.Text, textBox3.Text, textBox6.Text, textBox1.Text, emp.technician, textBox4.Text);
                emp_.edit();
                this.e = emp_;
                this.Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены.\nПоля 'Фамилия', 'Имя', 'Отчество' должны содержать только символы кириллицы.\nНомер телефона должжен быть введен в формате 'xx-xx-xx'.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.None;
            }
        }

        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }
        public int textnom;
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (textnom != 1)
            {
                textBox4.Text = "хх-хх-хх";
                textBox4.ForeColor = Color.Gray;
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textnom != 1)
            {
                textBox4.Text = null;
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text =="")
            {
                textBox4.Text = "хх-хх-хх";
                textBox4.ForeColor = Color.Gray;
            }
        }

    }
}