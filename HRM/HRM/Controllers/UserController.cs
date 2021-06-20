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
    public class UserController : Controller
    {
        // GET: User
        [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/get-user-emp")]
        public ActionResult GetUserEmployee(User user)
        {
            return Json(DatabaseUser.GetUserEmployees(user), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("/insert-user")]
        public ActionResult InsertUser(User user)
        {
            return Json(DatabaseUser.InsertUser(user));
        }

        [HttpPut]
        [Route("/update-user")]
        public ActionResult UpdateUser(User user)
        {
            return Json(DatabaseUser.UpdateUser(user));
        }
    }
}