using System;

namespace CEMEX.Entidades.Catalogos
{
    public class Tienda:EntidadBase
    {
        public int DistritoId { get; set; }

        public Guid UniqueTienda { get; set; }

        public string CRTienda { get; set; }

        public string NombreTienda { get; set; }

        public string Calle { get; set; }

        public string Numero { get; set; }

        public string EntreCalles { get; set; }

        public string Colonia { get; set; }

        public string Municipio { get; set; }

        public string Ciudad { get; set; }

        public string Estado { get; set; }

        public string CodigoPostal { get; set; }

        public string Latitud { get; set; }
        
        public string Longitud { get; set; }

        public string EstatusTienda { get; set; }

        public int Estatus { get; set; }
    }
}
