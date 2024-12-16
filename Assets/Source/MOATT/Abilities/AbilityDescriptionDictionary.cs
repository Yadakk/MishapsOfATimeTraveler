using MOATT.Abilities.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MOATT.Abilities
{
    public class AbilityDescriptionDictionary : IInitializable
    {
        private readonly RewindAbility.Description rewindAbility;

        public AbilityDescriptionDictionary(RewindAbility.Description rewindAbility)
        {
            this.rewindAbility = rewindAbility;
        }

        public Dictionary<AbilityType, object> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
            };
        }
    }
}
