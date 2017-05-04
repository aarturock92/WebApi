using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class DetalleModuloPermisoConfiguration:EntityBaseConfiguration<DetalleModuloPermiso>
    {
        public DetalleModuloPermisoConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.IdUsuarioAlta).IsRequired();

            Property(d => d.IdUsuarioModifico).IsOptional();

            Property(d => d.FechaAlta).IsRequired();

            Property(d => d.FechaModifico).IsOptional();
        }
    }
}
