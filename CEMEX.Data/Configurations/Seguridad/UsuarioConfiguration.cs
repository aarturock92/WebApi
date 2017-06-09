using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class UsuarioConfiguration: EntityBaseConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.ID);

            Property(u => u.PerfilUsuarioId).IsRequired();

            Property(u => u.Nombre).IsRequired().HasMaxLength(100);

            Property(u => u.PrimerApellido).IsRequired().HasMaxLength(100);

            Property(u => u.SegundoApellido).IsRequired().HasMaxLength(100);

            Property(u => u.Sexo).IsRequired();

            Property(u => u.Telefono).HasMaxLength(20).IsRequired();

            Property(u => u.Email).IsRequired().HasMaxLength(100);

            Property(u => u.Curp).IsRequired().HasMaxLength(50);

            Property(u => u.RFC).IsRequired().HasMaxLength(50);

            Property(u => u.FechaNacimiento).IsRequired().HasMaxLength(50);

            Property(u => u.NombreUsuario).IsRequired().HasMaxLength(100);

            Property(u => u.HashedContraseña).IsRequired().HasMaxLength(300);

            Property(u => u.Salt).IsRequired().HasMaxLength(300);

            Property(u => u.Calle).IsRequired().HasMaxLength(100);

            Property(u => u.NumeroExterior).IsRequired().HasMaxLength(10);

            Property(u => u.Colonia).IsRequired().HasMaxLength(100);

            Property(u => u.CodigoPostal).IsRequired().HasMaxLength(10);

            Property(u => u.IdPais).IsRequired();

            Property(u => u.IdEstado).IsRequired();

            Property(u => u.IdMunicipio).IsRequired();

            Property(u => u.Imagen).HasMaxLength(400).IsOptional();            

            Property(u => u.IdEstatus).IsRequired();
            
            Property(u => u.IdUsuarioAlta).IsRequired();

            Property(u => u.IdUsuarioModifico).IsOptional();

            Property(u => u.FechaAlta).IsRequired();

            Property(u => u.FechaModifico).IsOptional();
        }
    }
}
