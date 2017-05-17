using System.Collections.Generic;

namespace CEMEX.API.Models.Catalogos
{
    public class PlazaOxxoViewModel
    {
        public int ID { get; set; }

        public string CRPlazaOxxo { get; set; }

        public string NombrePlazaOxxo { get; set; }

        public int Estatus { get; set; }

        public List<DistritoViewModel> Distritos { get; set; }
    }
}