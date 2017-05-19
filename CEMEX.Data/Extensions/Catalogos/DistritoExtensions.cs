using CEMEX.Data.Repositories;
using CEMEX.Entidades;
using CEMEX.Entidades.Catalogos;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CEMEX.Data.Extensions.Catalogos
{
    public static class DistritoExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositoryDistrito"></param>
        /// <param name="estatusRegistro"></param>
        /// <returns></returns>
        public static IEnumerable<Distrito> GetDistritos(this IEntityBaseRepository<Distrito> repositoryDistrito, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Distrito> distritos = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    distritos = repositoryDistrito.GetAll()
                                                 .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    distritos = repositoryDistrito.GetAll()
                                                 .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    distritos = repositoryDistrito.GetAll()
                                                  .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                                  .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    distritos = repositoryDistrito.GetAll()
                                                  .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                                              d.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                  .ToList();
                    break;
                default:
                    distritos = repositoryDistrito.GetAll()
                                                  .ToList();
                    break;
            }

            return distritos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repositoryDistrito"></param>
        /// <param name="estatusRegistro"></param>
        /// <returns></returns>
        public static IEnumerable<Distrito> GetDistritosWithTiendas(this IEntityBaseRepository<Distrito> repositoryDistrito, ETypeEstatusRegistro estatusRegistro)
        {
            IEnumerable<Distrito> distritos = null;

            switch (estatusRegistro)
            {
                case ETypeEstatusRegistro.Activo:
                    distritos = repositoryDistrito.GetAll()
                                                 .Include(d => d.Tiendas)
                                                 .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Activo)
                                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Inactivo:
                    distritos = repositoryDistrito.GetAll()
                                                 .Include(d => d.Tiendas)
                                                 .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                 .ToList();
                    break;
                case ETypeEstatusRegistro.Eliminado:
                    distritos = repositoryDistrito.GetAll()
                                                  .Include(d => d.Tiendas)
                                                  .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Eliminado)
                                                  .ToList();
                    break;
                case ETypeEstatusRegistro.Todos:
                    distritos = repositoryDistrito.GetAll()
                                                  .Include(d => d.Tiendas)
                                                  .Where(d => d.Estatus == (int)ETypeEstatusRegistro.Activo ||
                                                              d.Estatus == (int)ETypeEstatusRegistro.Inactivo)
                                                  .ToList();
                    break;
                default:
                    distritos = repositoryDistrito.GetAll()
                                                  .Include(d => d.Tiendas)
                                                  .ToList();
                    break;
            }

            return distritos;
        }
    }
}
