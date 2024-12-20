﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialGreetingState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialCameraState nextState;

        public TutorialGreetingState(TutorialWindow tutorialWindow, TutorialCameraState nextState)
        {
            this.tutorialWindow = tutorialWindow;
            this.nextState = nextState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Welcome to the tutorial.");
            sb.AppendLine("This window can be collapsed with the button on top.");
            sb.AppendLine("Press \"Next\" to proceed to next page.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(nextState));
        }
    }
}
