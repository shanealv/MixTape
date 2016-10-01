using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MixTapeApp.Command
{
    /// <summary>
    /// ICommand Implementation for Asynchronous Methods.
    /// Ignores multple invocations.  Commands can share a mutex to emulate this behavior accross seperate commands.
    /// </summary>
    abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        protected AsyncMutex Mutex;
        protected Predicate<object> CanExecuteFunc;
        
        /// <summary>
        /// Predicates whether or not this command may execute.
        /// </summary>
        /// <param name="parameter">command parameter</param>
        /// <returns>whether or not this command is enabled</returns>
        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Execute this command
        /// </summary>
        /// <param name="parameter">command parameter</param>
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            lock (Mutex)
            {
                if (Mutex.Locked)
                {
                    return;
                }
                Mutex.Locked = true;
            }
            StartAsyncTask(parameter);
        }

        /// <summary>
        /// Execute the task associated with this command.  Must be implemented by descendent.
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract void StartAsyncTask(object parameter);

        /// <summary>
        /// Releases the mutex.  Must follow the StartAsyncTask invocation.
        /// </summary>
        /// <param name="result"></param>
        protected void PostExecute(Task result)
        {
            lock (Mutex)
            {
                Mutex.Locked = false;
            }
            if (result.IsFaulted) 
            {
                // if there was an unhandled error, forward it to the main thread
                Application.Current.Dispatcher.Invoke(() => { throw result.Exception; });
            }
        }

        /// <summary>
        /// Raises the CanExecuteChanged Event.  Use to update UI.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, null);
        }
    }
    class AsyncCommand : AsyncCommandBase
    {
        private Func<Task> ExecuteFunc;
        
        /// <summary>
        /// Creates a new AsyncCommand
        /// </summary>
        /// <param name="executeFunc">the executed function</param>
        /// <param name="canExecuteFunc">the predicate function</param>
        /// <param name="mutex">a shared mutex</param>
        public AsyncCommand(Func<Task> executeFunc, Predicate<object> canExecuteFunc = null, AsyncMutex mutex = null)
        {
            ExecuteFunc = executeFunc;
            CanExecuteFunc = canExecuteFunc;
            Mutex = mutex ?? new AsyncMutex();
        }

        protected override void StartAsyncTask(object parameter)
        {
            ExecuteFunc.Invoke().ContinueWith(PostExecute);
        }
    }

    class AsyncCommand<Targ> : AsyncCommandBase
    {
        private Func<Targ, Task> ExecuteFunc;

        /// <summary>
        /// Creates a new AsyncCommand which operates on the generic type Targ
        /// </summary>
        /// <param name="executeFunc">the executed function</param>
        /// <param name="canExecuteFunc">the predicate function</param>
        /// <param name="mutex">a shared mutex</param>
        public AsyncCommand(Func<Targ, Task> executeFunc, Predicate<object> canExecuteFunc = null, AsyncMutex mutex = null)
        {
            ExecuteFunc = executeFunc;
            CanExecuteFunc = canExecuteFunc;
            Mutex = mutex ?? new AsyncMutex();
        }

        protected override void StartAsyncTask(object parameter)
        {
            Targ arg = default(Targ);
            try
            {
                arg = (Targ)parameter;
            }
            catch { };
            ExecuteFunc.Invoke(arg).ContinueWith(PostExecute);
        }
    }

}
