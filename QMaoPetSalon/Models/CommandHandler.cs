using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QMaoPetSalon.Models
{
    public class CommandHandler : ICommand
    {
        private readonly Action mAction;
        private readonly bool mCanExecute;

        public CommandHandler(Action action)
        {
            mAction = action;
        }

        public CommandHandler(Action action, bool canExecute)
        {
            mAction = action;
            mCanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return mCanExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
