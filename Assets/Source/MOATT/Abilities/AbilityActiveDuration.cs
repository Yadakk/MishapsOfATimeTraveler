using MOATT.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityActiveDuration : ITickable
    {
        public float duration = 30f;

        private readonly ScalableTimer scalableTimer;

        public AbilityActiveDuration(ScalableTimer scalableTimer)
        {
            this.scalableTimer = scalableTimer;
        }

        public ScalableTimer ScalableTimer => scalableTimer;
        public bool IsActive { get; private set; }

        public void Tick()
        {
            if (scalableTimer.Elapsed < duration) return;
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
            scalableTimer.Reset();
        }
    }
}
