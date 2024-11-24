using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.Factories;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using Levels.UnitHealth;
    using UnitRange;

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

            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<Object, BulletTunables, BulletFacade, BulletFacade.Factory>().
                FromFactory<TunablePrefabFactory<BulletTunables, BulletFacade>>();
        }

        [System.Serializable]
        public class Settings
        {
            public UnitHealthInstaller.Settings unitHealth;
            public UnitRangeInstaller.Settings unitRange;
        }
    }
}
