using CoreLib.Commons;
using CoreLib.Models;
using CoreLib.Models.ModelView;
using CoreLib.Models.ViewModels;
using CoreLib.Utils;
using HRM.Authentication;
using HRM.Utils;
using Newtonsoft.Json;
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
        public async Task<ActionResult> Login(string username, string password, string captchaCode)
        {
            var errorCode = 0;
            var errorMess = string.Empty;
            
            if (Validate(username, password, out errorCode, out errorMess))
            {                
                if (Captcha.ValidateCaptchaCode(captchaCode, HttpContext))
                {
                    var cResult = await CCallApi.PostTemplateAsync(new LoginViewModel { UserName = username, PassWord = password }, CommonConstants.API_LOGIN);

                    if (cResult.ErrorCode == 0)
                    {
                        var param = $"?username={username}&empCode=&fullname=&email=&clienStatus=";

                        try
                        {
                            var obj = await CCallApi.SearchTemplateAsync(CommonConstants.API_GET_USER + param);

                            List<UserModelView> users = JsonConvert.DeserializeObject<List<UserModelView>>(obj.ToString());

                            if (users.Count > 0)
                            {
                                HttpContext.Session["Username"] = users.FirstOrDefault().Username;
                                HttpContext.Session["EmpCode"] = users.FirstOrDefault().EmpCode;
                                HttpContext.Session["Fullname"] = users.FirstOrDefault().FullName;
                                HttpContext.Session["Email"] = users.FirstOrDefault().Email;
                                HttpContext.Session["GroupCode"] = users.FirstOrDefault().GroupCode;
                            }

                            return RedirectToAction("Index", "Profile");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        
                    }

                    TempData.Add("Message", cResult.ErrorMessage);

                    ViewBag.Data = cResult;

                    return RedirectToAction("Index", "Login");
                }

                TempData.Add("Message", "Nhập sai captcha!");

                return RedirectToAction("Index", "Login");
            }

            TempData.Add("Message", errorMess);

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [Route("/logout")]
        [RequiredLogin]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            return RedirectToAction("Index", "Login");
        }

        // Get captcha
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