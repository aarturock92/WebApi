using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class MovilExtensions
    {
        public static Movil GetMovilPorIMEI(this IEntityBaseRepository<Movil> movilRepository, string IMEI)
        {
            return movilRepository.FindBy(m => string.Equals(m.IMEI.ToUpper(), IMEI.ToUpper()))
                                  .FirstOrDefault();
        }

        public static Movil GetMovilPorNumeroTelefono(this IEntityBaseRepository<Movil> movilRepository, string numeroTelefono)
        {
            return movilRepository.FindBy(m => string.Equals(m.NumeroTelefono.ToUpper(), numeroTelefono.ToUpper()))
                                  .FirstOrDefault();
        }

        public static Movil GetMovilPorNumeroSerie(this IEntityBaseRepository<Movil> movilRepository, string numeroSerie)
        {
            return movilRepository.FindBy(m => string.Equals(m.NumeroSerie.ToUpper(), numeroSerie.ToUpper().Trim()))
                                  .FirstOrDefault();
        }

        public static IEnumerable<Movil> GetMovilesByStatusRegistro(this IEntityBaseRepository<Movil> movilRepository, 
                                                                    ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Movil> moviles = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    moviles = movilRepository.GetAll()
                                             .Where(m => m.IdEstatus == (int)ETypeEstatusRegistro.Activo)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    moviles = movilRepository.GetAll()
                                             .Where(m => m.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    moviles = movilRepository.GetAll()
                                             .Where(m => m.IdEstatus == (int)ETypeEstatusRegistro.Eliminado)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    moviles = movilRepository.GetAll()
                                             .Where(m => m.IdEstatus == (int)ETypeEstatusRegistro.Activo ||
                                                         m.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                             .ToList();
                    break;
                default:
                    moviles = movilRepository.GetAll()
                                             .ToList();
                    break;
            }

            return moviles;
        }

        public static IEnumerable<Movil> GetMovilesByPlazaImmex(this IEntityBaseRepository<Movil> movilRepository, int idPlazaImmex, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Movil> moviles = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    moviles = movilRepository
                                .GetAll()
                                .Where(m => m.PlazaImmexId == idPlazaImmex && m.IdEstatus == (int)ETypeEstatusRegistro.Activo)
                                .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    moviles = movilRepository
                                 .GetAll()
                                 .Where(m => m.PlazaImmexId == idPlazaImmex && m.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    moviles = movilRepository
                                 .GetAll()
                                 .Where(m => m.PlazaImmexId == idPlazaImmex && m.IdEstatus == (int)ETypeEstatusRegistro.Eliminado)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    moviles = movilRepository
                                  .GetAll()
                                  .Where(m => m.PlazaImmexId == idPlazaImmex && (m.IdEstatus == (int)ETypeEstatusRegistro.Inactivo || m.IdEstatus == (int)ETypeEstatusRegistro.Activo))
                                  .ToList();
                    break;
                default:
                    moviles = movilRepository
                                 .GetAll()
                                 .ToList();
                    break;
            }

            return moviles;
        }

        public static Movil GetMovilPorId(this IEntityBaseRepository<Movil> movilRepository, int id)
        {
            return movilRepository.GetAll().Where(m => m.IdEstatus == (int)ETypeEstatusRegistro.Activo || m.IdEstatus == (int)ETypeEstatusRegistro.Inactivo).FirstOrDefault();
        }
    }
}
