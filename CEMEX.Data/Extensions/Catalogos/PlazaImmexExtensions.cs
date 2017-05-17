using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class PlazaImmexExtensions
    {
        public static IEnumerable<PlazaImmex> GetPlazasImmex(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex)
        {
            return repositoryPlazaImmex.GetAll().ToList();
        }

        public static IEnumerable<PlazaImmex> GetPlazasImmexWithPlazaOxxo(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex)
        {
            return repositoryPlazaImmex.GetAll().Include(p => p.PlazasOxxo).ToList();
        }

        public static PlazaImmex GetPlazaImmexById(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex, int id)
        {
            return repositoryPlazaImmex.GetAll().FirstOrDefault(p => p.ID == id);
        }

        public static PlazaImmex GetPlazaImmexByIdWithPlazaOxxo(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex, int id)
        {
            return repositoryPlazaImmex.GetAll().Include(p => p.PlazasOxxo).FirstOrDefault(p => p.ID == id);
        }
    }
}
