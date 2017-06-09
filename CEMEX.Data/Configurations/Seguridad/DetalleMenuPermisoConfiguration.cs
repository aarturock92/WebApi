using CEMEX.Entidades.Seguridad;

namespace CEMEX.Data.Configurations.Seguridad
{
    public class DetalleMenuPermisoConfiguration:EntityBaseConfiguration<DetalleMenuPermiso>
    {
        public DetalleMenuPermisoConfiguration()
        {
            HasKey(d => d.ID);

            Property(d => d.IdModulo).IsRequired();

            Property(d => d.IdPermiso).IsRequired();

            Property(d => d.IdEstatus).IsRequired();
        }
    }
}
