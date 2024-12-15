using MOATT.Tooltips;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialTooltipState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly Tooltip tooltip;
        private readonly TutorialEnemiesState tutorialEnemiesState;

        public TutorialTooltipState(TutorialWindow tutorialWindow, Tooltip tooltip, TutorialEnemiesState tutorialEnemiesState)
        {
            this.tutorialWindow = tutorialWindow;
            this.tooltip = tooltip;
            this.tutorialEnemiesState = tutorialEnemiesState;
        }

        public override void Start()
        {
            tooltip.OnShown += StepComplete;

            StringBuilder sb = new();
            sb.AppendLine("There are tooltips that display information about certain mechanics in the game.");
            sb.AppendLine("Try hovering over some UI elements.");
            sb.AppendLine("The \"Next\" button will appear once you have displayed the tooltip.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetActiveNextButton(false);
        }

        public override void Dispose()
        {
            tooltip.OnShown -= StepComplete;
        }

        private void StepComplete()
        {
            tutorialWindow.SetActiveNextButton(true);
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialEnemiesState));
        }
    }
}
