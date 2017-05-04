namespace CEMEX.Entidades.Seguridad
{
    public class Permiso:EntidadBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Icono { get; set; }

        public int Estatus { get; set; }
    }
}
