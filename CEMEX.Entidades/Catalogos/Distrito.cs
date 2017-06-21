using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class Distrito:EntidadBase
    {
        public Distrito()
        {
            Tiendas = new List<Tienda>();
        }

        public int PlazaOxxoId { get; set; }

        public string ClaveDistrito { get; set; }

        public string NombreDistrito { get; set; }

        public int Estatus { get; set; }

        public ICollection<Tienda> Tiendas { get; set; }
    }
}
