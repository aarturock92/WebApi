using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class RegionExtensions
    {
        public static IEnumerable<Region> GetRegionesWithPlazaImmex(this IEntityBaseRepository<Region> repositoryRegion)
        {
            return repositoryRegion.GetAll().Include(r => r.PlazasImmex).ToList();
        }

        public static IEnumerable<Region> GetRegiones(this IEntityBaseRepository<Region> repositoryRegion)
        {
            return repositoryRegion.GetAll().ToList();
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
