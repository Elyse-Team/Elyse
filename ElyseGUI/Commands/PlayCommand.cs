using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ElyseGUI.ViewModels;

namespace ElyseGUI.Commands
{
    internal class PlayCommand : ICommand
    {
        private MainViewModel _mainViewModel;

        public PlayCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return _mainViewModel.CanPlayStory;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value;  }
            remove { CommandManager.RequerySuggested -= value;  }
        }

        public void Execute(object parameter)
        {
            _mainViewModel.Play();
        }

        public void TriggerChange()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
