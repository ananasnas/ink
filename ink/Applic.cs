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
    public partial class Applic : Form
    {
        public Applic()
        {
            InitializeComponent();                      

            Field f1 = new Field();
            Field f2 = new Field();
            List<object> fields = new Fields().getList(f1,f2);
            foreach(object fiel in fields)
            {
                Fields fielh = (Fields)fiel;
  
                comboBox1.Items.Add(fielh.name_);
            }

            Repair r1 = new Repair();
            Repair r2 = new Repair();
            List<object> repairs = new Repairs().getList(r1, r2);
            foreach (object o in repairs)
            {
                Repairs rep = (Repairs)o;
                comboBox2.Items.Add(rep.name_);
            }
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;      

            dataGridView1.Rows.Clear();
            
            Equipment e = new Equipment();
            Equipment m = new Equipment();
            List<object> list = new Equipments().getList(e, m);
            foreach (object appl in list)
            {
                Equipments obj = (Equipments)appl;
                dataGridView1.Rows.Add(obj.name_,  false, obj.count, obj.ID);
            }
            dataGridView1.Columns[3].Visible = false;

            dataGridView2.Rows.Clear();
            Employee er = new Employee();
            Employee mu = new Employee();
            List<object> list_t = new Employees().getList(er, mu);
            foreach (object appl in list_t)
            {
                Employees obj = (Employees)appl;
                dataGridView2.Rows.Add(obj.surname, obj.name_, obj.middleName, false, obj.ID);
            }
            dataGridView2.Columns[4].Visible = false;

            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;            
        }
        public int flag_;
        //public static bool isValid2(string str)
        //{
        //    string pattern = @"^[\s+,+\d]*$";
        //    Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}
        //public static bool isValid1(string str)
        //{
        //    string pattern = "^[а-яА-Я]";
        //    Match isMatch = Regex.Match(str, pattern, RegexOptions.IgnoreCase);
        //    return isMatch.Success;
        //}
        public int index = 0;
        public Application_ mi = new Application_();
    
        private void button2Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; 
        
            Applications apl = (Applications)new Applications().findByID(index);            
            List<string> countEquip = new List<string>();
            countEquip.Add("");
            List<Equipments> equipm = new List<Equipments>();

            int flag1 = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[1, i].Value.ToString() == "True")
                    {
                        Equipments equi = (Equipments)new Equipments().findByID(Convert.ToInt32(dataGridView1[3, i].Value.ToString()));
                        if (countEquip[0] != "")
                        { 
                            countEquip[0] = countEquip[0] + "," + dataGridView1[2, i].Value.ToString();
                        }
                        else
                        {
                            countEquip[0] = dataGridView1[2, i].Value.ToString();
                        }
                        equipm.Add(equi);
                        flag1++;
                        continue;
                    }
                }

            List<object> fields = new Fields().findByName(comboBox1.GetItemText(comboBox1.SelectedItem));
            Fields fiel = (Fields)fields[0];

            List<object> repairs = new Repairs().findByName(comboBox2.GetItemText(comboBox2.SelectedItem));
            Repairs repair = (Repairs)repairs[0];

            string se = textBox1.Text;
            string[] mas = se.Split(' ');
            List<object> chel = new Employees().findByName(mas[0]);
            Employees senderr = new Employees();           
            foreach (object ch in chel)
            {
               Employees chelk = (Employees)ch;
             if (chelk.surname == mas[2])
               {
                   senderr = chelk;
               }
            }

           List<Employees> elp = new List<Employees>();
           int flag2 = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2[3, i].Value.ToString() == "True")
                    {
                        Employees epn = (Employees)new Employees().findByID(Convert.ToInt32(dataGridView2[4, i].Value.ToString()));
                        elp.Add(epn);
                        flag2++;
                        continue;
                    }
                }

                DateTime start = dateTimePicker1.Value;
                DateTime end = dateTimePicker2.Value;

                if ((flag2 == 0) || (flag1 == 0) || (insp.isValid1(solution.Text)==false) || (insp.isValid2(textBox3.Text)==false))
                {
                    MessageBox.Show("Поля не могут быть пустыми.\nТаблицы оборудования и техников должны быть заполнены.\nПоле 'Фактическая сумма по заявке' должно содержать только цифры.\nПоле 'Комментарий' должно содержать только символы кириллицы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    Application_ ion_ = new Application_();

                    string co = "";
                    foreach (string c in countEquip)
                    {
                        if (co == "")
                        {
                            co = co + c;
                        }
                        else
                        {
                            co = co + "," + c;
                        }
                    }

                    decimal sumNom = 0;
                    foreach (Equipments eq in equipm)
                    {
                        sumNom = sumNom + eq.price;
                    }

                    try
                    {
                        ion_.ID = apl.ID;
                        ion_.WasDel = 0;
                        ion_.comment = solution.Text;
                        ion_.equipment = equipm;
                        ion_.count = co;
                        ion_.field = fiel;
                        ion_.finish = dateTimePicker2.Value;
                        ion_.performed = Convert.ToInt32(radioButton1.Checked);
                        ion_.repair = repair;

                        string ser = textBox1.Text;
                        string[] masi = ser.Split(' ');
                        List<object> chel1 = new Employees().findByName(masi[0]);
                        Employees senderr5 = new Employees();
                        foreach (object ch in chel1)
                        {
                            Employees chelk = (Employees)ch;
                            if (chelk.surname == mas[2])
                            {
                                senderr5 = chelk;
                            }
                        }

                        ion_.SenderOfApplication = senderr5;
                        ion_.start = dateTimePicker1.Value;
                        ion_.sumReal = Convert.ToDecimal(textBox3.Text);
                        ion_.sumNominal = sumNom;
                        ion_.technicians = elp;
                        ion_.wasEdit = 1;
                        ion_.wasPerformed = Convert.ToInt32(radioButton2.Checked);

                        this.mi = ion_;
                        mi.ID = index;

                        ion_.edit();
                    }
                    catch
                    {
                        MessageBox.Show("Введены некорректные данные. Попробуйте снова.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DialogResult = DialogResult.None;
                    }
                    
                  
                    this.Close();
                }
        }

        private void button1Canc_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;            
        }

    }
}
