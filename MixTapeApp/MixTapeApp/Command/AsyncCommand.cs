using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MixTapeApp.Command
{
    class AsyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AsyncContext _context;
        private Func<Task> _execute;
        private Predicate<object> _canExecute;
        
        public AsyncCommand(Func<Task> execute, Predicate<object> canExecute = null, AsyncContext context = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _context = context;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            lock (_context)
            {
                if (_context.Busy)
                {
                    return;
                }
                _context.Busy = true;
            }
            var task = _execute.Invoke();
            task.ContinueWith(PostExecute);
        }

        private void PostExecute(Task result)
        {
            lock (_context)
            {
                _context.Busy = false;
            }
            if (result.IsFaulted) // if there was an unhandled error, forward it to the main thread
            {
                Application.Current.Dispatcher.Invoke(() => { throw result.Exception; });
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }

    class AsyncCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private AsyncContext _context;
        private Func<T, Task> _execute;
        private Predicate<object> _canExecute;

        public AsyncCommand(Func<T, Task> execute, Predicate<object> canExecute = null, AsyncContext context = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _context = context;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is T))
                throw new ArgumentException($"{nameof(parameter)} is not of type: {nameof(T)}");

            lock (_context)
            {
                if (_context.Busy)
                {
                    return;
                }
                _context.Busy = true;
            }

            var task = _execute.Invoke((T) parameter);
            task.ContinueWith(PostExecute);
        }

        private void PostExecute(Task result)
        {
            lock (_context)
            {
                _context.Busy = false;
            }
            if (result.IsFaulted) // if there was an unhandled error, forward it to the main thread
            {
                Application.Current.Dispatcher.Invoke(() => { throw result.Exception; });
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }

}
