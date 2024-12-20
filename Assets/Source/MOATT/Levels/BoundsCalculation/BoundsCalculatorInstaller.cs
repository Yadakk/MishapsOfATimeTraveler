﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BoundsCalculation
{
    public class BoundsCalculatorInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<Renderer>().To<MeshRenderer>().FromComponentsInHierarchy().AsSingle();
            Container.BindExecutionOrder<BoundsCalculator>(1);
            Container.BindInterfacesAndSelfTo<BoundsCalculator>().AsSingle();
        }
    }
}
