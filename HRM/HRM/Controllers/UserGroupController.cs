using CoreLib.Models;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class UserGroupController : Controller
    {
        // GET: UserGroup
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/get-user-group")]
        public ActionResult GetUserGroup(string groupCode)
        {
            var userGroups = DatabaseUserGroup.SearchUserGroup(groupCode);

            return Json(userGroups, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("/insert-user-group")]
        public ActionResult InsertUserGroup(string groupCode, string userName)
        {
            if (string.IsNullOrEmpty(groupCode) || string.IsNullOrEmpty(userName))
                return Json(new CResult { ErrorMessage = "Không tìm thấy!", ErrorCode = -1 });

            var createBy = HttpContext.Session["Username"]?.ToString() ?? "admin";

            var result = DatabaseUserGroup.InsertUserGroup(new CoreLib.Models.UserGroup { GroupCode = groupCode, Username = userName, CreateBy = createBy });

            return Json(result);
        }

        [HttpDelete]
        [Route("/delete-user-group")]
        public ActionResult DeleteUserGroup(string groupCode, string userName)
        {
            if (string.IsNullOrEmpty(groupCode) || string.IsNullOrEmpty(userName))
                return Json(new CResult { ErrorMessage = "Không tìm thấy!", ErrorCode = -1 });

            var result = DatabaseUserGroup.DeleteUserGroup(groupCode, userName);

            return Json(result);
        }
    }
}