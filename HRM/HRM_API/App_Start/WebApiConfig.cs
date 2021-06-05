using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HRM_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable Cors for API
            //config.EnableCors();      cho phép enable cors từng class controllerAPI một
            //http://localhost:51362/   là trang được cho phép lấy dữ từ API 
            var corsAttr = new EnableCorsAttribute("http://localhost:51362/", "*", "*"); // cho phép enable cors tất cả class controllerAPI
            config.EnableCors(corsAttr);
        }
    }
}
