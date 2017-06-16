using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class VehiculoExtensions
    {
        public static IEnumerable<Vehiculo> GetVehiculosByEstatusRegistro(this IEntityBaseRepository<Vehiculo> repositoryVehiculo, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Vehiculo> Vehiculos = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    Vehiculos = repositoryVehiculo.GetAll()
                                                  .Where(v => v.IdEstatus == (int)ETypeEstatusRegistro.Activo)
                                                  .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    Vehiculos = repositoryVehiculo.GetAll()
                              .Where(v => v.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                              .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    Vehiculos = repositoryVehiculo.GetAll()
                                                  .Where(v => v.IdEstatus == (int)ETypeEstatusRegistro.Eliminado)
                                                  .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    Vehiculos = repositoryVehiculo.GetAll()
                                                  .Where(v => v.IdEstatus == (int)ETypeEstatusRegistro.Activo ||
                                                              v.IdEstatus == (int)ETypeEstatusRegistro.Inactivo)
                                                  .ToList();
                    break;
                default:
                    Vehiculos = repositoryVehiculo.GetAll()
                                                  .ToList();
                    break;
            }

            return Vehiculos;
        }

        public static Vehiculo GetVehiculoDetailsById(this IEntityBaseRepository<Vehiculo> repositoryVehiculo, int id)
        {
            return repositoryVehiculo.GetAll()
                                     .Where(v => v.ID == id && v.IdEstatus != (int)ETypeEstatusRegistro.Eliminado)
                                     .FirstOrDefault();
        }
    }
}
