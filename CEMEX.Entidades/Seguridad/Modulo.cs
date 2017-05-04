using System.Collections;
using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class Modulo:EntidadBase
    {

        public Modulo()
        {
            ModuloDetallePermisos = new List<DetalleModuloPermiso>();
        }

        public int IdRegistroModulo { get; set; }

        public int Orden { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string IconoMenu { get; set; }

        public string Url { get; set; }

        public int Estatus { get; set; }

        public virtual ICollection<DetalleModuloPermiso> ModuloDetallePermisos { get; set; }
    }
}
