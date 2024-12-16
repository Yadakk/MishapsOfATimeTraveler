using MOATT.Levels.Tutorial.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tutorial
{
    public class TutorialStateInitter : IInitializable
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialGreetingState greetingState;

        public TutorialStateInitter(TutorialWindow tutorialWindow, TutorialGreetingState greetingState)
        {
            this.tutorialWindow = tutorialWindow;
            this.greetingState = greetingState;
        }

        public void Initialize()
        {
            tutorialWindow.SetState(greetingState);
        }
    }
}
