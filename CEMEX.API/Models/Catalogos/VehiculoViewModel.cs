using CEMEX.API.Infrastructure.Validators.Catalogos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Catalogos
{
    public class VehiculoViewModel: IValidatableObject
    {
        public int ID { get; set; }

        public int PlazaImmexId { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroPlaca { get; set; }

        public string NumeroEconomico { get; set; }

        public int IdEstatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new VehiculoViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,
               new[] { item.PropertyName }));
        }
    }
}