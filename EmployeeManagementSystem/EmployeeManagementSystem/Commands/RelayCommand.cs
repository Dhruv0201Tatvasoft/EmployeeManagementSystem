using System.ComponentModel.Composition;
using System.Windows.Input;

namespace EmployeeManagementSystem.Commands
{
    internal class RelayCommand : ICommand
    {
        Action<object> execute;
        Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)

        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
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


        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                if (parameter != null)
                {
                    return canExecute(parameter);
                }
                return false;
            }
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                execute(parameter);
            }
        }
    }
}
