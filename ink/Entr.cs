using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Reflection;

namespace ink
{
    public partial class Entr : Form
    {
        public Entr()
        {
            InitializeComponent();
        }
        private void button2Ok_Click(object sender, EventArgs e)
        {
            if (adminCheckBox1.Checked == true)
            {
                this.Hide();
                Main_M mm = new Main_M();
                mm.flag_ = 1;
                mm.ShowDialog();
            }
            else
            {
                if ((loginTextBox.Text != "") && (passwordTextBox1.Text != ""))
                {
                    int insp = new Employees().inspection(loginTextBox.Text, passwordTextBox1.Text);
                    if (insp == 1)
                    {
                        this.Hide();
                        Main_M mm = new Main_M();
                        Employees empl = new Employees();

                        ConnectionStringSettings conString;
                        conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
                        using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
                        {
                            con.Open();
                            string sql = @"select * from employees where " + "(" + "login=" + "'" + loginTextBox.Text + "'" + " and " + " password=" + "'" + passwordTextBox1.Text + "'" + ")";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            MySqlDataReader result = cmd.ExecuteReader();

                            if (result.HasRows)
                            {
                                result.Read();
                                foreach (var prop in empl.GetType().GetProperties())
                                {
                                    if (prop.Name == "tableName") continue;
                                    PropertyInfo propertyInfo = empl.GetType().GetProperty(prop.Name);
                                    string NameResult;

                                    if (propertyInfo.PropertyType.Name == "Int32")
                                    {
                                        NameResult = propertyInfo.Name;
                                        propertyInfo.SetValue(empl, Convert.ChangeType(result.GetInt32(NameResult), propertyInfo.PropertyType), null);
                                    }
                                    else
                                    {
                                        if (propertyInfo.PropertyType.Name == "String")
                                        {
                                            NameResult = propertyInfo.Name;

                                            if (NameResult != "tableName_")
                                            {
                                                propertyInfo.SetValue(empl, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        mm.employee = empl;

                        if (empl.technician == 1) { mm.flag_ = 3; }
                        if (empl.financier == 1) { mm.flag_ = 2; }
                        mm.ShowDialog();
                    }
                        else
                        {
                        MessageBox.Show("Неверно введены логин и пароль. Попробуйте еще раз.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите логин и пароль.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        DialogResult = DialogResult.None;
                    }
                }
            }
     

        private void adminCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(adminCheckBox1.Checked == true)
            {
                this.loginTextBox.Enabled = false;
                this.passwordTextBox1.Enabled = false;
            }
            else
            {
                this.loginTextBox.Enabled = true;
                this.passwordTextBox1.Enabled = true;
            }
        }
    }
}
