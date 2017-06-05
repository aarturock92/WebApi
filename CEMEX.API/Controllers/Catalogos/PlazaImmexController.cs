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
    [RoutePrefix("api/PlazaImmex")]
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
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirPlazasOxxo = false, ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<PlazaImmexViewModel> _plazaImmxVM;

                if (incluirPlazasOxxo)
                    _plazaImmxVM = Mapper.Map<IEnumerable<PlazaImmex>,
                                             IEnumerable<PlazaImmexViewModel>>
                                             (_repositoryPlazaImmex.GetPlazasImmexWithPlazaOxxo(estatusRegistro));
                else
                    _plazaImmxVM = Mapper.Map<IEnumerable<PlazaImmex>,
                                              IEnumerable<PlazaImmexViewModel>>
                                              (_repositoryPlazaImmex.GetPlazasImmex(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, _plazaImmxVM);

                return response;
            });
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, int id, bool incluirPlazaOxxo = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                PlazaImmexViewModel plazaImmexVM = null;

                if (incluirPlazaOxxo)
                    plazaImmexVM = Mapper.Map<PlazaImmex, 
                                              PlazaImmexViewModel>
                                              (_repositoryPlazaImmex.GetPlazaImmexByIdWithPlazaOxxo(id));
                else
                    plazaImmexVM = Mapper.Map<PlazaImmex, 
                                              PlazaImmexViewModel>
                                              (_repositoryPlazaImmex.GetPlazaImmexById(id));

                if (plazaImmexVM != null && plazaImmexVM.Estatus != (int)ETypeEstatusRegistro.Eliminado)
                    response = request.CreateResponse(HttpStatusCode.OK, plazaImmexVM);
                else
                    response = request.CreateResponse(HttpStatusCode.NotFound);

                return response;
            });
        }
    }
}