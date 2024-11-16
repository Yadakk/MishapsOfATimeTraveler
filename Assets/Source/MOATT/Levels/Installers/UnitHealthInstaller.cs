using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Installers
{
    using Health;
    using Healthbars;
    using Billboards;

    public class UnitHealthInstaller : MonoInstaller
    {
        private GlobalSettings globalSettings;

        [Inject]
        public void Construct(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        public override void InstallBindings()
        {
            Container.Bind<HealthModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BillboardSource>().AsSingle();
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
