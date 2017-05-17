using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Catalogos
{
    [Authorize]
    [RoutePrefix("api/Distrito")]
    public class DistritoController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Distrito> _repositoryDistrito;

        public DistritoController(IEntityBaseRepository<Error> errorRepository, 
                                  IEntityBaseRepository<Distrito> repositoryDistrito,
                                  IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _repositoryDistrito = repositoryDistrito;
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirTiendas = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //IEnumerable<DistritoViewModel> _distritosVM;

                //if (incluirTiendas)
                //   _distritosVM = Mapper.Map<IEnumerable<Distrito>, IEnumerable<DistritoViewModel>>()
                //else

                
                return response;
            });
        }

    }
}