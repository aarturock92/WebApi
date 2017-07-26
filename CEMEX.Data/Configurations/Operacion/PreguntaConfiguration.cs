using CEMEX.Entidades.Operacion;

namespace CEMEX.Data.Configurations.Operacion
{
    public class PreguntaConfiguration: EntityBaseConfiguration<Pregunta>
    {
        public PreguntaConfiguration()
        {
            HasKey(p => p.ID);

            Property(p => p.IdSeccion).IsRequired();

            Property(p => p.Orden).IsRequired();

            Property(p => p.Nombre).HasMaxLength(500).IsRequired();

            Property(p => p.Valor).IsRequired();

            Property(p => p.IdEscala).IsRequired();

            Property(p => p.IdRespuesta).IsRequired();

            Property(p => p.IdTipoValidacion).IsRequired();

            Property(p => p.IdTipoRespuesta).IsRequired();

            Property(p => p.TipAyuda).HasMaxLength(300).IsRequired();

            Property(p => p.ImagenAyuda).HasMaxLength(300).IsRequired();

            Property(p => p.EvidenciaObligatorio).IsRequired();

            Property(p => p.ComentarioObligatorio).IsRequired();

            Property(p => p.VideoObligatorio).IsRequired();

            Property(p => p.PreguntaFicticia).IsRequired();

            Property(p => p.IdEstatus).IsRequired();

            Property(p => p.IdUsuarioAlta).IsRequired();

            Property(p => p.IdUsuarioModifico).IsOptional();

            Property(p => p.FechaAlta).IsRequired();

            Property(p => p.FechaModifico).IsOptional();
        }
    }
}
