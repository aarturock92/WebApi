using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class DistritoConfiguration:EntityBaseConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            HasKey(m => m.ID);

            Property(d => d.PlazaOxxoId).IsRequired();

            Property(d => d.ClaveDistrito).IsRequired().HasMaxLength(50);

            Property(d => d.NombreDistrito).IsRequired().HasMaxLength(100);

            Property(d => d.Estatus).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();

            HasMany(d => d.Tiendas).WithRequired().HasForeignKey(t => t.DistritoId);
        }
    }
}
