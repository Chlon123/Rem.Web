using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Remont.Web.API.App_Start;

[assembly: OwinStartup(typeof(Remont.Web.Startup))]

namespace Remont.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           app.UseWebApi(WebApiConfig.Register());
        }
    }
}
