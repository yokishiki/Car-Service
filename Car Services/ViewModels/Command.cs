using System;
using System.Windows.Input;

namespace Car_Services
{
    public class Command : ICommand
    {
        private Action _execute = null;
        private bool _canExecute = false;

        public Command(Action execute, bool canExecute = true)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
