using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProUnitConverter.Services;
using System;
using System.ComponentModel;

namespace ProUnitConverter.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public Models.LoginModel LoginModel { get; set; }

        public string LoginName
        {
            get { return LoginModel.LoginId; }
            set
            {
                LoginModel.LoginId = value;
                RaisePropertyChanged(nameof(LoginName));
            }
        }

        public string LoginPassword
        {
            get { return LoginModel.LoginPassword; }
            set
            {
                LoginModel.LoginPassword = value;
                RaisePropertyChanged(nameof(LoginPassword));
            }
        }

        // Use a tuple to pass both username and password to the command
        public RelayCommand<(string Username, string Password)> GetLogin { get; private set; }

        public LoginViewModel()
        {
            LoginModel = new Models.LoginModel();

            // Initialize the RelayCommand with a tuple parameter
            GetLogin = new RelayCommand<(string Username, string Password)>(AuthenticateUser);
        }

        private void AuthenticateUser((string Username, string Password) credentials)
        {
            if (AuthenticateUser(credentials.Username, credentials.Password))
            {
            }
            else
            {
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                sharedResources.Logs.Logger.Instance.LogInfo($"Authentication started for user: {username}");

                var userIsValid = Services.LoginService.Instance.AuthenticateUser(username, password);

                sharedResources.Logs.Logger.Instance.LogInfo($"Authentication {(userIsValid ? "was successful" : "failed")} for user: {username}");

                return userIsValid;
            }
            catch (Exception ex)
            {
                sharedResources.Logs.Logger.Instance.LogError($"Authentication failed with an exception: {ex.Message}");
                return false;
            }
        }
    }
}
