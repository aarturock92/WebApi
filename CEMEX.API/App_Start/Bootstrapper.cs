using CEMEX.API.Mappings;
using System.Web.Http;

namespace CEMEX.API.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);

            AutoMapperConfiguration.Configure();
        }
    }
}