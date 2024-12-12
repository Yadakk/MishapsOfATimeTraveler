using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    using MOATT.Levels.Units.Damage;
    using MOATT.Levels.Units.ReloadTime;
    using Units.Range;

    public class BombInstaller : BuildingInstaller
    {
        private readonly Settings settings;

        public BombInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Bind<UnitDamage>().AsSingle();

            Container.BindInstance(settings.UnitRange);
            Container.Install<UnitRangeInstaller>();

            Container.BindInterfacesAndSelfTo<BombTimer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BombExploder>().AsSingle();
            Container.Bind<UnitReloadTime>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitRangeInstaller.Settings UnitRange;
        }
    }
}
