using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Healthbars
{
    using Billboards;
    using BillboardGroup;

    public class UnitHealthbarDisplayer : IStartable, System.IDisposable
    {
        private readonly BillboardGroupFacade billboardGroup;
        private readonly BillboardSource source;
        private readonly HealthbarFacade.Factory healthbarFactory;

        private BillboardFacade healthbarBillboard;

        public UnitHealthbarDisplayer(BillboardGroupFacade billboardGroup, HealthbarFacade.Factory healthbarFactory, BillboardSource source = null)
        {
            this.billboardGroup = billboardGroup;
            this.healthbarFactory = healthbarFactory;
            this.source = source;
        }

        public void Start()
        {
            healthbarBillboard = billboardGroup.AddBillboard(source, healthbarFactory.Create().gameObject);
        }

        public void Dispose()
        {
            if (healthbarBillboard == null) return;
            healthbarBillboard.Dispose();
        }
    }
}
