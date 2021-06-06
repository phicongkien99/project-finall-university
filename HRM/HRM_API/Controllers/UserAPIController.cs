using CoreLib.Commons;
using CoreLib.Models.ViewModels;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRM_API.Controllers
{
    public class UserAPIController : ApiController
    {      
        [HttpGet]
        [Route(CommonConstants.API_GET_USER)]        
        public IHttpActionResult GetUser(string username, string empCode, string fullname, string email, bool? clienStatus)
        {
            return Ok(DatabaseUser.GetUsers(new UserViewModel {Username = username, EmpCode = empCode, FullName = fullname, Email = email, ClientStatus = clienStatus}));
        }
    }
}
