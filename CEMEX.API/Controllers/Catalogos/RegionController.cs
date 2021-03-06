﻿using CEMEX.API.Infrastructure.Core;
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
using CEMEX.Entidades;

namespace CEMEX.API.Controllers.Catalogos
{
    [Authorize]
    [RoutePrefix("api/Region")]
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
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirPlazaImmex = false, 
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<RegionViewModel> regionesVM;

                if (incluirPlazaImmex)
                    regionesVM = Mapper.Map<IEnumerable<Region>, 
                                            IEnumerable<RegionViewModel>>
                                            (_regionRepository.GetRegionesWithPlazaImmex(estatusRegistro));
                else
                    regionesVM = Mapper.Map<IEnumerable<Region>, 
                                            IEnumerable<RegionViewModel>>
                                            (_regionRepository.GetRegiones(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, regionesVM);

                return response;
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id, bool incluirPlazasImmex = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                RegionViewModel regionVM = null;

                if (incluirPlazasImmex)
                    regionVM = Mapper.Map<Region,
                                          RegionViewModel>
                                          (_regionRepository.GetRegionByIdWithPlazasImmex(id));
                else
                    regionVM = Mapper.Map<Region, 
                                          RegionViewModel>
                                          (_regionRepository.GetRegionById(id));

                if (regionVM != null)
                {
                    response = request.CreateResponse(HttpStatusCode.OK, regionVM);
                }else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound);
                }

                return response;
            });
        }

    }
}