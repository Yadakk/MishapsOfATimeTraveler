using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialBuildingTypesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialBuildingTriviaState tutorialBuildingTriviaState;

        public TutorialBuildingTypesState(TutorialWindow tutorialWindow, TutorialBuildingTriviaState tutorialBuildingTriviaState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialBuildingTriviaState = tutorialBuildingTriviaState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("There are 5 building types you can place:");
            sb.AppendLine("Turret - shoots bullets at enemies, can be placed on slots only.");
            sb.AppendLine("Spikes - damages non flying enemies that step on its tile, can be placed on roads only.");
            sb.AppendLine("Bomb - explodes one time, dealing damage to all enemies in range, can be placed on roads only.");
            sb.AppendLine("Support tower - heals all building in range, can be placed on slots only.");
            sb.AppendLine("Fence - blocks non flying enemies, can be placed on roads only. Jumpers can jump over fence once.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialBuildingTriviaState));
        }
    }
}
