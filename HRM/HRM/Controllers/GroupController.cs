﻿using HRM.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class GroupController : Controller
    {
        [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGroup()
        {


            return Json(null);
        }
    }
}