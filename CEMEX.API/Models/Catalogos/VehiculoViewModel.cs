namespace CEMEX.API.Models.Catalogos
{
    public class VehiculoViewModel
    {
        public int ID { get; set; }

        public int PlazaImmexId { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroPlaca { get; set; }

        public string NumeroEconomico { get; set; }

        public int IdEstatus { get; set; }
    }
}