using CEMEX.Entidades.Catalogos;

namespace CEMEX.Data.Configurations.Catalogos
{
    public class TiendaConfiguration:EntityBaseConfiguration<Tienda>
    {
        public TiendaConfiguration()
        {
            HasKey(t => t.ID);

            Property(t => t.DistritoId).IsRequired();

            Property(t => t.UniqueTienda).IsRequired();

            Property(t => t.CRTienda).IsRequired().HasMaxLength(50);

            Property(t => t.NombreTienda).IsRequired().HasMaxLength(100);

            Property(t => t.Calle).IsRequired().HasMaxLength(150);

            Property(t => t.Numero).IsRequired().HasMaxLength(20);

            Property(t => t.EntreCalles).IsRequired().HasMaxLength(150);

            Property(t => t.Colonia).IsRequired().HasMaxLength(100);

            Property(t => t.Municipio).IsRequired().HasMaxLength(100);

            Property(t => t.Ciudad).IsRequired().HasMaxLength(100);

            Property(t => t.Estado).IsRequired().HasMaxLength(100);

            Property(t => t.CodigoPostal).IsRequired().HasMaxLength(10);

            Property(t => t.Latitud).IsRequired().HasMaxLength(20);

            Property(t => t.Longitud).IsRequired().HasMaxLength(20);

            Property(t => t.EstatusTienda).IsRequired().HasMaxLength(20);

            Property(t => t.Estatus).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();
        }
    }
}
