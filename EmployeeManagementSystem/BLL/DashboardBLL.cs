using EmployeeManagementSystem.DAL;

namespace EmployeeManagementSystem.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL dashboardDAL =
            new DashboardDAL();

        public void GetDashboardStats(
            out int employeeCount,
            out int departmentCount)
        {
            dashboardDAL.GetDashboardStats(
                out employeeCount,
                out departmentCount);
        }
    }
}