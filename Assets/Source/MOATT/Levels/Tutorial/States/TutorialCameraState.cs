using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialCameraState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialTooltipState nextState;

        public TutorialCameraState(TutorialWindow tutorialWindow, TutorialTooltipState nextState)
        {
            this.tutorialWindow = tutorialWindow;
            this.nextState = nextState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Here are camera controls:");
            sb.AppendLine("Middle mouse button or WASD to pan.");
            sb.AppendLine("Right click or Z/X to rotate.");
            sb.AppendLine("Mouse scroll or E/Q to move up and down.");
            sb.AppendLine("Left click is used for interaction.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(nextState));
        }
    }
}
