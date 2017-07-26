namespace CEMEX.Entidades.Operacion
{
    public class Pregunta:EntidadBase
    {
        public int IdSeccion { get; set; }

        public int Orden { get; set; }

        public string Nombre { get; set; }

        public double Valor { get; set; }

        public int IdEscala { get; set; }

        public int IdRespuesta { get; set; }

        public int IdTipoValidacion { get; set; }

        public int IdTipoRespuesta { get; set; }

        public string TipAyuda { get; set; }

        public string ImagenAyuda { get; set; }

        public bool EvidenciaObligatorio { get; set; }

        public bool ComentarioObligatorio { get; set; }

        public bool VideoObligatorio { get; set; }

        public bool PreguntaFicticia { get; set; }

        public int IdEstatus { get; set; }
    }
}
