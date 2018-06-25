using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace ink
{
    public class Field : Abst
    {
        public Field(int id_, string name_r, int wasDel)
        {
            this.ID = id_;
            this.name_ = name_r;
            this.WasDel = wasDel;
            this.tableName_ = "fields";
        }
        public Field()
        {
            this.ID = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.tableName_ = "fields";
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
