using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace ink
{
    public partial class FieldTab : Form
    {
        public FieldTab()
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

            Field e = new Field();
            Field m = new Field();
            List<object> list = new Fields().getList(e, m);
            foreach(object field in list)
            {                 
                 Fields obj = (Fields)field;
                 if (obj.WasDel != 1) { dataGridView1.Rows.Add(Convert.ToString(obj.ID), obj.name_, "Редактировать", "Удалить"); }                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2) // редактировать
            {
                if ((flag_ == 2) || (flag_ == 3))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    FieldForm fieldForm = new FieldForm();
                    fieldForm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    fieldForm.index = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    fieldForm.ShowDialog();
                    if (fieldForm.DialogResult == DialogResult.OK)
                    {
                        GetTable();
                    }
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 3) // удалить          
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
                        Fields cut = (Fields)new Fields().findByID(id);
                        // перезапись из fields в field, чтобы пометить на удаление
                        Field field = new Field(cut.ID, cut.name_, 1);
                        field.edit();
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
                FieldForm fieldForm = new FieldForm();
                fieldForm.index = new Fields().getMaxID() + 1;
                fieldForm.ShowDialog();
                if (fieldForm.DialogResult == DialogResult.OK)
                {
                    Field field = new Field(fieldForm.index, fieldForm.textBox1.Text, 0);
                    field.add();
                    GetTable();
                }
            }
        }

        private void button2Back_Click(object sender, EventArgs e)
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

        private void FieldTab_Load(object sender, EventArgs e)
        {
            if ((flag_ == 2) || (flag_ == 3))
            {
                this.button1Create.Visible = false;
            }
            this.Font = Properties.Settings.Default.FormFont;
        }

        private void FieldTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormFont = this.Font;
            //сохранение настроек
            Properties.Settings.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTable();
            toolStripStatusLabel1.Text = "Таблица успешно обновлена";
            timer1.Start();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }
    }
}
