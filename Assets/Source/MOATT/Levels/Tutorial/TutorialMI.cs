﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tutorial
{
    using States;

    public class TutorialMI : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TutorialStateInitter>().AsSingle();
            BindTutorialState<TutorialGreetingState>();
            BindTutorialState<TutorialTooltipState>();
            BindTutorialState<TutorialEnemiesState>();
            BindTutorialState<TutorialEnemyTypesState>();
            BindTutorialState<TutorialBuildingPlacementState>();
            BindTutorialState<TutorialBuildingTypesState>();
            BindTutorialState<TutorialBuildingTriviaState>();
            BindTutorialState<TutorialEarningNutsAndBoltsState>();
            BindTutorialState<TutorialScientistsState>();
            BindTutorialState<TutorialUpgradesState>();
            BindTutorialState<TutorialWinConditionsState>();
            BindTutorialState<TutorialCompleteState>();
        }

        private void BindTutorialState<T>() where T : TutorialState
        {
            Container.BindInterfacesAndSelfTo<T>().AsSingle();
        }
    }
}