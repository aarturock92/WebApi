using System;

namespace CEMEX.Entidades.Catalogos
{
    public class Vehiculo : EntidadBase
    {
        public int PlazaImmexId { get; set; }

        public Guid UniqueVehiculo { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroPlaca { get; set; }

        public string NumeroEconomico { get; set; }

        public int IdEstatus { get; set; }
    }
}
