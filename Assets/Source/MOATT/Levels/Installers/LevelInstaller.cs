using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Installers
{
    using Map.Tiles;
    using Enemies;
    using Waves;
    using Health;
    using Healthbars;
    using Billboards;

    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform billboardGroup;

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
            InstallBillboards();
        }

        private void InstallMap()
        {
            Container.Bind<Tilemap>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Tile>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveStateMachine>().AsSingle();
        }

        private void InstallEnemies()
        {
            Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(settings.EnemyPrefab).
                WithGameObjectName("Enemy").UnderTransformGroup("Enemies");
        }

        private void InstallBillboards()
        {
            Container.BindFactory<BillboardSource, BillboardFacade, BillboardFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<BillboardInstaller>(settings.BillboardPrefab).
                WithGameObjectName("Billboard").
                UnderTransform(billboardGroup);

            Container.BindFactory<HealthModel, HealthbarFacade, HealthbarFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<HealthbarInstaller>(settings.HealthbarPrefab).
                WithGameObjectName("Healthbar");
        }

        private void InstallMisc()
        {
            Container.Bind<Timer>().AsTransient();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField]
            public Enemy EnemyPrefab { get; private set; }

            [field: SerializeField]
            public GameObject HealthbarPrefab { get; private set; }

            [field: SerializeField]
            public GameObject BillboardPrefab { get; internal set; }
        }
    }
}
