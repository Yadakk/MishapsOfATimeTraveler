﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.TubableFactories;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using MOATT.Levels.Units.Damage;
    using MOATT.Levels.Units.ReloadTime;
    using Units.Health;
    using Units.Range;

    public class TurretInstaller : BuildingInstaller
    {
        private readonly Settings settings;

        public TurretInstaller(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.BindInstance(settings.unitHealth);
            Container.Install<UnitHealthInstaller>();

            Container.BindInstance(settings.unitRange);
            Container.Install<UnitRangeInstaller>();

            Container.Bind<UnitReloadTime>().AsSingle();
            Container.Bind<UnitDamage>().AsSingle();

            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentsInHierarchy().AsSingle();
            Container.BindFactory<Object, BulletTunables, BulletFacade, BulletFacade.Factory>().
                FromIFactory(x => x.To<TunablePrefabFactory<BulletTunables, BulletFacade>>().
                AsSingle().WithArguments("Bullets"));

            Container.BindInterfacesAndSelfTo<BuildingUpgrader>().AsSingle().WithArguments(settings.buildingUpgrader);
        }

        [System.Serializable]
        public class Settings
        {
            public UnitHealthInstaller.Settings unitHealth;
            public UnitRangeInstaller.Settings unitRange;
            public BuildingUpgrader.Settings buildingUpgrader;
        }
    }
}
