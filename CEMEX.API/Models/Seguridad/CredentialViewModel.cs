using CEMEX.API.Infrastructure.Validators.Seguridad;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Seguridad
{
    public class CredentialViewModel:IValidatableObject
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CredentialViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new string[] {item.PropertyName }));
        }
    }
}