using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MOATT.Levels.Enemies;

namespace MOATT.Levels.Enemies
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
