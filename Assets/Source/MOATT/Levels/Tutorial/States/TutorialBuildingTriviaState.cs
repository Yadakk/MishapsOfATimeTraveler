using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialBuildingTriviaState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialEarningNutsAndBoltsState tutorialEarningNutsAndBoltsState;

        public TutorialBuildingTriviaState(TutorialWindow tutorialWindow, TutorialEarningNutsAndBoltsState tutorialEarningNutsAndBoltsState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialEarningNutsAndBoltsState = tutorialEarningNutsAndBoltsState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Once you have placed the building, the recharge timer on it's button will show up.");
            sb.AppendLine("You can't place this building while it's recharging.");
            sb.AppendLine("Also if you don't have enough Nuts and Bolts, the main currency, you can't place this building either.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialEarningNutsAndBoltsState));
        }
    }
}
