using System;

namespace CEMEX.Entidades.Catalogos
{
    public class Municipio : EntidadBase
    {
        public string Nombre { get; set; }

        public int Estatus { get; set; }

        public int IdEstado { get; set; }
    }
}
