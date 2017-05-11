using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using CEMEX.Entidades.Catalogos;
using System.Web.Http;
using System.Net.Http;
using CEMEX.API.Models.Catalogos;
using System.Collections.Generic;
using AutoMapper;
using CEMEX.Data.Extensions.Catalogos;
using System.Net;
using System.Linq;

namespace CEMEX.API.Controllers.Catalogos
{
    [RoutePrefix("api/Regiones")]
    public class RegionController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Region> _regionRepository;

        public RegionController(IEntityBaseRepository<Region> regionRepository,
                                IEntityBaseRepository<Error> errorRepository, 
                                IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _regionRepository = regionRepository;
        }


        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirPlazaImmex = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<RegionViewModel> regionesVM;

                if (incluirPlazaImmex)
                    regionesVM = Mapper.Map<IEnumerable<Region>, IEnumerable<RegionViewModel>>(_regionRepository.GetRegionesWithPlazaImmex());
                else
                    regionesVM = Mapper.Map<IEnumerable<Region>, IEnumerable<RegionViewModel>>(_regionRepository.GetRegiones());

                response = request.CreateResponse(HttpStatusCode.OK, regionesVM);

                return response;
            });
        }

    }
}