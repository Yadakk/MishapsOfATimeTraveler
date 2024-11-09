using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Health
{
    using Billboards;

    public class HealthbarBillboard : IInitializable, ITickable
    {
        private readonly HealthModel healthmodel;
        private readonly BillboardSource billboardSource;
        private readonly Healthbar.Factory healthbarFactory;
        private readonly Billboard.Factory billboardFactory;

        private Billboard billboard;

        public HealthbarBillboard(HealthModel healthmodel,
            BillboardSource billboardSource,
            Healthbar.Factory healthbarFactory,
            Billboard.Factory billboardFactory)
        {
            this.healthmodel = healthmodel;
            this.billboardSource = billboardSource;
            this.healthbarFactory = healthbarFactory;
            this.billboardFactory = billboardFactory;
        }

        public void Initialize()
        {
            billboard = billboardFactory.Create(
                billboardSource, healthbarFactory.Create(healthmodel).transform);
        }

        public void Tick()
        {
            billboard.Update();
        }

        public void Destroy()
        {
            Object.Destroy(billboard.transform.gameObject);
        }
    }
}
