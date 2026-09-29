using System;
using EmployeeManagementSystem.BLL;
using System.Web.UI.WebControls;

namespace EmployeeManagementSystem.Pages.Departments
{
    public partial class Departments : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDepartments();
            }
        }

        private void LoadDepartments()
        {
            DepartmentBLL departmentBLL = new DepartmentBLL();

            gvDepartments.DataSource = departmentBLL.GetAllDepartments();
            gvDepartments.DataBind();
        }


        protected void gvDepartments_RowCommand( object sender,GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteDepartment")
            {
                int departmentId =
                    Convert.ToInt32(e.CommandArgument);

                try
                {
                    DepartmentBLL departmentBLL =
                        new DepartmentBLL();

                    bool canDelete =
                        departmentBLL.CanDeleteDepartment(departmentId);

                    if (!canDelete)
                    {
                        lblMessage.Text =
                            "This department cannot be deleted because it has active employees.";

                        return;
                    }

                    departmentBLL.DeleteDepartment(departmentId);

                    lblMessage.Text =
                        "Department deleted successfully.";

                    LoadDepartments();
                }
                catch (Exception)
                {
                    lblMessage.Text =
                        "An error occurred while deleting the department.";
                }
            }
        }

    }
}