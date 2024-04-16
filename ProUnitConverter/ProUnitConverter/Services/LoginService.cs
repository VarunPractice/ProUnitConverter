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
            SharedResources.Logs.Logger.Instance.LogInfo("Authentication started for user {'"+username+"'} with password '"+password+"'");
            //
            SharedResources.Logs.Logger.Instance.LogInfo("Authentication was successful.");

            return true;
        }

    }
}
