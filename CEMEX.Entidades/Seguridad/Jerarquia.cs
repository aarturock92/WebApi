namespace CEMEX.Entidades.Seguridad
{
    public class Jerarquia : EntidadBase
    {
        public int NivelJerarquia { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Estatus { get; set; }
    }
}
