using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}