using CoreLib.Models;
using DatabaseDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class BonusController : Controller
    {
        // GET: Bonus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBonus(Bonus bonus)
        {
            return Json(DatabaseBonus.SearchBonus(bonus), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertBonus(Bonus bonus)
        {
            return Json(DatabaseBonus.InsertBonus(bonus));
        }

        [HttpDelete]
        public ActionResult DeleteBonus(int id)
        {
            return Json(DatabaseBonus.DeleteBonus(id));
        }
    }
}