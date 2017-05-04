using CEMEX.API.Models.Seguridad;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Seguridad
{
    public class CredentialViewModelValidator: AbstractValidator<CredentialViewModel>
    {
        public CredentialViewModelValidator()
        {
            RuleFor(c => c.EmailAddress).NotEmpty().WithMessage("El campo EmailAddress es requerido")
                                        .EmailAddress().WithMessage("El campo EmailAddress es invalido");

            RuleFor(c => c.Password).NotEmpty().WithMessage("El campo Password es requerido")
                                     .Length(1, 20).WithMessage("El campo Password debe tener entre 1 y 20 caracteres");
        }
    }
}