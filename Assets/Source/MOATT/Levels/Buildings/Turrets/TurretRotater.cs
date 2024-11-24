using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretRotater : IUpdatable
    {
        private readonly TurretTargetPicker targetPicker;
        private readonly BuildingFacade facade;

        public TurretRotater(TurretTargetPicker targetPicker, BuildingFacade facade = null)
        {
            this.targetPicker = targetPicker;
            this.facade = facade;
        }

        public void Update()
        {
            var enemy = targetPicker.Enemy;
            if (enemy == null) return;

            var transform = facade.transform;
            Vector3 enemyDirection = enemy.transform.position - transform.position;

            if (enemyDirection == Vector3.zero) return;
            transform.rotation = Quaternion.LookRotation(enemyDirection);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
    }
}
