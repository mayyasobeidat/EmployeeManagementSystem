using System;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Pages.Employees
{
    public partial class EditEmployee : BasePage
    {
        private void LoadDepartments()
        {
            DepartmentBLL departmentBLL = new DepartmentBLL();

            ddlDepartment.DataSource = departmentBLL.GetAllDepartments();
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentId";
            ddlDepartment.DataBind();
        }

        private void LoadEmployee()
        {
            int employeeId = Convert.ToInt32(Request.QueryString["id"]);

            EmployeeBLL employeeBLL = new EmployeeBLL();

            Employee employee = employeeBLL.GetEmployeeById(employeeId);

            if (employee != null)
            {
                hfEmployeeId.Value = employee.EmployeeId.ToString();

                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtEmail.Text = employee.Email;
                txtPhone.Text = employee.Phone;
                txtJobTitle.Text = employee.JobTitle;
                txtSalary.Text = employee.Salary.ToString();

                ddlDepartment.SelectedValue =
                    employee.DepartmentId.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDepartments();
                LoadEmployee();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            employee.EmployeeId =
                Convert.ToInt32(hfEmployeeId.Value);

            employee.FirstName = txtFirstName.Text.Trim();
            employee.LastName = txtLastName.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Phone = txtPhone.Text.Trim();
            employee.JobTitle = txtJobTitle.Text.Trim();

            employee.DepartmentId =
                Convert.ToInt32(ddlDepartment.SelectedValue);

            decimal salary;

            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                lblMessage.Text = "Please enter a valid salary.";
                return;
            }

            employee.Salary = salary;

            try
            {
                EmployeeBLL employeeBLL = new EmployeeBLL();

                employeeBLL.UpdateEmployee(employee);

                lblMessage.Text = "Employee updated successfully.";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred while updating the employee.";
            }
        }
    }
}