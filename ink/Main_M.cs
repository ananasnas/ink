using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ink
{
    public partial class Main_M : Form
    {
        public Main_M()
        {
            InitializeComponent();
        }
        public int flag_;
        public Employees employee = new Employees();        
        private void button2Field_Click(object sender, EventArgs e)
        {
            this.Hide();
            FieldTab ft = new FieldTab();
            ft.textbo = this.employee;
            ft.flag_ = flag_;
            ft.ShowDialog();
        }

        private void button3Equip_Click(object sender, EventArgs e) // дробная часть
        {
            this.Hide();
            EquipTab eq = new EquipTab();
            eq.textbo = this.employee;
            eq.flag_ = flag_;
            eq.ShowDialog();            
        }

        private void button4Rep_Click(object sender, EventArgs e) // дробная часть
        {
            this.Hide();
            RepairTab rt = new RepairTab();
            rt.textbo = this.employee;
            rt.flag_ = flag_;
            rt.ShowDialog();       
        }

        private void button5Empl_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmplTab et = new EmplTab();
            et.textbo = this.employee;
            et.flag_ = flag_;
            et.ShowDialog();
        }

        private void button1Applic_Click(object sender, EventArgs e) // дробная часть
        {
            this.Hide();
            ApplicTable at = new ApplicTable();
            at.textbo = this.employee;
            at.flag_ = flag_;
            at.textbo = employee;
            at.ShowDialog();
        }

        private void button6Report_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateReport cr = new CreateReport();
            cr.textbo = this.employee;
            cr.ShowDialog();
        }

        private void Main_M_Load(object sender, EventArgs e)
        {
            if(flag_ == 1)
            {
                button1Applic.Enabled = false;
                button6Report.Enabled = false;
            }
            this.Font = Properties.Settings.Default.FormFont;
            
            if (employee.name_ != "")
            { 
                this.label2.Text = employee.surname + " " + employee.name_ + " " + employee.middleName;
            }

            else
            {
                this.label2.Text = "";
                this.label1.Text = "Выполнен вход от имени администратора";
            }
        }

        private void button1Authoriz_Click(object sender, EventArgs e)
        {
            this.Hide();
            Entr ent = new Entr();
            ent.ShowDialog();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Params pr = new Params();
            if (pr.ShowDialog() == DialogResult.OK)
            {
                //присваиваем значение шрифта
                this.Font = Properties.Settings.Default.FormFont = pr.GetFormFont;
                //сохраняем настройки
                Properties.Settings.Default.Save();
            }
        }

        private void Main_M_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormFont = this.Font;
            //сохранение настроек
            Properties.Settings.Default.Save();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
