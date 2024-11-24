using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.UnitRanges
{
    public class UnitRangeInstaller : Installer
    {
        private readonly Settings settings;

        public UnitRangeInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(settings.unitRange);
            Container.Bind<UnitRange>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitRange.Settings unitRange;
        }
    }
}
