using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Support
{
    using MOATT.Levels.Units.ReloadTime;
    using Units.Damage;
    using Units.Health;
    using Units.Range;

    [CreateAssetMenu(fileName = "SupportBuildingSOI", menuName = "Installers/Buildings/Support")]
    public class SupportBuildingSOI : BuildingSOI
    {
        public UnitReloadTime.Settings unitReloadTime;
        public UnitDamage.Settings unitDamage;
        public UnitRange.Settings unitRange;
        public UnitHealthInstaller.Settings unitHealth;
        public BuildingUpgrader.Settings buildingUpgrader;
        public SupportBuildingHealer.Settings supportBuildingHealer;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(unitHealth);
            Container.Install<UnitHealthInstaller>();
            Container.Bind<UnitDamage>().AsSingle().WithArguments(unitDamage);
            Container.Bind<UnitRange>().AsSingle().WithArguments(unitRange);
            Container.Bind<UnitReloadTime>().AsSingle().WithArguments(unitReloadTime);
            Container.BindInterfacesAndSelfTo<SupportBuildingHealer>().AsSingle().WithArguments(supportBuildingHealer);
            Container.BindInterfacesAndSelfTo<BuildingUpgrader>().AsSingle().WithArguments(buildingUpgrader);
        }
    }
}
