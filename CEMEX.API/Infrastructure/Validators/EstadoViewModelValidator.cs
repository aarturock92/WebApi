using CEMEX.API.Models.Catalogos;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators
{
    public class EstadoViewModelValidator:AbstractValidator<EstadoViewModel>
    {
        public EstadoViewModelValidator()
        {
            RuleFor(estado => estado.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido")
                                            .Length(1, 100).WithMessage("El campo Nombre solo permite entre 1 y 100 caracteres");

            RuleFor(estado => estado.Abreviatura).NotEmpty().WithMessage("El campo Abreviatura no debe estar vacío")
                                                 .Length(1, 50).WithMessage("El campo Abreviatura solo permite entre 1 y 50 caracteres");

            RuleFor(estado => estado.Estatus).NotEmpty().WithMessage("El campo Estatus es requerido")
                                             .Must(x => x == (int)EstatusRegistro.Activo || x == (int)EstatusRegistro.Inactivo || x == (int)EstatusRegistro.Eliminado)
                                             .WithMessage("El campo Estatus es inválido");

        }
    }
}