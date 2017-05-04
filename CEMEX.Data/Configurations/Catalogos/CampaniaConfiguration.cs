using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class CampaniaConfiguration:EntityBaseConfiguration<Campania>
    {
        public CampaniaConfiguration()
        {
            HasKey(c => c.ID);

            Property(c => c.Descripcion);

            Property(c => c.Estatus).IsRequired();

            Property(c => c.FechaAlta).IsRequired();

            Property(c => c.FechaModifico).IsOptional();

            Property(c => c.IdUsuarioAlta).IsRequired();

            Property(c => c.IdUsuarioModifico).IsOptional();
        }
    }
}
