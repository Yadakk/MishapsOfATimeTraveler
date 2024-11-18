using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings
{
    using Tiles;

    public class BuildingInstaller : MonoInstaller
    {
        private TileBuilding initTile;

        [Inject]
        public void Construct(TileBuilding initTile)
        {
            this.initTile = initTile;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(initTile).WhenInjectedInto<BuildingFacade>();
            Container.Bind<BuildingFacade>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingDeathHandler>().AsSingle();
        }
    }
}
