using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using TimeTimers;

namespace MOATT.Levels.Enemies
{
    public class EnemyReloader : IUpdatable
    {
        private readonly Timer timer;
        private readonly Settings settings;

        private bool readyToAttack = true;

        public EnemyReloader(Timer timer, Settings settings)
        {
            this.timer = timer;
            this.settings = settings;
        }

        public bool ReadyToAttack
        {
            get => readyToAttack;
            set
            {
                readyToAttack = value;
                if (!readyToAttack) timer.Reset();
            }
        }

        public void Update()
        {
            if (timer.Elapsed > settings.attackSpeed) ReadyToAttack = true;
        }

        [System.Serializable]
        public class Settings
        {
            public float attackSpeed = 1f;
        }
    }
}
