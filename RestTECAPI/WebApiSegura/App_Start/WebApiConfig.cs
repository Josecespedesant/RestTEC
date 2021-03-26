using System;
using System.Web.Http;

namespace Tarea1_API
{
    /*
     * La clase WebApiConfig configura las rutas y servivios API
     */
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
         
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
