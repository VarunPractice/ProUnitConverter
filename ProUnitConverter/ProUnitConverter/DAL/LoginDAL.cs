using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ProUnitConverter.DAL
{
    public sealed class DALLogin
    {
        private static string _connectionString { get; set; }

        private DALLogin()
        {
            _connectionString = Environment.GetEnvironmentVariable("PUCConnectionString");
        }
        private static DALLogin _instance { get; set; }
        private static readonly object _instanceLock = new object();
        public static DALLogin Instance
        { get {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        _instance = new DALLogin();
                    }
                }
                return _instance;
            } }
        public bool ValidateUserCredentials(string username, string password)
        {
           
            sharedResources.Logs.Logger.Instance.LogInfo("Validation process started for user : '"+username);
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ValidateLogin", sqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Username", (object)username ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("@Password", (object)password ?? DBNull.Value));

                    try
                    {
                        sqlConn.Open();
                        int userCount = (int)cmd.ExecuteScalar();

                        return userCount > 0;
                    }
                    catch (Exception ex)
                    {
                       sharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
                        return false;
                    }
                    finally { sqlConn.Close(); }
                }
            }
        }
    }
}
