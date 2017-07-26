using CEMEX.Entidades.Operacion;

namespace CEMEX.Data.Configurations.Operacion
{
    public class SeccionConfiguration: EntityBaseConfiguration<Seccion>
    {
        public SeccionConfiguration()
        {
            HasKey(s => s.ID);

            Property(s => s.IdEncuesta).IsRequired();

            Property(s => s.Orden).IsRequired();

            Property(s => s.Nombre).HasMaxLength(500).IsRequired();

            Property(s => s.Valor).IsRequired();

            Property(s => s.IdEstatus).IsRequired();

            Property(s => s.FechaAlta).IsRequired();

            Property(s => s.FechaModifico).IsOptional();

            Property(s => s.IdUsuarioAlta).IsRequired();

            Property(s => s.IdUsuarioModifico).IsOptional();

            HasMany(s => s.Preguntas).WithRequired().HasForeignKey(p => p.IdSeccion);
        }
    }
}
