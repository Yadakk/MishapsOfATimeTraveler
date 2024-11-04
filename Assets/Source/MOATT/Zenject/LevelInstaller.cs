using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using TimeTimers;
using MOATT.Enemies;
using MOATT.Map.Waves;

namespace MOATT.Zenject
{
    public class LevelInstaller : MonoInstaller
    {
        private Settings settings;

        [Inject]
        public void Construct(Settings settings)
        {
            this.settings = settings;
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
            Container.Bind<Tile>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<WaveSpawner>().AsSingle();
        }

        private void InstallEnemies()
        {
            Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(settings.EnemyPrefab).
                WithGameObjectName("Enemy").UnderTransformGroup("Enemies");
        }

        private void InstallMisc()
        {
            Container.Bind<Timer>().AsTransient();
        }

        [System.Serializable]
        public class Settings
        {
            [field: SerializeField]
            public Enemy EnemyPrefab { get; private set; }
        }
    }
}
