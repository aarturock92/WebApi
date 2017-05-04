using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class UsuarioConfiguration: EntityBaseConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.ID);

            Property(u => u.NombreUsuario).IsRequired().HasMaxLength(100);

            Property(u => u.IdRolUsuario).IsRequired();

            Property(u => u.HashedContraseña).IsRequired().HasMaxLength(300);

            Property(u => u.Salt).IsRequired().HasMaxLength(300);

            Property(u => u.Nombre).IsRequired().HasMaxLength(100);

            Property(u => u.PrimerApellido).IsRequired().HasMaxLength(100);

            Property(u => u.SegundoApellido).IsRequired().HasMaxLength(100);

            Property(u => u.Sexo).IsRequired();

            Property(u => u.Calle).IsRequired().HasMaxLength(100);

            Property(u => u.NumeroExterior).IsRequired().HasMaxLength(10);

            Property(u => u.NumeroInterior).IsRequired().HasMaxLength(10);

            Property(u => u.Colonia).IsRequired().HasMaxLength(100);

            Property(u => u.CodigoPostal).IsRequired().HasMaxLength(10);

            Property(u => u.IdPais).IsRequired();

            Property(u => u.IdEstado).IsRequired();

            Property(u => u.IdMunicipio).IsRequired();

            Property(u => u.Email).IsRequired().HasMaxLength(100);

            Property(u => u.TelefonoOficina).IsRequired().HasMaxLength(20);

            Property(u => u.Extension).IsRequired().HasMaxLength(10);

            Property(u => u.TelefonoCasa).IsRequired().HasMaxLength(20);

            Property(u => u.TelefonoCelular).IsRequired().HasMaxLength(20);

            Property(u => u.IdZona).IsRequired();

            Property(u => u.IdPlaza).IsRequired();

            Property(u => u.IdGerencia).IsRequired();

            Property(u => u.IdEstatus).IsRequired();
            
            Property(u => u.IdUsuarioAlta).IsRequired();

            Property(u => u.IdUsuarioModifico).IsOptional();

            Property(u => u.FechaAlta).IsRequired();

            Property(u => u.FechaModifico).IsOptional();
        }
    }
}
