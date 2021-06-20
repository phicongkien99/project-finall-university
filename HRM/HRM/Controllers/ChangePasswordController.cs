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
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        [RequiredLogin]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword changePassword)
        {
            changePassword.Username = HttpContext.Session["Username"].ToString();
            return Json(DatabaseLogin.ChangePassword(changePassword));
        }
    }
}