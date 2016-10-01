using MixTapeApp.Properties;

namespace MixTapeApp.ViewModels
{
    class MainViewModel : ViewModel, IMainViewModel
    {
        private string message = Resources.Message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
        
        public MainViewModel()
        {
            Title = "Musical Assistant";
        }
    }
}
