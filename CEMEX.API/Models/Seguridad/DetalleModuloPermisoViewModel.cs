using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEMEX.API.Models.Seguridad
{
    public class DetalleModuloPermisoViewModel
    {
        public int ID { get; set; }

        public virtual PermisoViewModel Permiso { get; set; }
        
        public int Estatus { get; set; }
    }
}