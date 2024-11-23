using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using UnitHealth;

    public class EnemyInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Install<UnitHealthInstaller>();

            Container.Bind<EnemyFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTowerDamager>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTilemapPositionCalculator>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyPathfinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyDeathHandler>().AsSingle();
        }
    }
}
