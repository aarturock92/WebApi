using CEMEX.API.Infrastructure.Validators.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Seguridad
{
    public class RolViewModel : IValidatableObject
    {
        public int ID { get; set; }

        public int IdJerarquia { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int AsignacionMultiple { get; set; }

        public int Estatus { get; set; }

        //public List<>


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new RolViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,
                            new[] { item.PropertyName }));
        }
    }
}