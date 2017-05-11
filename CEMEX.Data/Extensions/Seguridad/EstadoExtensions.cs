using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Seguridad
{
    public static class EstadoExtensions
    {
        public static Estado GetSingleEstadoWithMunicipiosById(this IEntityBaseRepository<Estado> repositoryEstado,int id)
        {
            return repositoryEstado.GetAll().Include(estado => estado.Municipios).FirstOrDefault(e => e.ID == id);
        }
        
        public static Estado GetSingleEstadoById(this IEntityBaseRepository<Estado> repositoryEstado, int id)
        {
            return repositoryEstado.GetAll().Where(x => x.ID == id).FirstOrDefault();
        }

        public static IEnumerable<Estado> GetAllEstados(this IEntityBaseRepository<Estado> repositoryEstado)
        {
            return repositoryEstado.GetAll().ToList();
        }

        public static IEnumerable<Estado> GetAllEstadosWithMunicipios(this IEntityBaseRepository<Estado> repositoryEstado)
        {
            return repositoryEstado.GetAll().Include(e => e.Municipios).ToList();
        }
    }
}
