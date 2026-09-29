using System;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Pages.Departments
{
    public partial class EditDepartment : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDepartment();
            }
        }

        private void LoadDepartment()
        {
            int departmentId =
                Convert.ToInt32(Request.QueryString["id"]);

            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            Department department =
                departmentBLL.GetDepartmentById(departmentId);

            if (department != null)
            {
                hfDepartmentId.Value =
                    department.DepartmentId.ToString();

                txtDepartmentName.Text =
                    department.DepartmentName;

                txtDescription.Text =
                    department.Description;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Department department = new Department();

            department.DepartmentId =
                Convert.ToInt32(hfDepartmentId.Value);

            department.DepartmentName =
                txtDepartmentName.Text.Trim();

            department.Description =
                txtDescription.Text.Trim();

            try
            {
                DepartmentBLL departmentBLL =
                    new DepartmentBLL();

                departmentBLL.UpdateDepartment(department);

                lblMessage.Text =
                    "Department updated successfully.";
            }
            catch (Exception)
            {
                lblMessage.Text =
                    "An error occurred while updating the department.";
            }
        }
    }
}