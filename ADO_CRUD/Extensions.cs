using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Text;
using System.Data;
using System.Reflection;

namespace ADO_CRUD {
    public static class Extensions {

        static T[] Slice<T>(this T[] data, int start, int finish) {
            var result = new T[finish - start];
            int counter = 0;
            for (int i = start; i < finish; i++) {
                result[counter++] = data[i];
            }
            return result;
        }

        public static void AddToDatabase<T>(this T obj) where T : class {
            string tableName = typeof(T).Name.ToString() + "s "; 
            string left = "INSERT INTO " + tableName + " (";
            string right = "VALUES (";

            // Get the properties that have not null values
            List<string> properties = typeof(T).GetProperties()
                                               .Where(x => (x.GetValue(obj) != null) && (x.GetValue(obj).ToString() != "0"))
                                               .Select(x => x.Name)
                                               .ToList();

            // Get the values of those properties
            List<string> values = typeof(T).GetProperties()
                                           .Where(x => (x.GetValue(obj) != null) && (x.GetValue(obj).ToString() != "0"))
                                           .Select(x => x.GetValue(obj).ToString())
                                           .ToList();
            
            for (int i = 0; i < properties.Count; i++) {
                left += "`" + properties[i] + "`";
                right += "'" + values[i] + "'";

                var t = ",";
                if (i == properties.Count - 1) {
                    t = ")";
                }
                left += t;
                right += t;
            }

            var query = left + right;
            using (var conn = new SQLiteConnection(@"Data Source=D:Projects\MyDB.s3db")) {
                //conn.Open();
                //using (var cmd = new SQLiteCommand(conn)) {
                //    cmd.CommandText = query;
                //    SQLiteDataReader reader = cmd.ExecuteReader();
                //}
            };
        }
    }
}