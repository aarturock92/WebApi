using CEMEX.API.Models.Catalogos;
using CEMEX.Data.Extensions.Catalogos;
using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System;
using System.Collections.Generic;

namespace CEMEX.API.Infrastructure.Extensions
{
    public static class MovilExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="movilVM"></param>
        /// <param name="validacionesEntidad"></param>
        /// <returns></returns>
        public static bool ValidarCreacionMovil(this IEntityBaseRepository<Movil> movilRepository, MovilViewModel movilVM, out List<string> validacionesEntidad)
        {
            bool esValido = true;
            validacionesEntidad = new List<string>();

            //Valida que no exista un movil con el mismo IMEI
            if (movilRepository.GetMovilPorIMEI(movilVM.IMEI.Trim()) != null)
            {
                validacionesEntidad.Add("Existe un movil con el mismo IMEI");
                esValido = false;
            }

            //Valida que no exista un movil con el mismo Número de Serie.
            if (movilRepository.GetMovilPorNumeroSerie(movilVM.NumeroSerie.Trim()) != null)
            {
                validacionesEntidad.Add("Existe un movil con el mismo Número de Serie");
                esValido = false;
            }

            //Valida que no exista un movil con el mismo Numero de telefono.
            if (movilRepository.GetMovilPorNumeroTelefono(movilVM.NumeroTelefono.Trim()) != null)
            {
                validacionesEntidad.Add("Existe un movil con el mismo Número de Telefono");
                esValido = false;
            }

            return esValido;
        }

        /// <summary>
        /// Realiza el mapeo de campos para una entidad Movil
        /// </summary>
        /// <param name="movil">Modelo que se ingresa a base de datos</param>
        /// <param name="movilVM">Modelo que recibe el servicio</param>
        public static void CrearMovil(this Movil movil, MovilViewModel movilVM)
        {
            movil.PlazaImmexId = movilVM.PlazaImmexId;
            movil.RegionId = movilVM.RegionId;
            movil.Marca = movilVM.Marca.Trim();
            movil.Modelo = movilVM.Modelo.Trim();
            movil.NumeroTelefono = movilVM.NumeroTelefono.Trim();
            movil.NumeroSerie = movilVM.NumeroSerie.Trim();
            movil.IMEI = movilVM.IMEI.Trim();
            movil.IdEstatus = movilVM.IdEstatus;
            movil.FechaAlta = DateTime.UtcNow;
            movil.FechaModifico = DateTime.Now;
        }


        public static void UpdateMovil(this Movil movil, MovilViewModel movilVM)
        {
            movil.RegionId = movilVM.RegionId;
            movil.PlazaImmexId = movilVM.PlazaImmexId;
            movil.IMEI = movilVM.IMEI.Trim();
            movil.Marca = movilVM.Marca.Trim();
            movil.Modelo = movilVM.Modelo.Trim();
            movil.NumeroSerie = movilVM.NumeroSerie.Trim();
            movil.NumeroTelefono = movilVM.NumeroTelefono.Trim();
            movil.FechaModifico = DateTime.UtcNow;
            movil.IdEstatus = movilVM.IdEstatus;
        }

        /// <summary>
        /// Realiza un eliminado lògico del una entidad Movil
        /// </summary>
        /// <param name="movil">Objeto a eliminar</param>
        public static void EliminarMovil(this Movil movil)
        {
            movil.IdEstatus = (int)ETypeEstatusRegistro.Eliminado;
        }
    }
}