using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
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
            return usersRepository.GetAll().FirstOrDefault(u => u.Email.Trim() == emailAddress.Trim());
        }
    }
}
