using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SexyBooks.Helpers
{
    public class DelegateCommand : ICommand
    {

        //https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/keywords/add
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        //https://docs.microsoft.com/de-de/dotnet/csharp/programming-guide/generics/generic-delegates

        Action<object> _executeMethod;
        Func<object, bool> _canExecuteMethod;

        public DelegateCommand(Action<object> executeMethod, Func<object, bool> canExecuteMethod = null)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if(_canExecuteMethod != null)
            {
                return _canExecuteMethod.Invoke(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke(parameter);
        }
    }
}