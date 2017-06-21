using CEMEX.API.Infrastructure.Validators.Seguridad;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Seguridad
{
    public class UsuarioViewModel : IValidatableObject
    {
        public int ID { get; set; }

        public int IdPerfilUsuario { get; set; }

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

        public string Contrasena { get; set; }

        public string Calle { get; set; }

        public string NumeroExterior { get; set; }

        public string Colonia { get; set; }

        public string CodigoPostal { get; set; }

        public int IdPais { get; set; }

        public int IdEstado { get; set; }

        public int IdMunicipio { get; set; }

        public string Imagen { get; set; }

        public int Estatus { get; set; }

        public List<DetalleUsuarioAsignacionViewModel> DetallesUsuarioAsignacion { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UsuarioViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}