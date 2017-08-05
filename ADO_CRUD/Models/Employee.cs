using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ADO_CRUD.Models {
    public class Employee {
        [Display(Name = "Id")]
            public string EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
            public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
            public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }
        
            public string City { get; set; }
        
            public string Address { get; set; }

            public List<Task> Tasks;
    }
}