using System;

namespace CEMEX.Entidades.Seguridad
{
    public class Error:EntidadBase
    {
        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}
