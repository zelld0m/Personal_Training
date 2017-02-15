using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCDEMO
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "viewAllEmployee", id = UrlParameter.Optional }
       
            );

            routes.MapRoute(
               name: "Employee details2",
               url: "{Controller}/{action}/{id}/{id2}/{id3}/{id4}/{id5}",
               defaults: new { Controller = "Employee", action = "Details2", id = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional, id4 = UrlParameter.Optional, id5 = UrlParameter.Optional }
           );


            #region Implement Commaseparated for paramters  // Fixed On Controllers 
            // routes.MapRoute(
            //    name: "Employee details2",
            //    url: "{Controller}/{action}/{id}/{id2}/{id3}/{id4}/{id5}",
            //    defaults: new { Controller = "Employee", action = "multipleDetails", id = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional, id4 = UrlParameter.Optional, id5 = UrlParameter.Optional }
            //);
            #endregion

        }
    }
}
