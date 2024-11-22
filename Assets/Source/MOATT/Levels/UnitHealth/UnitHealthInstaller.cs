using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.UnitHealth
{
    using Health;
    using Healthbars;
    using Billboards;
    using BoundsCalculation;

    public class UnitHealthInstaller : Installer
    {
        private GlobalSettings globalSettings;

        [Inject]
        public void Construct(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        public override void InstallBindings()
        {
            Container.Install<BoundsCalculatorInstaller>();
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
            Container.BindExecutionOrder<UnitHealthbarDisplayer>(2);
            Container.BindInterfacesAndSelfTo<UnitHealthbarDisplayer>().AsSingle();
            Container.BindInterfacesAndSelfTo<HealthWatcher>().AsSingle();

            Container.Bind<HealthbarFacade>().
                FromSubContainerResolve().
                ByNewContextPrefab(globalSettings.healthbarPrefab).
                AsSingle();
        }

        [System.Serializable]
        public class GlobalSettings
        {
            public HealthbarFacade healthbarPrefab;
        }
    }
}
