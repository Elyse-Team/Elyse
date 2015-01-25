using ElyseGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.Commands
{
    class OpenStoryBookCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public OpenStoryBookCommand(MainViewModel mainViewModel)
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
            System.Diagnostics.Debug.WriteLine("open window");
            _mainViewModel.OpenStoryBookWindow();
        }
    }
}
