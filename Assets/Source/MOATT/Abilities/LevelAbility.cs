using MOATT.Abilities.Types;
using MOATT.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class LevelAbility : IInitializable
    {
        private readonly AbilityTypeDictionary abilityDictionary;
        private readonly SelectedAbilityType selectedAbilityType;
        private readonly AbilityRecharger abilityRecharger;

        public event Action OnAbilityActivated;

        public Ability SelectedAbility { get; private set; }

        public LevelAbility(AbilityTypeDictionary abilityDictionary, SelectedAbilityType selectedAbilityType, AbilityRecharger abilityRecharger)
        {
            this.abilityDictionary = abilityDictionary;
            this.selectedAbilityType = selectedAbilityType;
            this.abilityRecharger = abilityRecharger;
        }

        public void Initialize()
        {
            SelectedAbility = abilityDictionary.Dictionary.GetValueOrDefault(selectedAbilityType.ability);
        }

        internal void Activate()
        {
            if (!abilityRecharger.IsReady) return;
            SelectedAbility.Activate();
            abilityRecharger.IsReady = false;
            OnAbilityActivated?.Invoke();
        }
    }
}
