using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades;
using FluentValidation;

namespace CEMEX.API.Infrastructure.Validators.Seguridad
{
    public class UsuarioViewModelValidator:AbstractValidator<UsuarioViewModel>
    {
        public UsuarioViewModelValidator()
        {
            RuleFor(u => u.IdPerfilUsuario)
                        .NotEmpty()
                        .WithMessage("El campo Perfil Usuario es requerido.");

            RuleFor(u => u.NumeroEmpleado).NotEmpty().WithMessage("El campo Numero Empleado es requerdio");

            RuleFor(u => u.Nombre).NotEmpty().WithMessage("El campo Nombre es requerido")
                                  .Length(2, 50).WithMessage("El campo Nombre solo permite entre 2 y 50 caracteres.");

            RuleFor(u => u.PrimerApellido).NotEmpty().WithMessage("El campo Primer Apellido es requerido")
                                  .Length(2, 50).WithMessage("El campo Primer Apellido permite entre 2 y 50 caracteres.");

            RuleFor(u => u.SegundoApellido).NotEmpty().WithMessage("El campo Segundo Apellido es requerido.")
                                   .Length(2, 50).WithMessage("El campo Segundo Apellido permite entre 2 y 50 caracteres.");

            RuleFor(u => u.Sexo).Must(x => x == (int)ETypeEstatusRegistro.Activo || x == (int)ETypeEstatusRegistro.Inactivo)
                                .WithMessage("El campo Sexo es invalido.");

            RuleFor(u => u.Telefono).NotEmpty().WithMessage("El campo Telefono es requerido.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("El campo Email es requerido")
                                .EmailAddress().WithMessage("El campo Email es invalido");

            RuleFor(u => u.NombreUsuario).NotEmpty().WithMessage("El campo Usuario Nombre es requerido.")
                                  .Length(5, 50).WithMessage("El campo Usuario solo permite entre 5 y 50 caracteres.");

            RuleFor(u => u.Contrasena).NotEmpty().WithMessage("El campo Contraseña es requerido.")
                                      .Length(5, 50).WithMessage("El campo Contraseña solo permite entre 5 y 50 caracteres.");

            RuleFor(u => u.Calle).NotEmpty().WithMessage("El campo Calle es requerido")
                                    .Length(2,50).WithMessage("El campo Calle permite entre 2 y 50 caracteres");

            RuleFor(u => u.NumeroExterior).NotEmpty().WithMessage("El campo Numero Exterior es requerido")
                                     .Length(1, 5).WithMessage("El campo Numero Exterior permite entre 1 y 5 caracteres");

            RuleFor(u => u.Colonia).NotEmpty().WithMessage("El campo Colonia es requerido")
                                    .Length(2, 50).WithMessage("El campo Colonia permite entre 2 y 50 caracteres");

            RuleFor(u => u.CodigoPostal).NotEmpty().WithMessage("El campo Codigo Postal es requerido")
                                    .Length(5).WithMessage("El campo Codigo Postal permite solo 5 caracteres");

            RuleFor(u => u.IdPais).NotEmpty().WithMessage("El campo Pais es requerido");

            RuleFor(u => u.IdEstado).NotEmpty().WithMessage("El campo Estado es requerido");

            RuleFor(u => u.IdMunicipio).NotEmpty().WithMessage("El campo Municipio es requerido");

           
        }
    }
}