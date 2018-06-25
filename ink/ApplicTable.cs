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
    public partial class ApplicTable : Form
    {
        public ApplicTable()
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
            Application_ e = new Application_();
            Application_ m = new Application_();
            List<object> list = new Applications().getList(e, m);
            foreach (object appl in list)
            {
                Applications obj = (Applications)appl;
                dataGridView1.Rows.Add(obj.ID, obj.field.name_, obj.start.ToShortDateString(), obj.finish.ToShortDateString(), obj.repair.name_, "Показать список", "Редактировать", "Удалить");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 5) // список оборудования
            {
                EquipList el = new EquipList();
                Applications apl = (Applications)new Applications().findByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                List<Equipments> equipList = apl.equipment;
                string[] mas = apl.count.Split(',');
                int nom = 0;
                int nomber = 0;
                for (int k = 0; k < equipList.Count; k++)
                {
                    nomber++;
                    nom = k;
                    el.dataGridView1.Rows.Add(nomber, equipList[k].name_, mas[nom]);
                }
                el.ShowDialog();

            }
            if (dataGridView1.CurrentCell.ColumnIndex == 6) // редактировать
            {
                if ((flag_ == 1) || (flag_ == 2))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    Applic aplForm = new Applic();

                    aplForm.dataGridView1.Rows.Clear();

                    Equipment ej = new Equipment();
                    Equipment m = new Equipment();
                    List<object> list = new Equipments().getList(ej, m);
                    foreach (object appl in list)
                    {
                        Equipments obj = (Equipments)appl;
                        if (obj.WasDel != 1)
                        { aplForm.dataGridView1.Rows.Add(obj.name_, false, obj.count, obj.ID); }
                    }
                    aplForm.dataGridView1.Columns[3].Visible = false;
                    aplForm.comboBox2.Items.Clear();

                    aplForm.dataGridView2.Rows.Clear();
                    Employee er = new Employee();
                    Employee mu = new Employee();
                    List<object> list_t = new Employees().getList(er, mu);
                    foreach (object appl in list_t)
                    {
                        Employees obj = (Employees)appl;
                        if (obj.WasDel != 1)
                        { aplForm.dataGridView2.Rows.Add(obj.surname, obj.name_, obj.middleName, false, obj.ID); }
                    }
                    aplForm.dataGridView2.Columns[4].Visible = false;

                    Repair r1 = new Repair();
                    Repair r2 = new Repair();
                    List<object> repairs = new Repairs().getList(r1, r2);
                    foreach (object o in repairs)
                    {
                        Repairs rep = (Repairs)o;
                        if (rep.WasDel != 1)
                        { aplForm.comboBox2.Items.Add(rep.name_); }
                    }

                    aplForm.comboBox1.Items.Clear();

                    Field f1 = new Field();
                    Field f2 = new Field();
                    List<object> fields = new Fields().getList(f1, f2);
                    foreach (object fiel in fields)
                    {
                        Fields fielh = (Fields)fiel;
                        if (fielh.WasDel != 1)
                        { aplForm.comboBox1.Items.Add(fielh.name_); }
                    }


                    aplForm.comboBox2.Items.Add(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                    aplForm.comboBox1.Items.Add(dataGridView1.CurrentRow.Cells[1].Value.ToString());
 
                    aplForm.comboBox1.SelectedIndex = aplForm.comboBox1.FindStringExact(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    aplForm.comboBox2.SelectedIndex = aplForm.comboBox2.FindStringExact(dataGridView1.CurrentRow.Cells[4].Value.ToString());

                    EquipList el = new EquipList();
                    Applications apl = (Applications)new Applications().findByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));                                    

                    List<Equipments> equipList = apl.equipment;
                    string[] mas = apl.count.Split(',');
                    int fl = -1;
                    for (int y = 0; y < equipList.Count; y++)
                    {
                        for (int i = 0; i < aplForm.dataGridView1.RowCount; i++)
                        {
                            if (aplForm.dataGridView1[0, i].FormattedValue.ToString().Contains(equipList[y].name_))
                            {
                                fl++;
                                aplForm.dataGridView1[1, i].Value = true;

                                aplForm.dataGridView1[2, i].Value = mas[fl];
                            }
                        }
                    }            

                    List<Employees> techList = apl.technicians;
                    for (int y = 0; y < techList.Count; y++)
                    {
                        if (techList[y].WasDel == 1)
                        {
                            aplForm.dataGridView2.Rows.Add(techList[y].surname, techList[y].name_, techList[y].middleName, true, techList[y].ID);
                        }

                        for (int i = 0; i < aplForm.dataGridView2.RowCount; i++)
                        {
                            if (aplForm.dataGridView2[0, i].FormattedValue.ToString().Contains(techList[y].surname))
                            {
                                aplForm.dataGridView2[3, i].Value = true;
                            }
                        }
                    }

                    string send = apl.SenderOfApplication.name_ + " " + apl.SenderOfApplication.middleName + " " + apl.SenderOfApplication.surname;
                    aplForm.textBox1.Text = send;
                

                    if (apl.performed == 1)
                    {
                        aplForm.radioButton1.Checked = true;
                        aplForm.radioButton2.Checked = false;
                    }

                    if (apl.wasPerformed == 1)
                    {
                        aplForm.radioButton1.Checked = false;
                        aplForm.radioButton2.Checked = true;
                    }

                    decimal sum = 0;
                    foreach (Equipments eq in equipList)
                    {
                        string v = eq.price.ToString();
                        sum = Convert.ToDecimal(sum + Convert.ToDecimal(v));                      
                    }
                    sum = sum + apl.repair.price;
                    aplForm.textBox2.Text = sum.ToString();
                    aplForm.textBox3.Text = apl.sumReal.ToString();
                    aplForm.dateTimePicker1.Value = apl.start;
                    aplForm.dateTimePicker2.Value = apl.finish;
                    aplForm.solution.Text = apl.comment;

                    aplForm.index = apl.ID;

                    aplForm.ShowDialog();

                    if (aplForm.DialogResult == DialogResult.OK)
                    {
                        GetTable();
                    }
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 7) // удалить
            {
                if ((flag_ == 1) || (flag_ == 2))
                {
                    MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    if (MessageBox.Show("Вы уверены? Данные будут удалены без возможности восстановления.", "Внимание!", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    {
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        Applications cut = (Applications)new Applications().findByID(id);

                        List<string> equipm = new List<string>();
                        foreach (Equipments g in cut.equipment)
                        { equipm.Add(g.ID.ToString()); }

                        List<string> techn = new List<string>();
                        foreach (Employees m in cut.technicians)
                        { techn.Add(m.ID.ToString()); }
                        Application_ a = new Application_();
                        a.ID = cut.ID;
                        a.del();
                        GetTable();
                    }
                }
            }
        }

        private void button2Back_Click(object sender, EventArgs e)
        {
            int fl = this.flag_;
            this.Hide();
          
            Main_M menu = new Main_M();
            menu.employee = this.textbo;
            menu.flag_ = fl;

            if (flag_ == 1)
            {
                menu.button1Applic.Enabled = false;
                menu.button6Report.Enabled = false;
                
            }
            menu.ShowDialog();
        }

        private void button1Create_Click(object sender, EventArgs e)
        {

            if ((flag_ == 1) || (flag_ == 2))
            {
               MessageBox.Show("Недостаточно прав.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               DialogResult = DialogResult.None;
            }
            else
            {
                Applic newap = new Applic();
                newap.flag_ = this.flag_;

                newap.dataGridView1.Rows.Clear();

                Equipment ej = new Equipment();
                Equipment m = new Equipment();
                List<object> list = new Equipments().getList(ej, m);
                foreach (object appl in list)
                {
                    Equipments obj = (Equipments)appl;
                    if (obj.WasDel != 1)
                    { newap.dataGridView1.Rows.Add(obj.name_, false, obj.count, obj.ID); }
                }
                newap.dataGridView1.Columns[3].Visible = false;


                newap.dataGridView2.Rows.Clear();
                Employee er = new Employee();
                Employee mu = new Employee();
                List<object> list_t = new Employees().getList(er, mu);
                foreach (object appl in list_t)
                {
                    Employees obj = (Employees)appl;
                    if (obj.WasDel != 1)
                    { newap.dataGridView2.Rows.Add(obj.surname, obj.name_, obj.middleName, false, obj.ID); }
                }
                newap.dataGridView2.Columns[4].Visible = false;
                newap.comboBox2.Items.Clear();

                Repair r1 = new Repair();
                Repair r2 = new Repair();
                List<object> repairs = new Repairs().getList(r1, r2);
                foreach (object o in repairs)
                {
                    Repairs rep = (Repairs)o;
                    if (rep.WasDel != 1)
                    { newap.comboBox2.Items.Add(rep.name_); }
                }

                newap.comboBox1.Items.Clear();

                Field f1 = new Field();
                Field f2 = new Field();
                List<object> fields = new Fields().getList(f1, f2);
                foreach (object fiel in fields)
                {
                    Fields fielh = (Fields)fiel;
                    if (fielh.WasDel != 1)
                    { newap.comboBox1.Items.Add(fielh.name_); }
                }

                newap.comboBox1.SelectedIndex = 1;
                newap.comboBox2.SelectedIndex = 1;

                newap.textBox1.Text = textbo.name_ + " " + textbo.middleName + " " + textbo.surname;
                newap.textBox2.Text = "0";
                newap.radioButton1.Checked = true;
                newap.radioButton2.Checked = false;

                newap.dateTimePicker1.Value = DateTime.Now.AddDays(1);
                newap.dateTimePicker2.Value = DateTime.Now.AddDays(30);
                newap.index = new Applications().getMaxID() + 1;
                newap.ShowDialog();
                if (newap.DialogResult == DialogResult.OK)
                {
                    newap.mi.add();
                    GetTable();
                }
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
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
        private void ApplicTable_Load(object sender, EventArgs e)
        {
            if ((flag_ == 1) || (flag_ == 2))
            {
                this.button1Create.Visible = false;
            }
            this.Font = Properties.Settings.Default.FormFont;
        }

        private void ApplicTable_FormClosing(object sender, FormClosingEventArgs e)
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

        private void датеНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}