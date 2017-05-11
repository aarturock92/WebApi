using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Catalogos;
using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System;

namespace CEMEX.API.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="estadoVM"></param>
        public static void UpdateEstado(this Estado estado, EstadoViewModel estadoVM )
        {
            estado.Nombre = estadoVM.Nombre.Trim();
            estado.Abreviatura = estadoVM.Abreviatura.Trim();
            estado.Estatus = estadoVM.Estatus;           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="municipio"></param>
        /// <param name="municipioVM"></param>
        public static void UpdateMunicipio(this Municipio municipio, MunicipioViewModel municipioVM)
        {
            municipio.Nombre = municipioVM.Nombre.Trim();
            //municipio.Estado_ID = municipioVM.IdEstado;
            municipio.Estatus = municipioVM.Estatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="usuarioVM"></param>
        public static void UpdateUsuario(this Usuario usuario, UsuarioViewModel usuarioVM)
        {
            usuario.NombreUsuario = usuarioVM.NombreUsuario.Trim();
            usuario.IdRolUsuario = usuarioVM.IdRolUsuario;
            usuario.Salt = EncryptionService.CrearSalt();
            usuario.HashedContraseña = EncryptionService.EncriptarPassowrd(usuarioVM.Contrasena.Trim(), usuario.Salt);
            usuario.Nombre = usuarioVM.Nombre.Trim();
            usuario.PrimerApellido = usuarioVM.PrimerApellido.Trim();
            usuario.SegundoApellido = usuarioVM.SegundoApellido.Trim();
            usuario.Sexo = usuarioVM.Sexo;
            usuario.Calle = usuarioVM.Calle.Trim();
            usuario.NumeroExterior = usuarioVM.NumeroExterior.Trim();
            usuario.NumeroInterior = usuarioVM.NumeroInterior.Trim();
            usuario.Colonia = usuarioVM.Colonia.Trim();
            usuario.CodigoPostal = usuarioVM.CodigoPostal.Trim();
            usuario.IdPais = usuarioVM.IdPais;
            usuario.IdEstado = usuarioVM.IdEstado;
            usuario.IdMunicipio = usuarioVM.IdMunicipio;
            usuario.Email = usuarioVM.Email.Trim();
            usuario.TelefonoOficina = usuarioVM.TelefonoOficina.Trim();
            usuario.TelefonoCasa = usuarioVM.TelefonoCasa.Trim();
            usuario.TelefonoCelular = usuarioVM.TelefonoCelular.Trim();
            usuario.Extension = usuarioVM.Extension.Trim();
            usuario.IdZona = usuarioVM.IdZona;
            usuario.IdGerencia = usuarioVM.IdGerencia;
            usuario.IdEstatus = usuarioVM.Estatus;
            usuario.FechaAlta = DateTime.UtcNow;
            usuario.FechaModifico = DateTime.UtcNow;
        }
    }
}