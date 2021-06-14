using CoreLib.Models;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetContract(Contract contract)
        {            
            return Json(DatabaseContract.GetEmployees(contract), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertContract(Contract contract)
        {
            return Json(DatabaseContract.InsertContract(contract));
        }

        [HttpPut]
        public ActionResult UpdateContract(Contract contract)
        {
            return Json(DatabaseContract.UpdateContract(contract));
        }
    }
}