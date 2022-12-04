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



            routes.MapRoute("HomeIndex", "", new { controller = "Home", action = "Index" }, namespaces: new[] { "Pro_1_MVC_Learning.Controllers" });
            routes.MapRoute("HomeNews", "News", new { controller = "Home", action = "News" }, namespaces: new[] { "Pro_1_MVC_Learning.Controllers" });
            routes.MapRoute("HomeBlog", "Blogs", new { controller = "Home", action = "Blog" }, namespaces: new[] { "Pro_1_MVC_Learning.Controllers" });
            routes.MapRoute("HomeAbout", "About", new { controller = "Home", action = "About" }, namespaces: new[] { "Pro_1_MVC_Learning.Controllers" });
            routes.MapRoute("HomePanel", "Panel", new { controller = "Home", action = "Panel" }, namespaces: new[] { "Pro_1_MVC_Learning.Controllers" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new[] { "Pro_1_MVC_Learning.Controllers" }
            //    );
            //  Admin Area
        }
    }
}
