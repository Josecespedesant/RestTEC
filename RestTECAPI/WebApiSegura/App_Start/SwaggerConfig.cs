using System.Web.Http;
using WebActivatorEx;
using Tarea1_API;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Collections.Generic;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace Tarea1_API
{
    /*
     * La clase SwaggerConfig , agrega configuracion al API
     */
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Tarea1_API");
                })
                .EnableSwaggerUi();
        }

    }
}