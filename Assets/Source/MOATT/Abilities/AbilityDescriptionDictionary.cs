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
        private readonly FastBuildingsAbility.Description fastBuildings;

        public AbilityDescriptionDictionary(RewindAbility.Description rewindAbility, SlowEnemiesAbility.Description slowEnemies, FastBuildingsAbility.Description fastBuildings)
        {
            this.rewindAbility = rewindAbility;
            this.slowEnemies = slowEnemies;
            this.fastBuildings = fastBuildings;
        }

        public Dictionary<AbilityType, object> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
                { AbilityType.SlowEnemies, slowEnemies },
                { AbilityType.FastBuildings, fastBuildings },
            };
        }
    }
}
