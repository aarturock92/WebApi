using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class PlazaOxxoConfiguration:EntityBaseConfiguration<PlazaOxxo>
    {
        public PlazaOxxoConfiguration()
        {
            Property(p => p.PlazaImmexId).IsRequired();

            Property(p => p.CRPlazaOxxo).IsRequired().HasMaxLength(50);

            Property(p => p.NombrePlazaOxxo).IsRequired().HasMaxLength(100);

            Property(p => p.Estatus).IsRequired();

            Property(p => p.FechaAlta).IsRequired();

            Property(p => p.FechaModifico).IsOptional();

            Property(p => p.IdUsuarioAlta).IsRequired();

            Property(p => p.IdUsuarioModifico).IsOptional();

            HasMany(p => p.Distritos).WithRequired().HasForeignKey(d => d.DistritoId);
        }
    }
}
