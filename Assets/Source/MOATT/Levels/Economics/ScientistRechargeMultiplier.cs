using Cannedenuum.UnityUtils.ValueChangeWatcher;
using MOATT.Abilities;
using MOATT.Levels.BuildingPlacement;
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
        private readonly BuildingPlacementSelectorVM[] selectorVMs;
        private readonly AbilityRecharger abilityRecharger;

        public ScientistRechargeMultiplier(PlayerResources playerResources, Settings settings, BuildingPlacementSelectorVM[] selectorVMs, AbilityRecharger abilityRecharger)
        {
            this.playerResources = playerResources;
            this.settings = settings;
            this.selectorVMs = selectorVMs;
            this.abilityRecharger = abilityRecharger;
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

            for (int i = 0; i < selectorVMs.Length; i++)
            {
                selectorVMs[i].BuildingInfo.RemoveMultiplier(this);
                selectorVMs[i].BuildingInfo.AddMultiplier(this, Value);
            }

            abilityRecharger.AddMultiplier(this, Value);
        }

        [Serializable]
        public class Settings
        {
            public float multiplierPerIdleScientist = 0.05f;
        }
    }
}
