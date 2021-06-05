using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;

namespace HRM.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class RequiredLoginAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["Username"] == null)
                return false;
            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                try
                {
                    return;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }        
    }
}