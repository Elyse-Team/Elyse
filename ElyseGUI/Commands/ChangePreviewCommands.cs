using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ElyseGUI.ViewModels;

namespace ElyseGUI.Commands
{
    class ChangePreviewCommands: ICommand
    {
        private MainViewModel _mainViewModel;

        public ChangePreviewCommands(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NextBackground()
        {
            _mainViewModel.NextPreviewBackground();
        }

        public void PreviousBackground()
        {
            _mainViewModel.PreviousPreviewBackground();
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {

        }
    }
}
