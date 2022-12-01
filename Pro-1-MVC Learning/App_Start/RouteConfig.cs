using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pro_1_MVC_Learning
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("NewsIndex", "News/Index", new { controller = "News", action = "Index"});
            routes.MapRoute("NewsInfo", "News/ShowNewsFromHome/{id}", new { controller = "News", action = "ShowNewsFromHome", id = UrlParameter.Optional });
            routes.MapRoute("NewsCreate", "News/CreateNews", new { controller = "News", action = "CreateNews" });
            routes.MapRoute("SubmitNews", "News/SubmitNews", new { controller = "News", action = "SubmitNews" });
            routes.MapRoute("UpdateNews", "News/Update/{id}", new { controller = "News", action = "Update" });
            routes.MapRoute("DeleteNews", "News/Delete/{id}", new { controller = "News", action = "Delete" });

            routes.MapRoute("ModelIndex", "ModelIndex", new { controller = "ModelBinding", action = "Index" });
            routes.MapRoute("ModelSubmit", "ModelSubmit", new { controller = "ModelBinding", action = "Submit" });
            
            //routes.MapRoute("ValidationIndex", "Validation/Index", new { controller = "Validation", action = "Index" });
            routes.MapRoute("ValidationCreate", "Validation/Create", new { controller = "Validation", action = "Create" });
            routes.MapRoute("ValidationRegisterForm", "Validation/RegisterForm", new { controller = "Validation", action = "RegisterForm" });
            routes.MapRoute("ValidatonShowData", "Validation/ShowData", new { controller = "Validation", action = "ShowData" });
        }
    }
}
