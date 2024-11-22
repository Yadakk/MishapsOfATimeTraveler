using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretReloader : ITickable
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

        public void Tick()
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
