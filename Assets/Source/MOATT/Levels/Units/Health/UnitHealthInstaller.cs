using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Units.Health
{
    using Levels.Health;
    using Healthbars;
    using Billboards;
    using BoundsCalculation;

    public class UnitHealthInstaller : Installer
    {
        private GlobalSettings globalSettings;
        private Settings settings;

        [Inject]
        public void Construct(GlobalSettings globalSettings, Settings settings)
        {
            this.globalSettings = globalSettings;
            this.settings = settings;
        }

        public override void InstallBindings()
        {
            Container.Install<BoundsCalculatorInstaller>();

            Container.BindInstance(settings.healthModel).AsSingle();
            Container.Bind<HealthModel>().AsSingle();

            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindExecutionOrder<UnitHealthbarDisplayer>(2);
            Container.BindInterfacesAndSelfTo<UnitHealthbarDisplayer>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthWatcher>().AsSingle();

            Container.BindFactory<HealthbarFacade, HealthbarFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab(globalSettings.healthbarPrefab).
                AsSingle();
        }

        [System.Serializable]
        public class GlobalSettings
        {
            public HealthbarFacade healthbarPrefab;
        }

        [System.Serializable]
        public class Settings
        {
            public HealthModel.Settings healthModel;
        }
    }
}
