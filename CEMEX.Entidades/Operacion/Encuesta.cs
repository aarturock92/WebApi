using System;
using System.Collections.Generic;

namespace CEMEX.Entidades.Operacion
{
    public class Encuesta:EntidadBase
    {
        public Encuesta()
        {
            Secciones = new List<Seccion>();
        }

        public int IdTipoEncuesta { get; set; }

        public Guid Unique { get; set; }

        public string Nombre { get; set; }

        public string IdEstatus { get; set; }

        public ICollection<Seccion> Secciones { get; set; }
    }
}
