using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialBuildingTriviaState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialEnemiesState nextState;

        public TutorialBuildingTriviaState(TutorialWindow tutorialWindow, TutorialEnemiesState nextState)
        {
            this.tutorialWindow = tutorialWindow;
            this.nextState = nextState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Once you have placed the building, the recharge timer on its button will show up.");
            sb.AppendLine("You can't place this building while it's recharging.");
            sb.AppendLine("Also if you don't have enough Nuts and Bolts, the main currency, you can't place this building either.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(nextState));
        }
    }
}
