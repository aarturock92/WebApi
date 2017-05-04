using CEMEX.API.Infrastructure.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Catalogos
{
    public class MunicipioViewModel:IValidatableObject
    {
        public int ID { get; set; }   

        public string Nombre { get; set; }

        public int Estatus { get; set; }

        public int IdEstado { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MunicipioViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,
                new[] { item.PropertyName }));
        }
    }
}