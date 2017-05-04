namespace CEMEX.Entidades.Seguridad
{
    public class UsuarioRol:EntidadBase
    {
        public int UsuarioId { get; set; }

        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
