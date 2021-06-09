using CoreLib.Commons;
using CoreLib.Models;
using HRM.Authentication;
using HRM.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class GroupController : Controller
    {        
        // [RequiredLogin]
        public ActionResult Index()
        {
            return View();
        }
               
        public ActionResult IndexCreate()
        {
            return View();
        }

        [HttpGet]
        [Route("/get-group")]
        public async Task<ActionResult> GetGroup(Group group)
        {
            var obj = await CCallApi.SearchTemplateAsync(CommonConstants.API_GET_GROUP + $"?groupcode={group.GroupCode}&groupname={group.GroupName}");

            if (string.IsNullOrEmpty(obj?.ToString() ?? null)) return Json(null);

            var listGroup = JsonConvert.DeserializeObject<List<Group>>(obj.ToString());

            return Json(listGroup, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("/insert-group")]
        public async Task<ActionResult> InsertGroup(Group group)
        {
            var obj = await CCallApi.PostTemplateAsync(group, CommonConstants.API_INSERT_GROUP);
            
            return Json(obj);
        }

        [HttpPut]
        [Route("/update-group")]
        public async Task<ActionResult> UpdateGroup(Group group)
        {
            var obj = await CCallApi.PutTemplateAsync(group, CommonConstants.API_UPDATE_GROUP);
            
            return Json(obj);
        }

        [HttpDelete]
        [Route("/delete-group")]
        public async Task<ActionResult> DeleteGroup(string groupCode)
        {
            var obj = await CCallApi.DeleteTemplateAsync(CommonConstants.API_DELETE_GROUP + $"?groupCode={groupCode}");
            
            return Json(obj);
        }
    }
}