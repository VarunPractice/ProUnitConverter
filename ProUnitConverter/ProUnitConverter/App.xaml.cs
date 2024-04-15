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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            log4net.Config.XmlConfigurator.Configure();  // Correctly placed inside a method
        }

    }

}
