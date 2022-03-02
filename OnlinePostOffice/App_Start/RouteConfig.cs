using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlinePostOffice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "Dashboard",
            url: "admin/dashboard/{action}/{id}",
            defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
         name: "Auth",
         url: "admin/Auth/{action}/{id}",
         defaults: new { controller = "Auth", action = "Index", id = UrlParameter.Optional }
     );
            routes.MapRoute(
          name: "Users",
          url: "admin/users/{action}/{id}",
          defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
      );
            routes.MapRoute(
        name: "Branch",
        url: "admin/branch/{action}/{id}",
        defaults: new { controller = "Branch", action = "Index", id = UrlParameter.Optional }
    );
            routes.MapRoute(
     name: "Cities",
     url: "admin/cities/{action}/{id}",
     defaults: new { controller = "Cities", action = "Index", id = UrlParameter.Optional }
 );
            routes.MapRoute(
    name: "Services",
    url: "admin/services/{action}/{id}",
    defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional }
);
           

            routes.MapRoute(
  name: "Orders",
  url: "admin/orders/{action}/{id}",
  defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional }
);
            routes.MapRoute(
name: "Page",
url: "admin/page/{action}/{id}",
defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional }
);


            // frontend routes
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
   name: "Pages",
   url: "pages/{action}/{id}",
   defaults: new { controller = "Pages", action = "About", id = UrlParameter.Optional }
);

        }
    }
}
