using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class JerarquiaConfiguration: EntityBaseConfiguration<Jerarquia>
    {
        public JerarquiaConfiguration()
        {
            HasKey(j => j.ID);

            Property(j => j.NivelJerarquia).IsRequired();

            Property(j => j.Nombre).IsRequired().HasMaxLength(100);

            Property(j => j.Descripcion).IsRequired().HasMaxLength(200);

            Property(j => j.Estatus).IsRequired();

            Property(j => j.IdUsuarioAlta).IsRequired();

            Property(j => j.IdUsuarioModifico).IsOptional();

            Property(j => j.FechaAlta).IsRequired();

            Property(j => j.FechaModifico).IsOptional();

            HasMany(j => j.PerfilesUsuario).WithRequired().HasForeignKey(p => p.JerarquiaId);


        }
    }
}
