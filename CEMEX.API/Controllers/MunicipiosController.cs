using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Infrastructure.Extensions;
using CEMEX.API.Models.Catalogos;
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

namespace CEMEX.API.Controllers
{
    [RoutePrefix("api/municipios")]
    public class MunicipiosController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Municipio> _municipiosRepository;

        public MunicipiosController(IEntityBaseRepository<Municipio> municipiosRepository,
                                    IEntityBaseRepository<Error> errorRepository,
                                    IUnitOfWork unitOfWork)
            : base(errorRepository, unitOfWork)
        {
            _municipiosRepository = municipiosRepository;
        }

        [Route("list")]
        [Authorize]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<MunicipioViewModel> municipiosVM = Mapper.Map<IEnumerable<Municipio>,
                                                                          IEnumerable<MunicipioViewModel>>
                                                                          (_municipiosRepository.GetAll().ToList());

                response = request.CreateResponse(HttpStatusCode.OK, municipiosVM);

                return response;
            });
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(HttpRequestMessage request,
                                            MunicipioViewModel municipio)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                        .Select(m => m.ErrorMessage).ToArray());
                } else
                {
                    Municipio newMunicipio = new Municipio();
                    newMunicipio.UpdateMunicipio(municipio);

                    newMunicipio.FechaAlta = DateTime.Now;
                    newMunicipio.FechaModifico = DateTime.Now;

                    _municipiosRepository.Add(newMunicipio);

                    _unitOfWork.Commit();

                    municipio = Mapper.Map<Municipio, MunicipioViewModel>(newMunicipio);
                    response = request
                               .CreateResponse<MunicipioViewModel>
                               (HttpStatusCode.Created, municipio);

                }

                return response;
            });
        }


        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, MunicipioViewModel municipio)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;

                 if (!ModelState.IsValid)
                 {
                     response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                       ModelState.Keys.SelectMany(x => ModelState[x].Errors)
                                                       .Select(m => m.ErrorMessage).ToArray());
                 } else
                 {
                     Municipio _municipio = _municipiosRepository.GetSingle(municipio.ID);

                     if (_municipio != null)
                     {
                         _municipio.UpdateMunicipio(municipio);
                         _unitOfWork.Commit();

                         response = request.CreateResponse(HttpStatusCode.OK);
                     } else
                     {
                         response = request.CreateResponse(HttpStatusCode.NotFound,
                                                 string.Format(ResponseMessages.MessageResponseMunicipios.NoEncontrado,
                                                               municipio.ID));
                     }

                 }

                 return response;
             });
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;

                 Municipio _municipio = _municipiosRepository.GetSingle(id);

                 if (_municipio != null)
                 {
                     MunicipioViewModel municipioVM =
                                     Mapper.Map<Municipio, MunicipioViewModel>(_municipio);

                     response = request.CreateResponse<MunicipioViewModel>
                                     (HttpStatusCode.OK, municipioVM);
                 } else
                 {
                     response = request.CreateResponse(HttpStatusCode.NotFound,
                                     string.Format(ResponseMessages.MessageResponseMunicipios.NoEncontrado, id));
                 }

                 return response;
             });
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, ()=>
            {
                HttpResponseMessage response = null;

                Municipio _municipio = _municipiosRepository.GetSingle(id);

                if (_municipio != null)
                {
                    _municipio.Estatus = (int)EstatusRegistro.Eliminado;
                    _unitOfWork.Commit();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }else
                {
                    response = request.CreateResponse(HttpStatusCode.NotFound,
                                                      string.Format(ResponseMessages.MessageResponseMunicipios.NoEncontrado,id));
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

            return CreateHttpResponse(request,()=>
            {
                HttpResponseMessage response = null;
                List<Municipio> municipios = null;
                int totalMunicipios = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();
                    municipios = _municipiosRepository.FindBy(m => m.Nombre.ToLower().Contains(filter) ||
                                                              m.IdEstado.ToString().Contains(filter))
                                                      .OrderBy(c => c.ID)
                                                      .Skip(currentPage * currentPageSize)
                                                      .Take(currentPageSize)
                                                      .ToList();

                    totalMunicipios = _municipiosRepository.GetAll()
                                       .Where(m => m.Nombre.ToLower().Contains(filter) ||
                                              m.IdEstado.ToString().Contains(filter))
                                       .Count();
                }else
                {
                    municipios = _municipiosRepository.GetAll()
                                        .OrderBy(m => m.ID)
                                        .Skip(currentPage * currentPageSize)
                                        .Take(currentPageSize)
                                        .ToList();

                    totalMunicipios = _municipiosRepository.GetAll().Count();
                }

                IEnumerable<MunicipioViewModel> municipiosVM = Mapper.Map<IEnumerable<Municipio>, IEnumerable<MunicipioViewModel>>(municipios);

                PaginationSet<MunicipioViewModel> pagedSet = new PaginationSet<MunicipioViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalMunicipios,
                    TotalPages = (int)Math.Ceiling((decimal)totalMunicipios /currentPageSize),
                    Items = municipiosVM
                };

                response = request.CreateResponse<PaginationSet<MunicipioViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }


    }
}