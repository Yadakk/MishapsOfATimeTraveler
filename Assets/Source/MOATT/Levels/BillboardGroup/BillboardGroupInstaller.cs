using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.BillboardGroup
{
    using Billboards;

    public class BillboardGroupInstaller : MonoInstaller
    {
        private GlobalSettings globalSettings;

        [Inject]
        public void Construct(GlobalSettings globalSettings)
        {
            this.globalSettings = globalSettings;
        }

        public override void InstallBindings()
        {
            Container.BindFactory<BillboardSource, BillboardFacade, BillboardFacade.Factory>().
                FromSubContainerResolve().
                ByNewContextPrefab<BillboardInstaller>(globalSettings.billboardPrefab).
                AsSingle();
        }

        [System.Serializable]
        public class GlobalSettings
        {
            public BillboardFacade billboardPrefab;
        }
    }
}
