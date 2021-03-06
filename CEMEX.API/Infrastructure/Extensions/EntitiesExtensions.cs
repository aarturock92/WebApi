﻿using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Catalogos;
using CEMEX.API.Models.Seguridad;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using CEMEX.Entidades.Seguridad;
using System;
using System.Collections.Generic;

namespace CEMEX.API.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="estadoVM"></param>
        public static void CrearEstado(this Estado estado, EstadoViewModel estadoVM)
        {
            estado.Nombre = estadoVM.Nombre.Trim();
            estado.Abreviatura = estadoVM.Abreviatura.Trim();
            estado.Estatus = estadoVM.Estatus;
            estado.FechaAlta = DateTime.Now;
            estado.FechaModifico = DateTime.Now;
        }


        public static void ModificarEstado(this Estado estado, EstadoViewModel estadoVM)
        {
            estado.Nombre = estadoVM.Nombre.Trim();
            estado.Abreviatura = estadoVM.Abreviatura.Trim();
            estado.Estatus = estadoVM.Estatus;
            estado.FechaModifico = DateTime.Now;
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
            usuario.NumeroEmpleado = usuarioVM.NumeroEmpleado.Trim();
            usuario.NombreUsuario = usuarioVM.NombreUsuario.Trim();
            usuario.PerfilUsuarioId = usuarioVM.IdPerfilUsuario;
            usuario.Salt = EncryptionService.CrearSalt();
            usuario.HashedContraseña = EncryptionService.EncriptarPassowrd(usuarioVM.Contrasena.Trim(), usuario.Salt);
            usuario.Nombre = usuarioVM.Nombre.Trim();
            usuario.PrimerApellido = usuarioVM.PrimerApellido.Trim();
            usuario.SegundoApellido = usuarioVM.SegundoApellido.Trim();
            usuario.Sexo = usuarioVM.Sexo;
            usuario.Calle = usuarioVM.Calle.Trim();
            usuario.NumeroExterior = usuarioVM.NumeroExterior.Trim();
            usuario.Colonia = usuarioVM.Colonia.Trim();
            usuario.CodigoPostal = usuarioVM.CodigoPostal.Trim();
            usuario.IdPais = usuarioVM.IdPais;
            usuario.IdEstado = usuarioVM.IdEstado;
            usuario.IdMunicipio = usuarioVM.IdMunicipio;
            usuario.Email = usuarioVM.Email.Trim();
            usuario.IdEstatus = usuarioVM.Estatus;
            usuario.Curp = usuarioVM.Curp.Trim();
            usuario.RFC = usuarioVM.RFC.Trim();
            usuario.FechaNacimiento = usuarioVM.FechaNacimiento.Trim();
            usuario.Imagen = usuarioVM.Imagen.Trim();
            usuario.FechaAlta = DateTime.UtcNow;
            usuario.FechaModifico = DateTime.UtcNow;
        }




        public static void DeleteUser(this Usuario usuario)
        {
            usuario.IdEstatus = (int)ETypeEstatusRegistro.Eliminado;
        }


       

        public static void CreateVehiculo(this Vehiculo vehiculo, VehiculoViewModel vehiculoVM)
        {
            vehiculo.PlazaImmexId = vehiculoVM.PlazaImmexId;
            vehiculo.Marca = vehiculoVM.Marca.Trim();
            vehiculo.NumeroPlaca = vehiculoVM.NumeroPlaca.Trim();
            vehiculo.NumeroEconomico = vehiculoVM.NumeroEconomico.Trim();
            vehiculo.IdEstatus = vehiculoVM.IdEstatus;
            vehiculo.FechaAlta = DateTime.Now;
            vehiculo.UniqueVehiculo = Guid.NewGuid();
            vehiculo.FechaModifico = DateTime.MinValue;
        }

        public static void UpdateVehiculo(this Vehiculo vehiculo, VehiculoViewModel vehiculoVM)
        {
            vehiculo.PlazaImmexId = vehiculoVM.PlazaImmexId;
            vehiculo.Marca = vehiculoVM.Marca.Trim();
            vehiculo.NumeroPlaca = vehiculoVM.NumeroPlaca.Trim();
            vehiculo.NumeroEconomico = vehiculoVM.NumeroEconomico.Trim();
            vehiculo.IdEstatus = vehiculoVM.IdEstatus;
            vehiculo.FechaModifico = DateTime.Now;
        }
    }
}