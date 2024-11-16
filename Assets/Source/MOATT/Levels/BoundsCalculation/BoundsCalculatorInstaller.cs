using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BoundsCalculation
{
    public class BoundsCalculatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Renderer>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BoundsCalculator>().AsSingle();
        }
    }
}
