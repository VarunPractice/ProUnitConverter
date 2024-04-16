using System;
using System.Configuration;
using System.Data;
using System.Windows;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ProUnitConverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary
    /// 

    public partial class App : Application
    {
      
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);
        //    //log4net.Config.XmlConfigurator.Configure();  
             
        //    //this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        //}

        //private void SetupGlobalExceptionHandling()
        //{
        //    AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
        //    Application.Current.DispatcherUnhandledException += App_DispatcherUnhandledException;
        //}

        //private void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Exception ex = (Exception)e.ExceptionObject;
        //    LogAndHandleException(ex);
        //}

        //private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        //{
        //    LogAndHandleException(e.Exception);
        //    e.Handled = true;
        //}

        //private void LogAndHandleException(Exception ex)
        //{
        //    SharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
        //}

    }

}
