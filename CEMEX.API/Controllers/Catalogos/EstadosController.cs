using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Linq;
using System.Net;
using CEMEX.API.Models.Catalogos;
using CEMEX.API.Infrastructure.Extensions;
using AutoMapper;
using CEMEX.Entidades;
using System.Collections.Generic;
using System.Data.Entity;
using CEMEX.Data.Extensions.Seguridad;

namespace CEMEX.API.Controllers.Catalogos
{
    [Authorize]
    [RoutePrefix("api/estados")]
    public class EstadosController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Estado> _estadosRepository;

        public EstadosController(IEntityBaseRepository<Estado> estadosRepository,
                                 IEntityBaseRepository<Error> errorRepository, 
                                 IUnitOfWork unitOfWork) : base(errorRepository, unitOfWork)
        {
            _estadosRepository = estadosRepository;
        }
     
        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request, bool incluirMunicipios = false, ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                IEnumerable<EstadoViewModel> estadosVM;

                if (incluirMunicipios)
                    estadosVM = Mapper.Map<IEnumerable<Estado>,
                                            IEnumerable<EstadoViewModel>>
                                            (_estadosRepository.GetAllEstadosWithMunicipios(estatusRegistro));
                else
                    estadosVM = Mapper.Map<IEnumerable<Estado>,
                                          IEnumerable<EstadoViewModel>>
                                          (_estadosRepository.GetAllEstados());

                response = request.CreateResponse(HttpStatusCode.OK, estadosVM);

                return response;
            });
        }

        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request,
                                            EstadoViewModel estadoVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                            .Select(m => m.ErrorMessage).ToArray());
                }else
                {
                    Estado newEstado = new Estado();
                    newEstado.UpdateEstado(estadoVM);

                    newEstado.FechaAlta = DateTime.Now;
                    newEstado.FechaModifico = DateTime.Now;

                    _estadosRepository.Add(newEstado);

                    _unitOfWork.Commit();

                    estadoVM = Mapper.Map<Estado, EstadoViewModel>(newEstado);
                    response = request.CreateResponse<EstadoViewModel>(HttpStatusCode.Created, estadoVM);
                }

                return response;
            });
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, EstadoViewModel estado)
        {
            return CreateHttpResponse(request,() =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                      ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                                      .Select(m => m.ErrorMessage).ToArray());
                }else
                {
                    Estado _estado = _estadosRepository.GetSingle(estado.ID);

                    if (_estado!=null)
                    {
                        _estado.UpdateEstado(estado);
                        _unitOfWork.Commit();

                        response = request.CreateResponse(HttpStatusCode.OK);
                    }else
                    {
                        response = request.CreateResponse(HttpStatusCode.NotFound, 
                            string.Format(ResponseMessages.MessageResponseEstados.NoEncontrado, estado.ID));
                    }
                    
                }

                return response;
            });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id, bool incluirMunicipios = false)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                Estado estado = null;

                if (incluirMunicipios)
                    estado = _estadosRepository.GetSingleEstadoWithMunicipiosById(id);
                else
                    estado = _estadosRepository.GetSingleEstadoById(id);
                
                if (estado != null)
                {
                     EstadoViewModel estadoVM = Mapper.Map<Estado, EstadoViewModel>(estado);
                     response = request.CreateResponse<EstadoViewModel>(HttpStatusCode.OK, estadoVM);
                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound, 
                                                      string.Format(ResponseMessages.MessageResponseEstados.NoEncontrado, id));
                }                
                return response;
            });
        }


        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter=null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request,() =>
            {
                HttpResponseMessage response = null;
                List<Estado> estados = null;
                int totalEstados = new int();


                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();
                    estados = _estadosRepository.FindBy(c => c.Abreviatura.ToLower().Contains(filter) ||
                                                        c.Nombre.ToLower().Contains(filter))
                                                        .OrderBy(c => c.ID)
                                                        .Skip(currentPage * currentPageSize)
                                                        .Take(currentPageSize)
                                                        .ToList();

                    totalEstados = _estadosRepository.GetAll()
                                    .Where(c => c.Abreviatura.ToLower().Contains(filter) ||
                                           c.Nombre.ToLower().Contains(filter))
                                    .Count();

                }else
                {
                    estados = _estadosRepository.GetAll()
                                .OrderBy(e => e.ID)
                                .Skip(currentPage * currentPageSize)
                                .Take(currentPageSize)
                                .ToList();

                    totalEstados = _estadosRepository.GetAll().Count();
                }

                IEnumerable<EstadoViewModel> estadosVM = Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(estados);

                PaginationSet<EstadoViewModel> pagedSet = new PaginationSet<EstadoViewModel>()
                {
                    Page = currentPage,
                    TotalCount= totalEstados,
                    TotalPages =(int)Math.Ceiling((decimal)totalEstados /currentPageSize),
                    Items = estadosVM
                };

                response = request.CreateResponse<PaginationSet<EstadoViewModel>>(HttpStatusCode.OK,pagedSet);

                return response;
            });
        }
    }
}