using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class EstadoConfiguration:EntityBaseConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            HasKey(e => e.ID);

            Property(e => e.Nombre).IsRequired().HasMaxLength(100);

            Property(e => e.Abreviatura).IsRequired().HasMaxLength(50);

            Property(e => e.Estatus).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();

            HasMany(e => e.Municipios).WithRequired().HasForeignKey(s => s.EstadoId);
        }
    }
}
