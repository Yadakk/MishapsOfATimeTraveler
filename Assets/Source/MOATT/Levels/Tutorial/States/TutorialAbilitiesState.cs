using MOATT.Abilities;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialAbilitiesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly LevelAbility levelAbility;
        private readonly TutorialCompleteState tutorialCompleteState;

        public TutorialAbilitiesState(TutorialWindow tutorialWindow, LevelAbility levelAbility, TutorialCompleteState tutorialCompleteState)
        {
            this.tutorialWindow = tutorialWindow;
            this.levelAbility = levelAbility;
            this.tutorialCompleteState = tutorialCompleteState;
        }

        public override void Start()
        {
            levelAbility.OnAbilityActivated += StepComplete;
            tutorialWindow.SetActiveNextButton(false);

            StringBuilder sb = new();
            sb.AppendLine("You can select an ability in bottom right corner in level selection menu.");
            sb.AppendLine("Each ability has a recharge time which can be reduced with idle scientists.");
            sb.AppendLine("To see what ability does you can hover over it in level selection or during gameplay.");
            sb.AppendLine("Some abilities have green bar which appears after use. This is duration of its effect.");
            sb.AppendLine("To proceed, use your ability using button in bottom right corner");
            tutorialWindow.SetTextContent(sb.ToString());
        }

        public override void Dispose()
        {
            levelAbility.OnAbilityActivated -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialCompleteState));
        }
    }
}
