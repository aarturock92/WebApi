namespace CEMEX.Entidades.Seguridad
{
    public class PerfilUsuario:EntidadBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int IdJerarquia { get; set; }

        public bool AsignacionMultiple { get; set; }

        public int Estatus { get; set; }
    }
}
