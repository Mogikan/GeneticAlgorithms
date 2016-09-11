using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ASTU.GeneticAlgorithm
{
    internal class Command<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<T, bool> _predicate;
        public event EventHandler CanExecuteChanged;

        public Command(Action<T> action, Func<T, bool> predicate)
        {
            this._action = action;
            this._predicate = predicate;
        }

        public Command(Action<T> action)
        {
            this._action = action;
            _predicate = obj => true;
        }

        public bool CanExecute(object parameter)
        {
            var documents = (T)parameter;
            return _predicate(documents);
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
