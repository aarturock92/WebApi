using CEMEX.Entidades.Operacion;

namespace CEMEX.Data.Configurations.Operacion
{
    public class DetalleRespuestaConfiguration: EntityBaseConfiguration<DetalleRespuesta>
    {
        public DetalleRespuestaConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.IdRespuesta).IsRequired();

            Property(d => d.Respuesta).HasMaxLength(500).IsRequired();

            Property(d => d.IdUsuarioAlta).IsRequired();

            Property(d => d.IdUsuarioModifico).IsOptional();

            Property(d => d.FechaAlta).IsRequired();

            Property(d => d.FechaModifico).IsOptional();

            Property(d => d.IdEstatus).IsRequired();
        }
    }
}
