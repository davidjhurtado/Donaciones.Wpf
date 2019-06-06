using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Donaciones.WPF {
    public class RelayCommand :ICommand {
        private Action ExecuteAction { get; set; }
        private Func<bool> CanExecuteAction { get; set; }

        public RelayCommand(Action execute,Func<bool> canExecute = null) {
            ExecuteAction = execute;
            CanExecuteAction = canExecute;
        }
        
        public bool CanExecute(object parameter) {
            return CanExecuteAction == null || CanExecuteAction();
        }

        public void Execute(object parameter) {
            ExecuteAction();
        }

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Refresh() {
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public class RelayCommand<T> :ICommand where T:class {
        private Action<T> ExecuteAction { get; set; }
        private Func<bool> CanExecuteAction { get; set; }

        public RelayCommand(Action<T> execute,Func<bool> canExecute = null) {
            ExecuteAction = execute;
            CanExecuteAction = canExecute;
        }

        public bool CanExecute(object parameter) {
            return CanExecuteAction == null || CanExecuteAction();
        }

        public void Execute(object parameter) {
            var param = parameter as T;
            ExecuteAction(param);
        }

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Refresh() {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
