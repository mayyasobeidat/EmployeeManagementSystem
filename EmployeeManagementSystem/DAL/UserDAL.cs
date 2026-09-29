using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace EmployeeManagementSystem.DAL
{
    public class UserDAL
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public int Login(string username, string password)
        {
            int userId = 0;

            using (OracleConnection connection =
                new OracleConnection(connectionString))
            using (OracleCommand command =
                new OracleCommand("CHECK_APP_LOGIN", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.BindByName = true;

                command.Parameters.Add(
                    "P_USERNAME",
                    OracleDbType.Varchar2
                ).Value = username;

                command.Parameters.Add(
                    "P_PASSWORD",
                    OracleDbType.Varchar2
                ).Value = password;

                OracleParameter returnParameter =
                    new OracleParameter(
                        "RETURN_VALUE",
                        OracleDbType.Int32,
                        ParameterDirection.ReturnValue
                    );

                command.Parameters.Add(returnParameter);

                connection.Open();
                command.ExecuteNonQuery();

                userId = ((Oracle.ManagedDataAccess.Types.OracleDecimal)returnParameter.Value).ToInt32();
            }

            return userId;
        }
    }
}