using System.Collections.Generic;

namespace CEMEX.API.Models.Aplicacion
{
    public class MenuViewModel
    {
        public int ID { get; set; }

        public int IdMenuPadre { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public string CssClass { get; set; }

        public int IdEstatus { get; set; }

        public IEnumerable<MenuViewModel> SubMenus { get; set; }
    }
}