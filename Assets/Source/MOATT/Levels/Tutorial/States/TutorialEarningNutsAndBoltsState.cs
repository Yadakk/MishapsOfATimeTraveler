using MOATT.Levels.Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialEarningNutsAndBoltsState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly EnemyRegistry enemyRegistry;
        private readonly TutorialScientistsState tutorialScientistsState;

        public TutorialEarningNutsAndBoltsState(TutorialWindow tutorialWindow, EnemyRegistry enemyRegistry, TutorialScientistsState tutorialScientistsState)
        {
            this.tutorialWindow = tutorialWindow;
            this.enemyRegistry = enemyRegistry;
            this.tutorialScientistsState = tutorialScientistsState;
        }

        public override void Start()
        {
            enemyRegistry.OnEnemyDied += StepComplete;
            tutorialWindow.SetActiveNextButton(false);

            StringBuilder sb = new();
            sb.AppendLine("To earn Nuts and Bolts you need to defeat enemies with your buildings.");
            sb.AppendLine("Defeat an enemy to proceed.");
            tutorialWindow.SetTextContent(sb.ToString());
        }

        public override void Dispose()
        {
            enemyRegistry.OnEnemyDied -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialScientistsState));
        }
    }
}
