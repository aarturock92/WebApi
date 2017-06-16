using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Catalogos;
using CEMEX.Data.Extensions.Catalogos;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System.Collections;
using System.Collections.Generic;
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
    }
}