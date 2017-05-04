using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class ActividadPGVConfiguration:EntityBaseConfiguration<ActividadPGV>
    {
        public ActividadPGVConfiguration()
        {
            HasKey(a => a.ID);

            Property(a => a.Descripcion).IsRequired().HasMaxLength(100);

            Property(a => a.Estatus).IsRequired();

            Property(a => a.IdUsuarioAlta).IsRequired();

            Property(a => a.IdUsuarioModifico).IsOptional();

            Property(a => a.FechaAlta).IsRequired();

            Property(a => a.FechaModifico).IsOptional();
        }
    }
}
