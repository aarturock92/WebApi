using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Catalogos;
using CEMEX.Data.Extensions.Catalogos;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Net;
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
        public HttpResponseMessage Get(HttpRequestMessage request, 
                                       bool incluirTiendas = false, 
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<DistritoViewModel> _distritosVM;

                if (incluirTiendas)
                    _distritosVM = Mapper.Map<IEnumerable<Distrito>, 
                                              IEnumerable<DistritoViewModel>>
                                              (_repositoryDistrito.GetDistritosWithTiendas(estatusRegistro));
                else
                    _distritosVM = Mapper.Map<IEnumerable<Distrito>,
                                              IEnumerable<DistritoViewModel>>
                                              (_repositoryDistrito.GetDistritos(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, _distritosVM);

                return response;
            });
        }

    }
}