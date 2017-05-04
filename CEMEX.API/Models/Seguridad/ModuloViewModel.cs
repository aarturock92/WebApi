using CEMEX.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CEMEX.API.Models.Seguridad
{
    public class ModuloViewModel
    {

        public ModuloViewModel()
        {
            DetalleModuloPermisos = new List<DetalleModuloPermisoViewModel>();

            SubModulos = new List<ModuloViewModel>();
        }

        public int ID { get; set; }

        public int IdRegistroModulo { get; set; }

        public int Orden { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string IconoMenu { get; set; }

        public string Url { get; set; }

        public int Estatus { get; set; }

        public List<DetalleModuloPermisoViewModel> DetalleModuloPermisos { get; set; }

        public List<ModuloViewModel> SubModulos { get; set; }
    }
}