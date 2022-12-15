using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Category",
               url: "san-pham/{cateId}",
               defaults: new { controller = "Product", action = "DetailCategory", id = UrlParameter.Optional },
               namespaces: new[] { "BookStore.Controllers" }
           );

            routes.MapRoute(
              name: "Product Detail",
              url: "chi-tiet/{id}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "BookStore.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BookStore.Controllers" }
            );
        }
    }
}