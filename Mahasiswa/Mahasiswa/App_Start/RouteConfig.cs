using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mahasiswa.Models;

namespace Mahasiswa
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Mahasiswa", action = "Index", id = UrlParameter.Optional }
                defaults: new { controller = "Image", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
