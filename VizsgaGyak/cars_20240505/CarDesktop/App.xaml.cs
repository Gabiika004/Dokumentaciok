using System.Configuration;
using System.Data;
using System.Windows;

namespace CarDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if ( e.Args.Contains("--stat"))
            {
                Statisztika.Run();
                Shutdown();
            }
            else
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }

}
