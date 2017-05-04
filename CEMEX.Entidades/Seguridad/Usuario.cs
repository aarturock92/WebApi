using System.Collections;
using System.Collections.Generic;

namespace CEMEX.Entidades.Seguridad
{
    public class Usuario : EntidadBase
    {
        public Usuario()
        {
            UsuarioRoles = new List<UsuarioRol>();
        }

        public string NombreUsuario { get; set; }

        public int IdRolUsuario { get; set; }

        public string HashedContraseña { get; set; }

        public string Salt { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public int Sexo { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string NumeroInterior { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public int IdPais { get; set; }

        public int IdEstado { get; set; }

        public int IdMunicipio { get; set; }

        public string Email { get; set; }

        public string TelefonoOficina { get; set; }

        public string Extension { get; set; }

        public string TelefonoCasa { get; set; }

        public string TelefonoCelular { get; set; }

        public int IdZona { get; set; }
        
        public int IdPlaza { get; set; }

        public int IdGerencia { get; set; }

        public int IdEstatus { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRoles { get; set; }
    }
}
