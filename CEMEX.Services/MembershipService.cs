using System;
using System.Collections.Generic;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using CEMEX.Services.Abstract;
using CEMEX.Data.Extensions.Seguridad;
using System.Linq;
using CEMEX.Services.Utilities;
using System.Security.Principal;

namespace CEMEX.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IEntityBaseRepository<Usuario> _usuarioRepositorio;
        private readonly IEntityBaseRepository<Rol> _rolRepositorio;
        private readonly IEntityBaseRepository<UsuarioRol> _usuarioRolRepositorio;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;

        public MembershipService(IEntityBaseRepository<Usuario> usuarioRepositorio,
                                 IEntityBaseRepository<Rol> rolRepositorio,
                                 IEntityBaseRepository<UsuarioRol> usuarioRolRepositorio,
                                 IEncryptionService encryptionService,
                                 IUnitOfWork unitOfWork)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _rolRepositorio = rolRepositorio;
            _usuarioRolRepositorio = usuarioRolRepositorio;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        public MembershipContext ValidarUsuario(string username, string contraseña)
        {
            var membershipCtx = new MembershipContext();

            var usuario = _usuarioRepositorio.GetSingleByUserName(username);

            if (usuario != null && esUsuarioValido(usuario, contraseña))
            {
                var usuarioRoles = GetUsuarioRoles(usuario.NombreUsuario);
                membershipCtx.usuario = usuario;

                var identity = new GenericIdentity(usuario.NombreUsuario);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    usuarioRoles.Select(x => x.Nombre).ToArray());
            }

            return membershipCtx;
        }

        public Usuario CrearUsuario(string username, string email, string password, int[] roles, int idUsuarioAlta)
        {
            var existeUsuario = _usuarioRepositorio.GetSingleByUserName(username);

            if (existeUsuario != null)
            {
                throw new Exception("Ya hay otra persona que tiene este usuario.");
            }

            var contraseñaSalt = _encryptionService.CrearSalt();

            var usuario = new Usuario()
            {
                Email = email.Trim(),
                NombreUsuario = username.Trim(),
                HashedContraseña = _encryptionService.EncryptionPassword(password, contraseñaSalt),
                Salt = contraseñaSalt,
                FechaAlta = DateTime.Now,
                IdUsuarioAlta = idUsuarioAlta
            };

            _usuarioRepositorio.Add(usuario);

            _unitOfWork.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var rol in roles)
                {
                    AgregarRolaUsuario(usuario, rol);
                }
            }

            _unitOfWork.Commit();


            return usuario;
        }

        public Usuario GetUsuario(int userId)
        {
            return _usuarioRepositorio.GetSingle(userId);
        }

        public List<Rol> GetUsuarioRoles(string username)
        {
            List<Rol> _resultado = new List<Rol>();

            var existeUsuario = _usuarioRepositorio.GetSingleByUserName(username.Trim());

            if (existeUsuario != null)
            {
                foreach (var usuarioRol in existeUsuario.UsuarioRoles)
                {
                    _resultado.Add(usuarioRol.Rol);
                }
            }

            return _resultado.Distinct().ToList();
        }

        private void AgregarRolaUsuario(Usuario usuario, int rolId)
        {
            var rol = _rolRepositorio.GetSingle(rolId);
            if (rol == null)
                throw new ApplicationException("El rol no existe");

            _usuarioRolRepositorio.Add(new UsuarioRol()
            {
                RolId = rol.ID,
                UsuarioId = usuario.ID
            });
        }

        private bool esContraseñaValida(Usuario usuario, string contraseña)
        {
            return string.Equals(_encryptionService.EncryptionPassword(contraseña, usuario.Salt),
                                                                       usuario.HashedContraseña);
        }

        private bool esUsuarioValido(Usuario usuario, string password)
        {
            if (esContraseñaValida(usuario, password))
            {
                return !true;
            }

            return false;
        }
    }
}
