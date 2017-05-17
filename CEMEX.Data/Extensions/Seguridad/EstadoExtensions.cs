using CEMEX.Data.Repositories;
using CEMEX.Entidades;
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

        public static IEnumerable<Estado> GetAllEstados(this IEntityBaseRepository<Estado> repositoryEstado,
                                                        ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Estado> estados = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    estados = repositoryEstado.GetAll()
                                              .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Activo)
                                              .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    estados = repositoryEstado.GetAll()
                                              .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                              .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    estados = repositoryEstado.GetAll()
                                              .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Inactivo ||
                                                          e.Estatus == (int)ETypeEstatusRegistro.Activo)
                                              .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    estados = repositoryEstado.GetAll()
                                              .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                              .ToList();
                    break;
                default:
                    estados = repositoryEstado.GetAll()
                                              .ToList();
                    break;
            }


            return estados;
        }

        public static IEnumerable<Estado> GetAllEstadosWithMunicipios(this IEntityBaseRepository<Estado> repositoryEstado, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Estado> estados = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    estados = repositoryEstado.GetAll()
                                              .Include(e => e.Municipios)
                                              .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Activo)
                                              .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    estados = repositoryEstado.GetAll()
                                             .Include(e => e.Municipios)
                                             .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    estados = repositoryEstado.GetAll()
                                             .Include(e => e.Municipios)
                                             .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                             .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    estados = repositoryEstado.GetAll()
                                             .Include(e => e.Municipios)
                                             .Where(e => e.Estatus == (int)ETypeEstatusRegistro.Inactivo ||
                                                         e.Estatus == (int)ETypeEstatusRegistro.Activo)
                                             .ToList();
                    break;
                default:
                    estados = repositoryEstado.GetAll()
                                              .ToList();
                    break;
            }

            return estados;
        }
    }
}
