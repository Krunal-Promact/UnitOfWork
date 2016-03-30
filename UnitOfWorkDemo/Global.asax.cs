using System.Web.Mvc;
using System.Web.Routing;
using UnitOfWorkDemo.App_Start;

namespace UnitOfWorkDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DataBaseConfig.InitializeDataBase();
        }
    }
}
