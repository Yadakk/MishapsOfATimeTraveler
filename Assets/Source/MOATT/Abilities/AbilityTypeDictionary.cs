using MOATT.Abilities.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityTypeDictionary : IInitializable
    {
        private readonly RewindAbility rewindAbility;

        public AbilityTypeDictionary(RewindAbility rewindAbility)
        {
            this.rewindAbility = rewindAbility;
        }

        public Dictionary<AbilityType, Ability> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
            };
        }
    }
}
