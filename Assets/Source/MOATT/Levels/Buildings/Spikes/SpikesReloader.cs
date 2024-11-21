using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;

namespace MOATT.Levels.Buildings.Spikes
{
    public class SpikesReloader : ITickable
    {
        private readonly Timer timer;
        private readonly Settings settings;

        private bool isReady = true;

        public SpikesReloader(Timer timer, Settings settings = null)
        {
            this.timer = timer;
            this.settings = settings;
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

        public void Tick()
        {
            if (IsReady) return;
            if (timer.Elapsed >= settings.reloadTime) IsReady = true;
        }

        [System.Serializable]
        public class Settings
        {
            public float reloadTime = 0.5f;
        }
    }
}
