using AutoMapper;
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
    [RoutePrefix("api/Movil")]
    public class MovilController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Movil> _movilRepository;

        public MovilController(IEntityBaseRepository<Movil> movilRepository,
                               IEntityBaseRepository<Error> errorRepository,
                               IUnitOfWork unitOfWork)
            : base(errorRepository, unitOfWork)
        {
            _movilRepository = movilRepository;
        }

        /// <summary>
        /// Consulta todos los registros de la entidad Movil.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="estatusRegistro"></param>
        /// <returns>
        /// OK 200: Retorna todos los registros de la entidad Movil.
        /// </returns>
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<MovilViewModel> _movilesVM = Mapper.Map<IEnumerable<Movil>,
                                                                    IEnumerable<MovilViewModel>>
                                                                    (_movilRepository.GetMovilesByStatusRegistro(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, _movilesVM);

                return response;
            });
        }

        /// <summary>
        /// Consulta un solo registro de la entidad Movil a partir de su Id.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>
        /// OK 200: Se encontro el registro.
        /// NotFound 404: El recurso no se encuentra en BD.
        /// </returns>
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Movil _movil = _movilRepository.GetMovilPorId(id);

                if (_movil != null)
                    response = request.CreateResponse(HttpStatusCode.OK, Mapper.Map<Movil, MovilViewModel>(_movil));
                else
                    response = request.CreateResponse(HttpStatusCode.NotFound);

                return response;
            });
        }

        /// <summary>
        /// Crea un nuevo registro para la entidad Movil.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="movilVM"></param>
        /// <returns>
        /// BadRequest 400: La estructura no contiene el formato correcto.
        /// Conflict 409: El registro ya existe en base de datos.
        /// Created 201: La trasacción se realizo con exito.
        /// </returns>
        [HttpPost]
        [Route("Crear")]
        public HttpResponseMessage Crear(HttpRequestMessage request, MovilViewModel movilVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                      ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                                                .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    List<string> validacionesMovil = new List<string>();

                    if (_movilRepository.ExisteMovilCreacion(movilVM, out validacionesMovil))
                    {
                        Movil newMovil = new Movil();
                        newMovil.CrearMovil(movilVM);
                        _movilRepository.Add(newMovil);
                        _unitOfWork.Commit();

                        movilVM = Mapper.Map<Movil, MovilViewModel>(newMovil);
                        response = request.CreateResponse(HttpStatusCode.Created, movilVM);
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.Conflict, validacionesMovil);
                    }                   
                }

                return response;
            });
        }

        /// <summary>
        /// Realiza un eliminado logico del registro Movil.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>
        /// OK 200: La operación se realizo con exito.
        /// NotFound 404: El registro no se encuentra en la BD.
        /// </returns>
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Eliminar(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, ()=>
            {
                HttpResponseMessage response = null;
                Movil movil = _movilRepository.GetMovilPorId(id);

                if (movil != null)
                {
                    movil.EliminarMovil();
                    _unitOfWork.Commit();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound);
                }

                return response;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <param name="movilVM"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public HttpResponseMessage Modificar(HttpRequestMessage request, int id, MovilViewModel movilVM)
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
                    Movil _movil = _movilRepository.GetMovilPorId(id);

                    List<string> validacionesMovil = new List<string>();

                    if (_movil != null)
                    {
                        _movil.ModificarMovil(movilVM);
                        _unitOfWork.Commit();
                        movilVM = Mapper.Map<Movil, MovilViewModel>(_movil);
                        response = request.CreateResponse(HttpStatusCode.OK, movilVM);
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.NotFound);
                    }                        
                }

                return response;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <param name="estatusRegistro"></param>
        /// <returns>
        /// OK 200: Retorna los registros en formato de paginación.
        /// </returns>
        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null, ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            int currentPage = page.Value,
                currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Movil> moviles = null;

                int totalMoviles = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();

                    moviles = _movilRepository.FindBy(m => m.Marca.ToLower().Contains(filter) ||
                                                           m.Modelo.ToLower().Contains(filter) ||
                                                           m.NumeroTelefono.ToLower().Contains(filter) ||
                                                           m.NumeroSerie.ToLower().Contains(filter))
                                               .OrderBy(m => m.ID)
                                               .Skip(currentPage * currentPageSize)
                                               .Take(currentPageSize)
                                               .ToList();

                    totalMoviles = _movilRepository.FindBy(m => m.Marca.ToLower().Contains(filter) ||
                                                          m.Modelo.ToLower().Contains(filter) ||
                                                          m.NumeroTelefono.ToLower().Contains(filter) ||
                                                          m.NumeroSerie.ToLower().Contains(filter)).Count();

                }else
                {
                    moviles = _movilRepository.GetMovilesByStatusRegistro(estatusRegistro)
                                              .OrderBy(e => e.ID)
                                              .Skip(currentPage * currentPageSize)
                                              .Take(currentPageSize)
                                              .ToList();

                    totalMoviles = _movilRepository.GetMovilesByStatusRegistro(estatusRegistro)
                                                   .Count();
                }

                IEnumerable<MovilViewModel> movilesVM = Mapper.Map<IEnumerable<Movil>, IEnumerable<MovilViewModel>>(moviles);

                PaginationSet<MovilViewModel> pagedSet = new PaginationSet<MovilViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMoviles,
                    TotalPages = (int)Math.Ceiling((decimal)totalMoviles / currentPageSize),
                    Items = movilesVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}