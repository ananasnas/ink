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
    public class Employee : Abst
    {
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
        public Employee(int id_, string name_r, int wasDel, int financier_,
            string login_, string middlename_, string password_, string surname_, int technician_, string tel_)
        {
            this.ID = id_;
            this.name_ = name_r;
            this.WasDel = wasDel;
            this.financier = financier_;
            this.login = login_;
            this.middleName = middlename_;
            this.password = password_;
            this.surname = surname_;
            this.technician = technician_;
            this.tel = tel_;

            this.tableName_ = "employees";
        }
        public Employee()
        {
            this.ID = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.financier = -1;
            this.login = "-1";
            this.middleName = "-1";
            this.password = "-1";
            this.surname = "-1";
            this.technician = -1;
            this.tel = "-1";

            this.tableName_ = "employees";
        }
        public override void add()
        {
            base.add();
        }

        public override void del()
        {
            base.del();
        }

        public override void edit()
        {
            base.edit();
        }
    }
}

