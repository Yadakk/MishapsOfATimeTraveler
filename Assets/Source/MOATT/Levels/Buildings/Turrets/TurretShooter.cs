using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using Enemies;

    public class TurretShooter : MonoBehaviour
    {
        private TurretTargetPicker targetPicker;
        private BulletFacade.Factory bulletFactory;

        [Inject]
        public void Construct(TurretTargetPicker targetPicker, BulletFacade.Factory bulletFactory)
        {
            this.targetPicker = targetPicker;
            this.bulletFactory = bulletFactory;
        }

        public void Shoot()
        {
            if (targetPicker.Enemy == null) return;
            var bullet = bulletFactory.Create();
            bullet.transform.position = transform.position;
        }
    }
}
