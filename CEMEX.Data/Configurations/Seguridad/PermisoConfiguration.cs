using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class PermisoConfiguration:EntityBaseConfiguration<Permiso>
    {
        public PermisoConfiguration()
        {
            HasKey(p => p.ID);

            Property(p => p.Nombre).IsRequired().HasMaxLength(100);

            Property(p => p.Descripcion).IsRequired().HasMaxLength(200);

            Property(p => p.Icono).IsRequired().HasMaxLength(100);

            Property(p => p.Estatus).IsRequired();

            Property(p => p.IdUsuarioAlta).IsRequired();

            Property(p => p.IdUsuarioModifico).IsOptional();

            Property(p => p.FechaAlta).IsRequired();

            Property(p => p.FechaModifico).IsOptional();
        }
    }
}
