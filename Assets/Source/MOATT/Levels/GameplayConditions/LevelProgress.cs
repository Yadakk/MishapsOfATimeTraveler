using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimeTimers;
using Zenject;

namespace MOATT.Levels.GameplayConditions
{
    public class LevelProgress : ITickable
    {
        private readonly Settings settings;
        private readonly Timer timer;

        public event Action OnWon;

        public LevelProgress(Settings settings, Timer timer)
        {
            this.settings = settings;
            this.timer = timer;
        }

        public bool HasWon { get; private set; }
        public float Progress => timer.Elapsed / settings.timeLimitSeconds;

        public void Tick()
        {
            if (HasWon) return;
            if (timer.Elapsed < settings.timeLimitSeconds) return;
            HasWon = true;
            OnWon?.Invoke();
        }

        [Serializable]
        public class Settings
        {
            public float timeLimitSeconds = 180f;
        }
    }
}
