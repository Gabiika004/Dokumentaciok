using System.Configuration;
using System.Data;
using System.Windows;

namespace Bookclub_desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Contains("--stat"))
            {
                Statisztika.Run();
                Shutdown();
            }
            else
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
            }
        }
    }

}
