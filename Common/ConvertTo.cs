using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConvertTo
    {

        public static IList<T> convertToList<T>(DataTable dt) where T : new()
        {
            List<T> lis = new List<T>();
            Type type = typeof(T);
            string tempName = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value) { pi.SetValue(t, value, null); }
                    }

                }
                lis.Add(t);
            }
            return lis;
        }

        public static object convertToModel(DataTable dt, object model)
        {
            if (dt != null && dt.Rows.Count != 0)
            {

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in model.GetType().GetProperties())
                    {
                        if (row.Table.Columns.Contains(item.Name))
                        {
                            if (DBNull.Value != row[item.Name])
                            {
                                item.SetValue(model, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                            }

                        }
                    }
                }
            }
            else
            {
                model = null;

            }


            return model;

        }
    }
}

