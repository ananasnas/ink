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
    public class NominalRepair : Abst
    {
        public NominalRepair(int id_, string name_r, int wasDel)
        {
            this.ID = id_;
            this.name_ = name_r;
            this.WasDel = wasDel;
            this.tableName_ = "repairs";
        }
        public NominalRepair()
        {
            this.ID = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.tableName_ = "repairs";
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
