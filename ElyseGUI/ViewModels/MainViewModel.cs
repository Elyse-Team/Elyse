﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseGUI.Models;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using ElyseGUI.Commands;
using ElyseEngine;
using System.Runtime.InteropServices;

namespace ElyseGUI.ViewModels
{
    internal class MainViewModel
    {
        public Engine Engine { get; private set; }
        public bool EngineLoaded {
            get;
            private set;
        }

        public TutorialBox TutorialBox
        {
            get;
            private set;
        }

        public readonly Images Images;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public MainViewModel()
        {
            AllocConsole();
            Console.WriteLine("Elyse started");

            Story = new Story();
            StoryBook = new StoryBook();
            TutorialBox = new TutorialBox();
            Preview = new Preview();
            Images = new Images();
            PlayCommand = new PlayCommand(this);
            OpenProfileCommand = new OpenProfileCommand(this);
            OpenStoryBookCommand = new OpenStoryBookCommand(this);
            EngineLoaded = false;
            new Task(LoadEngine).Start();
            SetPlaying(false);
        }

        public void Closing(object sender, CancelEventArgs e)
        {
            if (!Story.IsEmpty && !StoryBook.IsExists(Story))
            {
                StoryBook.Save(Story);
            }
        }

        private void LoadEngine()
        {
                TutorialBox.Msg = "loading parser...";
                Engine = new Engine();
                TutorialBox.Msg = "Type your text";
                EngineLoaded = true;
        }

        #region Story
        public Story Story
        {
            get;
            private set;
        }

        public bool CanPlayStory { 
            get {
                return Story.CanPlay;
            } 
        }

        public bool IsPlaying { get; private set; }

        public PlayCommand PlayCommand
        {
            get;
            private set;
        }

        internal void Play()
        {
            SetPlaying(true);
            TutorialBox.Msg = "Loading..";

            new Action(async () =>
            {
                bool exceptionHappened = false;
                try
                {
                    await Story.FindSpellCheckerErrors();
                }
                catch(Elyse.Languagetool.Exception e)
                {
                    exceptionHappened = true;
                    SetPlaying(false);
                    System.Windows.MessageBox.Show("Languagetool: "+e.Message);
                    TutorialBox.Msg = "Sorry but there is a little problem";
                }
                SetPlaying(false);

                if (Story.HasError)
                {
                    TutorialBox.SetMsgFromErrors(Story.SpellCheckerErrors);
                }
                else if(!exceptionHappened)
                {
                    Engine.SceneBuilder.EditStory(Story.Text);
                    Engine.SceneBuilder.Characters = Preview.GetCoreCharacters();
                    Engine.Play();
                    TutorialBox.Msg = "Type your text";
                }
                PlayCommand.TriggerChange();
            }).Invoke();
        }

        private void SetPlaying(bool playing)
        {
            IsPlaying = playing;
            Story.CanEdit = !playing;
        }

        #endregion

        #region Profile
        public ICommand OpenProfileCommand
        {
            get;
            private set;
        }
        private ProfileWindow _profileWindow;
        public void OpenProfileWindow(Models.Character character)
        {
            if (_profileWindow != null)
            {
                _profileWindow.DataContext = new ProfileViewModel(this, character);
                _profileWindow.Focus();
                return;
            }

            if (Preview.CanAddCharacter())
            {
                Preview.CharacterList.Add(new Character());
            }

            if (character.IsEmpty)
            {
                character.Name = "Dummy name";
            }
            _profileWindow = new ProfileWindow();
            _profileWindow.DataContext = new ProfileViewModel(this, character);
            _profileWindow.Closing += OnProfileClose;
            _profileWindow.Show();
        }

        public void OnProfileClose(object sender, CancelEventArgs e)
        {
            _profileWindow = null;
        }
        #endregion

        #region StoryBook
        public ICommand OpenStoryBookCommand
        {
            get;
            private set;
        }
        public StoryBook StoryBook
        {
            get;
            private set;
        }
        private Window _storyBookWindow;
        public void OpenStoryBookWindow()
        {
            if (_storyBookWindow != null)
            {
                _storyBookWindow.Focus();
                return;
            }

            OnStoryBookChange onChange = new OnStoryBookChange(OnStoryBookChange);
            _storyBookWindow = new StoryBookWindow(onChange);
            _storyBookWindow.DataContext = new StoryBookViewModel(this);
            _storyBookWindow.Closing += StoryBookClosing;
            _storyBookWindow.Show();
        }

        public void OnStoryBookChange(string text)
        {
            var file = StoryBook.GetPathFromSubstring(text);
            Story.Text = StoryBook.GetFileContent(file);
            _storyBookWindow.Close();
        }

        public void StoryBookClosing(object sender, CancelEventArgs e)
        {
            _storyBookWindow = null;
        }
        #endregion

        #region Preview
        public Preview Preview
        {
            get;
            private set;
        }
        private int _currentPreviewBackground = 1;

        private ICommand _previousPreviewBackground;
        public ICommand PreviousPreviewBackgroundCommand
        {
            get
            {
                if (_previousPreviewBackground == null)
                {
                    _previousPreviewBackground = new Commands.RelayCommand(
                        param => this.PreviousPreviewBackground(),
                        param => true
                    );
                }
                return _previousPreviewBackground;
            }
        }

        private ICommand _nextPreviewBackground;
        public ICommand NextPreviewBackgroundCommand
        {
            get
            {
                if (_nextPreviewBackground == null)
                {
                    _nextPreviewBackground = new Commands.RelayCommand(
                        param => this.NextPreviewBackground(),
                        param => true
                    );
                }
                return _nextPreviewBackground;
            }
        }

        public void NextPreviewBackground()
        {
            _currentPreviewBackground += 1;
            if (_currentPreviewBackground > (Images.Backgrounds.Count() - 1))
            {
                _currentPreviewBackground = 1;
            }
            Preview.backgroundImage = Images.Backgrounds[_currentPreviewBackground];
            Engine.SceneBuilder.SetBackground((ElyseLibrary.Entities.Background.BackgroundType)_currentPreviewBackground);
        }

        public void PreviousPreviewBackground()
        {
            _currentPreviewBackground -= 1;
            if (_currentPreviewBackground < 1)
            {
                _currentPreviewBackground = 0;
            }
            Preview.backgroundImage = Images.Backgrounds[_currentPreviewBackground];
            Engine.SceneBuilder.SetBackground((ElyseLibrary.Entities.Background.BackgroundType)_currentPreviewBackground);
            System.Diagnostics.Debug.WriteLine(Images.Backgrounds[_currentPreviewBackground]);
        }
        #endregion
    }
}
