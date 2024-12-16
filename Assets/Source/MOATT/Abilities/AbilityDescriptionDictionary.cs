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
        private readonly FastRechargeUpgradeAbility.Description fastRechargeUpgradeAbility;

        public AbilityDescriptionDictionary(RewindAbility.Description rewindAbility, SlowEnemiesAbility.Description slowEnemies, FastBuildingsAbility.Description fastBuildings, FastRechargeUpgradeAbility.Description fastRechargeUpgradeAbility)
        {
            this.rewindAbility = rewindAbility;
            this.slowEnemies = slowEnemies;
            this.fastBuildings = fastBuildings;
            this.fastRechargeUpgradeAbility = fastRechargeUpgradeAbility;
        }

        public Dictionary<AbilityType, object> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
                { AbilityType.SlowEnemies, slowEnemies },
                { AbilityType.FastBuildings, fastBuildings },
                { AbilityType.RechargeUpgrade, fastRechargeUpgradeAbility }
            };
        }
    }
}
