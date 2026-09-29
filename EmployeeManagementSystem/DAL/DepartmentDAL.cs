using EmployeeManagementSystem.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace EmployeeManagementSystem.DAL
{
    public class DepartmentDAL
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (OracleConnection connection = new OracleConnection(connectionString))
            using (OracleCommand command = new OracleCommand("GET_ALL_DEPARTMENTS", connection))
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
                        Department department = new Department();

                        department.DepartmentId =
                            Convert.ToInt32(reader["DEPARTMENT_ID"]);

                        department.DepartmentName =
                            reader["DEPARTMENT_NAME"].ToString();

                        department.Description =
                            reader["DESCRIPTION"].ToString();

                        department.IsActive =
                            Convert.ToInt32(reader["IS_ACTIVE"]) == 1;

                        departments.Add(department);
                    }
                }
            }

            return departments;
        }

        public void AddDepartment(Department department)
        {
            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("ADD_DEPARTMENT", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add(
                    "P_DEPARTMENT_NAME",
                    OracleDbType.Varchar2).Value =
                    department.DepartmentName;

                command.Parameters.Add(
                    "P_DESCRIPTION",
                    OracleDbType.Varchar2).Value =
                    department.Description;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(Department department)
        {
            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("UPDATE_DEPARTMENT", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add(
                    "P_DEPARTMENT_ID",
                    OracleDbType.Int32).Value =
                    department.DepartmentId;

                command.Parameters.Add(
                    "P_DEPARTMENT_NAME",
                    OracleDbType.Varchar2).Value =
                    department.DepartmentName;

                command.Parameters.Add(
                    "P_DESCRIPTION",
                    OracleDbType.Varchar2).Value =
                    department.Description;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            Department department = null;

            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("GET_DEPARTMENT_BY_ID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add(
                    "P_DEPARTMENT_ID",
                    OracleDbType.Int32).Value =
                    departmentId;

                OracleParameter resultParameter =
                    new OracleParameter(
                        "P_RESULT",
                        OracleDbType.RefCursor,
                        ParameterDirection.Output);

                command.Parameters.Add(resultParameter);

                connection.Open();
                command.ExecuteNonQuery();

                using (OracleDataReader reader =
                    ((OracleRefCursor)resultParameter.Value).GetDataReader())
                {
                    if (reader.Read())
                    {
                        department = new Department();

                        department.DepartmentId =
                            Convert.ToInt32(reader["DEPARTMENT_ID"]);

                        department.DepartmentName =
                            reader["DEPARTMENT_NAME"].ToString();

                        department.Description =
                            reader["DESCRIPTION"].ToString();

                        department.IsActive =
                            Convert.ToInt32(reader["IS_ACTIVE"]) == 1;
                    }
                }
            }

            return department;
        }

        public void DeleteDepartment(int departmentId)
        {
            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("DELETE_DEPARTMENT", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add(
                    "P_DEPARTMENT_ID",
                    OracleDbType.Int32).Value =
                    departmentId;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool CanDeleteDepartment(int departmentId)
        {
            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("CAN_DELETE_DEPARTMENT", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                OracleParameter returnParameter =
                    new OracleParameter(
                        "RETURN_VALUE",
                        OracleDbType.Int32,
                        ParameterDirection.ReturnValue);

                command.Parameters.Add(returnParameter);

                command.Parameters.Add(
                    "P_DEPARTMENT_ID",
                    OracleDbType.Int32).Value =
                    departmentId;

                connection.Open();
                command.ExecuteNonQuery();

                int result =
                    ((Oracle.ManagedDataAccess.Types.OracleDecimal)
                        returnParameter.Value).ToInt32();

                return result == 1;
            }
        }
    }
}