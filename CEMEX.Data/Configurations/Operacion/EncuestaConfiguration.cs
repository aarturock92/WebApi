using CEMEX.Entidades.Operacion;

namespace CEMEX.Data.Configurations.Operacion
{
    public class EncuestaConfiguration:EntityBaseConfiguration<Encuesta>
    {
        public EncuestaConfiguration()
        {
            HasKey(e => e.ID);

            Property(e => e.Unique).IsRequired();

            Property(e => e.Nombre).HasMaxLength(500).IsRequired();

            Property(e => e.IdTipoEncuesta).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();

            HasMany(e => e.Secciones).WithRequired().HasForeignKey(s => s.IdEncuesta);
        }
    }
}
