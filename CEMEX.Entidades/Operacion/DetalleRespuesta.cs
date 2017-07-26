namespace CEMEX.Entidades.Operacion
{
    public class DetalleRespuesta:EntidadBase
    {
        public int IdRespuesta { get; set; }

        public string Respuesta { get; set; }

        public int IdEstatus { get; set; }
    }
}
