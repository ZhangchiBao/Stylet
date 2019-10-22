using System;
using System.Windows.Input;

namespace StyletCore
{
    /// <summary>
    /// Defines a command
    /// </summary>
    public partial class Command : PropertyChangedBase, ICommand
    {
        private Action executeMethod;
        private Func<bool> canExecuteMethod;

        public Action ExecuteMethod { get => executeMethod; set => SetAndNotify(ref executeMethod, value); }
        public Func<bool> CanExecuteMethod { get => canExecuteMethod; set => SetAndNotify(ref canExecuteMethod, value); }

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
            this.ExecuteMethod = execute;
            this.CanExecuteMethod = canExecute;
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
            return CanExecuteMethod();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteMethod();
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(CanExecuteMethod):
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                    break;
            }
            base.OnPropertyChanged(propertyName);
        }
    }

    /// <summary>
    /// Defines a command
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class Command<T> : PropertyChangedBase, ICommand
    {
        private Action<T> executeMethod;
        private Func<T, bool> canExecuteMethod;

        public Action<T> ExecuteMethod { get => executeMethod; set => SetAndNotify(ref executeMethod, value); }
        public Func<T, bool> CanExecuteMethod { get => canExecuteMethod; set => SetAndNotify(ref canExecuteMethod, value); }

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
            this.ExecuteMethod = execute;
            this.CanExecuteMethod = canExecute;
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
            return CanExecuteMethod((T)parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                ExecuteMethod((T)parameter);
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(CanExecuteMethod):
                    CanExecuteChanged?.Invoke(this, new EventArgs());
                    break;
            }
            base.OnPropertyChanged(propertyName);
        }
    }
}
