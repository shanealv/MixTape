using MixTapeApp.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MixTapeApp.Factory
{
    /// <summary>
    /// Factory for creating several AsyncCommands with a shared predicate and mutex
    /// </summary>
    class AsyncCommandGroupFactory
    {
        private Predicate<object> SharedCanExecute { get; }
        private AsyncMutex SharedMutex { get; }
        private List<AsyncCommandBase> Commands { get; }

        /// <summary>
        /// Creates a new factory with the specified predicate
        /// </summary>
        /// <param name="sharedCanExecute">predicate, defaults to always return true</param>
        public AsyncCommandGroupFactory(Predicate<object> sharedCanExecute = null)
        {
            SharedCanExecute = sharedCanExecute ?? ((obj) => true);
            SharedMutex = new AsyncMutex();
            Commands = new List<AsyncCommandBase>();
        }

        /// <summary>
        /// RaiseCanExecuteChanged for every Command this factory created
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            foreach (var command in Commands)
            {
                command.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Create a command using the given function and predicate
        /// </summary>
        /// <param name="func">execution function</param>
        /// <param name="pred">predicate funciton, defaults to shared predicate when null</param>
        /// <returns>the generated command</returns>
        public ICommand CreateCommand (Func<Task> func, Predicate<object> pred = null)
        {
            var predicate = pred ?? SharedCanExecute;
            var command = new AsyncCommand(func, predicate, SharedMutex);
            Commands.Add(command);
            return command;
        }

        /// <summary>
        /// Create a command using the given function and predicate
        /// </summary>
        /// <param name="func">execution function</param>
        /// <param name="pred">predicate funciton, defaults to shared predicate when null</param>
        /// <returns>the generated command</returns>
        public ICommand CreateCommand<Targ>(Func<Targ, Task> func, Predicate<object> pred = null)
        {
            var predicate = pred ?? SharedCanExecute;
            var command = new AsyncCommand<Targ>(func, predicate, SharedMutex);
            Commands.Add(command);
            return command;
        }
    }
}
