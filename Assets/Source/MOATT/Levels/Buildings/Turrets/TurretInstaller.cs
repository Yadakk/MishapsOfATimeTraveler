using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.Factories;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using Levels.UnitHealth;

    public class TurretInstaller : BuildingInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            Container.Install<UnitHealthInstaller>();

            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<Object, BulletTunables, BulletFacade, BulletFacade.Factory>().
                FromFactory<TunablePrefabFactory<BulletTunables, BulletFacade>>();
        }
    }
}
