﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TeamUp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Usuario",
                url: "Usuario/{id}",
                defaults: new
                {
                    controller = "Usuario",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "BuscaProjetos", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
