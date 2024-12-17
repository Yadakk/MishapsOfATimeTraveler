using MOATT.Levels.Waves;
using MOATT.Levels.Waves.States;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MOATT.Levels.Tutorial.States
{
    public class TutorialEnemyTypesState : TutorialState
    {
        private readonly TutorialWindow tutorialWindow;
        private readonly TutorialBuildingPlacementState tutorialBuildingPlacementState;
        private readonly WaveStateMachine waveStateMachine;

        public TutorialEnemyTypesState(TutorialWindow tutorialWindow, TutorialBuildingPlacementState tutorialBuildingPlacementState, WaveStateMachine waveStateMachine)
        {
            this.tutorialWindow = tutorialWindow;
            this.tutorialBuildingPlacementState = tutorialBuildingPlacementState;
            this.waveStateMachine = waveStateMachine;
        }

        public override void Start()
        {
            StringBuilder sb = new();
            sb.AppendLine("Regular - just moves to main tower.");
            sb.AppendLine("Heavy - slow but more health and attack.");
            sb.AppendLine("Destroyer - stops to attack buildings you placed.");
            sb.AppendLine("Helicopter - attacks your buildings without stopping. Once it reaches your main tower, deals damage equivalent to it's health and disappears.");
            sb.AppendLine("Jumper - fast and weak. Can jump over fences once.");
            tutorialWindow.SetTextContent(sb.ToString());
            tutorialWindow.SetNextButtonEvent(() => tutorialWindow.SetState(tutorialBuildingPlacementState));
        }

        public override void Dispose()
        {
            waveStateMachine.SetState<Delay>();
        }
    }
}
