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
    public class Reports : Abst2
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

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
        public Reports()
        {
            this.tableName_ = "reports";
        }
        public override int getMaxID()
        {
            return base.getMaxID();
        }
        public List<Report> GetReportsByAllApplications(DateTime start, DateTime end)
        {
            List<Report> reports = new List<Report>();
            Application_ apStart = new Application_();
            Application_ apFinish = new Application_();

            apStart.start = start;
            apFinish.start = end;
            List<Applications> applications = new Applications().getApplicationsListOnDate(apStart, apFinish);

            foreach (Applications application in applications)
            {
                int ID = application.ID;
                Report report = new Report(ID);
                reports.Add(report);
            }
            return reports;
        }
        public List<Report> GetReportsByFilter(Report filter)
        {
            Application_ sorting = new Application_();
            List<Applications> List = new List<Applications>();
            if (filter.field != null)
            {
                foreach (Fields field in filter.field)
                {
                    Application_ f = new Application_();
                    f.field = field;
                    List<object> ap = new Applications().getList(f, sorting);
                    foreach (object a in ap)
                    {
                        Applications aplic = (Applications)a;
                        List.Add(aplic);
                    }
                }
            }
            if (filter.equipment != null)
            {
                Application_ f = new Application_();
                f.equipment = filter.equipment;
                List<object> ap = new Applications().getList(f, sorting);
                foreach (object a in ap)
                {
                    Applications aplic = (Applications)a;
                    List.Add(aplic);
                }
            }
            if (filter.repairs != null)
            {
                foreach (Repairs repair in filter.repairs)
                {
                    Application_ f = new Application_();
                    f.repair = repair;
                    List<object> ap = new Applications().getList(f, sorting);
                    foreach (object a in ap)
                    {
                        Applications aplic = (Applications)a;
                        List.Add(aplic);
                    }
                }
            }

            List<Report> reports = new List<Report>();
            foreach (Applications aplics in List)
            {
                int id = aplics.ID;
                Report report = new Report(id);
                reports.Add(report);
            }

            return reports;
        }
    }
}
