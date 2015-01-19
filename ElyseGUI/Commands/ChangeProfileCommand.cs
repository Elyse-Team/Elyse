using ElyseGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.Commands
{
    class ChangeProfileCommand : ICommand
    {
        private ProfileViewModel _profileViewModel;

        public ChangeProfileCommand(ProfileViewModel profileViewModel)
        {
            _profileViewModel = profileViewModel;
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
            
        }

        public void PreviousHead()
        {
            _profileViewModel.PreviousHead();
        }

        public void NextHead()
        {
            _profileViewModel.NextHead();
        }

        public void PreviousBody()
        {
            _profileViewModel.PreviousBody();
        }

        public void NextBody()
        {
            _profileViewModel.NextBody();

        }
    }
}
