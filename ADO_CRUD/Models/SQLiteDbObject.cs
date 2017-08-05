using ADO_CRUD.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;

namespace ADO_CRUD.Models {
    public abstract class SQLiteDbObject<T> where T : new() {
        public List<T> GetAll(string whereClause = "") {
            List<T> result = new List<T>();
            using (SQLiteConnection conn = new SQLiteConnection(ServerSettings.ConnectionString)) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = "SELECT * FROM " + typeof(T).Name.ToString() + "s " + whereClause;
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.HasRows) {
                            PropertyInfo[] properties = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                            while (reader.Read()) {
                                var obj = new T();
                                foreach (var property in properties) {
                                    var columnIndex = reader.GetOrdinal(property.Name);
                                    if (!reader.IsDBNull(columnIndex))
                                        property.SetValue(obj, Convert.ToString(reader.GetValue(columnIndex)));
                                }
                                result.Add(obj);
                            }
                        }
                    }
                }
            };
            return result;
        }
        public void DeleteById(int id) {
            using (SQLiteConnection conn = new SQLiteConnection(ServerSettings.ConnectionString)) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = "DELETE FROM " + typeof(T).Name.ToString() 
                        + "s WHERE " + typeof(T).Name.ToString() + "Id = " + id.ToString();
                    cmd.ExecuteNonQuery();
                }
            };
        }
    }

}