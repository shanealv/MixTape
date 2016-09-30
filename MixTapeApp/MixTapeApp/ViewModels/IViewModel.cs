using System.ComponentModel;

namespace MixTapeApp.ViewModels
{
    interface IViewModel
    {
        string Title { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}