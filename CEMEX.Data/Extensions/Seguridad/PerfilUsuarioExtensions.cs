using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.App;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Seguridad
{
    public static class PerfilUsuarioExtensions
    {
        public static IEnumerable<PerfilUsuario> GetPerfilUsuarioByEstatus(this IEntityBaseRepository<PerfilUsuario> perfilUsuarioRepository, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<PerfilUsuario> perfilesUsuario = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    perfilesUsuario = perfilUsuarioRepository.GetAll()
                                                             .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    perfilesUsuario = perfilUsuarioRepository.GetAll()
                                                             .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    perfilesUsuario = perfilUsuarioRepository.GetAll()
                                                             .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    perfilesUsuario = perfilUsuarioRepository.GetAll()
                                                             .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                                                         p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                             .ToList();
                    break;
                default:
                    perfilesUsuario = perfilUsuarioRepository.GetAll()
                                                             .ToList();
                    break;
            }


            return perfilesUsuario;
        }

        public static IEnumerable<Menu> GetMenuByPerfilUsuarioId(this IEntityBaseRepository<PerfilUsuario>  perfilUsuarioRepository,
                                                                 IEntityBaseRepository<DetallePerfilUsuarioMenu> detallePerfilUsuarioMenuRepository,
                                                                 IEntityBaseRepository<Menu> menuRepository, 
                                                                 int id)
        {
            return (from perfil in perfilUsuarioRepository.GetAll()
                    join detalle in detallePerfilUsuarioMenuRepository.GetAll()
                    on perfil.ID equals detalle.PefilUsuarioId
                    join menu in menuRepository.GetAll()
                    on detalle.MenuId equals menu.ID
                    where perfil.ID == id && 
                          detalle.IdEstatus == (int)ETypeEstatusRegistro.Activo && 
                          menu.IdEstatus == (int)ETypeEstatusRegistro.Activo
                    select menu).ToArray();
        }
    }
}
