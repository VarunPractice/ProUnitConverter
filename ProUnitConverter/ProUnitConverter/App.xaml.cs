using System;
using System.Configuration;
using System.Data;
using System.Windows;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ProUnitConverter
{
 
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Views.Login loginWindow = new Views.Login();
            ViewModels.LoginViewModel loginViewModel = new ViewModels.LoginViewModel();
            loginWindow.ShowDialog();

            if (loginViewModel.IsLoginSuccessful)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                Shutdown();  // Closes the application if login is unsuccessful
            }
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
          // Explicit initialization of Logger
            var logger = sharedResources.Logs.Logger.Instance;

            // Setup exception handling
            SetupGlobalExceptionHandling();
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }


        private void SetupGlobalExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        private void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            LogAndHandleException(ex);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            LogAndHandleException(e.Exception);
            e.Handled = true;
        }

        private void LogAndHandleException(Exception ex)
        {
            var handler = sharedResources.GlobalExceptionHandling.ExceptionHandler.Instance;
            if (handler != null)
            {
                handler.RegisterGlobalExceptionHandler(ex);
            }
            else
            {
                // Fallback logging or handling
                Console.WriteLine("ExceptionHandler is not initialized.");
            }
        }


    }

}
