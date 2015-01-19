﻿using System;
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

        private int _currentHead;
        private int _currentBody;

        private ICommand _previousHead;

        public ICommand PreviousHeadCommand
        {
            get
            {
                if (_previousHead == null)
                {
                    _previousHead = new Commands.RelayCommand(
                        param => this.PreviousHead(),
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
                        param => this.NextHead(),
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
            _currentBody = _currentHead = 0; 

            if(Character.IsEmpty)
            {
                //Character.Name = "Name";
                _mainViewModel.Preview.CharacterList.Add(new Character());
            }
        }

        public void PreviousHead()
        {
            _currentHead -= 1;
            if (_currentHead < 1)
            {
                _currentHead = 0;
            }

            Character.HeadImage = _mainViewModel.Images.Heads[_currentHead];
            System.Diagnostics.Debug.WriteLine("previous head");
        }

        public void NextHead()
        {
            _currentHead += 1;
            if (_currentHead > (_mainViewModel.Images.Heads.Count() - 1))
            {
                _currentHead = 0;
            }

            Character.HeadImage = _mainViewModel.Images.Heads[_currentHead];
            System.Diagnostics.Debug.WriteLine("next head "+ _currentHead);

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
            if (_currentBody > (_mainViewModel.Images.Bodies.Count() - 1))
            {
                _currentBody = 0;
            }

            Character.BodyImage = _mainViewModel.Images.Bodies[_currentBody];
            System.Diagnostics.Debug.WriteLine("next body " + Character.BodyImage);
        }
    }
}
