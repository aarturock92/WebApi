using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class PlazaImmex:EntidadBase
    {
        public PlazaImmex()
        {
            PlazasOxxo = new List<PlazaOxxo>();

            Vehiculos = new List<Vehiculo>();

            Moviles = new List<Movil>();
        }

        public int RegionId { get; set; }

        public string CRPlazaImmex { get; set; }

        public string NombrePlazaImmex { get; set; }

        public int Estatus { get; set; }

        public ICollection<PlazaOxxo> PlazasOxxo { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }

        public ICollection<Movil> Moviles { get; set; }
    }
}
