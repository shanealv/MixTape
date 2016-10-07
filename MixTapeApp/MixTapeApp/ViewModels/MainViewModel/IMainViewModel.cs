using System.Windows.Input;

namespace MixTapeApp.ViewModels
{
    interface IMainViewModel
    {
        string Message { get; set; }
        ICommand UpdateMessageCommand { get; }
    }
} 