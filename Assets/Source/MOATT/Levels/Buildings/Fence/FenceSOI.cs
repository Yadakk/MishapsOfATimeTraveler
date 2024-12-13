using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Fence
{
    using Units.Health;

    [CreateAssetMenu(
    fileName = "FenceSOI",
    menuName = "Installers/Buildings/Fence")]
    public class FenceSOI : BuildingSOI
    {
        public UnitHealthInstaller.Settings unitHealth;
        public BuildingUpgrader.Settings buildingUpgrader;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.BindInstance(unitHealth);
            Container.Install<UnitHealthInstaller>();
            Container.BindInterfacesAndSelfTo<FenceUnitBlocker>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingUpgrader>().AsSingle().WithArguments(buildingUpgrader);
        }
    }
}
