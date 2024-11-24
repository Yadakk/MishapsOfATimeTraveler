using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TimeTimers;
using Cannedenuum.ZenjectUtils.MonoInterfaces;

namespace MOATT.Levels.Buildings.Bombs
{
    public class BombTimer : IUpdatable
    {
        private readonly Timer timer;
        private readonly Settings settings;
        private readonly BombExploder exploder;

        public BombTimer(Timer timer, Settings settings = null, BombExploder exploder = null)
        {
            this.timer = timer;
            this.settings = settings;
            this.exploder = exploder;
        }

        public void Update()
        {
            if (timer.Elapsed >= settings.explosionDelay)
                exploder.Explode();
        }

        [System.Serializable]
        public class Settings
        {
            public float explosionDelay = 3f;
        }
    }
}
