using CEMEX.Data.Repositories;
using CEMEX.Entidades;
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
        public static IEnumerable<PlazaImmex> GetPlazasImmex(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<PlazaImmex> plazasImmex = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                      .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                      .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                                      .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                  .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                              p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                  .ToList();
                    break;
                default:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .ToList();
                    break;
            }

            return plazasImmex;           
        }

        public static IEnumerable<PlazaImmex> GetPlazasImmexWithPlazaOxxo(this IEntityBaseRepository<PlazaImmex> repositoryPlazaImmex, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<PlazaImmex> plazasImmex = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                      .Include(p => p.PlazasOxxo)
                                                      .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                     .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                     .Include(p => p.PlazasOxxo)
                                                     .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                         .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                                         .Include(p => p.PlazasOxxo)
                                                         .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .Where(p => p.Estatus == (int)ETypeEstatusRegistro.Inactivo ||
                                                                  p.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                      .Include(p => p.PlazasOxxo)
                                                      .ToList();
                    break;
                default:
                    plazasImmex = repositoryPlazaImmex.GetAll()
                                                      .ToList();
                    break;
            }

            return plazasImmex;
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
