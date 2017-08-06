using ADO_CRUD.Helpers;
using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employees = employeeRepository.GetAll();

            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id) {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            TaskRepository taskRepository = new TaskRepository();

            ViewModels.Employee.Details model = new ViewModels.Employee.Details();
            model.employee = employeeRepository.GetById(id);
            model.tasks = taskRepository.GetTasksForEmployee(id);
            return View(model);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                employeeRepository.Insert(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = new Employee();
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employee = employeeRepository.GetById(id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.DeleteById(id);
            return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Details", "Employee", new { id = 5 } );
            }
            catch
            {
                return View();
            }
        }
    }
}
