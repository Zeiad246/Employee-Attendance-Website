﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RegisterEmployee
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "LogIn", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Registeration",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Employee", id = UrlParameter.Optional }
            );
        }
    }
}
