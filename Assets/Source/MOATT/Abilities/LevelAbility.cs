using MOATT.Abilities.Types;
using MOATT.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class LevelAbility : IInitializable, IDisposable
    {
        private readonly AbilityTypeDictionary abilityDictionary;
        private readonly SelectedAbilityType selectedAbilityType;
        private readonly AbilityRecharger abilityRecharger;
        private readonly LevelAbilitySoundPlayer soundPlayer;

        public event Action OnAbilityActivated;

        public Ability SelectedAbility { get; private set; }

        public LevelAbility(AbilityTypeDictionary abilityDictionary, SelectedAbilityType selectedAbilityType, AbilityRecharger abilityRecharger, LevelAbilitySoundPlayer soundPlayer)
        {
            this.abilityDictionary = abilityDictionary;
            this.selectedAbilityType = selectedAbilityType;
            this.abilityRecharger = abilityRecharger;
            this.soundPlayer = soundPlayer;
        }

        public void Initialize()
        {
            SelectedAbility = abilityDictionary.Dictionary.GetValueOrDefault(selectedAbilityType.ability);
            abilityRecharger.OnReady += ReadyHandler;
        }

        public void Dispose()
        {
            abilityRecharger.OnReady -= ReadyHandler;
        }

        public void Activate()
        {
            if (!abilityRecharger.IsReady) return;
            soundPlayer.PlayActivated();
            SelectedAbility.Activate();
            abilityRecharger.IsReady = false;
            OnAbilityActivated?.Invoke();
        }

        private void ReadyHandler()
        {
            soundPlayer.PlayCharged();
        }
    }
}
