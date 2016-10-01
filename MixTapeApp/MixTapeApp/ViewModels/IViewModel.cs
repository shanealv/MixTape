using System;
using System.ComponentModel;

namespace MixTapeApp.ViewModels
{
    interface IViewModel
    {
        string Title { get; }

        event PropertyChangedEventHandler PropertyChanged;

        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}