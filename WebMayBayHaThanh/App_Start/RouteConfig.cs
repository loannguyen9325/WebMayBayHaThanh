using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMayBayHaThanh.Controllers;

namespace WebMayBayHaThanh
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Root",
                "{action}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new { isMethodInHomeController = new HomeController.RootRouteConstraint<HomeController>() }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
