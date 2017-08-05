using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO_CRUD.ViewModels.Employee {
    public class Details {
        public Models.Employee employee = new Models.Employee();
        public List<Task> tasks = new List<Task>();
    }
}