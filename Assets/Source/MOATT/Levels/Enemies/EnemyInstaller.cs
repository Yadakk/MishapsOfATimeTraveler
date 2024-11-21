using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Enemies
{
    using Installers;

    public class EnemyInstaller : MonoInstaller
    {
        private Vector3 initPos;

        [Inject]
        public void Construct(Vector3 initPos)
        {
            this.initPos = initPos;
        }

        public override void InstallBindings()
        {
            Container.Install<UnitHealthInstaller>();

            Container.BindInstance(initPos).WhenInjectedInto<EnemyFacade>();
            Container.Bind<EnemyFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTowerDamager>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyRotater>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyTilemapPositionCalculator>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyPathfinder>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyDeathHandler>().AsSingle();
        }
    }
}
