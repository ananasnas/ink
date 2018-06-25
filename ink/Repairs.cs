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
    public class Repairs : Abst2
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

        private decimal price_;
        public decimal price
        {
            get { return price_; }
            set { price_ = value; }
        }
        public Repairs()
        {
            this.tableName_ = "repairs";
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
    }
}
