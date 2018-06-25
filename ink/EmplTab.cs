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
    public partial class EmplTab : Form
    {
        public EmplTab()
        {
            InitializeComponent();
            GetTable();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }
       public Employees textbo = new Employees();
        public int flag_;
        private void GetTable()
        {
            dataGridView1.Rows.Clear();
            Employee e = new Employee();
            Employee m = new Employee();
            List<object> list = new Employees().getList(e, m);
            foreach (object employee in list)
            {
                Employees obj = (Employees)employee;
                if(obj.technician ==1)
                { 
                    if (obj.WasDel != 1) { dataGridView1.Rows.Add(obj.ID, obj.surname, obj.name_, obj.middleName, obj.tel, "Техник", "Редактировать", "Удалить"); }
                }
                else
                {
                    if (obj.WasDel != 1) { dataGridView1.Rows.Add(obj.ID, obj.surname, obj.name_, obj.middleName, obj.tel, "Финансовый работник", "Редактировать", "Удалить"); }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 6) // редактировать
            {
                if ((flag_ == 2) || (flag_ == 2))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    EmployeeForm EmpForm = new EmployeeForm();
                    EmpForm.textnom = 1;
                    EmpForm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    EmpForm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    EmpForm.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    EmpForm.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "Финансовый работник") { EmpForm.radioButton1.Checked = true; }
                    else { EmpForm.radioButton2.Checked = true; }

                    EmpForm.index = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    Employees empl = (Employees)new Employees().findByID(EmpForm.index);

                    EmpForm.textBox5.Text = empl.login;
                    EmpForm.textBox6.Text = empl.password;

                    EmpForm.ShowDialog();
                    if (EmpForm.DialogResult == DialogResult.OK)
                    {
                        GetTable();
                    }
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 7) // удалить          
            {
                if ((flag_ == 2) || (flag_ == 3))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены? Данные будут удалены без возможности восстановления.", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        Employees cut = (Employees)new Employees().findByID(id);
                        // перезапись из employees в employee, чтобы пометить на удаление
                        Employee employee = new Employee(cut.ID, cut.name_, 1, cut.financier, cut.login, cut.middleName, cut.password, cut.surname, cut.technician, cut.tel);

                        employee.edit();
                        GetTable();
                    }
                }
            }
        }
        private void button1Create_Click(object sender, EventArgs e)
        {
            if ((flag_ == 2) || (flag_ == 3))
            {
                MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.None;
            }
            else
            {
                EmployeeForm empForm = new EmployeeForm();
                empForm.index = new Employees().getMaxID() + 1;
                empForm.radioButton1.Checked = true;
                empForm.ShowDialog();

                if (empForm.DialogResult == DialogResult.OK)
                {
                    empForm.e.add();
                    GetTable();
                }
            }
        }

        private void button1Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_M menu = new Main_M();
            menu.employee = this.textbo;
            menu.flag_ = flag_;
            if (flag_ == 1)
            {
                menu.button1Applic.Enabled = false;
                menu.button6Report.Enabled = false;
            }
            menu.ShowDialog();
        }
        Font font;
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

        private void EmplTab_Load(object sender, EventArgs e)
        {
            if ((flag_ == 2) || (flag_ == 3))
            {
                this.button1Create.Visible = false;
            }
            this.Font = Properties.Settings.Default.FormFont;

        }

        private void EmplTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormFont = this.Font;
            //сохранение настроек
            Properties.Settings.Default.Save();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Таблица успешно обновлена";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
