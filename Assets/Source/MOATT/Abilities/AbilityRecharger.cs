using MOATT.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityRecharger : ITickable
    {
        private readonly Dictionary<object, float> multipliers = new();

        private readonly ScalableTimer scalableTimer;
        private readonly AbilityRechargeTime rechargeTime;
        private bool isReady = false;

        public AbilityRecharger(ScalableTimer scalableTimer, AbilityRechargeTime rechargeTime)
        {
            this.scalableTimer = scalableTimer;
            this.rechargeTime = rechargeTime;
        }

        public bool IsReady
        {
            get => isReady;
            set
            {
                isReady = value;
                if (!isReady) scalableTimer.Reset();
            }
        }

        public ScalableTimer ScalableTimer => scalableTimer;

        public void Tick()
        {
            if (scalableTimer.Elapsed < rechargeTime.value) return;
            IsReady = true;
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

            scalableTimer.timeScale = totalMultiplier;
        }
    }
}
