using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ADO_CRUD.Helpers {
    public abstract class SQLiteDbObject<T> where T : new() {
        public void Insert(T obj) {
            string tableName = typeof(T).Name.ToString() + "s ";
            string left = "INSERT INTO " + tableName + " (";
            string right = "VALUES (";
            
            List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
            // Excepting `ID` fields, because its set to autoincrement
            properties = properties.Slice(1, properties.Count);
            
            // Get the values of those properties
            List<string> values = properties
                                  .Select(x => x.GetValue(obj).ToString())
                                  .ToList();

            List<string> names = properties
                        .Select(x => x.Name)
                        .ToList();

            for (int i = 0; i < properties.Count; i++) {
                left += "`" + names[i] + "`";
                right += "'" + values[i] + "'";

                var t = ",";
                if (i == names.Count - 1) {
                    t = ")";
                }
                left += t;
                right += t;
            }

            var query = left + right;
            using (var conn = new SQLiteConnection(@"Data Source=D:Projects\MyDB.s3db")) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public List<T> GetAll(string whereClause = "") {
            List<T> result = new List<T>();
            using (SQLiteConnection conn = new SQLiteConnection(ServerSettings.ConnectionString)) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = "SELECT * FROM " + typeof(T).Name.ToString() + "s " + whereClause;
                    using (var reader = cmd.ExecuteReader()) {
                        if (reader.HasRows) {
                            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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

        public T GetById(int id) {
            T result = new T();
            using (SQLiteConnection conn = new SQLiteConnection(ServerSettings.ConnectionString)) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = "SELECT * FROM " + typeof(T).Name.ToString()
                        + "s WHERE " + typeof(T).Name.ToString() + "Id = " + id.ToString();
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
                                result = obj;
                            }
                        }
                    }
                }
            };
            return result;
        }
    }
}