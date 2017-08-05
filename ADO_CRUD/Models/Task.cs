using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO_CRUD.Models {
    public class Task {
        public string TaskId { get; set; }
        public string Title { get; set; }
        public string EmployeeId { get; set; }
    }
}