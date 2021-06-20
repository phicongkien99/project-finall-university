using DatabaseDAL.DataAccess;
using HRM.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class StatisticEmployeeController : Controller
    {
        // GET: StatisticEmployee
        [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStatisticEmp()
        {
            return Json(DatabaseStatisticEmployee.SearchStatisticEmployee(), JsonRequestBehavior.AllowGet);
        }
    }
}