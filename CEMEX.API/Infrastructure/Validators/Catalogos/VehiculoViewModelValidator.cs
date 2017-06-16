using CEMEX.API.Models.Catalogos;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Catalogos
{
    public class VehiculoViewModelValidator: AbstractValidator<VehiculoViewModel>
    {
        public VehiculoViewModelValidator()
        {
            RuleFor(v => v.PlazaImmexId).Must(x => x > 0).WithMessage("Seleccione una Plaza");

            RuleFor(v => v.Marca).NotEmpty().WithMessage("El campo Marca es requerido");
            RuleFor(v => v.Marca).Length(2, 50).WithMessage("El campo Marca solo permite entre 2 y 50 caracteres");

            RuleFor(v => v.Modelo).NotEmpty().WithMessage("El campo Modelo es requerido");
            RuleFor(v => v.Modelo).Length(2, 50).WithMessage("El campo Modelo solo permite entre 2 y 50 caracteres");

            RuleFor(v => v.NumeroPlaca).NotEmpty().WithMessage("El campo Número Placa es requerido");
            RuleFor(v => v.NumeroPlaca).Length(7).WithMessage("El campo Número de Placa debe tener  caracteres");

            RuleFor(v => v.NumeroEconomico).NotEmpty().WithMessage("El campo Número Economico es requerido");
            RuleFor(v => v.NumeroEconomico).Length(1, 30).WithMessage("El campo Número Economico solo permite entre 1 y 30 caracteres");

            RuleFor(v => v.IdEstatus).Must(e => e >= (int)ETypeEstatusRegistro.Activo && e <= (int)ETypeEstatusRegistro.Inactivo)
                                     .WithMessage("El campo Estatus es invalido");
                   
        }
    }
}