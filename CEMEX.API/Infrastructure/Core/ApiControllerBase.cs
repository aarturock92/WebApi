using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CEMEX.API.Infrastructure.Core
{
    public class ApiControllerBase:ApiController
    {
        protected readonly IEntityBaseRepository<Error> _errorRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ApiControllerBase(IEntityBaseRepository<Error> errorRepository,
                                 IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }

        public HttpResponseMessage CreateHttpResponse(HttpRequestMessage request,
                                                         Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);

            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {                    
                    Message = ex.InnerException.Message,
                    StackTrace = ex.StackTrace,
                    FechaAlta = DateTime.Now
                };

                _errorRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch 
            {  }
        }
    }
}