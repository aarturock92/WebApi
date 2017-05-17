using System.Collections.Generic;

namespace CEMEX.API.Models.Catalogos
{
    public class DistritoViewModel
    {
        public int ID { get; set; }

        public string ClaveDistrito { get; set; }

        public string NombreDistrito { get; set; }

        public int Estatus { get; set; }

        public List<TiendaViewModel> Tiendas { get; set; }
    }
}