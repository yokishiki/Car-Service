using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Car_Services
{

        public class CommandParameter : ICommand
        {
            private Action<object> _action;
            private bool _canExecute;
            public CommandParameter(Action<object> action, bool canExecute=true)
            {
                _action = action;
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _action(parameter);
            }
        }
    
}
