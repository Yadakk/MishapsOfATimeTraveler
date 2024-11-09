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
            Container.BindFactory< BillboardSource, Transform, Billboard, Billboard.Factory>();

            Container.BindFactory<HealthModel, Healthbar, Healthbar.Factory>().
                FromComponentInNewPrefab(settings.HealthbarPrefab).
                WithGameObjectName("Healthbar").UnderTransform(billboardGroup);
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
            public Healthbar HealthbarPrefab { get; private set; }
        }
    }
}
