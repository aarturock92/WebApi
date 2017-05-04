namespace CEMEX.Entidades.Seguridad
{
    public class Jerarquia : EntidadBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdJerarquiaPadre { get; set; }

        public int NivelEstructura { get; set; }

        public int Estatus { get; set; }
    }
}
