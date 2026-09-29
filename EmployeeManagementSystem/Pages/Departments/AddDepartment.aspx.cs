using System;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Pages.Departments
{
    public partial class AddDepartment : BasePage
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Department department = new Department();

            department.DepartmentName =
                txtDepartmentName.Text.Trim();

            department.Description =
                txtDescription.Text.Trim();

            try
            {
                DepartmentBLL departmentBLL =
                    new DepartmentBLL();

                departmentBLL.AddDepartment(department);

                lblMessage.Text =
                    "Department added successfully.";

                txtDepartmentName.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception)
            {
                lblMessage.Text =
                    "An error occurred while adding the department.";
            }
        }
    }
}