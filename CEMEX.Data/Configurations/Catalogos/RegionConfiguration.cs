using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class RegionConfiguration:EntityBaseConfiguration<Region>
    {
        public RegionConfiguration()
        {
            HasKey(r => r.ID);

            Property(r => r.IdNegocio).IsRequired();

            Property(r => r.ClaveRegion).IsRequired().HasMaxLength(50);

            Property(r => r.NombreRegion).IsRequired().HasMaxLength(100);

            Property(r => r.Estatus).IsRequired();

            Property(p => p.FechaAlta).IsRequired();

            Property(p => p.FechaModifico).IsOptional();

            Property(p => p.IdUsuarioAlta).IsRequired();

            Property(p => p.IdUsuarioModifico).IsOptional();

            HasMany(r => r.PlazasImmex).WithRequired().HasForeignKey(p => p.RegionId);
        }
    }
}
