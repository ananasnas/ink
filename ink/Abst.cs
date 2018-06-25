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
    public abstract class Abst
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
        public string tableName_ { get; set; }
        public virtual void add()
        {
            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                List<string> sqlNames = new List<string>();
                List<string> sqlValues = new List<string>();
                foreach (var prop in this.GetType().GetProperties()) // По всем атрибутам класса
                {
                    if (prop.Name == "tableName_") continue;

                    if (this.tableName_ == "applications")
                    {
                        if (prop.Name == "name_") continue;
                        PropertyInfo propertyInfo = this.GetType().GetProperty(prop.Name);
                        if (prop.Name == "equipment")
                        {
                            sqlNames.Add(prop.Name);

                            Object e = propertyInfo.GetValue(this);
                            List<Equipments> eq = (List<Equipments>)e;
                            string p = null;
                            string value_ = null;
                            for (int i = 0; i < eq.Count; i++)
                            {
                                p = eq[i].ID.ToString();

                                if (i == 0)
                                {
                                    value_ = value_ + p;
                                }
                                else
                                {
                                    value_ = value_ + "," + p;
                                }
                            }
                           // sqlValues[0] = sqlValues[0] + "'" + " ";
                            sqlValues.Add("'" + value_ + "'");
                        }
                        if (prop.Name == "technicians")
                        {
                            sqlNames.Add(prop.Name);
                            Object e = propertyInfo.GetValue(this);
                            List<Employees> em = (List<Employees>)e;
                            string p = null;
                            string value_ = null;
                            for (int i = 0; i < em.Count; i++)
                            {
                                p = em[i].ID.ToString();
                                if (i == 0)
                                {
                                    value_ = value_ + p;
                                }
                                else
                                {
                                    value_ = value_ + "," + p;
                                }
                            }
                            sqlValues.Add("'" + value_ + "'");
                        }
                        if (prop.Name == "field")
                        {
                            sqlNames.Add(prop.Name);
                            Object e = propertyInfo.GetValue(this);
                            Fields field = (Fields)e;
                            string p = field.ID.ToString();
                            sqlValues.Add("'" + p + "'");
                        }
                        if (prop.Name == "repair")
                        {
                            sqlNames.Add(prop.Name);
                            Object e = propertyInfo.GetValue(this);
                            Repairs re = (Repairs)e;
                            string p = re.ID.ToString();
                            sqlValues.Add("'" + p + "'");
                        }
                        if (prop.Name == "SenderOfApplication")
                        {
                            sqlNames.Add(prop.Name);
                            Object e = propertyInfo.GetValue(this);
                            Employees re = (Employees)e;
                            string p = re.ID.ToString();
                            sqlValues.Add("'" + p + "'");
                        }

                        if (((propertyInfo.PropertyType.Name == "String") ||
                            (propertyInfo.PropertyType.Name == "Int32") || (propertyInfo.PropertyType.Name == "Decimal")) && prop.Name != "comment")
                        {
                            sqlNames.Add(prop.Name);
                            sqlValues.Add("'" + Convert.ToString(prop.GetValue(this)) + "'");
                        }
                        if (propertyInfo.PropertyType.Name == "DateTime")
                        {
                            sqlNames.Add(prop.Name);
                            DateTime g = (DateTime)prop.GetValue(this);
                            string data = g.ToString("yyyy-MM-dd HH:mm:ss");
                            sqlValues.Add("'" + data + "'");
                        }
                        if (prop.Name == "comment")
                        {
                            sqlNames.Add(prop.Name);
                            sqlValues.Add("'" + prop.GetValue(this) + "'");
                        }
                    }
                    else
                    {
                        sqlNames.Add(prop.Name);
                        sqlValues.Add("'" + Convert.ToString(prop.GetValue(this)) + "'");
                    }
                }
                string sql = @"insert into " + this.tableName_ + " (" + sqlNames.Aggregate((workingSQL, next) => next + ", " + workingSQL) + ") values (" + sqlValues.Aggregate((workingSQL, next) => next + ", " + workingSQL) + ")";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }
        public virtual void del()
        {
            ConnectionStringSettings conString;

            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                string queryString = @"DELETE FROM " + this.tableName_ + " WHERE (id =@id_)";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@id_", ID);
                cmd.ExecuteNonQuery();
            }
        }

        public virtual void edit()
        {
            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                List<string> sqlValues = new List<string>();

              
                foreach (var prop in this.GetType().GetProperties()) // По всем атрибутам класса
                {
                    if (prop.Name == "tableName_") continue;
                    if (prop.Name == "id") continue;
                    if (this.tableName_ == "applications")
                    {
                        if (prop.Name == "name_") continue;
                        PropertyInfo propertyInfo = this.GetType().GetProperty(prop.Name);
                            if (prop.Name == "equipment")
                            {
                                Object e = propertyInfo.GetValue(this);
                                List<Equipments> eq = (List<Equipments>)e;
                                string p = null;
                                for (int i = 0; i < eq.Count; i++)
                                {
                                    p = eq[i].ID.ToString();

                                    if (i == 0)
                                    {
                                        sqlValues[0] = sqlValues[0] + "," + prop.Name + "='" + p;
                                    }
                                    else
                                    {
                                        sqlValues[0] = sqlValues[0] + "," + p;
                                    }
                                }
                                sqlValues[0] = sqlValues[0] + "'" + " ";
                            }
                            if (prop.Name == "technicians")
                            {
                                Object e = propertyInfo.GetValue(this);
                                List<Employees> em = (List<Employees>)e;
                                string p = null;
                                for (int i = 0; i < em.Count; i++)
                                {
                                    p = em[i].ID.ToString();
                                    if (i == 0)
                                    {
                                        sqlValues[0] = sqlValues[0] + "," + prop.Name + "='" + p;
                                    }
                                    else
                                    {
                                        sqlValues[0] = sqlValues[0] + "," + p;
                                    }
                                }
                                sqlValues[0] = sqlValues[0] + "'";
                            }
                            if (prop.Name == "field")
                            {
                                Object e = propertyInfo.GetValue(this);
                                Fields field = (Fields)e;
                                string p = field.ID.ToString();
                                sqlValues[0] = sqlValues[0] + ", " + prop.Name + "='" + p + "'";
                            }
                            if (prop.Name == "repair")
                            {
                                Object e = propertyInfo.GetValue(this);
                                Repairs re = (Repairs)e;
                                string p = re.ID.ToString();
                                sqlValues[0] = sqlValues[0] + ", " + prop.Name + "='" + p + "'";
                            }
                            if (prop.Name == "SenderOfApplication")
                            {
                                Object e = propertyInfo.GetValue(this);
                                Employees re = (Employees)e;
                                string p = re.ID.ToString();
                                sqlValues[0] = sqlValues[0] + ", " + prop.Name + "='" + p + "'";
                            }

                            if (((propertyInfo.PropertyType.Name == "String") ||
                                (propertyInfo.PropertyType.Name == "Int32") || (propertyInfo.PropertyType.Name == "Decimal")) && prop.Name != "comment")
                            {
                                sqlValues[0] = sqlValues[0] + ", " + prop.Name + "='" + Convert.ToString(prop.GetValue(this)) + "'";
                            }
                            if (propertyInfo.PropertyType.Name == "DateTime")
                            {
                                DateTime g = (DateTime)prop.GetValue(this);
                                string data = g.ToString("yyyy-MM-dd HH:mm:ss");
                                sqlValues[0] = sqlValues[0] + ", " + prop.Name + "='" + data + "'";
                            }
                            if (prop.Name == "comment")
                            {
                                sqlValues.Add(prop.Name + "='" + prop.GetValue(this) + "'");
                            }
                         if (prop.Name == "count")
                         {
                             string co = (string)prop.GetValue(this);
                             sqlValues[0] = sqlValues[0] + "," + prop.Name + "='" + co + "'";
                         }
                    }
                      
                    else
                    {
                        sqlValues.Add(prop.Name + "='" + Convert.ToString(prop.GetValue(this)) + "'");
                    }
                }
                string sql = "update " + this.tableName_ + " set " + sqlValues.Aggregate((workingSQL, next) => next + ", " + workingSQL) + " where id=" + this.id;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

    }
}