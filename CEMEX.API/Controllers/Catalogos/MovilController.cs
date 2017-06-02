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

        [HttpGet]
        [Route("list")]
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

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(HttpRequestMessage request, MovilViewModel movilVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                      ModelState.Keys.SelectMany(k => ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    Movil _movil = _movilRepository.GetMovil(movilVM.IMEI,
                                                             movilVM.NumeroTelefono,
                                                             movilVM.NumeroSerie);

                    if (_movil != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, "Ya existe un movil con el IMEI, Número Telefonico o Numero de Serie en el sistema.");
                    }
                    else
                    {
                        Movil newMovil = new Movil();
                        newMovil.CreateMovil(movilVM);
                        _movilRepository.Add(newMovil);
                        _unitOfWork.Commit();

                        movilVM = Mapper.Map<Movil, MovilViewModel>(newMovil);
                        response = request.CreateResponse(HttpStatusCode.Created, movilVM);
                    }
                }

                return response;
            });
        }

        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;


                return response;
            });
        }

    }
}