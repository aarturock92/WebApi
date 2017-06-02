using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class MovilExtensions
    {
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
    }
}
