using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Models.ViewModels;
using DatabaseDAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HRM_API.Controllers
{
    [Route("api/[controller]")]
    public class LoginAPIController : ApiController
    {       
        [HttpPost]
        [Route(CommonConstants.API_LOGIN)]       
        public IHttpActionResult Login(LoginViewModel loginViewModel)
        {
            if (!string.IsNullOrEmpty(loginViewModel.UserName) && !string.IsNullOrEmpty(loginViewModel.PassWord))
            {                
                return Ok(DatabaseLogin.UserLogin(loginViewModel));
            }
                
            return Ok(new CResult { ErrorCode = -1, ErrorMessage = "Tên đăng nhập hoặc mật khẩu sai!" });
        }

        
    }
}
