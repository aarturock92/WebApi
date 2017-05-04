using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class ModuloConfiguration: EntityBaseConfiguration<Modulo>
    {
        public ModuloConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.IdRegistroModulo).IsRequired();

            Property(m => m.Orden).IsRequired();

            Property(m => m.Nombre).IsRequired().HasMaxLength(100);

            Property(m => m.Descripcion).IsRequired().HasMaxLength(200);

            Property(m => m.IconoMenu).IsRequired().HasMaxLength(50);

            Property(m => m.Url).IsRequired().HasMaxLength(100);

            Property(m => m.Estatus).IsRequired();

            Property(m => m.IdUsuarioAlta).IsRequired();

            Property(m => m.IdUsuarioModifico).IsOptional();

            Property(m => m.FechaAlta).IsRequired();

            Property(m => m.FechaModifico).IsRequired();
        }
    }
}
