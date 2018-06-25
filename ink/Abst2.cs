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
    public abstract class Abst2
    {
        public string tableName_ { get; set; }
        public virtual object findByID(int id)
        {
            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                string queryString = @"SELECT * FROM " + this.tableName_ + " WHERE id=" + id;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);

                MySqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows)
                {
                    result.Read();

                    foreach (var prop in this.GetType().GetProperties())
                    {
                        if (prop.Name == "tableName") continue;
                        PropertyInfo propertyInfo = this.GetType().GetProperty(prop.Name);
                        string NameResult;

                        if (propertyInfo.PropertyType.Name == "Fields")
                        {
                            Fields f = (Fields)new Fields().findByID(result.GetInt32(propertyInfo.Name));
                            propertyInfo.SetValue(this, Convert.ChangeType(f, propertyInfo.PropertyType), null);
                        }

                        if (propertyInfo.PropertyType.Name == "Repairs")
                        {
                            Repairs r = (Repairs)new Repairs().findByID(result.GetInt32(propertyInfo.Name));
                            propertyInfo.SetValue(this, Convert.ChangeType(r, propertyInfo.PropertyType), null);
                        }

                        if (propertyInfo.PropertyType.Name == "Employees")
                        {
                            Employees e = (Employees)new Employees().findByID(result.GetInt32(propertyInfo.Name));
                            propertyInfo.SetValue(this, Convert.ChangeType(e, propertyInfo.PropertyType), null);
                        }

                        if (propertyInfo.PropertyType.Name == "DateTime")
                        {
                            propertyInfo.SetValue(this, Convert.ChangeType(result.GetString(propertyInfo.Name), propertyInfo.PropertyType), null);
                        }

                        if (propertyInfo.PropertyType.Name == "Decimal")
                        {
                            propertyInfo.SetValue(this, Convert.ChangeType(result.GetDecimal(propertyInfo.Name), propertyInfo.PropertyType), null);
                        }


                        if (propertyInfo.PropertyType.Name == "List`1")
                        {
                            string s = result.GetString(propertyInfo.Name);
                            string[] mas = s.Split(',');
                            if (propertyInfo.Name == "equipment")
                            {
                                List<Equipments> e = new List<Equipments>();
                                foreach (string val in mas)
                                {
                                    Equipments eq = (Equipments)new Equipments().findByID(Convert.ToInt32(val));
                                    e.Add(eq);
                                }
                                propertyInfo.SetValue(this, Convert.ChangeType(e, propertyInfo.PropertyType), null);
                            }

                            else
                            {
                                List<Employees> e = new List<Employees>();
                                foreach (string val in mas)
                                {
                                    Employees emp = (Employees)new Employees().findByID(Convert.ToInt32(val));
                                    e.Add(emp);
                                }
                                propertyInfo.SetValue(this, Convert.ChangeType(e, propertyInfo.PropertyType), null);
                            }         
                        }

                        if (propertyInfo.PropertyType.Name == "Int32")
                        {
                            NameResult = propertyInfo.Name;
                            propertyInfo.SetValue(this, Convert.ChangeType(result.GetInt32(NameResult), propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            if (propertyInfo.PropertyType.Name == "String")
                            {
                                NameResult = propertyInfo.Name;

                                if (NameResult != "tableName_")
                                {
                                    propertyInfo.SetValue(this, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                }
                            }
                        }
                    }
                }
            }
            return this;
        }
        public virtual List<object> findByName(string name)
        {
            List<object> List = new List<object>();

            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                string queryString = @"SELECT * FROM " + this.tableName_ + " WHERE name_=" + "'" + name + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);

                MySqlDataReader result = cmd.ExecuteReader();
                Type t = this.GetType();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var SomeObject = Activator.CreateInstance(t);

                        foreach (var prop in t.GetProperties())
                        {
                            if (prop.Name == "tableName") continue;
                            PropertyInfo propertyInfo = this.GetType().GetProperty(prop.Name);
                            string NameResult;

                            if (propertyInfo.PropertyType.Name == "Int32")
                            {
                                NameResult = propertyInfo.Name;
                                propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetInt32(NameResult), propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                if (propertyInfo.PropertyType.Name == "String")
                                {
                                    NameResult = propertyInfo.Name;

                                    if (NameResult != "tableName_")
                                    {
                                        propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                    }
                                }
                            }
                        }
                        List.Add(SomeObject);
                    }
                }
            }
            return List;
        }

        public virtual List<object> getList(object filter, object sorting)
        {
            List<string> valuesFilter = new List<string>();
            List<string> valuesSorting = new List<string>();
            List<object> ListObjects = new List<object>();

            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                con.Open();
                foreach (var prop in filter.GetType().GetProperties())
                {
                    if (prop.Name == "tableName_") continue;
                    // -1 это поля, не задействованные в фильтре
                    if ((prop.GetValue(filter) != null) && (prop.GetValue(filter).ToString() != "-1") && (prop.GetValue(filter).ToString() != "01.01.0001 0:00:00"))
                    {
                        try
                        {
                            Fields f = (Fields)prop.GetValue(filter);

                            valuesFilter.Add(prop.Name + "=" + "'" + f.ID + "'");
                            continue;
                        }
                        catch
                        {
                            valuesFilter.Add(prop.Name + "=" + "'" + prop.GetValue(filter) + "'");
                        }
                    }
                }

                foreach (var prop in sorting.GetType().GetProperties())
                {
                    if (prop.Name == "tableName_") continue;
                    if ((prop.GetValue(sorting) != null) && (prop.GetValue(sorting).ToString() != "-1") && (prop.GetValue(sorting).ToString() != "01.01.0001 0:00:00"))
                    {
                        valuesSorting.Add(prop.Name);
                    }
                }
                string sql = "";

                try
                {
                    if ((valuesSorting.Count != 0) && (valuesFilter.Count != 0))
                    { sql = @"select * from " + this.tableName_ + " where " + "(" + valuesFilter.Aggregate((workingSQL, next) => next + " and " + workingSQL) + ")" + " order by " + valuesSorting.Aggregate((workingSQL, next) => next + ", " + workingSQL); }
                    else
                    {
                        if ((valuesSorting.Count != 0) && (valuesFilter.Count == 0))
                        {
                            sql = @"select * from " + this.tableName_ + " order by " + valuesSorting.Aggregate((workingSQL, next) => next + ", " + workingSQL);
                        }

                        if ((valuesSorting.Count == 0) && (valuesFilter.Count != 0))
                        {
                            sql = @"select * from " + this.tableName_ + " where " + "(" + valuesFilter.Aggregate((workingSQL, next) => next + " and " + workingSQL) + ")";
                        }
                    }
                }

                catch { sql = @"select * from " + this.tableName_; }

                if (sql == "") { sql = @"select * from " + this.tableName_; }

                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader result = cmd.ExecuteReader();
                Type t = this.GetType();

                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        var SomeObject = Activator.CreateInstance(t);

                        List<Equipments> elp = new List<Equipments>(); 
                        PropertyInfo equipments_ = this.GetType().GetProperty("equipment");

                        foreach (var props in t.GetProperties())
                        {
                            if (props.Name == "tableName") continue;
                            PropertyInfo propertyInfo = this.GetType().GetProperty(props.Name);
                            

                            string NameResult;

                            if (propertyInfo.PropertyType.Name == "Int32")
                            {
                                NameResult = propertyInfo.Name; 
                                propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetInt32(NameResult), propertyInfo.PropertyType), null);
                            }
                            else
                            {
                                if (propertyInfo.PropertyType.Name == "String")
                                {
                                    NameResult = propertyInfo.Name;

                                    if (NameResult != "tableName_")
                                    {
                                        propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetString(NameResult), propertyInfo.PropertyType), null);
                                    }
                                }
                                if (propertyInfo.PropertyType.Name == "Fields")
                                {

                                    Fields f = (Fields)new Fields().findByID(result.GetInt32(propertyInfo.Name));
                                    propertyInfo.SetValue(SomeObject, Convert.ChangeType(f, propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "Repairs")
                                {
                                    Repairs r = (Repairs)new Repairs().findByID(result.GetInt32(propertyInfo.Name));
                                    propertyInfo.SetValue(SomeObject, Convert.ChangeType(r, propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "Employees")
                                {
                                    Employees ep = (Employees)new Employees().findByID(result.GetInt32(propertyInfo.Name));
                                    propertyInfo.SetValue(SomeObject, Convert.ChangeType(ep, propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "DateTime")
                                {
                                    propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetString(propertyInfo.Name), propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "Decimal")
                                {
                                    propertyInfo.SetValue(SomeObject, Convert.ChangeType(result.GetDecimal(propertyInfo.Name), propertyInfo.PropertyType), null);
                                }

                                if (propertyInfo.PropertyType.Name == "List`1")
                                {
                                    string s = result.GetString(propertyInfo.Name);
                                    string[] mas = s.Split(',');
                                    

                                    if (propertyInfo.Name == "equipment")
                                    {                     
                                        foreach (string val in mas)
                                        {
                                            Equipments eq = (Equipments)new Equipments().findByID(Convert.ToInt32(val));
                                            elp.Add(eq);
                                        }
                                        propertyInfo.SetValue(SomeObject, Convert.ChangeType(elp, propertyInfo.PropertyType), null);
                                    }

                                    else
                                    {
                                        if (propertyInfo.Name != "count")
                                        {
                                            List<Employees> ed = new List<Employees>();
                                            foreach (string val in mas)
                                            {
                                                Employees emp = (Employees)new Employees().findByID(Convert.ToInt32(val));
                                                ed.Add(emp);
                                            }
                                            propertyInfo.SetValue(SomeObject, Convert.ChangeType(ed, propertyInfo.PropertyType), null);
                                        }

                                        if (propertyInfo.Name == "count")
                                        {
                                            List<string> countSt = new List<string>();
                                            string countt = "";
                                            foreach (string val in mas)
                                            {
                                                if (countt == "")
                                                {
                                                    countt = countt + val;
                                                }
                                                else
                                                {
                                                    countt = countt + ", "+ val;
                                                }                                               
                                            }
                                            propertyInfo.SetValue(SomeObject, Convert.ChangeType(countt, propertyInfo.PropertyType), null);

                                           
                                        }
                                    }
                                }
                            }
                        }
                        ListObjects.Add(SomeObject);
                    }
                }
            }
            return ListObjects;
        }
        public virtual int getMaxID()
        {
            int max = 0;

            ConnectionStringSettings conString;
            conString = ConfigurationManager.ConnectionStrings["MySQLConStr"];
            using (MySqlConnection con = new MySqlConnection(conString.ConnectionString))
            {
                string queryString = @"select * from " + this.tableName_ + " WHERE id=(select max(id) from " + this.tableName_ + ")";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);

                MySqlDataReader result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    Type t = this.GetType();

                    foreach (var prop in t.GetProperties())
                    {
                        if (prop.Name == "ID")
                        {
                            max = result.GetInt32("id");
                            break;
                        }
                    }
                }
            }
            return max;
        }
    }
}

