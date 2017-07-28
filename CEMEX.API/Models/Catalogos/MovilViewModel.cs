using CEMEX.API.Infrastructure.Validators.Catalogos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CEMEX.API.Models.Catalogos
{
    public class MovilViewModel:IValidatableObject
    {
        public int ID { get; set; }

        public int RegionId { get; set; }

        public int PlazaImmexId { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string NumeroTelefono { get; set; }

        public string  NumeroSerie { get; set; }

        public string IMEI { get; set; }

        public int IdEstatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new MovilViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage,
                new[] { item.PropertyName }));
        }

    }
}