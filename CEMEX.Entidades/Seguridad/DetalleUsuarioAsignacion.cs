using System;

namespace CEMEX.Entidades.Seguridad
{
    public class DetalleUsuarioAsignacion:EntidadBase
    {
        public int UsuarioId { get; set; }

        public int ReferenciaId { get; set; }

        public int IdEstatus { get; set; }    
    }
}
