using MOATT.Levels.Billboards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Health
{
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthModel.Settings healthModelSettings;

        public override void InstallBindings()
        {
            Container.Bind<Renderer>().FromComponentsInHierarchy().AsSingle();
            Container.BindInstance(gameObject);
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInstance(healthModelSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthbarBillboard>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthWatcher>().AsSingle();
        }
    }
}
