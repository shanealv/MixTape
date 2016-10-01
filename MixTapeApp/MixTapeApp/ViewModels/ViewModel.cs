using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MixTapeApp.ViewModels
{
    /// <summary>
    /// Base class for all View Models
    /// </summary>
    class ViewModel : INotifyPropertyChanged, IViewModel
    {
        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            protected set { SetProperty(ref title, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Set the backing data member to the given value. 
        /// Only saves the value if the two values are different.
        /// Raises the PropertyChanged event is the input value 
        /// is different from the backing data member
        /// </summary>
        /// <typeparam name="T">the type of the backing data member</typeparam>
        /// <param name="property">the property to save into</param>
        /// <param name="value">the value to save</param>
        /// <param name="propertyName">the name of the public property (autofilled)</param>
        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if (property.Equals(value))
                return;

            property = value;
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Raise a property changed even for the given property name
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// executes the action so that the state of this object 
        /// can be initialized externally
        /// </summary>
        /// <typeparam name="T">the type of this object</typeparam>
        /// <param name="action">the initialization actions</param>
        public void SetState<T>(Action<T> action)
            where T : class, IViewModel
        {
            action?.Invoke(this as T);
        }
    }
}
