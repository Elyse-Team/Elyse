using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseGUI.Models;
using System.Windows.Input;

namespace ElyseGUI.ViewModels
{
    internal class MainViewModel
    {
        public Story story
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
        public MainViewModel()
        {
            story = new Story();
            tutorialBox = new TutorialBox();
            PlayCommand = new Commands.PlayCommand(this);
            tutorialBox.msg = "Type your text";
            setPlaying(false);
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

        
    }
}
