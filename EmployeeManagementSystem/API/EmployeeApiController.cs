using System.Collections.Generic;
using System.Web.Http;
using EmployeeManagementSystem.BLL;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.API
{
    public class EmployeeApiController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public IHttpActionResult GetEmployees()
        {
            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            List<Employee> employees =
                employeeBLL.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet]
        [Route("api/employees/{id:int}")]
        public IHttpActionResult GetEmployee(int id)
        {
            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            Employee employee =
                employeeBLL.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("api/employees/search")]
        public IHttpActionResult SearchEmployees(string search = "",int departmentId = 0)
        {
            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            List<Employee> employees =
                employeeBLL.SearchEmployees(
                    search,
                    departmentId);

            return Ok(employees);
        }

        [HttpPost]
        [Route("api/employees")]
        public IHttpActionResult AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            employeeBLL.AddEmployee(employee);

            return Ok(employee);
        }

        [HttpPut]
        [Route("api/employees/{id:int}")]
          public IHttpActionResult UpdateEmployee(int id,Employee employee)
           {
            if (employee == null)
            {
                return BadRequest("Employee data is required.");
            }

            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            Employee existingEmployee =
                employeeBLL.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            employee.EmployeeId = id;

            employeeBLL.UpdateEmployee(employee);

            return Ok(employee);
        }

        [HttpDelete]
        [Route("api/employees/{id:int}")]
        public IHttpActionResult DeleteEmployee(int id)
        {
            EmployeeBLL employeeBLL =
                new EmployeeBLL();

            Employee employee =
                employeeBLL.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            employeeBLL.DeleteEmployee(id);

            return Ok();
        }
    }
}