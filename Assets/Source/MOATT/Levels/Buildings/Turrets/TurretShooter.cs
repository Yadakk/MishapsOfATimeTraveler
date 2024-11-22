using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Buildings.Turrets
{
    using Bullets;

    public class TurretShooter : MonoBehaviour
    {
        private Settings settings;
        private TurretTargetPicker targetPicker;
        private BulletFacade.Factory bulletFactory;

        [Inject]
        public void Construct(Settings settings, TurretTargetPicker targetPicker, BulletFacade.Factory bulletFactory)
        {
            this.targetPicker = targetPicker;
            this.bulletFactory = bulletFactory;
            this.settings = settings;
        }

        public void Shoot()
        {
            if (targetPicker.Enemy == null) return;

            GameObjectCreationParameters goParams = new()
            {
                Position = transform.position
            };

            bulletFactory.Create(settings.bulletPrefab, new(goParams, settings.baseDamage));
        }

        [System.Serializable]
        public class Settings
        {
            public BulletFacade bulletPrefab;
            public float baseDamage = 20f;
        }
    }
}
