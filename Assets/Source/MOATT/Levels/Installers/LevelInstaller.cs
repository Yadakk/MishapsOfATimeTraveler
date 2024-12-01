using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using HologramDisplayers;

namespace MOATT.Levels.Installers
{
    using Tiles;
    using Waves;
    using BillboardGroup;
    using BuildingPlacement;
    using UnitRanges;
    using TilemapSizeMultipliers;
    using Buildings;
    using TransformGrouping;

    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<WaveInstaller>();
            Container.Install<BuildingPlacementInstaller>();
            InstallMap();
            InstallMisc();
        }

        private void InstallMap()
        {
            Container.Bind<Tilemap>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TilemapSizeMultiplier>().AsSingle();
            Container.Bind<TileFacade>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<TileRaycaster>().AsSingle();
            Container.Bind<BuildingRegistry>().AsSingle();
        }

        private void InstallMisc()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<RTS_Cam.RTS_Camera>().FromComponentInHierarchy().AsSingle();

            Container.BindInterfacesAndSelfTo<LevelCamera.RTSCameraRotater>().AsSingle();

            Container.Bind<BillboardGroupFacade>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HologramDisplayer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UnitRangeHologram>().FromComponentInHierarchy().AsSingle();
            Container.Bind<RootTransformGrouper>().AsSingle();
        }
    }
}
