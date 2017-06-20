namespace CEMEX.Entidades.Catalogos
{
    public class Movil:EntidadBase
    {
        public int IdRegion { get; set; }

        public int PlazaImmexId { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroTelefono { get; set; }

        public string NumeroSerie { get; set; }

        public string IMEI { get; set; }

        public int IdEstatus { get; set; }
    }
}
