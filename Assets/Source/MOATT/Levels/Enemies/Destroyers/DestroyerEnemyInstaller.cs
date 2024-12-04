using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies.Destroyers
{
    using Units.Range;

    public class DestroyerEnemyInstaller : Installer
    {
        private readonly Settings settings;

        public DestroyerEnemyInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(settings.unitRangeInstaller);
            Container.Install<UnitRangeInstaller>();
            Container.BindInstance(settings.destroyerEnemyAttacker);
            Container.BindInterfacesAndSelfTo<DestroyerEnemyAttacker>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitRangeInstaller.Settings unitRangeInstaller;
            public DestroyerEnemyAttacker.Settings destroyerEnemyAttacker;
        }
    }
}
