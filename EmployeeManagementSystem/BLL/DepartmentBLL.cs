using System.Collections.Generic;
using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL departmentDAL = new DepartmentDAL();

        public List<Department> GetAllDepartments()
        {
            return departmentDAL.GetAllDepartments();
        }

        public void AddDepartment(Department department)
        {
            departmentDAL.AddDepartment(department);
        }

        public void UpdateDepartment(Department department)
        {
            departmentDAL.UpdateDepartment(department);
        }

        public Department GetDepartmentById(int departmentId)
        {
            return departmentDAL.GetDepartmentById(departmentId);
        }

        public void DeleteDepartment(int departmentId)
        {
            departmentDAL.DeleteDepartment(departmentId);
        }

        public bool CanDeleteDepartment(int departmentId)
        {
            return departmentDAL.CanDeleteDepartment(departmentId);
        }
    }
}