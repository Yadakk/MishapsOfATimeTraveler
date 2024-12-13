using Cannedenuum.UnityUtils.ValueChangeWatcher;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Levels.Economics
{
    public class ScientistRechargeMultiplier : IInitializable, IDisposable
    {
        public ValueChangeWatcher<float> valueWatcher = new(1f);

        private readonly PlayerResources playerResources;
        private readonly Settings settings;

        public ScientistRechargeMultiplier(PlayerResources playerResources, Settings settings)
        {
            this.playerResources = playerResources;
            this.settings = settings;
        }

        public float Value { get => valueWatcher.Value; private set => valueWatcher.Value = value; }

        public void Initialize()
        {
            playerResources.idleScientistsWatcher.OnValueChangedNewValue += IdleScientistsValueChangedHandler;
        }

        public void Dispose()
        {
            playerResources.idleScientistsWatcher.OnValueChangedNewValue -= IdleScientistsValueChangedHandler;
        }

        private void IdleScientistsValueChangedHandler(int newIdleScientists)
        {
            Value = 1f + settings.multiplierPerIdleScientist * newIdleScientists;
        }

        [Serializable]
        public class Settings
        {
            public float multiplierPerIdleScientist = 0.05f;
        }
    }
}
