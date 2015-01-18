using ElyseGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.Commands
{
    class OpenProfileCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public OpenProfileCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value;  }
        }

        public void Execute(object parameter)
        {
            _mainViewModel.OpenProfileWindow();
        }
    }
}
