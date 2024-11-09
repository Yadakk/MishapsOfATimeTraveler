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
            Container.Bind<Renderer>().FromComponentsInHierarchy().AsSingle();
            Container.BindInstance(healthModelSettings).AsSingle();
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthbarBillboard>().AsSingle();
        }
    }
}