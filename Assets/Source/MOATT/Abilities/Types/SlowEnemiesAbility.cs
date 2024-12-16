using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities.Types
{
    public class SlowEnemiesAbility : Ability, IInitializable
    {
        private readonly AbilityActiveDuration abilityActiveDuration;
        private readonly Settings settings;
        private readonly Description description;

        public SlowEnemiesAbility(AbilityActiveDuration abilityActiveDuration, Settings settings, Description description)
        {
            this.abilityActiveDuration = abilityActiveDuration;
            this.settings = settings;
            this.description = description;
        }

        public void Initialize()
        {
            abilityActiveDuration.duration = settings.duration;
        }

        public override void Activate()
        {
            abilityActiveDuration.Activate();
        }

        public override string ToString() => description.ToString();

        [Serializable]
        public class Settings
        {
            public float duration = 30f;
        }

        public class Description
        {
            public override string ToString()
            {
                return "All enemies walk and attack twice as slow for 30 seconds";
            }
        }
    }
}
