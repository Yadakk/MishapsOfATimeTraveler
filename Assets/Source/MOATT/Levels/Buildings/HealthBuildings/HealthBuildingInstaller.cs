using MOATT.Levels.Installers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.HealthBuildings
{
    public class HealthBuildingInstaller : BuildingInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Install<UnitHealthInstaller>();

            Container.BindInterfacesAndSelfTo<BuildingDeathHandler>().AsSingle();
        }
    }
}
