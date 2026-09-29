using System;
using EmployeeManagementSystem.BLL;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem.Pages.Employees
{
    public partial class Employees : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDepartments();
                LoadEmployees();

            }
        }

        private void LoadEmployees()
        {
            EmployeeBLL employeeBLL = new EmployeeBLL();

            gvEmployees.DataSource = employeeBLL.GetAllEmployees();
            gvEmployees.DataBind();
        }
        private void LoadDepartments()
        {
            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            ddlDepartment.DataSource =
                departmentBLL.GetAllDepartments();

            ddlDepartment.DataTextField =
                "DepartmentName";

            ddlDepartment.DataValueField =
                "DepartmentId";

            ddlDepartment.DataBind();

            ddlDepartment.Items.Insert(
                0,
                new ListItem("All Departments", "0"));
        }
        protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteEmployee")
            {
                int employeeId = Convert.ToInt32(e.CommandArgument);

                EmployeeBLL employeeBLL = new EmployeeBLL();

                employeeBLL.DeleteEmployee(employeeId);

                LoadEmployees();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();

            EmployeeBLL employeeBLL = new EmployeeBLL();

            int departmentId =
     Convert.ToInt32(ddlDepartment.SelectedValue);

            gvEmployees.DataSource =
                employeeBLL.SearchEmployees(
                    search,
                    departmentId);
            gvEmployees.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ddlDepartment.SelectedValue = "0";

            LoadEmployees();
        }
    }
}