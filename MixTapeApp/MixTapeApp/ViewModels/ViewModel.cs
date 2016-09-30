using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MixTapeApp.ViewModels
{
    class ViewModel : INotifyPropertyChanged, IViewModel
    {
        public string Title { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T> (ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property.Equals(value))
                return;

            property = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
