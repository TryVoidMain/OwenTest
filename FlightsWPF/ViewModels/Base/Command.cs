using System;
using System.Windows.Input;

namespace FlightsWPF.ViewModels.Base
{
    public class Command : ICommand
    {
        private Action action;
        private Func<bool> canExecute;

        public Command(Action action)
        {
            this.action = action;
        }

        public Command(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute.Invoke();
            else
                return true;
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }
    }

    public class Command<T> : ICommand
    {
        private Action<T> action;

        public Command(Action<T> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null) return true;
            return (parameter.GetType().IsAssignableTo(typeof(T)));
        }

        public void Execute(object parameter)
        {
            action.Invoke((T)parameter);
        }
    }
}