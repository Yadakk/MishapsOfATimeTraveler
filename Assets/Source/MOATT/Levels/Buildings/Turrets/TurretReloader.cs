using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Units.ReloadTime;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretReloader : IUpdatable
    {
        private readonly UnitReloadTime reloadTime;
        private readonly Timer timer;
        private readonly TurretShooter shooter;

        public TurretReloader(
            UnitReloadTime reloadTime,
            Timer timer, 
            TurretShooter shooter)
        {
            this.reloadTime = reloadTime;
            this.timer = timer;
            this.shooter = shooter;
        }

        public void Update()
        {
            if (timer.Elapsed < reloadTime.Value) return;
            shooter.Shoot();
            timer.Reset();
        }
    }
}
