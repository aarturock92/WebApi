using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Seguridad;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Seguridad
{
    [Authorize]
    [RoutePrefix("api/Modulo")]
    public class ModulosController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Modulo> _modulosRepository;

        public ModulosController(IEntityBaseRepository<Modulo> modulosRepository,
                                 IEntityBaseRepository<Error> errorRepository, 
                                 IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _modulosRepository = modulosRepository;
        }

        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<ModuloViewModel> modulosVM = Mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloViewModel>>
                                                         (_modulosRepository
                                                         .GetAll()
                                                         .OrderBy(m => m.ID)
                                                         .ToList());


                IEnumerable<ModuloViewModel> subModulos = modulosVM
                                                          .Where(m => m.IdRegistroModulo != 0)
                                                          .ToList();


                modulosVM.Where(m => m.IdRegistroModulo == 0).ToList().ForEach((modulo) =>
                {
                   modulo.SubModulos = subModulos.Where(s => s.IdRegistroModulo == modulo.ID).ToList();

                });

                response = request.CreateResponse(HttpStatusCode.OK, modulosVM);

                return response;
            });
        }


    }
}