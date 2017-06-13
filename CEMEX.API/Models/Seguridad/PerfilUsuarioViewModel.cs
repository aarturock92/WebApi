namespace CEMEX.API.Models.Seguridad
{
    public class PerfilUsuarioViewModel
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int JerarquiaId { get; set; }

        public bool AsignacionMultiple { get; set; }

        public int Estatus { get; set; }
    }
}