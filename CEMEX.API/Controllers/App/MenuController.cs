using CEMEX.API.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;

namespace CEMEX.API.Controllers.App
{
    public class MenuController : ApiControllerBase
    {
        public MenuController(IEntityBaseRepository<Error> errorRepository, 
                              IUnitOfWork unitOfWork) 
            : base(errorRepository, unitOfWork)
        {

        }
    }
}