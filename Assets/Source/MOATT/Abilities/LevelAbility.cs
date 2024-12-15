using MOATT.Abilities.Types;
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
        private readonly SelectedAbility selectedAbilityType;

        public Ability SelectedAbility { get; private set; }

        public LevelAbility(AbilityTypeDictionary abilityDictionary, SelectedAbility selectedAbilityType)
        {
            this.abilityDictionary = abilityDictionary;
            this.selectedAbilityType = selectedAbilityType;
        }

        public void Initialize()
        {
            SelectedAbility = abilityDictionary.Dictionary.GetValueOrDefault(selectedAbilityType.ability);
        }

        internal void Activate()
        {
            SelectedAbility.Activate();
        }
    }
}
