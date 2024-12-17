using MOATT.Levels.Waves;
using MOATT.Levels.Waves.States;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialEnemiesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialEnemyTypesState tutorialEnemyTypesState;

        public TutorialEnemiesState(TutorialWindow tutorialWindow, TutorialEnemyTypesState tutorialEnemyTypesState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialEnemyTypesState = tutorialEnemyTypesState;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("There are 5 types of enemies.");
            sb.AppendLine("They follow a random path to your main tower and start damaging it.");
            sb.AppendLine("If main tower is destroyed, level is lost.");
            sb.AppendLine("Enemy types are described on the next page.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialEnemyTypesState));
        }
    }
}
