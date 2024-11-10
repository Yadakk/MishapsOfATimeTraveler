using MOATT.Levels.Health;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings 
{
    using Billboards;

    public class BuildingInstaller : MonoInstaller
    {
        [SerializeField]
        private HealthModel.Settings healthModelSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(gameObject).AsSingle();
            Container.Bind<Renderer>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInstance(healthModelSettings).AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthbarBillboard>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthWatcher>().AsSingle();
        }
    }
}