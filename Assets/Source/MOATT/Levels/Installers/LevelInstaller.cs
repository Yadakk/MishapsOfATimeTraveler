using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Installers
{
    using Tiles;
    using Enemies;
    using Waves;
    using Health;
    using Healthbars;
    using Billboards;

    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private Transform billboardGroup;

        private GlobalSettings globalSettings;
        private Settings settings;

        [Inject]
        public void Construct(GlobalSettings globalSettings, Settings settings)
        {
            this.settings = settings;
            this.globalSettings = globalSettings;

            Container.Install<WaveInstaller>();
        }

        public override void InstallBindings()
        {
            InstallMap();
            InstallEnemies();
            InstallMisc();
            InstallBillboards();
            InstallHealthbars();
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

        private void InstallBillboards()
        {
            Container.BindFactory<BillboardSource, BillboardFacade, BillboardFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<BillboardInstaller>(globalSettings.billboardPrefab).
                WithGameObjectName("Billboard").
                UnderTransform(billboardGroup);
        }

        private void InstallHealthbars()
        {
            Container.BindFactory<HealthModel, HealthbarFacade, HealthbarFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<HealthbarInstaller>(globalSettings.healthbarPrefab).
                WithGameObjectName("Healthbar");
        }

        private void InstallMisc()
        {
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
        }

        [System.Serializable]
        public class Settings
        {
            public EnemyFacade enemyPrefab;
        }

        [System.Serializable]
        public class GlobalSettings
        {
            public HealthbarFacade healthbarPrefab;
            public BillboardFacade billboardPrefab;
        }
    }
}
