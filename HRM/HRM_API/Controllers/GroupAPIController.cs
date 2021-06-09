using CoreLib.Commons;
using CoreLib.Models;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRM_API.Controllers
{
    public class GroupAPIController : ApiController
    {
        [HttpGet]
        [Route(CommonConstants.API_GET_GROUP)]
        public IHttpActionResult GetGroup(string groupCode, string groupName)
        {
            //return Ok(DatabaseGroup.SearchGroup(groupCode, groupName));
            return Ok(DatabaseUserGroup.SearchGroup(groupCode, groupName));
        }

        [HttpPost]
        [Route(CommonConstants.API_INSERT_GROUP)]
        public IHttpActionResult InsertGroup(Group group)
        {            
            return Ok(DatabaseGroup.InsertGroup(group));
        }

        [HttpPut]
        [Route(CommonConstants.API_UPDATE_GROUP)]
        public IHttpActionResult UpateGroup(Group group)
        {
            return Ok(DatabaseGroup.UpdateGroup(group));
        }

        [HttpDelete]
        [Route(CommonConstants.API_DELETE_GROUP)]
        public IHttpActionResult DeleteGroup(string groupCode)
        {
            return Ok(DatabaseGroup.DeleteGroup(groupCode));
        }
    }
}
