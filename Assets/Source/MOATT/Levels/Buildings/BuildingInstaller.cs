using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using UnitHealth;

    public class BuildingInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<BuildingFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingDeathHandler>().AsSingle();
        }
    }
}
