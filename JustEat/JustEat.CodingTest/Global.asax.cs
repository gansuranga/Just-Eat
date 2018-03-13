namespace JustEat.CodingTest
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Bootstrap.AutoMapper;
    using Bootstrap.Extensions.StartupTasks;
    using Bootstrap.Unity;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrap.Bootstrapper.With.Unity().UsingAutoRegistration().And.AutoMapper().And.StartupTasks().Start();
        }
    }
}
