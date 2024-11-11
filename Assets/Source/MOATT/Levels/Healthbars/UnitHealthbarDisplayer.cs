using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Healthbars
{
    using Billboards;
    using BillboardGroup;

    public class UnitHealthbarDisplayer : IInitializable, System.IDisposable
    {
        private readonly BillboardGroupFacade billboardGroup;
        private readonly BillboardSource source;
        private readonly HealthbarFacade healthbar;

        private BillboardFacade healthbarBillboard;

        public UnitHealthbarDisplayer(BillboardGroupFacade billboardGroup, HealthbarFacade healthbar, BillboardSource source = null)
        {
            this.billboardGroup = billboardGroup;
            this.healthbar = healthbar;
            this.source = source;
        }

        [Inject]
        public void Initialize()
        {
            healthbarBillboard = billboardGroup.AddBillboard(source, healthbar.gameObject);
        }

        [Inject]
        public void Dispose()
        {
            healthbarBillboard.Dispose();
        }
    }
}
