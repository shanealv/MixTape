using MixTapeApp.Services;
using MixTapeApp.ViewModels;
using System.Windows;

namespace MixTapeApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = Resolver.Resolve<IMainViewModel>();
            InitializeComponent();
        }
    }
}
