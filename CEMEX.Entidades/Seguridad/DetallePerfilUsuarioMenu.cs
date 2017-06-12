using CEMEX.Entidades.App;

namespace CEMEX.Entidades.Seguridad
{
    public class DetallePerfilUsuarioMenu:EntidadBase
    {
        public int MenuId { get; set; }

        public int IdEstatus { get; set; }

        public int PefilUsuarioId { get; set; }
    }
}
