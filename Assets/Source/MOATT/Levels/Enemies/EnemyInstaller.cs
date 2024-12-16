using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Units.Health;
    using Units.Damage;
    using MOATT.Levels.Billboards;
    using MOATT.Levels.BoundsCalculation;

    public class EnemyInstaller : Installer
    {
        private readonly Settings settings;

        public EnemyInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.Install<BoundsCalculatorInstaller>();

            Container.BindInstance(settings.facade);
            Container.Bind<EnemyFacade>().FromComponentOnRoot().AsSingle();

            Container.BindInstance(settings.unitHealthSettings);
            Container.Install<UnitHealthInstaller>();

            Container.BindInstance(settings.unitDamage);
            Container.Bind<UnitDamage>().AsSingle();

            Container.BindInstance(settings.towerDamager).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTowerDamager>().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTilemapPositionCalculator>().AsSingle();

            Container.BindInstance(settings.enemyPathfinder);
            Container.BindInterfacesAndSelfTo<EnemyPathfinder>().AsSingle();

            Container.BindInstance(settings.deathHandler).AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyDeathHandler>().AsSingle();

            Container.BindInstance(settings.reloader);
            Container.BindInterfacesAndSelfTo<EnemyReloader>().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyFenceAttacker>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();

            Container.BindInterfacesAndSelfTo<EnemyPathHistory>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade.Settings facade;
            public UnitHealthInstaller.Settings unitHealthSettings;
            public EnemyPathfinder.Settings enemyPathfinder;
            public UnitDamage.Settings unitDamage;
            public EnemyReloader.Settings reloader;
            public EnemyTowerDamager.Settings towerDamager;
            public EnemyDeathHandler.Settings deathHandler;
        }
    }
}
