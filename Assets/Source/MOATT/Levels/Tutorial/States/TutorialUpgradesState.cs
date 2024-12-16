using MOATT.Levels.Buildings;
using MOATT.Levels.Economics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialUpgradesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly BuildingRegistry buildingRegistry;
        private readonly TutorialWinConditionsState tutorialWinConditionsState;

        public TutorialUpgradesState(TutorialWindow tutorialWindow, BuildingRegistry buildingRegistry, TutorialWinConditionsState tutorialWinConditionsState)
        {
            this.tutorialWindow = tutorialWindow;
            this.buildingRegistry = buildingRegistry;
            this.tutorialWinConditionsState = tutorialWinConditionsState;
        }

        public override void Start()
        {
            buildingRegistry.OnBuildingUpgraded += StepComplete;
            tutorialWindow.SetActiveNextButton(false);

            StringBuilder sb = new();
            sb.AppendLine("You can upgrade your buildings.");
            sb.AppendLine("Click on it when not in building mode and press on arrow button above it.");
            sb.AppendLine("Tooltips will show the costs and new building stats after upgrade.");
            sb.AppendLine("You will temporarily send some of your scientists to upgrade it.");
            sb.AppendLine("If building is destroyed during upgrade, the scientists are lost.");
            sb.AppendLine("Upgrade any building to proceed.");
            tutorialWindow.SetTextContent(sb.ToString());
        }

        public override void Dispose()
        {
            buildingRegistry.OnBuildingUpgraded -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialWinConditionsState));
        }
    }
}
