using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class Rol : EntidadBase
    {
        public Rol()
        {
            DetalleRolPermisos = new List<DetalleRolPermiso>();
        }

        public int IdJerarquia { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int AsignacionMultiple { get; set; }

        public int Estatus { get; set; }

        public virtual List<DetalleRolPermiso> DetalleRolPermisos { get; set; }
    }
}
