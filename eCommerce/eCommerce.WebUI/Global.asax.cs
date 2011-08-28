using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eCommerce.Model.Entities;
using eCommerce.WebUI.Binders;
using eCommerce.WebUI.Infrastructure;

namespace eCommerce.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                            "", // Only matches the empty URL (i.e. /)
                            new
                                {
                                    controller = "Food",
                                    action = "List",
                                    type = (string) null,
                                    page = 1
                                }
                );
            routes.MapRoute(null,
                            "Page{page}", // Matches /Page2, /Page123, but not /PageXYZ
                            new {controller = "Food", action = "List", type = (string) null},
                            new {page = @"\d+"} // Constraints: page must be numerical
                );
            routes.MapRoute(null,
                            "{type}", // Matches /Football or /AnythingWithNoSlash
                            new {controller = "Food", action = "List", page = 1}
                );
            routes.MapRoute(null,
                            "{type}/Page{page}", // Matches /Football/Page567
                            new {controller = "Food", action = "List"}, // Defaults
                            new {page = @"\d+"} // Constraints: page must be numerical
                );

            routes.MapRoute(null, "{controller}/{action}");
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //!Add NinjectControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}