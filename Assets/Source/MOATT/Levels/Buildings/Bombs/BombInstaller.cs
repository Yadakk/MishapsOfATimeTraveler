using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Buildings.Bombs
{
    using UnitRange;

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

            Container.BindInstance(settings.UnitRange);
            Container.Install<UnitRangeInstaller>();

            Container.BindInterfacesAndSelfTo<BombTimer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BombExploder>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitRangeInstaller.Settings UnitRange;
        }
    }
}
