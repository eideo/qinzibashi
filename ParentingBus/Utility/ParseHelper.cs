using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;

namespace Utility
{
    public static class ParseHelper
    {
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            List<PropertyInfo> pList = new List<PropertyInfo>();
            Type type = typeof(T);
            DataTable dt = new DataTable();
            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });
            foreach (var item in list)
            { 
                DataRow row = dt.NewRow(); 
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));  
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}
