using System.Collections.Generic;

namespace CEMEX.Entidades.Operacion
{
    public class Seccion: EntidadBase
    {
        public Seccion()
        {
            Preguntas = new List<Pregunta>();
        }

        public int IdEncuesta { get; set; }

        public int Orden { get; set; }

        public string Nombre { get; set; }

        public double Valor { get; set; }

        public int IdEstatus { get; set; }
        
        public ICollection<Pregunta> Preguntas { get; set; }        
    }
}
