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

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Pro_1_MVC_Learning.Controllers" }
                );
            routes.MapRoute("IndexHome", "Home/Index", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute("IndexProducts", "Home/Products", new { controller = "Home", action = "Products", id = UrlParameter.Optional });
            routes.MapRoute("IndexNews", "Home/News", new { controller = "Home", action = "News", id = UrlParameter.Optional });
        }
    }
}
