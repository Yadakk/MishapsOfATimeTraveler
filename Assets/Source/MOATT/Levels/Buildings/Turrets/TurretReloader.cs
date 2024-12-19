using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Units.ReloadTime;
using MOATT.Utils;
using System.Linq;

namespace MOATT.Levels.Buildings.Turrets
{
    public class TurretReloader : IUpdatable, IMultiplyableBuildingReloader
    {
        private readonly Dictionary<object, float> multipliers = new();

        private readonly UnitReloadTime reloadTime;
        private readonly ScalableTimer timer;
        private readonly TurretShooter[] shooters;

        private int barrelIndex;

        public TurretReloader(
            UnitReloadTime reloadTime,
            ScalableTimer timer, 
            TurretShooter[] shooters)
        {
            this.reloadTime = reloadTime;
            this.timer = timer;
            this.shooters = shooters;
        }

        public void Update()
        {
            if (timer.Elapsed < reloadTime.Value) return;
            if (barrelIndex >= shooters.Length) barrelIndex = 0;
            shooters[barrelIndex].Shoot();
            barrelIndex++;
            timer.Reset();
        }

        public void AddMultiplier(object obj, float value)
        {
            if (multipliers.ContainsKey(obj)) return;
            multipliers.Add(obj, value);
            RecalculateMultiplier();
        }

        public void RemoveMultiplier(object obj)
        {
            if (!multipliers.ContainsKey(obj)) return;
            multipliers.Remove(obj);
            RecalculateMultiplier();
        }

        private void RecalculateMultiplier()
        {
            float totalMultiplier = 1f;

            for (int i = 0; i < multipliers.Count; i++)
            {
                totalMultiplier *= multipliers.ElementAt(i).Value;
            }

            timer.timeScale = totalMultiplier;
        }
    }
}
