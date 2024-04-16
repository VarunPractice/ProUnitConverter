using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProUnitConverter.Services;
using System;
using System.ComponentModel;

namespace ProUnitConverter.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private  log4net.ILog  _logger;
        private readonly LoginService _loginService;

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
                RaisePropertyChanged(nameof(LoginPassword)); // Fixed to notify the correct property
            }
        }

        public RelayCommand GetLogin { get; set; }

        // Constructor that accepts the logger and loginService
        public LoginViewModel(log4net.ILog logger, LoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;

            LoginModel = new Models.LoginModel();
            GetLogin = new RelayCommand(AuthenticateUser);
        }

        private void AuthenticateUser()
        {
            try
            {
                _logger.Info("Attempting to authenticate user {LoginId}" + LoginModel.LoginId);

                var isSuccess = _loginService.AuthenticateUser(LoginModel.LoginId, LoginModel.LoginPassword);
                if (isSuccess)
                {
                    _logger.Info("User {LoginId} authenticated successfully" + LoginModel.LoginId);
                }
                else
                {
                    _logger.Warn("Failed to authenticate user {LoginId}" + LoginModel.LoginId);
                }
            }
            catch (Exception ex)
            {

                SharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
            }           
        }
    }
}
