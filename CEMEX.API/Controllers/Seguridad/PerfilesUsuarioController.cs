using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Seguridad;
using CEMEX.Data.Extensions.Seguridad;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Seguridad
{
    [Authorize]
    [RoutePrefix("api/PerfilUsuario")]
    public class PerfilesUsuarioController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<PerfilUsuario> _perfilUsuarioRepository;

        public PerfilesUsuarioController(IEntityBaseRepository<PerfilUsuario> perfilUsuarioRepository,
                                         IEntityBaseRepository<Error> errorRepository, 
                                         IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }

        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request, 
                                       ETypeEstatusRegistro estatusRegistro = ETypeEstatusRegistro.Todos)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<PerfilUsuarioViewModel> _perfilesUsuarioVM  = Mapper.Map<IEnumerable<PerfilUsuario>, 
                                                                                   IEnumerable<PerfilUsuarioViewModel>>
                                                                                   (_perfilUsuarioRepository
                                                                                   .GetPerfilUsuarioByEstatus(estatusRegistro));

                response = request.CreateResponse(HttpStatusCode.OK, _perfilesUsuarioVM);

                return response;
            });
        }




    }
}