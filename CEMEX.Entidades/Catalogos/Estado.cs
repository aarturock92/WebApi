using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class Estado:EntidadBase
    {
        public Estado()
        {
            Municipios = new List<Municipio>();
        }

        public string Nombre { get; set; }

        public string Abreviatura { get; set; }

        public int Estatus { get; set; }

        public ICollection<Municipio> Municipios { get; set; }
    }
}
