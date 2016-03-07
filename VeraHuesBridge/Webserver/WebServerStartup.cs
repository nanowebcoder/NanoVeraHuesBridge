using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using NLog;

namespace VeraHuesBridge
{
    public class WebServerStartup
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            logger.Info("Webserver configuration initiated...");
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();

            config.Routes.MapHttpRoute(
                            name: "SetupApi",
                            routeTemplate: "api/setup.xml",
                            defaults: new
                            {
                                controller = "Setup"

                            }
                        );
            config.Routes.MapHttpRoute(
                name: "DevicesApi",
                routeTemplate: "api/devices",
                defaults: new
                {
                    controller = "Devices"

                }
            );
            config.Routes.MapHttpRoute(
                name: "HueApi",
                routeTemplate: "api/{userId}",
                defaults: new
                {
                    controller = "HueApi"

                }
            );
            config.Routes.MapHttpRoute(
                name: "LightsApi",
                routeTemplate: "api/{userId}/lights/{id}/{state}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                    state = RouteParameter.Optional,
                    controller="Lights"

                }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
