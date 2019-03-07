using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace webApiFeatureTest
{
    class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration CONFIG = new HttpConfiguration();
            //CONFIG.EnableCors();
            CONFIG.Routes.MapHttpRoute(
                name: "createUserApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            appBuilder.UseWebApi(CONFIG);
        }

        static void Main(string[] args)
        {
            string domainAddress = "http://localhost:52678/";

            using (WebApp.Start(url: domainAddress))
            {
                Console.WriteLine("Service Hosted " + domainAddress);
                System.Threading.Thread.Sleep(-1);
            }
        }
    }
}
