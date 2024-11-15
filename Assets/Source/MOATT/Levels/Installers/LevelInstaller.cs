using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace MOATT.Levels.Installers
{
    using Tiles;
    using Enemies;
    using Waves;
    using BillboardGroup;
    using Buildings;
    using BuildingPlacement;
    using InputLogic;

    public class LevelInstaller : MonoInstaller
    {
        private Settings settings;

        [Inject]
        public void Construct(Settings settings)
        {
            this.settings = settings;

            Container.Install<WaveInstaller>();
        }

        public override void InstallBindings()
        {
            InstallMap();
            InstallEnemies();
            InstallMisc();
            InstallBuildingPlacer();
            InstallInputLogic();
        }

        private void InstallMap()
        {
            Container.Bind<Tilemap>().FromComponentInHierarchy().AsSingle();
            Container.Bind<TileFacade>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveStateMachine>().AsSingle();
        }

        private void InstallEnemies()
        {
            Container.BindFactory<EnemyFacade, EnemyFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab(settings.enemyPrefab).
                WithGameObjectName("Enemy").
                UnderTransformGroup("Enemies");
        }

        private void InstallMisc()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BillboardGroupFacade>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallBuildingPlacer()
        {
            Container.BindInterfacesAndSelfTo<BuildingPlacer>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingPlacementInputBinder>().AsSingle();
            Container.BindFactory<Object, BuildingFacade, BuildingFacade.Factory>().
                FromFactory<PrefabFactory<BuildingFacade>>();
        }

        private void InstallInputLogic()
        {
            Container.BindInterfacesAndSelfTo<InteractionModeSwitcher>().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade enemyPrefab;
        }
    }
}
