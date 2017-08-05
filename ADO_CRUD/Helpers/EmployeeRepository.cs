using ADO_CRUD.Helpers;
using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ADO_CRUD.Helpers {

    public class EmployeeRepository : SQLiteDbObject<Employee>, IQueryable<Employee> {

        //public List<Employee> GetAll() {
        //    List<Employee> employees = new List<Employee>();
        //    using (SQLiteConnection conn = new SQLiteConnection(ServerSettings.ConnectionString)) {
        //        conn.Open();
        //        using (var cmd = new SQLiteCommand(conn)) {
        //            cmd.CommandText = "select * from Employees";
        //            using (var reader = cmd.ExecuteReader()) {
        //                if (reader.HasRows) {
        //                    PropertyInfo[] properties = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //                    while (reader.Read()) {
        //                        var employee = new Employee();
        //                        foreach (var property in properties) {
        //                            var columnIndex = reader.GetOrdinal(property.Name);
        //                            if (!reader.IsDBNull(columnIndex))
        //                                property.SetValue(employee, Convert.ToString(reader.GetValue(columnIndex)));
        //                        }
        //                        employees.Add(employee);
        //                    }
        //                }
        //            }
        //        }
        //    };
        //    return employees;
        //}

        public object GetById(int id) {
            throw new NotImplementedException();
        }

        public void Update(object obj) {
            throw new NotImplementedException();
        }
    }
}