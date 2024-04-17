using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProUnitConverter.Services;
using System;
using System.ComponentModel;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        public RelayCommand GetLogin { get; private set; }
        public bool IsLoginSuccessful { get; set; }
        public LoginViewModel()
        {
            LoginModel = new Models.LoginModel();
            IsLoginSuccessful = false;
            GetLogin = new RelayCommand (AuthenticateUser);
        }

        private void GetCorrectWindow()
        {
            Views.Login loginWindow = new Views.Login();

            if (IsLoginSuccessful)
            {
               loginWindow.Close();

                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                LoginName = string.Empty; LoginPassword = string.Empty;
                mainWindow.Show();
            }
            else
            {
                Application.Current.MainWindow = loginWindow;
              LoginPassword = string.Empty;
                loginWindow.ShowDialog(); 
            }
        }
        private void AuthenticateUser()
        {
            try
            {
                try
                {
                    sharedResources.Logs.Logger.Instance.LogInfo($"Authentication started for user: {LoginModel.LoginId}");

                    if (Services.LoginService.Instance.AuthenticateUser(LoginModel.LoginId, LoginModel.LoginPassword))
                    {
                        IsLoginSuccessful = true;
                        sharedResources.Logs.Logger.Instance.LogInfo("Authentication was Successful for user: {LoginModel.LoginId}");
                        GetCorrectWindow();   }
                    else
                    { IsLoginSuccessful = false; GetCorrectWindow();
                        sharedResources.Logs.Logger.Instance.LogInfo("Authentication was Successful for user: {LoginModel.LoginId}");
                    }


                }
                catch (Exception ex)
                {
                    IsLoginSuccessful = false;
                    sharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
                }
               
            }
            catch (Exception ex)
            {
                    IsLoginSuccessful = false;
                sharedResources.Logs.Logger.Instance.LogError($"Authentication failed with an exception: {ex.Message}");
                 
            }
        }
    }
}
