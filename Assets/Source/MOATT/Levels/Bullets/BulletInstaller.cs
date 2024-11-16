using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    public class BulletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BulletFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletDistanceWatcher>().AsSingle();
            Container.BindInterfacesAndSelfTo<BulletTargetFollower>().AsSingle();
        }
    }
}
