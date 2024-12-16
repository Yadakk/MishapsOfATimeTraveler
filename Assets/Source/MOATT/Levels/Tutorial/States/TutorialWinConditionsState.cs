using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialWinConditionsState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialCompleteState tutorialCompleteState;

        public TutorialWinConditionsState(TutorialWindow tutorialWindow, TutorialCompleteState tutorialCompleteState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialCompleteState = tutorialCompleteState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("The progress bar on top right shows the progress of the mission.");
            sb.AppendLine("If you survive long enough you will win.");
            sb.AppendLine("The waves get stronger every time so keep advancing.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialCompleteState));
        }
    }
}
