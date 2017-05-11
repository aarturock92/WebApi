using System.Collections.Generic;

namespace CEMEX.API.Models.Catalogos
{
    public class RegionViewModel
    {
        public int ID { get; set; }
        
        public string IdNegocio { get; set; }

        public string ClaveRegion { get; set; }

        public string NombreRegion { get; set; }

        public int Estatus { get; set; }

        public List<PlazaImmexViewModel> PlazasImmex { get; set; }
    }
}