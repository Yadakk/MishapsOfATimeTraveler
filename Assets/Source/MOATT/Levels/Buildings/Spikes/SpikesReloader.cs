using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Units.ReloadTime;
using MOATT.Utils;
using System.Linq;

namespace MOATT.Levels.Buildings.Spikes
{
    public class SpikesReloader : IUpdatable, IMultiplyableBuildingReloader
    {
        private readonly Dictionary<object, float> multipliers = new();

        private readonly ScalableTimer timer;
        private readonly UnitReloadTime reloadTime;

        private bool isReady = true;

        public SpikesReloader(ScalableTimer timer, UnitReloadTime reloadTime)
        {
            this.timer = timer;
            this.reloadTime = reloadTime;
        }

        public bool IsReady
        {
            get => isReady;
            set
            {
                isReady = value;
                if (!isReady) timer.Reset();
            }
        }

        public void Update()
        {
            if (IsReady) return;
            if (timer.Elapsed >= reloadTime.Value) IsReady = true;
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
