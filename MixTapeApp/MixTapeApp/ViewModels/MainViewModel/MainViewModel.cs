namespace MixTapeApp.ViewModels
{
    class MainViewModel : ViewModel, IMainViewModel
    {
        private string message = "Hello World!";
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
