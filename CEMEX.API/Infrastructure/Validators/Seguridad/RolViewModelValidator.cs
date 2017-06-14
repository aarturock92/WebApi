using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Seguridad
{
    public class RolViewModelValidator:AbstractValidator<RolViewModel>
    {
        public RolViewModelValidator()
        {
            RuleFor(r => r.IdJerarquia).NotEmpty().WithMessage("El campo Jerarquía es requerido");

            RuleFor(r => r.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido")
                                  .Length(1, 100).WithMessage("El campo Nombre solo permite entre 1 y 100 caracteres");

            RuleFor(r => r.Descripcion).NotEmpty().WithMessage("El campo Descripción es requerido")
                                       .Length(1,200).WithMessage("El campo Descripción permite entre 1 y 200 caracteres");

            RuleFor(r => r.AsignacionMultiple).NotEmpty().WithMessage("El campo Asignación Multiple es requerido");

            RuleFor(r => r.Estatus).NotEmpty().WithMessage("El campo Estatus es requerido")
                                   .Must(e => e == (int)ETypeEstatusRegistro.Activo ||
                                              e == (int)ETypeEstatusRegistro.Eliminado ||
                                              e == (int)ETypeEstatusRegistro.Eliminado)
                                   .WithMessage("El campo Estatus es invalido");


        }
    }
}