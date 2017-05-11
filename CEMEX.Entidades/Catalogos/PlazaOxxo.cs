using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class PlazaOxxo:EntidadBase
    {
        public int PlazaImmexId { get; set; }

        public string CRPlazaOxxo { get; set; }

        public string NombrePlazaOxxo { get; set; }

        public int Estatus { get; set; }

        public ICollection<Distrito> Distritos { get; set; }
    }
}
