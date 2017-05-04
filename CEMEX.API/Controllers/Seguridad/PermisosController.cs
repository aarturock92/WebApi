using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Seguridad;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Seguridad
{
    [RoutePrefix("api/permisos")]
    public class PermisosController:ApiControllerBase
    {
        private readonly IEntityBaseRepository<Permiso> _permisosRepository;

        public PermisosController(IEntityBaseRepository<Permiso> permisosRepository,
                                  IEntityBaseRepository<Error> errorRepository, 
                                  IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _permisosRepository = permisosRepository;
        }


        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<Permiso> _permisos = _permisosRepository.GetAll().ToList();

                IEnumerable<PermisoViewModel> permisosVM = Mapper.Map<IEnumerable<Permiso>, IEnumerable<PermisoViewModel>>(_permisos);

                response = request.CreateResponse(HttpStatusCode.OK, permisosVM);

                return response;
            });
        }

        
    }
}