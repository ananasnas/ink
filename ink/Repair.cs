using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ink
{
    public class Repair : NominalRepair
    {
        private decimal price_;
        public decimal price
        {
            get { return price_; }
            set { price_ = value; }
        }
       public Repair()
        {
            this.ID = -1;
            this.price = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.tableName_ = "repairs";
        }
       public Repair(decimal price_p, int id, string name, int wasDel)
        {
            this.ID = id;
            this.price = price_p;
            this.name_ = name;
            this.WasDel = wasDel;
            this.tableName_ = "repairs";
        }
    }
}
