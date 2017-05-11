using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class PlazaImmex:EntidadBase
    {
        public int RegionId { get; set; }

        public string CRPlazaImmex { get; set; }

        public string NombrePlazaImmex { get; set; }

        public int Estatus { get; set; }

        public ICollection<PlazaOxxo> PlazasOxxo { get; set; }
    }
}
