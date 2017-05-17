using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class PlazaOxxoExtensions
    {
        public static IEnumerable<PlazaOxxo> GetPlazasOxxo(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo)
        {
            return repositoryPlazaOxxo.GetAll().ToList();
        }

        public static IEnumerable<PlazaOxxo> GetPlazasOxxoWithDistritos(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo)
        {
            return repositoryPlazaOxxo.GetAll().Include(p => p.Distritos).ToList();
        }
    }
}
