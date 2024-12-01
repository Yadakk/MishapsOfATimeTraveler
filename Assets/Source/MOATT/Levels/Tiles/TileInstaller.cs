using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TileFacade>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BuildingFacade>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TileBuilding>().AsSingle();
            Container.BindInterfacesAndSelfTo<TileCell>().AsSingle();
        }
    }
}