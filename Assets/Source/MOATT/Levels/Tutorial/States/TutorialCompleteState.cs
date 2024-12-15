using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialCompleteState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;

        public TutorialCompleteState(TutorialWindow tutorialWindow)
        {
            this.tutorialWindow = tutorialWindow;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("That's pretty much of all mechanics of the game.");
            sb.AppendLine("You can still play on this level or quit and select another one in the selection menu.");
            sb.AppendLine("Good luck!");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetActiveNextButton(false);
        }
    }
}
