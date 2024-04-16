using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ProUnitConverter.DAL
{
    public class DALLogin
    {
        private string _connectionString;

        public DALLogin()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PUCConnectionString"].ConnectionString;
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ValidateLogin", sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Username", username));
                    cmd.Parameters.Add(new SqlParameter("@Password", password));
                    try
                    {
                        sqlConn.Open();
                        int userCount = (int)cmd.ExecuteScalar();

                        return userCount > 0;
                    }
                    catch (Exception ex)
                    {
                        // Ideally use a logging mechanism here
                        Console.WriteLine("Exception: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
