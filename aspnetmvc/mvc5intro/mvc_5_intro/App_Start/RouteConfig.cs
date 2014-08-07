using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mvc_5_intro
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // fills Id in just added http://localhost:62559/helloworld/welcome?name=aj
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //http://localhost:62559/helloworld/welcome/Mr.Anonymous/4
            routes.MapRoute(
                name: "Hello",
                url: "{controller}/{action}/{name}/{id}"
            );
        }
    }
}
