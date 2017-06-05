using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class RegionExtensions
    {
        public static IEnumerable<Region> GetRegionesWithPlazaImmex(this IEntityBaseRepository<Region> repositoryRegion, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Region> regiones = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Activo)
                                               .Include(r => r.PlazasImmex)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                               .Include(r => r.PlazasImmex)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                               .Include(r => r.PlazasImmex)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Activo || 
                                                           r.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                               .Include(r => r.PlazasImmex)
                                               .ToList();
                    break;
                default:
                    regiones = repositoryRegion.GetAll()
                                               .Include(r => r.PlazasImmex)
                                               .ToList();
                    break;
            }

            return regiones;
        }

        public static IEnumerable<Region> GetRegiones(this IEntityBaseRepository<Region> repositoryRegion, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Region> regiones = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Activo)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                               .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    regiones = repositoryRegion.GetAll()
                                               .Where(r => r.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                                           r.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                               .ToList();
                    break;
                default:
                    regiones = repositoryRegion.GetAll()
                                               .ToList();
                    break;
            }            

            return regiones;            
        }

        public static Region GetRegionById(this IEntityBaseRepository<Region> repositoryRegion, int idRegion)
        {
            return repositoryRegion.GetAll().Where(r => r.ID == idRegion).FirstOrDefault();
        }

        public static Region GetRegionByIdWithPlazasImmex(this IEntityBaseRepository<Region> repositoryRegion, int idRegion)
        {
            return repositoryRegion.GetAll().Include(r => r.PlazasImmex).Where(r => r.ID == idRegion).FirstOrDefault();
        }
    }
}
