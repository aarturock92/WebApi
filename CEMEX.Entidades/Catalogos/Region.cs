using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class Region:EntidadBase
    {
        public Region()
        {
            PlazasImmex = new List<PlazaImmex>();
        }

        public int IdNegocio { get; set; }

        public string ClaveRegion { get; set; }

        public string NombreRegion { get; set; }

        public int Estatus { get; set; }

        public ICollection<PlazaImmex> PlazasImmex { get; set; }
    }
}
