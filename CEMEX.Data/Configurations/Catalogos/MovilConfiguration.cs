using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class MovilConfiguration: EntityBaseConfiguration<Movil>
    {
        public MovilConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.RegionId).IsRequired();

            Property(m => m.PlazaImmexId).IsRequired();

            Property(m => m.Marca).IsRequired().HasMaxLength(100);

            Property(m => m.Modelo).IsRequired().HasMaxLength(100);

            Property(m => m.NumeroTelefono).IsRequired().HasMaxLength(100);

            Property(m => m.NumeroSerie).IsRequired().HasMaxLength(100);

            Property(m => m.IMEI).IsRequired().HasMaxLength(100);

            Property(m => m.IdEstatus).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();
        }
    }
}
