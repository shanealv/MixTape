using MixTapeApp.Bootstrap;
using MixTapeApp.Properties;
using System.IO;
using System.Windows;
using static System.Environment;

namespace MixTapeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // initialize the dependency injection container
            new Bootstrapper().Run();

            // initialize some settings
            if (string.IsNullOrEmpty(Settings.Default.LastSavePath) || !Directory.Exists(Settings.Default.LastSavePath))
                Settings.Default.LastSavePath = GetFolderPath(SpecialFolder.MyDocuments);

            if (string.IsNullOrEmpty(Settings.Default.LastOpenPath) || !Directory.Exists(Settings.Default.LastOpenPath))
                Settings.Default.LastOpenPath = GetFolderPath(SpecialFolder.MyDocuments);
        }
    }
}
