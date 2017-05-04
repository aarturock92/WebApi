using CEMEX.API.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Catalogos
{
    public class EstadoViewModel:IValidatableObject
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Abreviatura { get; set; }

        public int Estatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new EstadoViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, 
                new[] { item.PropertyName }));

        }
    }
}