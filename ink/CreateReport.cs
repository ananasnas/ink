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
    public partial class CreateReport : Form
    {
        public CreateReport()
        {           
            InitializeComponent();
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox3.CheckOnClick = true;

            Field f = new Field();
            Field s = new Field();
            List<object> fields = new Fields().getList(f,s);
            foreach (object field in fields)
            {
                Fields fi = (Fields)field;
                if (fi.WasDel != 1)
                { checkedListBox1.Items.Add(fi.name_, false);}
            }

            Equipment q = new Equipment();
            Equipment h = new Equipment();
            List<object> equipments = new Equipments().getList(q, h);
            foreach (object equipment in equipments)
            {
                Equipments fi = (Equipments)equipment;
                if (fi.WasDel != 1)
                { checkedListBox2.Items.Add(fi.name_, false); }
            }

            Repair r = new Repair();
            Repair p = new Repair();
            List<object> repairs = new Repairs().getList(r,p);
            foreach (object repair in repairs)
            {
                Repairs fi = (Repairs)repair;
                if (fi.WasDel != 1)
                { checkedListBox3.Items.Add(fi.name_, false); }
            }
        }
        public int flag_;
        private void button2Create_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                if ((checkedListBox1.CheckedIndices.Count == 0) && (checkedListBox2.CheckedIndices.Count == 0) && (checkedListBox3.CheckedIndices.Count == 0))
                {
                    MessageBox.Show("Фильтр не может быть пустым.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    this.Hide();
                    this.DialogResult = DialogResult.OK;
                    Report filter = new Report();
                    if (checkedListBox1.CheckedIndices.Count != 0)
                    {
                        List<Fields> fis = new List<Fields>();
                        string fields_ = "";
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.GetItemChecked(i))
                            {
                                if (fields_ != "")
                                { fields_ = fields_ + "," + checkedListBox1.Items[i].ToString(); }
                                else
                                { fields_ = checkedListBox1.Items[i].ToString(); }
                            }
                        }
                        string[] masField = fields_.Split(',');
                        foreach (string name in masField)
                        {
                            List<object> found = new Fields().findByName(name);
                            foreach (object fo in found)
                            {
                                Fields fie = (Fields)fo;
                                fis.Add(fie);
                            }
                        }
                        filter.field = fis;
                    }
                    if (checkedListBox2.CheckedIndices.Count != 0)
                    {
                        List<Equipments> equi = new List<Equipments>();
                        string equipments_ = "";
                        for (int i = 0; i < checkedListBox2.Items.Count; i++)
                        {
                            if (checkedListBox2.GetItemChecked(i))
                            {
                                if (equipments_ != "")
                                { equipments_ = equipments_ + "," + checkedListBox2.Items[i].ToString(); }
                                else
                                { equipments_ = checkedListBox2.Items[i].ToString(); }
                            }
                        }
                        string[] masEqu = equipments_.Split(',');
                        foreach (string name in masEqu)
                        {
                            List<object> found = new Equipments().findByName(name);
                            foreach (object fo in found)
                            {
                                Equipments fie = (Equipments)fo;
                                equi.Add(fie);
                            }
                        }
                        filter.equipment = equi;
                    }
                    if (checkedListBox3.CheckedIndices.Count != 0)
                    {
                        List<Repairs> rep = new List<Repairs>();
                        string rep_ = "";
                        for (int i = 0; i < checkedListBox3.Items.Count; i++)
                        {
                            if (checkedListBox3.GetItemChecked(i))
                            {
                                if (rep_ != "")
                                { rep_ = rep_ + "," + checkedListBox3.Items[i].ToString(); }
                                else
                                { rep_ = checkedListBox3.Items[i].ToString(); }
                            }
                        }
                        string[] masEqu = rep_.Split(',');
                        foreach (string name in masEqu)
                        {
                            List<object> found = new Repairs().findByName(name);
                            foreach (object fo in found)
                            {
                                Repairs fie = (Repairs)fo;
                                rep.Add(fie);
                            }
                        }
                        filter.repairs = rep;
                    }
                    List<Report> reports = new Reports().GetReportsByFilter(filter);
                    ReportFilterTab rft = new ReportFilterTab();
                    rft.list = reports;
                    this.Close();
                    rft.ShowDialog();
                }
            }
            if(radioButton2.Checked == true)
            {
                DateTime start = dateTimePicker1.Value;
                DateTime end = dateTimePicker2.Value;
                if(start<end)
                {
                    this.Hide();
                    List<Report> r = new Reports().GetReportsByAllApplications(start, end);
                    ReportApplicTab rat = new ReportApplicTab();
                    rat.list = r;
                    rat.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Дата начала должна быть меньше даты окончания.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                checkedListBox1.Enabled = true;
                checkedListBox2.Enabled = true;
                checkedListBox3.Enabled = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                checkedListBox1.Enabled = false;
                checkedListBox2.Enabled = false;
                checkedListBox3.Enabled = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }
        public Employees textbo = new Employees();
        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_M menu = new Main_M();
            menu.employee = this.textbo;
            menu.ShowDialog();
        }
    }
}
