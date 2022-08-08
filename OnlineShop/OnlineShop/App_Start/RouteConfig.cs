using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });


            routes.MapRoute(
                name: "Product Category",
                url: "product/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Product Detail",
                url: "detail/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Add to Cart",
                url: "add-to-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "payment",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Success",
                url: "success",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Error",
                url: "error",
                defaults: new { controller = "Cart", action = "Error", id = UrlParameter.Optional },
                namespaces: new string[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, 
                namespaces: new string[] { "OnlineShop.Controllers"}
            );
        }
    }
}
