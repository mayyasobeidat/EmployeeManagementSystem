using EmployeeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace EmployeeManagementSystem.DAL
{
    public class EmployeeDAL
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("GET_ALL_EMPLOYEES", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                OracleParameter resultParameter = new OracleParameter(
                    "P_RESULT",
                    OracleDbType.RefCursor,
                    ParameterDirection.Output
                );

                command.Parameters.Add(resultParameter);

                connection.Open();

                command.ExecuteNonQuery();

                using (OracleDataReader reader =
                    ((OracleRefCursor)resultParameter.Value).GetDataReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.EmployeeId = Convert.ToInt32(reader["EMPLOYEE_ID"]);
                        employee.FirstName = reader["FIRST_NAME"].ToString();
                        employee.LastName = reader["LAST_NAME"].ToString();
                        employee.JobTitle = reader["JOB_TITLE"].ToString();
                        employee.DepartmentId =
                            Convert.ToInt32(reader["DEPARTMENT_ID"]);

                        employee.DepartmentName =
                            reader["DEPARTMENT_NAME"].ToString();
                        employee.Email = reader["EMAIL"].ToString();
                        employee.Salary = Convert.ToDecimal(reader["SALARY"]);
                        employee.HireDate = Convert.ToDateTime(reader["HIRE_DATE"]);
                        employee.IsActive = Convert.ToInt32(reader["IS_ACTIVE"]) == 1;

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("GET_EMPLOYEE_BY_ID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value =
                    employeeId;

                OracleParameter resultParameter = new OracleParameter(
                    "P_RESULT",
                    OracleDbType.RefCursor,
                    ParameterDirection.Output
                );

                command.Parameters.Add(resultParameter);

                connection.Open();

                command.ExecuteNonQuery();

                using (OracleDataReader reader =
                    ((OracleRefCursor)resultParameter.Value).GetDataReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee();

                        employee.EmployeeId =
                            Convert.ToInt32(reader["EMPLOYEE_ID"]);

                        employee.FirstName =
                            reader["FIRST_NAME"].ToString();

                        employee.LastName =
                            reader["LAST_NAME"].ToString();

                        employee.Email =
                            reader["EMAIL"].ToString();

                        employee.Phone =
                            reader["PHONE"].ToString();

                        employee.JobTitle =
                            reader["JOB_TITLE"].ToString();

                        employee.DepartmentId =
                            Convert.ToInt32(reader["DEPARTMENT_ID"]);

                        employee.DepartmentName =
    reader["DEPARTMENT_NAME"].ToString();

                        employee.Salary =
                            Convert.ToDecimal(reader["SALARY"]);

                        employee.HireDate =
                            Convert.ToDateTime(reader["HIRE_DATE"]);

                        employee.IsActive =
                            Convert.ToInt32(reader["IS_ACTIVE"]) == 1;
                    }
                }
            }

            return employee;
        }


        public void AddEmployee(Employee employee)
        {
            try
            {
                using (OracleConnection connection =
                    new OracleConnection(connectionString))
                using (OracleCommand command =
                    new OracleCommand("ADD_EMPLOYEE", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.BindByName = true;

                    command.Parameters.Add(
                        "P_FIRST_NAME",
                        OracleDbType.Varchar2).Value = employee.FirstName;

                    command.Parameters.Add(
                        "P_LAST_NAME",
                        OracleDbType.Varchar2).Value = employee.LastName;

                    command.Parameters.Add(
                        "P_EMAIL",
                        OracleDbType.Varchar2).Value = employee.Email;

                    command.Parameters.Add(
                        "P_PHONE",
                        OracleDbType.Varchar2).Value = employee.Phone;

                    command.Parameters.Add(
                        "P_JOB_TITLE",
                        OracleDbType.Varchar2).Value = employee.JobTitle;

                    command.Parameters.Add(
                        "P_DEPARTMENT_ID",
                        OracleDbType.Int32).Value = employee.DepartmentId;

                    command.Parameters.Add(
                        "P_SALARY",
                        OracleDbType.Decimal).Value = employee.Salary;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Error while adding employee.",
                    ex);
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("UPDATE_EMPLOYEE", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value =
                    employee.EmployeeId;

                command.Parameters.Add("P_FIRST_NAME", OracleDbType.Varchar2).Value =
                    employee.FirstName;

                command.Parameters.Add("P_LAST_NAME", OracleDbType.Varchar2).Value =
                    employee.LastName;

                command.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value =
                    employee.Email;

                command.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value =
                    employee.Phone;

                command.Parameters.Add("P_JOB_TITLE", OracleDbType.Varchar2).Value =
                    employee.JobTitle;

                command.Parameters.Add("P_DEPARTMENT_ID", OracleDbType.Int32).Value =
                    employee.DepartmentId;

                command.Parameters.Add("P_SALARY", OracleDbType.Decimal).Value =
                    employee.Salary;

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("DELETE_EMPLOYEE", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add("P_EMPLOYEE_ID", OracleDbType.Int32).Value =
                    employeeId;

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<Employee> SearchEmployees(
     string search,
     int departmentId)
        {
            List<Employee> employees = new List<Employee>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("SEARCH_EMPLOYEES", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add("P_SEARCH", OracleDbType.Varchar2).Value = search;
                command.Parameters.Add(
    "P_DEPARTMENT_ID",
    OracleDbType.Int32).Value = departmentId;
                OracleParameter resultParameter = new OracleParameter(
                    "P_RESULT",
                    OracleDbType.RefCursor,
                    ParameterDirection.Output
                );

                command.Parameters.Add(resultParameter);

                connection.Open();

                command.ExecuteNonQuery();

                using (OracleDataReader reader =
                    ((OracleRefCursor)resultParameter.Value).GetDataReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.EmployeeId =
                            Convert.ToInt32(reader["EMPLOYEE_ID"]);

                        employee.FirstName =
                            reader["FIRST_NAME"].ToString();

                        employee.LastName =
                            reader["LAST_NAME"].ToString();

                        employee.JobTitle =
                            reader["JOB_TITLE"].ToString();
                        employee.DepartmentName =
    reader["DEPARTMENT_NAME"].ToString();

                        employee.Email =
                            reader["EMAIL"].ToString();

                        employee.Salary =
                            Convert.ToDecimal(reader["SALARY"]);

                        employee.HireDate =
                            Convert.ToDateTime(reader["HIRE_DATE"]);

                        employee.IsActive =
                            Convert.ToInt32(reader["IS_ACTIVE"]) == 1;

                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

    }
}