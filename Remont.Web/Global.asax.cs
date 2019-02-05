using Remont.Web.API.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Remont.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register();
            //RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}
