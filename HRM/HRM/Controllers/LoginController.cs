using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Models.ViewModels;
using CoreLib.Utils;
using HRM.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRM.Controllers
{
    public class LoginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel)
        {
            var errorCode = 0;
            var errorMess = string.Empty;
            
            if (Validate(loginViewModel.UserName, loginViewModel.PassWord, out errorCode, out errorMess))
            {
                var cResult = await CCallApi.PostTemplateAsync(loginViewModel, CommonConstants.API_LOGIN);

                return Json(cResult);
            }
            
            return Json(new CResult { ErrorCode = errorCode, ErrorMessage = errorMess });
        }

        public ActionResult GetCaptchaImage()
        {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session["CaptchaCode"] = result.CaptchaCode;
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }

        // Validate Username, Password
        private bool Validate(string username, string password, out int errorCode, out string errorMess)
        {
            errorCode = 0;
            errorMess = null;

            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    errorMess = "Tên đăng nhập không được để trống!";
                    errorCode = -1;
                    return false;
                }

                if (!CheckUtils.ContainsUnicodeCharacter(username))
                {
                    errorMess = "Sai đên đăng nhập hoặc mật khẩu!";
                    errorCode = -1;
                    return false;
                }

                if (string.IsNullOrEmpty(password))
                {
                    errorMess = "Mật khẩu không được để trống!";
                    errorCode = -1;
                    return false;
                }
            }
            catch (Exception)
            {
                
            }
            return true;
        }
    }
}