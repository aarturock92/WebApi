using CEMEX.API.Infrastructure.Filters;
using CEMEX.API.Infrastructure.MessageHandlers;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace CEMEX.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new BearerAuthenticationFilter());

            config.MessageHandlers.Add(new SlidingExpirationHandler());

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
