using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using UnitHealth;
    using Health;

    public class EnemyInstaller : Installer
    {
        private readonly Settings settings;

        public EnemyInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(settings.unitHealthSettings);
            Container.Install<UnitHealthInstaller>();

            Container.Bind<EnemyFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTowerDamager>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTilemapPositionCalculator>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyPathfinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyDeathHandler>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitHealthInstaller.Settings unitHealthSettings;
        }
    }
}
