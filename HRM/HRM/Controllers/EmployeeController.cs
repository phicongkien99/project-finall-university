using CoreLib.Models.ViewModels;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ListEmployee()
        {
            return View();
        }

        // INSERT: Employee
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpGet]
        [Route("/get-employee")]
        public ActionResult GetEmployee(EmployeeViewModel employeeViewModel)
        {            
            return Json(DatabaseEmployee.GetEmployees(employeeViewModel), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("/insert-employee")]
        public ActionResult InsertEmployee(EmployeeViewModel employeeViewModel)
        {
            return Json(DatabaseEmployee.InsertEmployee(employeeViewModel));
        }

        [HttpPut]
        [Route("/update-employee")]
        public ActionResult UpdateEmployee(EmployeeViewModel employeeViewModel)
        {
            return Json(DatabaseEmployee.UpdateEmployee(employeeViewModel));
        }
    }
}