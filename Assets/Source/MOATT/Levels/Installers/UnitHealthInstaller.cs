using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Installers
{
    using Health;
    using Healthbars;
    using Billboards;

    public class UnitHealthInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(gameObject);
            Container.Bind<Renderer>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthbarBillboard>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthWatcher>().AsSingle();
        }
    }
}
