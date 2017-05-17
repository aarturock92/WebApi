using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Catalogos;
using CEMEX.Data.Extensions.Catalogos;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
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
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirDistritos = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<PlazaOxxoViewModel> _plazasOxxoVM;

                if (incluirDistritos)
                    _plazasOxxoVM = Mapper.Map<IEnumerable<PlazaOxxo>, 
                                               IEnumerable<PlazaOxxoViewModel>>
                                               (_plazaOxxoRepository.GetPlazasOxxoWithDistritos());
                else
                    _plazasOxxoVM = Mapper.Map<IEnumerable<PlazaOxxo>, 
                                               IEnumerable<PlazaOxxoViewModel>>
                                               (_plazaOxxoRepository.GetPlazasOxxo());

                response = request.CreateResponse(HttpStatusCode.OK, _plazasOxxoVM);

                return response;
            });
        }

    }
}