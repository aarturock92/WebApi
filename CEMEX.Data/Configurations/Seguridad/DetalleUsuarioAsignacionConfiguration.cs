using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class DetalleUsuarioAsignacionConfiguration: EntityBaseConfiguration<DetalleUsuarioAsignacion>
    {
        public DetalleUsuarioAsignacionConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.UsuarioId).IsRequired();

            Property(d => d.ReferenciaId).IsRequired();

            Property(d => d.IdEstatus).IsRequired();

            Property(d => d.FechaAlta).IsRequired();

            Property(d => d.FechaModifico).IsRequired();                   
        }
    }
}
