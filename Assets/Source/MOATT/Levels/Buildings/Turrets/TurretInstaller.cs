using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using InstallerParamFactories;

    public class TurretInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TurretTargetPicker>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurretReloader>().AsSingle();
            Container.Bind<TurretShooter>().FromComponentInHierarchy().AsSingle();
            Container.BindFactory<Object, BulletTunables, BulletFacade, BulletFacade.Factory>().
                FromFactory<TunablePrefabFactory<BulletTunables, BulletFacade>>();
        }
    }
}
