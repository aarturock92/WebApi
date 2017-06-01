using AutoMapper;
using CEMEX.API.Infrastructure.Core;
using CEMEX.API.Models.Seguridad;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Controllers.Seguridad
{
    [Authorize]
    [RoutePrefix("api/Jerarquia")]
    public class JerarquiasController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Jerarquia> _jerarquiasRepository;

        public JerarquiasController(IEntityBaseRepository<Jerarquia> jerarquiasRepository,
                                    IEntityBaseRepository<Error> errorRepository, 
                                    IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {
            _jerarquiasRepository = jerarquiasRepository;
        }

        [HttpGet]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, ()=>
            {
                HttpResponseMessage response = null;
                IEnumerable<JerarquiaViewModel> jerarquiasVM = Mapper.Map<IEnumerable<Jerarquia>,
                                                                          IEnumerable<JerarquiaViewModel>>
                                                                          (_jerarquiasRepository.GetAll().ToList());

                response = request.CreateResponse(HttpStatusCode.OK, jerarquiasVM);

                return response;
            });
        }
    }
}