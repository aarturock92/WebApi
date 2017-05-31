using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMEX.Entidades.Seguridad
{
    public class PerfilUsuario:EntidadBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdJerarquia { get; set; }

        public bool AsignacionMultiple { get; set; }

        public int Estatus { get; set; }
    }
}
