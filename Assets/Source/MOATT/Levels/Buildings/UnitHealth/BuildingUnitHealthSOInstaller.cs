using MOATT.Levels.Installers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.UnitHealth
{
    using Levels.UnitHealth;

    [CreateAssetMenu(
    fileName = "BuildingUnitHealthInstaller",
    menuName = "Installers/Buildings/UnitHealth")]
    public class BuildingUnitHealthSOInstaller : UnitHealthSOInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInterfacesAndSelfTo<BuildingDeathHandler>().AsSingle();
        }
    }
}
