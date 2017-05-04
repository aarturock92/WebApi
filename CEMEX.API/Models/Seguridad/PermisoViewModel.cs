using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CEMEX.API.Models.Seguridad
{
    public class PermisoViewModel
    {

        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Icono { get; set; }

        public int Estatus { get; set; }
    }
}