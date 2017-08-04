using CEMEX.API.Controllers.Seguridad;
using CEMEX.API.Infrastructure.Extensions;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace CEMEX.API.Infrastructure.MessageHandlers
{
    public class SlidingExpirationHandler:DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            var authorization = request.Headers.Authorization;
            if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
            {
                return response;
            }

            var claimsPrincipal = request.GetRequestContext().Principal as ClaimsPrincipal;
            if (claimsPrincipal == null)
            {
                return response;
            }

            var nombreCompleto = claimsPrincipal.Identity.Name;
            //var numeroEmpleado = claimsPrincipal.Identity.
            var usuarioId = claimsPrincipal.Identity.GetUserId();
            var lifetimeInMinutes = int.Parse(WebConfigurationManager.AppSettings["TokenLifeTimeInMinutes"]);

            var token = UsuariosController.CrearToken(usuarioId, nombreCompleto, "123", lifetimeInMinutes);
            response.Headers.Add("Set-Authorization", token);

            return response;
        }
    }
}