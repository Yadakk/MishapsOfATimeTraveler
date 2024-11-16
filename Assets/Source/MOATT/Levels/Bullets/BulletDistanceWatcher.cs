using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Bullets
{
    using Buildings;
    using Buildings.Turrets;

    public class BulletDistanceWatcher : ITickable
    {
        private readonly BuildingFacade origin;
        private readonly BulletFacade facade;
        private readonly TurretTargetPicker.Settings targetPickerSettings;

        public BulletDistanceWatcher(BuildingFacade origin, BulletFacade facade, TurretTargetPicker.Settings targetPickerSettings = null)
        {
            this.origin = origin;
            this.facade = facade;
            this.targetPickerSettings = targetPickerSettings;
        }

        public void Tick()
        {
            float distance = Vector3.Distance(origin.transform.position, facade.transform.position);
            if (distance <= targetPickerSettings.range) return;
            facade.Destroy();
        }
    }
}
