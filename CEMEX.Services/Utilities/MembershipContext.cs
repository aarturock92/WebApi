using CEMEX.Entidades.Seguridad;
using System.Security.Principal;

namespace CEMEX.Services.Utilities
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public Usuario usuario { get; set; }
        public bool esValido()
        {
            return Principal != null;
        }
    }
}
