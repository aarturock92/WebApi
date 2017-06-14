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
    [RoutePrefix("api/PlazaOxxo")]
    public class PlazaOxxoController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<PlazaOxxo> _plazaOxxoRepository;
        
        public PlazaOxxoController(IEntityBaseRepository<Error> errorRepository, 
                                   IEntityBaseRepository<PlazaOxxo> plazaOxxoRepository,
                                   IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _plazaOxxoRepository = plazaOxxoRepository;
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, 
                                       bool incluirDistritos = false, 
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos )
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<PlazaOxxoViewModel> _plazasOxxoVM;

                if (incluirDistritos)
                    _plazasOxxoVM = Mapper.Map<IEnumerable<PlazaOxxo>, 
                                               IEnumerable<PlazaOxxoViewModel>>
                                               (_plazaOxxoRepository.GetPlazasOxxoWithDistritos(estatusRegistro));
                else
                    _plazasOxxoVM = Mapper.Map<IEnumerable<PlazaOxxo>, 
                                               IEnumerable<PlazaOxxoViewModel>>
                                               (_plazaOxxoRepository.GetPlazasOxxo(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, _plazasOxxoVM);

                return response;
            });
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id, bool incluirDistritos = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                PlazaOxxoViewModel plazaOxxoVM = null;

                if (incluirDistritos)
                    plazaOxxoVM = Mapper.Map<PlazaOxxo, 
                                             PlazaOxxoViewModel>
                                             (_plazaOxxoRepository.GetPlazaOxxoByIdWithDistritos(id));
                else
                    plazaOxxoVM = Mapper.Map<PlazaOxxo, 
                                             PlazaOxxoViewModel>
                                             (_plazaOxxoRepository.GetPlazaOxxoById(id));

                if (plazaOxxoVM != null)
                    response = request.CreateResponse(HttpStatusCode.OK, plazaOxxoVM);
                else
                    response = request.CreateResponse(HttpStatusCode.NotFound);

                return response;
            });
        }


    }
}