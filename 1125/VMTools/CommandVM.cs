using System;
using System.Windows.Input;

namespace _1125.VMTools
{
    public class CommandVM : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> canExecute;

        public CommandVM(Action action, Func<bool> canExecute = null)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            // Если canExecute == null — считаем, что команда всегда доступна
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
