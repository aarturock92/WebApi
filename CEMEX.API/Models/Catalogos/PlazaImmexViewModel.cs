using System.Collections.Generic;

namespace CEMEX.API.Models.Catalogos
{
    public class PlazaImmexViewModel
    {
        public int ID { get; set; }

        public int RegionId { get; set; }

        public string CRPlazaImmex { get; set; }

        public string NombrePlazaImmex { get; set; }

        public int Estatus { get; set; }

        public List<PlazaOxxoViewModel> PlazasOxxo { get; set; }
    }
}