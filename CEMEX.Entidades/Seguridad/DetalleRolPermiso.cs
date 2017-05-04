namespace CEMEX.Entidades.Seguridad
{
    public class DetalleRolPermiso:EntidadBase
    {
        public virtual DetalleModuloPermiso DetalleModuloPermiso { get; set; }

        public virtual Rol Rol { get; set; }

        public int Estatus { get; set; }
    }
}
