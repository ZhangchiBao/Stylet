using System;
using System.Windows.Input;

namespace Stylet
{
    /// <summary>
    /// Defines a command
    /// </summary>
    public partial class Command : ICommand
    {
        private Action _Execute;
        private Func<bool> _CanExecute;

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/>
        /// </summary>
        /// <param name="execute"></param>
        public Command(Action execute) : this(execute, () => true)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/>
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action execute, Func<bool> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _Execute();
            }
        }
    }

    /// <summary>
    /// Defines a command
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Command<T> : ICommand
    {
        private Action<T> _Execute;
        private Func<T, bool> _CanExecute;

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/>
        /// </summary>
        /// <param name="execute"></param>
        public Command(Action<T> execute) : this(execute, o => true)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Command"/>
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecute((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _Execute((T)parameter);
            }
        }
    }
}
