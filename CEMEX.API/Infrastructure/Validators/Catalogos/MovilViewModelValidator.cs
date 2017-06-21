using CEMEX.API.Models.Catalogos;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Catalogos
{
    public class MovilViewModelValidator: AbstractValidator<MovilViewModel>
    {
        public MovilViewModelValidator()
        {
            RuleFor(m => m.RegionId).Must(m => m > 0).WithMessage("El campo Región es requerido");

            RuleFor(m => m.PlazaImmexId).Must(m => m > 0).WithMessage("El campo Plaza Immex es requerido");

            RuleFor(m => m.Marca).NotEmpty().WithMessage("El campo Nombre es requerido")
                                 .Length(2, 50).WithMessage("El campo Nombre solo permite entre 2 y 50 caracteres");

            RuleFor(m => m.Modelo).NotEmpty().WithMessage("El campo Modelo es requerido")
                                  .Length(2, 50).WithMessage("El campo Modelo solo permite entre 2 y 50 caracteres");

            RuleFor(m => m.NumeroSerie).NotEmpty().WithMessage("El campo Numero Serie es requerido")
                                       .Length(2, 50).WithMessage("El campo Número Serie solo permite entre 2 y 50 caracteres");

            RuleFor(m => m.IMEI).NotEmpty().WithMessage("El campo IMEI es requerido")
                                .Length(2, 50).WithMessage("El campo IMEI solo permite entre 2 y 50 caracteres");

            RuleFor(m => m.IdEstatus).NotEmpty().WithMessage("El campo Estatus es requerido")
                                    .Must(m => m == (int)ETypeEstatusRegistro.Activo || m == (int)ETypeEstatusRegistro.Inactivo)
                                    .WithMessage("El campo Estatus es invalido");
                                
        }
    }
}