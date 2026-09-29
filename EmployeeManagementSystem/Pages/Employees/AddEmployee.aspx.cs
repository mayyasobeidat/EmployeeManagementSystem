using System;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Pages.Employees
{
    public partial class AddEmployee : BasePage
    {
        private void LoadDepartments()
        {
            DepartmentBLL departmentBLL = new DepartmentBLL();

            ddlDepartment.DataSource = departmentBLL.GetAllDepartments();
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataValueField = "DepartmentId";
            ddlDepartment.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDepartments();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            employee.FirstName = txtFirstName.Text.Trim();
            employee.LastName = txtLastName.Text.Trim();
            employee.Email = txtEmail.Text.Trim();
            employee.Phone = txtPhone.Text.Trim();
            employee.JobTitle = txtJobTitle.Text.Trim();
            employee.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
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

                employeeBLL.AddEmployee(employee);

                lblMessage.Text = "Employee added successfully.";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred while adding the employee.";
            }
        }
    }
}