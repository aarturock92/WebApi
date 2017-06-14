using CEMEX.API.Models.Catalogos;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators
{
    public class MunicipioViewModelValidator: AbstractValidator<MunicipioViewModel>
    {
        public MunicipioViewModelValidator()
        {
            RuleFor(m => m.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido")
                                  .Length(1, 100).WithMessage("El campo Nombre solo permite entre 1 y 100 caracteres");

            RuleFor(m => m.Estatus).NotEmpty().WithMessage("El campo Estatus es requerido")
                                   .Must(e => e == (int)ETypeEstatusRegistro.Activo || e == (int)ETypeEstatusRegistro.Inactivo || e==(int)ETypeEstatusRegistro.Eliminado)
                                   .WithMessage("El campo Estatus es inválido");

            RuleFor(m => m.IdEstado).NotEmpty().WithMessage("El campo Estado es requerido")
                                    .NotEqual(0)
                                    .WithMessage("El campo Estado es requerido");

        }
    }
}