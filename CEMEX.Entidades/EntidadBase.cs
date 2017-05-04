using System;

namespace CEMEX.Entidades
{
    public class EntidadBase:IEntidadBase
    {
        public int ID { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime FechaModifico { get; set; }

        public int IdUsuarioAlta { get; set; }

        public int IdUsuarioModifico { get; set; }
    }
}
