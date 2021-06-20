using DatabaseDAL.DataAccess;
using HRM.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class StatisticSalaryController : Controller
    {
        // GET: StatisticSalary
        [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StatisticSalary()
        {
            return Json(DatabaseStatisticSalary.SearchStatisticEmployee(), JsonRequestBehavior.AllowGet);
        }
    }
}