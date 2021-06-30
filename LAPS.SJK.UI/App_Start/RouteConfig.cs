using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LAPS.SJK.UI
{
    public class RouteConfig
    {
        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //routes.MapRoute(
        //    name: "Language",
        //    url: "{lang}/{controller}/{action}/{id}",
        //    defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
        //    constraints: new { lang = @"id|en" }
        //);

        //routes.MapRoute(
        //    name: "Default",
        //    url: "{controller}/{action}/{id}",
        //    defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional, lang = "en" }
        //);
        //}
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Language",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"id|en|ru" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional, lang = "id" }
            );
        }
    }
}
