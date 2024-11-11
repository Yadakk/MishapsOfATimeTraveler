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
                FromComponentInNewPrefab(settings.enemyPrefab).
                WithGameObjectName("Enemy").
                UnderTransformGroup("Enemies");
        }

        private void InstallMisc()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BillboardGroupFacade>().FromComponentInHierarchy().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade enemyPrefab;
        }
    }
}
