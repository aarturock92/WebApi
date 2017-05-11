using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class MunicipioConfiguration : EntityBaseConfiguration<Municipio>
    {
        public MunicipioConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.Nombre).IsRequired().HasMaxLength(100);

            Property(m => m.Estatus).IsRequired();
            
            Property(m => m.EstadoId).IsRequired();

            Property(m => m.IdUsuarioAlta).IsRequired();

            Property(m => m.IdUsuarioModifico).IsOptional();

            Property(m => m.FechaAlta).IsRequired();

            Property(m => m.FechaModifico).IsOptional();

        }
    }
}
