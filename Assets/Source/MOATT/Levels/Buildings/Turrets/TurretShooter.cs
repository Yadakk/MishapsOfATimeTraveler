using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;
    using MOATT.Levels.Units.Damage;

    public class TurretShooter : MonoBehaviour
    {
        private Settings settings;
        private TurretTargetPicker targetPicker;
        private BulletFacade.Factory bulletFactory;
        private UnitDamage unitDamage;

        [Inject]
        public void Construct(Settings settings, TurretTargetPicker targetPicker, BulletFacade.Factory bulletFactory, UnitDamage unitDamage)
        {
            this.targetPicker = targetPicker;
            this.bulletFactory = bulletFactory;
            this.settings = settings;
            this.unitDamage = unitDamage;
        }

        public void Shoot()
        {
            if (targetPicker.Enemy == null) return;

            GameObjectCreationParameters goParams = new()
            {
                Position = transform.position
            };

            bulletFactory.Create(settings.bulletPrefab, new(goParams, unitDamage.Value));
        }

        [System.Serializable]
        public class Settings
        {
            public BulletFacade bulletPrefab;
        }
    }
}
