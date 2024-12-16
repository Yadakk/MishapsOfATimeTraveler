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
        private readonly SlowEnemiesAbility slowEnemies;

        public AbilityTypeDictionary(RewindAbility rewindAbility, SlowEnemiesAbility slowEnemies)
        {
            this.rewindAbility = rewindAbility;
            this.slowEnemies = slowEnemies;
        }

        public Dictionary<AbilityType, Ability> Dictionary { get; private set; }

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
