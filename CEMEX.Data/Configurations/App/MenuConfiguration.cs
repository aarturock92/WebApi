using CEMEX.Entidades.App;

namespace CEMEX.Data.Configurations.App
{
    public class MenuConfiguration: EntityBaseConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            HasKey(m => m.ID);

            Property(m => m.IdMenuPadre).IsRequired();

            Property(m => m.Nombre).IsRequired().HasMaxLength(100);

            Property(m => m.Descripcion).IsRequired().HasMaxLength(200);

            Property(m => m.Url).IsRequired().HasMaxLength(200);

            Property(m => m.Orden).IsRequired();

            Property(m => m.CssClass).IsRequired().HasMaxLength(100);

            Property(m => m.IdEstatus).IsRequired();

            Property(e => e.IdUsuarioAlta).IsRequired();

            Property(e => e.IdUsuarioModifico).IsOptional();

            Property(e => e.FechaAlta).IsRequired();

            Property(e => e.FechaModifico).IsOptional();
        }
    }
}
