using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseGUI.Models;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace ElyseGUI.ViewModels
{
    internal class MainViewModel
    {
        public Story story
        {
            get;
            private set;
        }

        public StoryBook storyBook
        {
            get;
            private set;
        }

        public Preview preview
        {
            get;
            private set;
        }

        public TutorialBox tutorialBox
        {
            get;
            private set;
        }

        public bool isPlaying { get; private set; }

        public Commands.PlayCommand PlayCommand
        {
            get;
            private set;
        }



        public List<Models.Character> CharacterList
        {
            get;
            private set;
        }


        public MainViewModel()
        {
            story = new Story();
            storyBook = new StoryBook();
            tutorialBox = new TutorialBox();
            preview = new Preview();

            PlayCommand = new Commands.PlayCommand(this);
            OpenProfileCommand = new Commands.OpenProfileCommand(this);
            OpenStoryBookCommand = new Commands.OpenStoryBookCommand(this);

            tutorialBox.msg = "Type your text";
            setPlaying(false);

            CharacterList = new List<Models.Character>();
            CharacterList.Add(new Models.Character());
            CharacterList.Add(new Models.Character());
            CharacterList.Add(new Models.Character());
        }

        public bool CanPlayStory { 
            get {
                return story.canPlay;
            } 
        }

        internal void Play()
        {
            System.Diagnostics.Debug.WriteLine("playing start ==========================================");
            setPlaying(true);
            tutorialBox.msg = "Loading..";

            new Action(async () =>
            {
                System.Diagnostics.Debug.WriteLine("checking start");
                try
                {
                    await story.FindSpellCheckerErrors();
                }
                catch(Elyse.Languagetool.Exception e)
                {
                    System.Windows.MessageBox.Show("Languagetool: "+e.Message);
                    System.Diagnostics.Debug.WriteLine("Languagetool exception: "+e.Message);
                    tutorialBox.msg = "Sorry but there is a little problem";
                }
                setPlaying(false);
                System.Diagnostics.Debug.WriteLine("checking done ");

               // tutorialBox.msg = story.hasError ? "Have errors !!!" : "no errors!";
                if(story.hasError)
                {
                    tutorialBox.SetMsgFromErrors(story.spellCheckerErrors);
                }
                PlayCommand.TriggerChange();
            }).Invoke();
        }

        private void setPlaying(bool playing)
        {
            isPlaying = playing;
            story.canEdit = !playing;
        }

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
                _profileWindow.Focus();
                return;
            }

            _profileWindow = new ProfileWindow();
            _profileWindow.DataContext = new ProfileViewModel(this, character);
            _profileWindow.Show();
        }


        public ICommand OpenStoryBookCommand
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
            OnStoryBookClose onClose = new OnStoryBookClose(OnStoryBookClose);

            _storyBookWindow = new StoryBookWindow(onChange, onClose);
            _storyBookWindow.DataContext = new StoryBookViewModel();
            _storyBookWindow.Show();
        }

        public void OnStoryBookChange(string text)
        {
            var file = storyBook.GetPathFromSubstring(text);
            story.text = storyBook.GetFileContent(file);
            _storyBookWindow.Close();
        }

        public void OnStoryBookClose()
        {
            _storyBookWindow = null;
        }

        public void Closing(object sender, CancelEventArgs e)
        {            
            if(!story.isEmpty && !storyBook.IsExists(story))
            {
                storyBook.Save(story);
            }
        }
    }
}
