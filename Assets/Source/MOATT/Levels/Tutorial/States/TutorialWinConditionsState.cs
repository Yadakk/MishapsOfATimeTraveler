using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialWinConditionsState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialAbilitiesState tutorialAbilitiesState;

        public TutorialWinConditionsState(TutorialWindow tutorialWindow, TutorialAbilitiesState tutorialAbilitiesState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialAbilitiesState = tutorialAbilitiesState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("The progress bar on top right shows the progress of the mission.");
            sb.AppendLine("If you survive long enough you will win.");
            sb.AppendLine("The waves get stronger every time so keep building your defences.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialAbilitiesState));
        }
    }
}
