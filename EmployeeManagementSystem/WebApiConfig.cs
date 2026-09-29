using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeManagementSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                "http://localhost:5173",
                "*",
                "*");

            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();
        }
    }
}