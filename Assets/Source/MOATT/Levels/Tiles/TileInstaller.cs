using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    public class TileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<TileFacade>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TileBuilding>().AsSingle();
            Container.Bind<TileCell>().AsSingle();
        }
    }
}