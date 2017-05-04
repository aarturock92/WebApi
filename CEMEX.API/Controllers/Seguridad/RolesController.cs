using CEMEX.API.Infrastructure.Core;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Seguridad
{
    [RoutePrefix("api/roles")]
    public class RolesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Rol> _rolRepository;


        public RolesController(IEntityBaseRepository<Rol> rolRepository,
                               IEntityBaseRepository<Error> errorRepository, 
                               IUnitOfWork unitOfWork) : base(errorRepository, unitOfWork)
        {
            _rolRepository = rolRepository;
        }

        //[Route("list")]
        //public HttpResponseMessage Get(bool include)
        //{

        //}


    }
}