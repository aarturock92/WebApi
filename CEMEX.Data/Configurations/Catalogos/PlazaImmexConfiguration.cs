using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class PlazaImmexConfiguration:EntityBaseConfiguration<PlazaImmex>
    {
        public PlazaImmexConfiguration()
        {
            HasKey(p => p.ID);

            Property(p => p.RegionId).IsRequired();

            Property(p => p.CRPlazaImmex).IsRequired().HasMaxLength(50);

            Property(p => p.NombrePlazaImmex).IsRequired().HasMaxLength(100);

            Property(p => p.Estatus).IsRequired();

            Property(p => p.FechaAlta).IsRequired();

            Property(p => p.FechaModifico).IsOptional();

            Property(p => p.IdUsuarioAlta).IsRequired();

            Property(p => p.IdUsuarioModifico).IsOptional();

            HasMany(p => p.PlazasOxxo).WithRequired().HasForeignKey(p => p.PlazaImmexId);

            HasMany(p => p.Vehiculos).WithRequired().HasForeignKey(v => v.PlazaImmexId);
        }
    }
}
