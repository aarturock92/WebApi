using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class UsuarioRolConfiguration:EntityBaseConfiguration<UsuarioRol>
    {
        public UsuarioRolConfiguration()
        {
            HasKey(u => u.ID);

            Property(u => u.UsuarioId).IsRequired();

            Property(u => u.RolId).IsRequired();

            Property(u => u.IdUsuarioAlta).IsRequired();

            Property(u => u.IdUsuarioModifico).IsOptional();

            Property(u => u.FechaAlta).IsRequired();

            Property(u => u.FechaModifico).IsOptional();
        }
    }
}
