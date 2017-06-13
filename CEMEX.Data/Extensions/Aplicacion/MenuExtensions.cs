using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.App;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Linq;

namespace CEMEX.Data.Extensions.Aplicacion
{
    public static class MenuExtensions
    {
        public static List<Menu> GetMenuByPerfilUsuarioId(this IEntityBaseRepository<Menu> menuRepository,
                                                          IEntityBaseRepository<DetallePerfilUsuarioMenu> detallePerfilUsuarioMenuRepository,
                                                          int idPerfilUsuario, 
                                                          int idMenuPadre = 0)
        {
            List<Menu> menusPadre;

            menusPadre = (from detalle in detallePerfilUsuarioMenuRepository.GetAll()
                          join menu in menuRepository.GetAll()
                          on detalle.MenuId equals menu.ID
                          where detalle.PefilUsuarioId == idPerfilUsuario &&
                                detalle.IdEstatus == (int)ETypeEstatusRegistro.Activo &&
                                menu.IdEstatus == (int)ETypeEstatusRegistro.Activo && 
                                menu.IdMenuPadre == idMenuPadre
                          orderby menu.Orden
                          select menu).ToList();

            return menusPadre;
        }
    }
}
