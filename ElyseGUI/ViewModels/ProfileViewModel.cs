using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.ViewModels
{
    internal class ProfileViewModel
    {
        private MainViewModel _mainViewModel;
        public Models.Character Character
        {
            get;
            private set;
        }

        public int CurrentHead
        {
            get;
            private set;
        }
        public int CurrentBody
        {
            get;
            private set;
        }
        private readonly Commands.ChangeProfileCommands _changeProfileCommand;

        private ICommand _previousHead;

        public ICommand PreviousHeadCommand
        {
            get
            {
                if (_previousHead == null)
                {
                    _previousHead = new Commands.RelayCommand(
                        param => _changeProfileCommand.PreviousHead(),
                        param => true
                    );
                }
                return _previousHead;
            }
        }

        private ICommand _nextHead;

        public ICommand NextHeadCommand
        {
            get
            {
                if (_nextHead == null)
                {
                    _nextHead = new Commands.RelayCommand(
                        param => _changeProfileCommand.NextHead(),
                        param => true
                    );
                }
                return _nextHead;
            }
        }

        private ICommand _previousBody;

        public ICommand PreviousBodyCommand
        {
            get
            {
                if (_previousBody == null)
                {
                    _previousBody = new Commands.RelayCommand(
                        param => _changeProfileCommand.PreviousBody(),
                        param => true
                    );
                }
                return _previousBody;
            }
        }

        private ICommand _nextBody;

        public ICommand NextBodyCommand
        {
            get
            {
                if (_nextBody == null)
                {
                    _nextBody = new Commands.RelayCommand(
                        param => _changeProfileCommand.NextBody(),
                        param => true
                    );
                }
                return _nextBody;
            }
        }

        public ProfileViewModel(MainViewModel mainViewModel, Models.Character character)
        {
            Character = character;
            _mainViewModel = mainViewModel;
            _changeProfileCommand = new Commands.ChangeProfileCommands(this);

            CurrentBody = CurrentHead = 0; 
        }

        public void PreviousHead()
        {
            CurrentHead -= 1;
            if (CurrentHead < 1)
            {
                CurrentHead = 0;
            }

            Character.HeadImage = _mainViewModel.Images.Heads[CurrentHead];
            System.Diagnostics.Debug.WriteLine("previous head");
        }

        public void NextHead()
        {
            CurrentHead += 1;
            if (CurrentHead > (_mainViewModel.Images.Heads.Count() - 1))
            {
                CurrentHead = 0;
            }

            Character.HeadImage = _mainViewModel.Images.Heads[CurrentHead];
            System.Diagnostics.Debug.WriteLine("next head "+ CurrentHead);

        }

        public void PreviousBody()
        {
            CurrentBody -= 1;
            if (CurrentBody < 1)
            {
                CurrentBody = 0;
            }

            Character.BodyImage = _mainViewModel.Images.Bodies[CurrentBody];
            System.Diagnostics.Debug.WriteLine("previous body");

        }

        public void NextBody()
        {
            CurrentBody += 1;
            if (CurrentBody > (_mainViewModel.Images.Bodies.Count() - 1))
            {
                CurrentBody = 0;
            }

            Character.BodyImage = _mainViewModel.Images.Bodies[CurrentBody];
            System.Diagnostics.Debug.WriteLine("next body " + Character.BodyImage);
        }
    }
}
