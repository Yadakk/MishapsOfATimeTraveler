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
        public UnitHealthInstaller.Settings UnitHealth;

        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.BindInstance(UnitHealth);
            Container.Install<UnitHealthInstaller>();
            Container.BindInterfacesAndSelfTo<FenceUnitBlocker>().AsSingle();
        }
    }
}
