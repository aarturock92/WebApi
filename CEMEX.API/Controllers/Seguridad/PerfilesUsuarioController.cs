using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Aplicacion;
using CEMEX.API.Models.Seguridad;
using CEMEX.Data.Extensions.Aplicacion;
using CEMEX.Data.Extensions.Seguridad;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.App;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IEntityBaseRepository<DetallePerfilUsuarioMenu>  _detallePerfilUsuarioMenuRepository;
        private readonly IEntityBaseRepository<Menu> _menuRepository;

        public PerfilesUsuarioController(IEntityBaseRepository<DetallePerfilUsuarioMenu> detallePerfilUsuarioRepository,
                                         IEntityBaseRepository<Menu>  menuRepository,
                                         IEntityBaseRepository<PerfilUsuario> perfilUsuarioRepository,
                                         IEntityBaseRepository<Error> errorRepository, 
                                         IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _perfilUsuarioRepository = perfilUsuarioRepository;
            _detallePerfilUsuarioMenuRepository = detallePerfilUsuarioRepository;
            _menuRepository = menuRepository;
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

        [HttpGet]
        [Route("{id:int}/Menu")]
        public HttpResponseMessage GetMenuByPerfilUsuarioId(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                List<Menu> menus = _menuRepository.GetMenuByPerfilUsuarioId(_detallePerfilUsuarioMenuRepository, id);
                List<MenuViewModel> _menusVM = Mapper.Map<List<Menu>, List<MenuViewModel>>(menus);

                for (int indexMenu = 0; indexMenu < _menusVM.Count(); indexMenu++)
                {
                    var identityMenu = _menusVM[indexMenu].ID;
                    _menusVM[indexMenu].SubMenus = Mapper.Map<List<Menu>, List<MenuViewModel>>(_menuRepository
                                                                                               .GetMenuByPerfilUsuarioId(_detallePerfilUsuarioMenuRepository, id, identityMenu));
                }

                response = request.CreateResponse(HttpStatusCode.OK, _menusVM);
                
                return response;
            });
        }

    }
}