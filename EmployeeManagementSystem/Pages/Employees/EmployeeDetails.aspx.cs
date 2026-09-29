using System;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Pages.Employees
{
    public partial class EmployeeDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployee();
            }
        }

        private void LoadEmployee()
        {

            int employeeId =
                Convert.ToInt32(Request.QueryString["id"]);

            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            Employee employee =
                employeeBLL.GetEmployeeById(employeeId);

            if (employee != null)
            {
                lblFirstName.Text =
                    employee.FirstName;

                lblLastName.Text =
                    employee.LastName;

                lblEmail.Text =
                    employee.Email;

                lblPhone.Text =
                    employee.Phone;

                lblJobTitle.Text =
                    employee.JobTitle;

                lblDepartmentId.Text =
     employee.DepartmentName;

                lblSalary.Text =
                    employee.Salary.ToString("0.00");

                lblHireDate.Text =
                    employee.HireDate.ToString("yyyy-MM-dd");

                lblStatus.Text =
                    employee.IsActive ? "Active" : "Inactive";
            }
        }
    }
}