using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEMEX.API.Models.Catalogos
{
    public class MovilViewModel
    {
        public int ID { get; set; }

        public int IdRegion { get; set; }

        public int IdPlazaImmex { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroTelefono { get; set; }

        public string  NumeroSerie { get; set; }

        public string IMEI { get; set; }

        public int IdEstatus { get; set; }
    }
}