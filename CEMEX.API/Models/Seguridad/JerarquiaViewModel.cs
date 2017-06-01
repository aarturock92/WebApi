using CEMEX.API.Infrastructure.Validators.Seguridad;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CEMEX.API.Models.Seguridad
{
    public class JerarquiaViewModel : IValidatableObject
    {
        public int ID { get; set; }

        public int NivelJerarquia { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Estatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new JerarquiaViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,
                            new[] { item.PropertyName }));
        }
    }
}