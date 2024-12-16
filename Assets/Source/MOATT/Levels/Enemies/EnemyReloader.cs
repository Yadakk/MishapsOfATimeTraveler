using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cannedenuum.ZenjectUtils.MonoInterfaces;
using MOATT.Utils;
using System.Linq;

namespace MOATT.Levels.Enemies
{
    public class EnemyReloader : IUpdatable
    {
        private readonly Dictionary<object, float> multipliers = new();

        private readonly ScalableTimer timer;
        private readonly Settings settings;

        private bool readyToAttack = true;

        public EnemyReloader(ScalableTimer timer, Settings settings)
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
            if (timer.Elapsed > settings.secondsToReload) ReadyToAttack = true;
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

        [System.Serializable]
        public class Settings
        {
            public float secondsToReload = 1f;
        }
    }
}
