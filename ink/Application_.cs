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
    public class Application_ : Abst
    {
        private string comment_;
        public string comment
        {
            get { return comment_; }
            set { comment_ = value; }
        }
        private List<Equipments> equipment_;
        public List<Equipments> equipment
        {
            get { return equipment_; }
            set { equipment_ = value; }
        }
        private Fields field_;
        public Fields field
        {
            get { return field_; }
            set { field_ = value; }
        }
        private DateTime finish_;
        public DateTime finish
        {
            get { return finish_; }
            set { finish_ = value; }
        }
        private int performed_;
        public int performed
        {
            get { return performed_; }
            set { performed_ = value; }
        }
        private Repairs repair_;
        public Repairs repair
        {
            get { return repair_; }
            set { repair_ = value; }
        }
        private Employees SenderOfApplication_;
        public Employees SenderOfApplication
        {
            get { return SenderOfApplication_; }
            set { SenderOfApplication_ = value; }
        }
        private DateTime start_;
        public DateTime start
        {
            get { return start_; }
            set { start_ = value; }
        }
        private decimal sumReal_;
        public decimal sumReal
        {
            get { return sumReal_; }
            set { sumReal_ = value; }
        }
        private decimal sumNominal_;
        public decimal sumNominal
        {
            get { return sumNominal_; }
            set { sumNominal_ = value; }
        }
        private List<Employees> technicians_;
        public List<Employees> technicians
        {
            get { return technicians_; }
            set { technicians_ = value; }
        }
        private int wasEdit_;
        public int wasEdit
        {
            get { return wasEdit_; }
            set { wasEdit_ = value; }
        }
        private int wasPerformed_;
        public int wasPerformed
        {
            get { return wasPerformed_; }
            set { wasPerformed_ = value; }
        }

        private string count_;
        public string count
        {
            get { return count_; }
            set { count_ = value; }
        }

        public Application_()
        {
            this.ID = -1;
            this.name_ = "-1";
            this.WasDel = -1;
            this.comment = "-1";
            this.equipment = null;
            this.field = null;
            this.finish = Convert.ToDateTime("01.01.0001").Date;
            this.performed = -1;
            this.repair = null;
            this.SenderOfApplication = null;
            this.start = Convert.ToDateTime("01.01.0001").Date;
            this.sumReal = -1;
            this.sumNominal = -1;
            this.technicians = null;
            this.wasEdit = -1;
            this.wasPerformed = -1;
            this.count = null;

            this.tableName_ = "applications";
        }
        public Application_(string id, string wasDel, string comment, List<string> equipment,
                           string field, string finish, string performed, string repair, string sender, string start,
                                   string SumReal, string sumNominal, List<string> technicians, string wasEdit, string WasPerformed, string count)
        {
            Equipments eq = new Equipments();
            Fields f = new Fields();
            Employees emp = new Employees();
            Repairs r = new Repairs();

            List<Equipments> equip = new List<Equipments>();
            List<Employees> empls = new List<Employees>();

            this.ID = Convert.ToInt32(id);
            this.WasDel = Convert.ToInt32(wasDel);
            this.comment = comment;

            foreach (string s in equipment) { equip.Add((Equipments)new Equipments().findByID(Convert.ToInt32(s))); }
            this.equipment = equip;

            this.field = (Fields)f.findByID(Convert.ToInt32(field));
            this.finish = Convert.ToDateTime(finish).Date;
            this.wasPerformed = Convert.ToInt32(performed);
            this.repair = (Repairs)r.findByID(Convert.ToInt32(repair));
            this.SenderOfApplication = (Employees)emp.findByID(Convert.ToInt32(sender));
            this.start = Convert.ToDateTime(start).Date;
            this.sumReal = Convert.ToDecimal(SumReal);
            this.sumNominal = Convert.ToDecimal(sumNominal);

            foreach (string e in technicians) { empls.Add((Employees)new Employees().findByID(Convert.ToInt32(e))); }
            this.technicians = empls;
            this.wasEdit = Convert.ToInt32(wasEdit);
            this.wasPerformed = wasPerformed;
            this.count = count;

            this.tableName_ = "applications";
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
