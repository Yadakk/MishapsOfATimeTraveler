using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using MOATT.Levels.Billboards;
    using MOATT.Levels.BoundsCalculation;
    using UnitHealth;

    public class BuildingInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Install<BoundsCalculatorInstaller>();
            Container.Bind<BuildingFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingDeathHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
        }
    }
}
