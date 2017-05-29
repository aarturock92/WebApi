using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Linq;

namespace CEMEX.Data.Extensions.Seguridad
{
    public static class UsuarioExtensions
    {
        public static Usuario GetSingleByUserName(this IEntityBaseRepository<Usuario> usuarioRepositorio, string nombreUsuario, string emailAddress)
        {
            return usuarioRepositorio.GetAll()
                                     .FirstOrDefault(x => x.NombreUsuario.Trim() == nombreUsuario.Trim() || 
                                                          x.Email.Trim() == emailAddress.Trim());
        }        

        public static Usuario GetSingleByEmailAddress(this IEntityBaseRepository<Usuario> usersRepository, string emailAddress)
        {
            return usersRepository.GetAll()
                                  .FirstOrDefault(u => u.Email.Trim() == emailAddress.Trim());
        }

        public static IEnumerable<Usuario> GetUsuarios(this IEntityBaseRepository<Usuario> userRepository, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Usuario> usuarios = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    usuarios = userRepository.GetAll()
                                             .Where(u => u.IdEstatus == (int)ETypeEstatusRegistro.Activo)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    usuarios = userRepository.GetAll()
                                             .Where(u => u.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    usuarios = userRepository.GetAll()
                                             .Where(u => u.IdEstatus == (int)ETypeEstatusRegistro.Eliminado)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    usuarios = userRepository.GetAll()
                                             .Where(u => u.IdEstatus == (int)ETypeEstatusRegistro.Activo || 
                                                         u.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                             .ToList();
                    break;
                default:
                    usuarios = userRepository.GetAll()
                                             .ToList();
                    break;
            }

            return usuarios;
        }

    }
}
