using CoreLib.Models;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSalary(Salary salary)
        {
            return Json(DatabaseSalary.SearchSalary(salary), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertSalary(Salary salary)
        {
            return Json(DatabaseSalary.InsertSalary(salary));
        }
        
        [HttpDelete]
        public ActionResult DeleteSalary(int id)
        {
            return Json(DatabaseSalary.DeleteSalary(id));
        }
    }
}