using System.Collections.Generic;
using System.Web.Http;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.API
{
    public class DepartmentApiController : ApiController
    {
        [HttpGet]
        [Route("api/departments")]
        public IHttpActionResult GetDepartments()
        {
            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            List<Department> departments =
                departmentBLL.GetAllDepartments();

            return Ok(departments);
        }

        [HttpPost]
        [Route("api/departments")]
        public IHttpActionResult AddDepartment(Department department)
        {
            if (department == null)
            {
                return BadRequest("Department data is required.");
            }

            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            departmentBLL.AddDepartment(department);

            return Ok(department);
        }

        [HttpPut]
        [Route("api/departments/{id:int}")]
        public IHttpActionResult UpdateDepartment(
            int id,
            Department department)
        {
            if (department == null)
            {
                return BadRequest("Department data is required.");
            }

            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            Department existingDepartment =
                departmentBLL.GetDepartmentById(id);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            department.DepartmentId = id;

            departmentBLL.UpdateDepartment(department);

            return Ok(department);
        }

        [HttpDelete]
        [Route("api/departments/{id:int}")]
        public IHttpActionResult DeleteDepartment(int id)
        {
            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            Department existingDepartment =
                departmentBLL.GetDepartmentById(id);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            if (!departmentBLL.CanDeleteDepartment(id))
            {
                return BadRequest(
                    "Department cannot be deleted because it has active employees.");
            }

            departmentBLL.DeleteDepartment(id);

            return Ok();
        }
        [HttpGet]
        [Route("api/departments/{id:int}")]
        public IHttpActionResult GetDepartment(int id)
        {
            DepartmentBLL departmentBLL =
                new DepartmentBLL();

            Department department =
                departmentBLL.GetDepartmentById(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
    }
}