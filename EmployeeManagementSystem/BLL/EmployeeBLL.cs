using System.Collections.Generic;
using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL employeeDAL = new EmployeeDAL();

        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return employeeDAL.GetEmployeeById(employeeId);
        }

        public void AddEmployee(Employee employee)
        {
            employeeDAL.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            employeeDAL.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            employeeDAL.DeleteEmployee(employeeId);
        }

        public List<Employee> SearchEmployees(
    string search,
    int departmentId)
        {
            return employeeDAL.SearchEmployees(
                search,
                departmentId);
        }
    }
}