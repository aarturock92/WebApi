using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class PerfilUsuario:EntidadBase
    {
        public PerfilUsuario()
        {
            Usuarios = new List<Usuario>();

            DetallesPefilUsuarioMenu = new List<DetallePerfilUsuarioMenu>();
        }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int JerarquiaId { get; set; }

        public bool AsignacionMultiple { get; set; }

        public int Estatus { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public ICollection<DetallePerfilUsuarioMenu> DetallesPefilUsuarioMenu { get; set; }
    }
}
