using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities.Types
{
    public class SlowEnemiesAbility : IInitializable
    {
        private readonly AbilityActiveDuration abilityActiveDuration;
        private readonly Settings settings;

        public SlowEnemiesAbility(AbilityActiveDuration abilityActiveDuration)
        {
            this.abilityActiveDuration = abilityActiveDuration;
        }

        public void Initialize()
        {
            abilityActiveDuration.duration = settings.duration;
        }

        [Serializable]
        public class Settings
        {
            public float duration = 30f;
        }

        public class Description
        {
            public override string ToString()
            {
                return string.Empty;
            }
        }
    }
}
