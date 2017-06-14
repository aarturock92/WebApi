using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class PlazaOxxoExtensions
    {
        public static IEnumerable<PlazaOxxo> GetPlazasOxxo(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<PlazaOxxo> plazasOxxo = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    plazasOxxo = repositoryPlazaOxxo
                                 .GetAll()
                                 .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    plazasOxxo = repositoryPlazaOxxo
                                 .GetAll()
                                 .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                            p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                .ToList();
                    break;
                default:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .ToList();
                    break;
            }

            return plazasOxxo;
        }

        public static IEnumerable<PlazaOxxo> GetPlazasOxxoWithDistritos(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<PlazaOxxo> plazasOxxo = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    plazasOxxo = repositoryPlazaOxxo
                                 .GetAll()
                                 .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                 .Include(p => p.Distritos)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                .Include(p => p.Distritos)
                                .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    plazasOxxo = repositoryPlazaOxxo
                                 .GetAll()
                                 .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                 .Include(p => p.Distritos)
                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo || 
                                            p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                .Include(p => p.Distritos)
                                .ToList();
                    break;
                default:
                    plazasOxxo = repositoryPlazaOxxo
                                .GetAll()
                                .Include(p => p.Distritos)
                                .ToList();
                    break;
            }

            return plazasOxxo;
        }

        public static PlazaOxxo GetPlazaOxxoById(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo, int id)
        {
            return repositoryPlazaOxxo.GetAll().Where(p => p.ID == id && p.Estatus != (int)ETypeEstatusRegistro.Eliminado).FirstOrDefault();
        }

        public static PlazaOxxo GetPlazaOxxoByIdWithDistritos(this IEntityBaseRepository<PlazaOxxo> repositoryPlazaOxxo, int id)
        {
            return repositoryPlazaOxxo.GetAll().Include(p => p.Distritos).Where(p => p.ID == id && p.Estatus != (int)ETypeEstatusRegistro.Eliminado).FirstOrDefault();
        }
    }
}
