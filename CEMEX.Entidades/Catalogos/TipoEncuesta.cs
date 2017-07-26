using CEMEX.Entidades.Operacion;
using System.Collections.Generic;

namespace CEMEX.Entidades.Catalogos
{
    public class TipoEncuesta: EntidadBase
    {
        public TipoEncuesta()
        {
            Encuestas = new List<Encuesta>();
        }

        public string Nombre { get; set; }

        public int IdEstatus { get; set; }

        public ICollection<Encuesta> Encuestas { get; set; }
    }
}
