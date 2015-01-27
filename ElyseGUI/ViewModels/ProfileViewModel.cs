using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ElyseGUI.Models;

namespace ElyseGUI.ViewModels
{
    internal class ProfileViewModel
    {
        private MainViewModel _mainViewModel;
        public Character Character
        {
            get;
            private set;
        }

        private int _currentBody;

        private ICommand _previousBody;

        public ICommand PreviousBodyCommand
        {
            get
            {
                if (_previousBody == null)
                {
                    _previousBody = new Commands.RelayCommand(
                        param => this.PreviousBody(),
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
                        param => this.NextBody(),
                        param => true
                    );
                }
                return _nextBody;
            }
        }

        public ProfileViewModel(MainViewModel mainViewModel, Character character)
        {
            Character = character;
            _mainViewModel = mainViewModel;
            _currentBody= 0; 

            if(Character.IsEmpty)
            {
                //Character.Name = "Name";
                _mainViewModel.Preview.CharacterList.Add(new Character());
            }
        }

        public void PreviousBody()
        {
            _currentBody -= 1;
            if (_currentBody < 1)
            {
                _currentBody = 0;
            }

            Character.BodyImage = _mainViewModel.Images.Bodies[_currentBody];
            System.Diagnostics.Debug.WriteLine("previous body");

        }

        public void NextBody()
        {
            _currentBody += 1;
            if (_currentBody > (Enum.GetNames(typeof(ElyseLibrary.Character.ShirtColor)).Length -1))
            {
                _currentBody = 0;
            }

            Character.SetBody(_currentBody);
            System.Diagnostics.Debug.WriteLine("next body " + Character.BodyImage);
        }
    }
}
