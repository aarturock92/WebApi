using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class RolConfiguration:EntityBaseConfiguration<Rol>
    {
        public RolConfiguration()
        {
            HasKey(r => r.ID);

            Property(r => r.IdJerarquia).IsRequired();

            Property(r => r.Nombre).IsRequired().HasMaxLength(100);

            Property(r => r.Descripcion).IsRequired().HasMaxLength(200);

            Property(r => r.AsignacionMultiple).IsRequired();

            Property(r => r.Estatus).IsRequired();

            Property(r => r.IdUsuarioAlta).IsRequired();

            Property(r => r.IdUsuarioModifico).IsOptional();

            Property(r => r.FechaAlta).IsRequired();

            Property(r => r.FechaModifico).IsOptional();
        }
    }
}
