
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDeveloper
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Address",
                url: "Address",
                defaults: new { controller = "Address", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PhoneNumberType",
                url: "PhoneNumberType",
                defaults: new { controller = "PhoneNumberType", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Person",
                url: "Person",
                defaults: new { controller = "Person", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RazorHelperId",
                url: "RazorHelper/ContactTypeDetails/{Id}",
                defaults: new
                {
                    controller = "RazorHelper",
                    action = "Edit",
                }
            );

            routes.MapRoute(
                name: "RazorHelper",
                url: "RazorHelper",
                defaults: new { controller = "RazorHelper", action = "ContactTypeDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
