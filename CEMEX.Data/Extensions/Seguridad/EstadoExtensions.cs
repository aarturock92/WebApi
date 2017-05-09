using CEMEX.Data.Repositories;
using CEMEX.Entidades.Catalogos;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Seguridad
{
    public static class EstadoExtensions
    {
        public static Estado GetSingleEstadoById(this IEntityBaseRepository<Estado> repositoryEstado,int id)
        {
            return repositoryEstado.GetAll().Include(e => e.Municipios).Where(x => x.ID == id).FirstOrDefault();
        } 

        //public static Estado GetSingleEstadoWithMunicipiosById()
        //{

        //}
    }
}
