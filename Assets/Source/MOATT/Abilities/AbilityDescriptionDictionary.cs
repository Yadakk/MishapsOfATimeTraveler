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
        private readonly SlowEnemiesAbility.Description slowEnemies;

        public AbilityDescriptionDictionary(RewindAbility.Description rewindAbility, SlowEnemiesAbility.Description slowEnemies)
        {
            this.rewindAbility = rewindAbility;
            this.slowEnemies = slowEnemies;
        }

        public Dictionary<AbilityType, object> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
                { AbilityType.SlowEnemies, slowEnemies },
            };
        }
    }
}
