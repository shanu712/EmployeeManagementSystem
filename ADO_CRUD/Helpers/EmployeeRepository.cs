using ADO_CRUD.Helpers;
using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ADO_CRUD.Helpers {

    public class EmployeeRepository : SQLiteDbObject<Employee> {

    }
}