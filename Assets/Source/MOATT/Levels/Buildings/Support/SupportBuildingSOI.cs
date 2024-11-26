using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Support
{
    using Units.Damage;
    using UnitRanges;
    using Levels.UnitHealth;

    [CreateAssetMenu(fileName = "SupportBuildingSOI", menuName = "Installers/Buildings/Support")]
    public class SupportBuildingSOI : BuildingSOI
    {
        public SupportBuildingHealer.Settings supportBuildingHealer;
        public UnitDamage.Settings unitDamage;
        public UnitRange.Settings unitRange;
        public UnitHealthInstaller.Settings unitHealth;

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(unitHealth);
            Container.Install<UnitHealthInstaller>();
            Container.Bind<UnitDamage>().AsSingle().WithArguments(unitDamage);
            Container.Bind<UnitRange>().AsSingle().WithArguments(unitRange);
            Container.BindInterfacesAndSelfTo<SupportBuildingHealer>().AsSingle().WithArguments(supportBuildingHealer);
        }
    }
}
