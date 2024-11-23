using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using TransformGrouping;
using HologramDisplayers;

namespace MOATT.Levels.Installers
{
    using Tiles;
    using Enemies;
    using Waves;
    using BillboardGroup;
    using BuildingPlacement;
    using UnitRange;

    public class LevelInstaller : MonoInstaller
    {
        private Settings settings;
        private TransformGrouper transformGrouper;

        private void Awake()
        {
            transformGrouper = Container.Resolve<TransformGrouper>();
        }

        [Inject]
        public void Construct(Settings settings)
        {
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.Install<WaveInstaller>();
            Container.Install<BuildingPlacementInstaller>();
            InstallMap();
            InstallEnemies();
            InstallMisc();
        }

        private void InstallMap()
        {
            Container.Bind<Tilemap>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TileFacade>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<TileRaycaster>().AsSingle();
        }

        private void InstallEnemies()
        {
            Container.BindFactory<Vector3, EnemyFacade, EnemyFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<EnemyInstaller>(settings.enemyPrefab).
                UnderTransform(context => transformGrouper.GetGroup("Enemies"));
        }

        private void InstallMisc()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BillboardGroupFacade>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HologramDisplayer>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UnitRangeHologram>().FromComponentInHierarchy().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade enemyPrefab;
        }
    }
}
