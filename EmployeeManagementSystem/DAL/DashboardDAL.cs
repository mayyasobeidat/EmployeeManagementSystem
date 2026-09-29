using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace EmployeeManagementSystem.DAL
{
    public class DashboardDAL
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public void GetDashboardStats(
            out int employeeCount,
            out int departmentCount)
        {
            employeeCount = 0;
            departmentCount = 0;

            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("GET_DASHBOARD_STATS", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                OracleParameter employeeParameter =
                    new OracleParameter(
                        "P_EMPLOYEE_COUNT",
                        OracleDbType.Int32,
                        ParameterDirection.Output);

                OracleParameter departmentParameter =
                    new OracleParameter(
                        "P_DEPARTMENT_COUNT",
                        OracleDbType.Int32,
                        ParameterDirection.Output);

                command.Parameters.Add(employeeParameter);
                command.Parameters.Add(departmentParameter);

                connection.Open();

                command.ExecuteNonQuery();

                employeeCount =
                    Convert.ToInt32(employeeParameter.Value.ToString());

                departmentCount =
                    Convert.ToInt32(departmentParameter.Value.ToString());
            }
        }
    }
}