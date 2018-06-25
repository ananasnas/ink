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
    public class Applications : Abst2
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int was_del;
        public int WasDel
        {
            get { return was_del; }
            set { was_del = value; }
        }
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
        public Applications()
        {
            this.tableName_ = "applications";
        }
        public override object findByID(int id) // проверить поля в заявке
        {
            return base.findByID(id);
        }
        public override List<object> getList(object filter, object sorting)
        {
            return base.getList(filter, sorting);
        }
        public override int getMaxID()
        {
            //this.tableName_ = "applications";
            return base.getMaxID();
        }
        public List<Applications> getApplicationsListOnDate(Application_ start, Application_ finish)
        // дописать типы см.ниже
        {
            List<Applications> List = new List<Applications>();
            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                string queryString = @"SELECT * FROM " + this.tableName_ + " WHERE start BETWEEN @dateS AND @dateF";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@dateS", start.start.Date);
                cmd.Parameters.AddWithValue("@dateF", finish.start.Date);
                MySqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Applications application = new Applications();

                        foreach (var prop in this.GetType().GetProperties())
                        {
                            if (prop.Name == "tableName") continue;
                            PropertyInfo propertyInfo = this.GetType().GetProperty(prop.Name);
                            string NameResult;

                            if (propertyInfo.PropertyType.Name == "Int32")
                            {
                                NameResult = propertyInfo.Name;
                                propertyInfo.SetValue(application, Convert.ChangeType(result.GetInt32(NameResult), propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                if (propertyInfo.PropertyType.Name == "String")
                                {
                                    NameResult = propertyInfo.Name;

                                    if (NameResult != "tableName_")
                                    {

                                        propertyInfo.SetValue(application, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                    }
                                }

                                if (propertyInfo.PropertyType.Name == "Fields")
                                {
                                    application.field = (Fields)new Fields().findByID(result.GetInt32(propertyInfo.Name));
                                }

                                if (propertyInfo.PropertyType.Name == "Repairs")
                                {
                                    application.repair = (Repairs)new Repairs().findByID(result.GetInt32(propertyInfo.Name));
                                }

                                if (propertyInfo.PropertyType.Name == "Employees")
                                {
                                    application.SenderOfApplication = (Employees)new Employees().findByID(result.GetInt32(propertyInfo.Name));
                                }

                                if (propertyInfo.PropertyType.Name == "DateTime")
                                {
                                    NameResult = propertyInfo.Name;
                                    propertyInfo.SetValue(application, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "Decimal")
                                {
                                    NameResult = propertyInfo.Name;
                                    propertyInfo.SetValue(application, Convert.ChangeType(result.GetDecimal(NameResult), propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "List`1")
                                {

                                    NameResult = propertyInfo.Name;
                                    string s = result.GetString(NameResult);
                                    string[] mas = s.Split(',');
                                    if (propertyInfo.Name == "equipment")
                                    {
                                        List<Equipments> e = new List<Equipments>();
                                        foreach (string val in mas)
                                        {
                                            Equipments eq = (Equipments)new Equipments().findByID(Convert.ToInt32(val));
                                            e.Add(eq);
                                        }
                                        application.equipment = e;
                                    }

                                    else
                                    {
                                        if (propertyInfo.Name != "count")
                                        {
                                            List<Employees> e = new List<Employees>();
                                            foreach (string val in mas)
                                            {
                                                Employees emp = (Employees)new Employees().findByID(Convert.ToInt32(val));
                                                e.Add(emp);
                                            }
                                            application.technicians = e;
                                        }
                                        ///////////////////////////////////////else
                                    }
                                }
                            }
                        }
                        List.Add(application);
                    }
                }
            }
            return List;
        }
    }
}
