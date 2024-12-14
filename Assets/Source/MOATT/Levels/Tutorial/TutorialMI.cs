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
            Container.BindInterfacesAndSelfTo<TutorialGreetingState>().AsSingle();
            Container.BindInterfacesAndSelfTo<TutorialTooltipState>().AsSingle();
        }
    }
}
