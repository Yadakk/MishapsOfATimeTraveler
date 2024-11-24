using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretReloader : IUpdatable
    {
        private readonly Settings settings;
        private readonly Timer timer;
        private readonly TurretShooter shooter;

        public TurretReloader(
            Settings settings,
            Timer timer, 
            TurretShooter shooter)
        {
            this.settings = settings;
            this.timer = timer;
            this.shooter = shooter;
        }

        public void Update()
        {
            if (timer.Elapsed < settings.reloadTime) return;
            shooter.Shoot();
            timer.Reset();
        }

        [System.Serializable]
        public class Settings
        {
            public float reloadTime = 1f;
        }
    }
}
