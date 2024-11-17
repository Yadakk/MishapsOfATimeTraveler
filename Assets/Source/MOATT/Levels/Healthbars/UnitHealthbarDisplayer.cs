using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Healthbars
{
    using Billboards;
    using BillboardGroup;

    public class UnitHealthbarDisplayer : System.IDisposable
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

        public void CreateHealthbar()
        {
            healthbarBillboard = billboardGroup.AddBillboard(source, healthbar.gameObject);
        }

        public void Dispose()
        {
            if (healthbarBillboard == null) return;
            healthbarBillboard.Dispose();
        }
    }
}
