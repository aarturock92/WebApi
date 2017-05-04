using CEMEX.Entidades.Seguridad;
using CEMEX.Services.Utilities;
using System.Collections.Generic;

namespace CEMEX.Services.Abstract
{
    public interface IMembershipService
    {
        MembershipContext ValidarUsuario(string usuario, string contraseña);
        Usuario CrearUsuario(string username, string email, string password, int[] roles, int idUsuarioAlta);
        Usuario GetUsuario(int userId);
        List<Rol> GetUsuarioRoles(string username);
    }
}
