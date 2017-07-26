using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class TipoEncuestaConfiguration: EntityBaseConfiguration<TipoEncuesta>
    {
        public TipoEncuestaConfiguration()
        {
            HasKey(t => t.ID);

            Property(t => t.Nombre).HasMaxLength(500).IsRequired();

            Property(t => t.IdUsuarioAlta).IsRequired();

            Property(t => t.IdUsuarioModifico).IsOptional();

            Property(t => t.FechaAlta).IsRequired();

            Property(t => t.FechaModifico).IsOptional();

            Property(t => t.IdEstatus).IsRequired();

            HasMany(t => t.Encuestas).WithRequired().HasForeignKey(e => e.IdTipoEncuesta);
        }
    }
}
