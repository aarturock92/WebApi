using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class DetalleRolPermisoConfiguration:EntityBaseConfiguration<DetalleRolPermiso>
    {
        public DetalleRolPermisoConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.Estatus).IsRequired();

            Property(d => d.IdUsuarioAlta).IsRequired();

            Property(d => d.IdUsuarioModifico).IsOptional();

            Property(d => d.FechaAlta).IsRequired();

            Property(d => d.FechaModifico).IsOptional();
        }
    }
}
