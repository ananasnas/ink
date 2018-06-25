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
    public class Report
    {
        private Applications application_;
        public Applications application
        {
            get { return application_; }
            set { application_ = value; }
        }
        private DateTime dateOfReport_;
        public DateTime dateOfReport
        {
            get { return dateOfReport_; }
            set { dateOfReport_ = value; }
        }
        private List<Equipments> equipment_;
        public List<Equipments> equipment
        {
            get { return equipment_; }
            set { equipment_ = value; }
        }
        private List<Fields> field_;
        public List<Fields> field
        {
            get { return field_; }
            set { field_ = value; }
        }
        private int id_;
        public int id
        {
            get { return id_; }
            set { id_ = value; }
        }
        private decimal NominalPrice_;
        public decimal NominalPrice
        {
            get { return NominalPrice_; }
            set { NominalPrice_ = value; }
        }
        private decimal RealPrice_;
        public decimal RealPrice
        {
            get { return RealPrice_; }
            set { RealPrice_ = value; }
        }
        private List<Repairs> repairs_;
        public List<Repairs> repairs
        {
            get { return repairs_; }
            set { repairs_ = value; }
        }
        public string tableName_ { get; set; }
        public Report()
        {
            this.id = new Reports().getMaxID() + 1;
            this.application = null;
            this.dateOfReport = Convert.ToDateTime("01.01.0001").Date;
            this.equipment = null;
            this.field = null;
            this.NominalPrice = -1;
            this.RealPrice = -1;
            this.repairs = null;

            this.tableName_ = "reports";
        }
        public Report(int nomberOfApplic)
        {
            this.tableName_ = "reports";
            this.id = new Reports().getMaxID() + 1;
            Applications s = (Applications)new Applications().findByID(nomberOfApplic);
            this.application = s;
            this.dateOfReport = DateTime.Now.Date;
            this.RealPrice = s.sumReal;
            this.NominalPrice = s.sumNominal;
        }
    }
}
