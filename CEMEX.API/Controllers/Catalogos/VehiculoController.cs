﻿using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Infrastructure.Extensions;
using CEMEX.API.Models.Catalogos;
using CEMEX.Data.Extensions.Catalogos;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Catalogos
{
    [Authorize]
    [RoutePrefix("api/Vehiculo")]
    public class VehiculoController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Vehiculo> _vehiculoRepository;

        public VehiculoController(IEntityBaseRepository<Vehiculo> vehiculoRepository,
                                  IEntityBaseRepository<Error> errorRepository,
                                  IUnitOfWork unitOfWork)
            : base(errorRepository, unitOfWork)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<VehiculoViewModel> vehiculosVM = Mapper.Map<IEnumerable<Vehiculo>,
                                                                        IEnumerable<VehiculoViewModel>>
                                                                        (_vehiculoRepository.GetVehiculosByEstatusRegistro(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, vehiculosVM);

                return response;
            });
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                VehiculoViewModel vehiculoVM = Mapper.Map<Vehiculo, 
                                                          VehiculoViewModel>
                                                          (_vehiculoRepository.GetVehiculoDetailsById(id));

                if (vehiculoVM != null)
                    response = request.CreateResponse(HttpStatusCode.OK, vehiculoVM);
                else
                    response = request.CreateResponse(HttpStatusCode.NotFound);

                return response;
            });
        }

        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, VehiculoViewModel vehiculoVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                      ModelState.Keys
                                                      .SelectMany(k => ModelState[k].Errors)
                                                      .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Vehiculo newVehiculo = new Vehiculo();
                    newVehiculo.CreateVehiculo(vehiculoVM);
                    _vehiculoRepository.Add(newVehiculo);
                    _unitOfWork.Commit();
                }

                return response;
            });
        }

        [Route("{id:int}")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, int id, VehiculoViewModel vehiculoVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                Vehiculo vehiculo = _vehiculoRepository.GetVehiculoDetailsById(id);

                if (vehiculo != null)
                {
                    if (!ModelState.IsValid)
                    {
                        response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                          ModelState.Keys
                                                          .SelectMany(k => ModelState[k].Errors)
                                                          .Select(m => m.ErrorMessage).ToArray());
                    }
                    else
                    {
                        vehiculo.UpdateVehiculo(vehiculoVM);
                        _unitOfWork.Commit();
                        response = request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Vehiculo, VehiculoViewModel>(vehiculo));
                    }
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound);
                }

                return response;
            });
        }


        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        [HttpGet]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Vehiculo> vehiculos = null;
                int totalVehiculos = new int();

                if (!string.IsNullOrEmpty(filter))
                {

                }else
                {
                    vehiculos = _vehiculoRepository
                                .GetAll()
                                .OrderBy(v => v.ID)
                                .Skip(currentPage * currentPageSize)
                                .Take(currentPageSize)
                                .ToList();

                    totalVehiculos = _vehiculoRepository
                                     .GetAll()
                                     .Count();
                }

                IEnumerable<VehiculoViewModel> vehiculosVM = Mapper.Map<IEnumerable<Vehiculo>, IEnumerable<VehiculoViewModel>>(vehiculos);

                PaginationSet<VehiculoViewModel> pagedSet = new PaginationSet<VehiculoViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalVehiculos,
                    TotalPages = (int)Math.Ceiling((decimal)totalVehiculos / currentPageSize),
                    Items = vehiculosVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}