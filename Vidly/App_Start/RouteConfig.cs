﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //To enable Attribute Routing
            routes.MapMvcAttributeRoutes();

            //custom route
            /*routes.MapRoute(
                "MoviesRouteByReleaseDate",
                "movies/releasedate/{year}/{month}",
                new { controller = "Movies", action = "ReleaseDate" },
                new { year = @"\d{4}", month = @"\d{2}" }
                //new { year = @"2014|2015", month = @"\d{2}" }
         );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
