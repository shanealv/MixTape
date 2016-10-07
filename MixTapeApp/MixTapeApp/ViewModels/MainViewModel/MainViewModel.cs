using MixTapeApp.Command;
using MixTapeApp.Properties;
using MixTapeApp.Services;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

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
        
        public ICommand UpdateMessageCommand { get; }

        private IDummyService _dummyService { get; }

        public MainViewModel(IDummyService dummyService)
        {
            Title = "Musical Assistant";
            _dummyService = dummyService;

            UpdateMessageCommand = new AsyncCommand(OnUpdateMessage);
        }

        private async Task OnUpdateMessage()
        {
            await Task.Yield();
            Message = _dummyService.GetMessage();
        }
    }
}
