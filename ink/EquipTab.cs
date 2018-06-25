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
    public partial class EquipTab : Form
    {
        public EquipTab()
        {
            InitializeComponent();
            GetTable();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
        }
        public int flag_;
        public Employees textbo = new Employees();
        private void GetTable()
        {
            dataGridView1.Rows.Clear();

            Equipment e = new Equipment();
            Equipment m = new Equipment();
            List<object> list = new Equipments().getList(e, m);
            foreach (object equipment in list)
            {
                Equipments obj = (Equipments)equipment;
                if (obj.WasDel != 1) { dataGridView1.Rows.Add(Convert.ToString(obj.ID), obj.name_, obj.price, "Редактировать", "Удалить"); }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 3) // редактировать
            {
                if ((flag_ == 2) || (flag_ == 3))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    EquipForm equipForm = new EquipForm();
                    equipForm.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    equipForm.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    equipForm.index = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    equipForm.ShowDialog();
                    if (equipForm.DialogResult == DialogResult.OK)
                    {
                        GetTable();
                    }
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 4) // удалить   
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
                        Equipments cut = (Equipments)new Equipments().findByID(id);
                        // перезапись из Equipments в Equipment, чтобы пометить на удаление
                        Equipment equipm = new Equipment(cut.ID, cut.name_, cut.price, 1, 1);
                        equipm.edit();
                        GetTable();
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
                EquipForm equipForm = new EquipForm();
                equipForm.index = new Equipments().getMaxID() + 1;
                equipForm.ShowDialog();
                if (equipForm.DialogResult == DialogResult.OK)
                {
                    Equipment equip = new Equipment(equipForm.index, equipForm.textBox1.Text, Convert.ToDecimal(equipForm.textBox2.Text), 0, 1);
                    equip.add();
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

        private void EquipTab_Load(object sender, EventArgs e)
        {
            if ((flag_ == 2) || (flag_ == 3))
            {
                this.button1Create.Visible = false;
            }
            //загружаем шрифт
            this.Font = Properties.Settings.Default.FormFont;
        }

        private void EquipTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormFont = this.Font;
            //сохранение настроек
            Properties.Settings.Default.Save();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTable();
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
