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

        private Vector2 originPosition;

        public BulletDistanceWatcher(BuildingFacade origin, BulletFacade facade, UnitRange unitRange)
        {
            this.origin = origin;
            this.facade = facade;
            this.unitRange = unitRange;
        }

        public void Initialize()
        {
            originPosition = new Vector2(origin.transform.position.x, origin.transform.position.z);
        }

        public void Tick()
        {
            float distance = Vector2.Distance(originPosition, new Vector2(facade.transform.position.x, facade.transform.position.z));
            if (distance <= unitRange.Range) return;
            facade.Destroy();
        }
    }
}
