namespace CEMEX.Entidades.Seguridad
{
    public class DetalleModuloPermiso : EntidadBase
    {
        public int Estatus { get; set; }

        public virtual Permiso Permiso {get;set;}

        public int IdModulo { get; set; }

        public int IdPermiso { get; set; }
    }
}
