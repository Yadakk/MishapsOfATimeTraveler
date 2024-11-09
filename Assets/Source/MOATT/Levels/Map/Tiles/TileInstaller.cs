using UnityEngine;
using Zenject;

namespace MOATT.Levels.Map.Tiles
{
    using Buildings;

    public class TileInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Building>().FromComponentInHierarchy().AsSingle();
        }
    }
}