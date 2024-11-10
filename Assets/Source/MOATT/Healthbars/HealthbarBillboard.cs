using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Healthbars
{
    using Billboards;
    using Health;

    public class HealthbarBillboard : IInitializable, System.IDisposable
    {
        private readonly HealthModel healthmodel;
        private readonly BillboardSource billboardSource;
        private readonly HealthbarFacade.Factory healthbarFactory;
        private readonly BillboardFacade.Factory billboardFactory;

        private BillboardFacade billboard;

        public HealthbarBillboard(
            HealthModel healthmodel,
            BillboardSource billboardSource,
            HealthbarFacade.Factory healthbarFactory,
            BillboardFacade.Factory billboardFactory)
        {
            this.healthmodel = healthmodel;
            this.billboardSource = billboardSource;
            this.healthbarFactory = healthbarFactory;
            this.billboardFactory = billboardFactory;
        }

        [Inject]
        public void Initialize()
        {
            billboard = billboardFactory.Create(billboardSource);
            var healthbar = healthbarFactory.Create(healthmodel);
            healthbar.transform.SetParent(billboard.transform, false);
        }

        [Inject]
        public void Dispose()
        {
            billboard.Dispose();
        }
    }
}
