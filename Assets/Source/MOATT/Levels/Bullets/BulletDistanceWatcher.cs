using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    using Buildings;
    using Buildings.Turrets;
    using UnitRange;

    public class BulletDistanceWatcher : ITickable
    {
        private readonly BuildingFacade origin;
        private readonly BulletFacade facade;
        private readonly UnitRange unitRange;

        public BulletDistanceWatcher(BuildingFacade origin, BulletFacade facade, UnitRange unitRange)
        {
            this.origin = origin;
            this.facade = facade;
            this.unitRange = unitRange;
        }

        public void Tick()
        {
            float distance = Vector3.Distance(origin.transform.position, facade.transform.position);
            if (distance <= unitRange.Range) return;
            facade.Destroy();
        }
    }
}
