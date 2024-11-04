using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Enemies;

namespace MOATT.Zenject
{
    public class EnemyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(transform).AsSingle();
            Container.Bind<MapNavigator>().AsSingle();
        }
    }
}
