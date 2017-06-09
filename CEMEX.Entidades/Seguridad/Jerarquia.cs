using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class Jerarquia : EntidadBase
    {
        public Jerarquia()
        {
            PerfilesUsuario = new List<PerfilUsuario>();
        }

        public int NivelJerarquia { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Estatus { get; set; }

        public ICollection<PerfilUsuario> PerfilesUsuario { get; set; }
    }
}
