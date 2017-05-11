using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Catalogos
{
    [RoutePrefix("api/PlazasImmex")]
    public class PlazaImmexController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<PlazaImmex> _repositoryPlazaImmex;

        public PlazaImmexController(IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex,
                                    IEntityBaseRepository<Error> errorRepository, 
                                    IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _repositoryPlazaImmex = repositoryPlazaImmex;
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirPlazasOxxo = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;



                return response;
            });
        }
    }
}