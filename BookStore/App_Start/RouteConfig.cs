using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
    new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

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
              name: "Add cart",
              url: "them-gio-hang",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
              namespaces: new[] { "BookStore.Controllers" }
          );

            routes.MapRoute(
             name: "Cart",
             url: "gio-hang",
             defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "BookStore.Controllers" }
         );

            routes.MapRoute(
             name: "Payment",
             url: "thanh-toan",
             defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
             namespaces: new[] { "BookStore.Controllers" }
         );

            routes.MapRoute(
             name: "Payment success",
             url: "hoan-thanh",
             defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
             namespaces: new[] { "BookStore.Controllers" }
         );

            routes.MapRoute(
            name: "Register",
            url: "dang-ky",
            defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
            namespaces: new[] { "BookStore.Controllers" }
        );

            routes.MapRoute(
            name: "Login",
            url: "dang-nhap",
            defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
            namespaces: new[] { "BookStore.Controllers" }
        );

            routes.MapRoute(
            name: "Search",
            url: "tim-kiem",
            defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
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