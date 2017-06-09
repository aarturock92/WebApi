namespace CEMEX.Entidades.App
{
    public class Menu: EntidadBase
    {
        public int IdMenuPadre { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Url { get; set; }

        public int Orden { get; set; }

        public string CssClass { get; set; }

        public int IdEstatus { get; set; }
    }
}
