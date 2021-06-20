using CoreLib.Models;
using DatabaseDAL.DataAccess;
using HRM.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class InsuranceController : Controller
    {
        // GET: Insurance
        [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetInsurance(InsuranceSocial insuranceSocial)
        {
            return Json(DatabaseInsurance.SearchInsurance(insuranceSocial), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertInsurance(InsuranceSocial insuranceSocial)
        {
            return Json(DatabaseInsurance.InsertInsurance(insuranceSocial));
        }

        [HttpDelete]
        public ActionResult DeleteInsurance(int id)
        {
            return Json(DatabaseInsurance.DeleteInsurance(id));
        }
    }
}