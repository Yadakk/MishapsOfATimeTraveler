using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Levels.Units.ReloadTime;

namespace MOATT.Levels.Buildings.Spikes
{
    public class SpikesReloader : IUpdatable
    {
        private readonly Timer timer;
        private readonly UnitReloadTime reloadTime;

        private bool isReady = true;

        public SpikesReloader(Timer timer, UnitReloadTime reloadTime)
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
    }
}
