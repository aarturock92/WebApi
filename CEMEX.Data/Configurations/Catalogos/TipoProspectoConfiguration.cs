using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class TipoProspectoConfiguration:EntityBaseConfiguration<TipoProspecto>
    {
        public TipoProspectoConfiguration()
        {
            HasKey(t => t.ID);

            Property(t => t.Descripcion).IsRequired().HasMaxLength(100);

            Property(t => t.Estatus).IsRequired();

            Property(t => t.FechaAlta).IsRequired();

            Property(t => t.FechaModifico).IsOptional();

            Property(t => t.IdUsuarioAlta).IsRequired();

            Property(t => t.IdUsuarioModifico).IsOptional();
        }
    }
}
