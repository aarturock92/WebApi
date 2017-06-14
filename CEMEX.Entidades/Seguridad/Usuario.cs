using System.Collections;
using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class Usuario : EntidadBase
    {
        public Usuario()
        {
            DetallesUsuarioAsignacion = new List<DetalleUsuarioAsignacion>();
        }

        public int PerfilUsuarioId { get; set; }

        public string NumeroEmpleado { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int Sexo { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Curp { get; set; }

        public string RFC { get; set; }

        public string FechaNacimiento { get; set; }

        public string NombreUsuario { get; set; }

        public string HashedContraseña { get; set; }

        public string Salt { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public int IdPais { get; set; }

        public int IdEstado { get; set; }

        public int IdMunicipio { get; set; }

        public string Imagen { get; set; }

        public int IdEstatus { get; set; }

        public ICollection<DetalleUsuarioAsignacion> DetallesUsuarioAsignacion { get; set; }
    }
}
