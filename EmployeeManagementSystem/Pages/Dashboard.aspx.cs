using System;
using EmployeeManagementSystem.BLL;

namespace EmployeeManagementSystem.Pages
{
    public partial class Dashboard : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDashboardStats();
            }
        }

        private void LoadDashboardStats()
        {
            DashboardBLL dashboardBLL = new DashboardBLL();

            int employeeCount;
            int departmentCount;

            dashboardBLL.GetDashboardStats(
                out employeeCount,
                out departmentCount);

            lblEmployeeCount.Text =
                employeeCount.ToString();

            lblDepartmentCount.Text =
                departmentCount.ToString();
        }
    }
}