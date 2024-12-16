using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    using Buildings;
    using Buildings.Turrets;
    using Units.Range;

    public class BulletDistanceWatcher : IInitializable, ITickable
    {
        private readonly BuildingFacade origin;
        private readonly BulletFacade facade;
        private readonly UnitRange unitRange;

        private Vector3 originPosition;

        public BulletDistanceWatcher(BuildingFacade origin, BulletFacade facade, UnitRange unitRange)
        {
            this.origin = origin;
            this.facade = facade;
            this.unitRange = unitRange;
        }

        public void Initialize()
        {
            originPosition = origin.transform.position;
        }

        public void Tick()
        {
            float distance = Vector3.Distance(originPosition, facade.transform.position);
            if (distance <= unitRange.Range) return;
            facade.Destroy();
        }
    }
}
