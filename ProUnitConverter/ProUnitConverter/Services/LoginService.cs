using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProUnitConverter.Services
{
 public sealed class LoginService: ILogin
    {
        private LoginService() { }
        private static LoginService _instance { get; set; }

        private static readonly object PUCLock  = new object();
        private static readonly log4net.ILog _logger;
        public static LoginService Instance
        {
            get
            {
                lock (PUCLock)
                {
                    return _instance ??= new LoginService();
                }
            }
        }
        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                // Log without sensitive information
                sharedResources.Logs.Logger.Instance.LogInfo($"Authentication started for user: {username}");

                // Example authentication logic
                //var userIsValid = CheckUserCredentials(username, password); // Implement this method to check credentials properly

                //sharedResources.Logs.Logger.Instance.LogInfo($"Authentication {(userIsValid ? "was successful" : "failed")} for user: {username}");

                return true;
            }
            catch (Exception ex)
            {
                sharedResources.Logs.Logger.Instance.LogError("Authentication failed with an exception: " + ex.Message);
                return false;
            }
        }


    }
}
