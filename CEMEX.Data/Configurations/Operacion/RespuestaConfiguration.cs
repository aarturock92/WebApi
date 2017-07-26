using CEMEX.Entidades.Operacion;

namespace CEMEX.Data.Configurations.Operacion
{
    public class RespuestaConfiguration: EntityBaseConfiguration<Respuesta>
    {
        public RespuestaConfiguration()
        {
            HasKey(r => r.ID);

            Property(d => d.IdEscala).IsRequired();

            Property(d => d.Nombre).HasMaxLength(500).IsRequired();

            Property(d => d.IdUsuarioAlta).IsRequired();

            Property(d => d.IdUsuarioModifico).IsOptional();

            Property(d => d.FechaAlta).IsRequired();

            Property(d => d.FechaModifico).IsOptional();

            HasMany(r => r.DetallesRespuesta).WithRequired().HasForeignKey(d => d.IdRespuesta);
        }
    }
}
