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
            Container.BindInterfacesAndSelfTo<EnemyPathfinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTowerDamager>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotater>().AsSingle();
        }
    }
}
