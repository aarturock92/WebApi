using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
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

        //[Route("list")]
        //[HttpGet]
        //public HttpResponseMessage Get()
        //{

        //}
    }
}