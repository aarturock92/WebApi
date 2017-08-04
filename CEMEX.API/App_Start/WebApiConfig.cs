using CEMEX.API.Infrastructure.Filters;
using CEMEX.API.Infrastructure.MessageHandlers;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CEMEX.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Rutas de API web.
            config.MapHttpAttributeRoutes();

            // Configure el filtro de autenticación para que se ejecute en cada solicitud marcada con el atributo Authorize.
            config.Filters.Add(new BearerAuthenticationFilter());

            // Configurar el manejador de caducidad deslizante para que se ejecute en cada solicitud.
            config.MessageHandlers.Add(new SlidingExpirationHandler());

            //Impone a las estructuras JSON a usar camelCase
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Habilita las peticiones desde cualquier origen.
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}
