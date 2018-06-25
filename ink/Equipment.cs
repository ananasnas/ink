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
    public class Equipment : Abst
    {
        private decimal price_;
        public decimal price
        {
            get { return price_; }
            set { price_ = value; }
        }
        private int count_;
        public int count
        {
            get { return count_; }
            set { count_ = value; }
        }
        public Equipment(int id_, string name_r, decimal price, int wasDel, int count)
        {
            this.ID = id_;
            this.name_ = name_r;
            this.WasDel = wasDel;
            this.price = price;
            this.count = count;
            this.tableName_ = "equipments";
        }
        public Equipment()
        {
            this.ID = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.price = -1;
            this.count = 1;
            this.tableName_ = "equipments";
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

