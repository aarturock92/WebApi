using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class DetallePerfilUsuarioMenuConfiguration:EntityBaseConfiguration<DetallePerfilUsuarioMenu>
    {
        public DetallePerfilUsuarioMenuConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.IdEstatus).IsRequired();

            Property(d => d.MenuId).IsRequired();

            Property(d => d.PefilUsuarioId).IsRequired();
        }
    }
}
