using MOATT.Levels.Economics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialScientistsState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly ScientistBuyerVM scientistBuyerVM;
        private readonly TutorialUpgradesState tutorialUpgradesState;

        public TutorialScientistsState(TutorialWindow tutorialWindow, ScientistBuyerVM scientistBuyerVM, TutorialUpgradesState tutorialUpgradesState)
        {
            this.tutorialWindow = tutorialWindow;
            this.scientistBuyerVM = scientistBuyerVM;
            this.tutorialUpgradesState = tutorialUpgradesState;
        }

        public override void Start()
        {
            scientistBuyerVM.OnScientistHired += StepComplete;
            tutorialWindow.SetActiveNextButton(false);

            StringBuilder sb = new();
            sb.AppendLine("Scientists are second resource in the game.");
            sb.AppendLine("When idle, scientists decrease charge time for buildings and abilities.");
            sb.AppendLine("You can also use them to upgrade your buildings.");
            sb.AppendLine("There is a maximum amount of scientists you can have.");
            sb.AppendLine("Hire a scientist to proceed.");
            tutorialWindow.SetTextContent(sb.ToString());
        }

        public override void Dispose()
        {
            scientistBuyerVM.OnScientistHired -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialUpgradesState));
        }
    }
}
