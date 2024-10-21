using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MishapsOfATimeTraveler.GameAssembly
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
