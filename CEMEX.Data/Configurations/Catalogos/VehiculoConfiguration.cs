using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class VehiculoConfiguration: EntityBaseConfiguration<Vehiculo>
    {
        public VehiculoConfiguration()
        {
            HasKey(v => v.ID);

            Property(v => v.PlazaImmexId).IsRequired();

            Property(v => v.UniqueVehiculo).IsRequired();

            Property(v => v.Marca).IsRequired().HasMaxLength(150);

            Property(v => v.Modelo).IsRequired().HasMaxLength(150);

            Property(v => v.NumeroPlaca).IsRequired().HasMaxLength(100);

            Property(v => v.NumeroEconomico).IsRequired().HasMaxLength(100);

            Property(v => v.IdEstatus).IsRequired();
        }
    }
}
