using System.Collections.Generic;

namespace CEMEX.Entidades.Operacion
{
    public class Respuesta:EntidadBase
    {
        public Respuesta()
        {
            DetallesRespuesta = new List<DetalleRespuesta>();
        }

        public int IdEscala { get; set; }

        public string Nombre { get; set; }

        public ICollection<DetalleRespuesta> DetallesRespuesta { get; set; }
    }
}
