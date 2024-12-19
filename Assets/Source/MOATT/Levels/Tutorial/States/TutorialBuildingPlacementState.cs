using MOATT.Levels.BuildingPlacement;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialBuildingPlacementState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly BuildingPlacementPlacer buildingPlacer;
        private readonly TutorialBuildingTypesState tutorialBuildingTypesState;

        public TutorialBuildingPlacementState(TutorialWindow tutorialWindow, BuildingPlacementPlacer buildingPlacer, TutorialBuildingTypesState tutorialBuildingTypesState)
        {
            this.tutorialWindow = tutorialWindow;
            this.buildingPlacer = buildingPlacer;
            this.tutorialBuildingTypesState = tutorialBuildingTypesState;
        }

        public override void Start()
        {
            buildingPlacer.OnBuildingPlaced += StepComplete;
            tutorialWindow.SetActiveNextButton(false);

            StringBuilder sb = new();
            sb.AppendLine("To protect your main tower you can place buildings.");
            sb.AppendLine("Click buttons in the left bottom corner to enter build mode.");
            sb.AppendLine("Then hover your mouse over a tile to place it.");
            sb.AppendLine("If building hologram becomes green, you're placing on the right tile.");
            sb.AppendLine("To exit building mode press the building button again or C on your keyboard.");
            sb.AppendLine("Place a building to proceed to next step.");
            tutorialWindow.SetTextContent(sb.ToString());
        }

        public override void Dispose()
        {
            buildingPlacer.OnBuildingPlaced -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialBuildingTypesState));
        }
    }
}
