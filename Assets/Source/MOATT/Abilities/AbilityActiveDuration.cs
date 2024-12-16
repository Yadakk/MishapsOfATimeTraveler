using MOATT.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityActiveDuration : ITickable
    {
        public float duration = 30f;
        private bool isActive;
        private readonly ScalableTimer scalableTimer;

        public event Action<bool> OnActiveChanged;

        public AbilityActiveDuration(ScalableTimer scalableTimer)
        {
            this.scalableTimer = scalableTimer;
        }

        public ScalableTimer ScalableTimer => scalableTimer;
        public bool IsActive
        {
            get => isActive;
            private set
            {
                if (value == isActive) return;
                isActive = value;
                OnActiveChanged?.Invoke(isActive);
            }
        }

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
