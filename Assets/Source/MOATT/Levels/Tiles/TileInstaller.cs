using UnityEngine;
using Zenject;

namespace MOATT.Levels.Tiles
{
    using Buildings;

    public class TileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BuildingFacade>().FromComponentInHierarchy().AsSingle();
        }
    }
}