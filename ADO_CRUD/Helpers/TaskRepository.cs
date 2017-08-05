
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADO_CRUD.Models;

namespace ADO_CRUD.Helpers {
    public class TaskRepository : SQLiteDbObject<Task> {
        public List<Task> GetTasksForEmployee(int employeeId) {
            return base.GetAll("WHERE EmployeeId = " + employeeId.ToString());
        }
    }
}