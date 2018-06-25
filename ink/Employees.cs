using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Reflection;

namespace ink
{
    public class Employees : Abst2
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string name_
        {
            get { return name; }
            set { name = value; }
        }
        private int was_del;
        public int WasDel
        {
            get { return was_del; }
            set { was_del = value; }
        }
        private int financier_;
        public int financier
        {
            get { return financier_; }
            set { financier_ = value; }
        }
        private string login_;
        public string login
        {
            get { return login_; }
            set { login_ = value; }
        }
        private string middleName_;
        public string middleName
        {
            get { return middleName_; }
            set { middleName_ = value; }
        }
        private string password_;
        public string password
        {
            get { return password_; }
            set { password_ = value; }
        }
        private string surname_;
        public string surname
        {
            get { return surname_; }
            set { surname_ = value; }
        }
        private int technician_;
        public int technician
        {
            get { return technician_; }
            set { technician_ = value; }
        }
        private string tel_;
        public string tel
        {
            get { return tel_; }
            set { tel_ = value; }
        }
        public Employees()
        {
            this.name_ = "";
            this.tableName_ = "employees";
        }
        public override object findByID(int id)
        {
            return base.findByID(id);
        }
        public override List<object> findByName(string name)
        {
            return base.findByName(name);
        }
        public override List<object> getList(object filter, object sorting)
        {
            return base.getList(filter, sorting);
        }
        public override int getMaxID()
        {
            return base.getMaxID();
        }
        public int inspection(string login, string password)
        {
            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                con.Open();
                string sql = @"select * from " + this.tableName_ + " where " + "(" + "login=" + "'" + login + "'" + " and " + " password=" + "'" + password + "'" + ")";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader result = cmd.ExecuteReader();
                if (result.HasRows) return 1;
                else return 0;
            }
        }
    }
}