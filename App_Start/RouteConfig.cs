using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LaVideotheque
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "DetailsForMovies",
               "Home/DetailsForMovies/{Id}",
               new { controller = "Home", action = "DetailsForMovies"},
               new { Id = @"\d{1}" });

            routes.MapRoute(
                "DetailsForCustomers",
                "Home/DetailsForCustomers/{Id}",
                new { controller = "Home", action = "DetailsForCustomers"},
                new { Id = @"\d{1}" });

            routes.MapRoute(
              "DeleteMovie",
              "Home/DeleteMovie/{Id}",
              new { controller = "Home", action = "DeleteMovie" },
              new { Id = @"\d{1}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
