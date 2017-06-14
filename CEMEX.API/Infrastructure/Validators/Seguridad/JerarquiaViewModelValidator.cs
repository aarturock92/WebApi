using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Seguridad
{
    public class JerarquiaViewModelValidator:AbstractValidator<JerarquiaViewModel>
    {
        public JerarquiaViewModelValidator()
        {
            RuleFor(j => j.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido")
                                  .Length(1, 100).WithMessage("El campo Nombre solo permite entre 1 y 100 caracteres");

            RuleFor(j => j.Descripcion).NotEmpty().WithMessage("El campo Descripcion es requerido")
                                  .Length(1, 200).WithMessage("El campo Descripcion solo permite entre 1 y 200 caracteres");

            RuleFor(j => j.NivelJerarquia).NotEmpty().WithMessage("El campo Nivel Jerarquia es requerido");

            RuleFor(j => j.Estatus).NotEmpty().WithMessage("El campo Estatus es requerido")
                                   .Must(j => j == (int)ETypeEstatusRegistro.Activo || j == (int)ETypeEstatusRegistro.Inactivo || j == (int)ETypeEstatusRegistro.Eliminado)
                                   .WithMessage("El campo Estatus es invalido");
                                 
        }
    }
}