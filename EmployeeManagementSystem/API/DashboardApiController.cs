using System.Web.Http;
using EmployeeManagementSystem.BLL;

namespace EmployeeManagementSystem.API
{
    public class DashboardApiController : ApiController
    {
        [HttpGet]
        [Route("api/dashboard/stats")]
        public IHttpActionResult GetStats()
        {
            DashboardBLL dashboardBLL =
                new DashboardBLL();

            int employeeCount;
            int departmentCount;

            dashboardBLL.GetDashboardStats(
                out employeeCount,
                out departmentCount);

            return Ok(new
            {
                EmployeeCount = employeeCount,
                DepartmentCount = departmentCount
            });
        }
    }
}