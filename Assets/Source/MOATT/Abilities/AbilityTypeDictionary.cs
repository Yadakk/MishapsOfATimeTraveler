﻿using MOATT.Abilities.Types;
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
        private readonly FastBuildingsAbility fastBuildings;
        private readonly FastRechargeUpgradeAbility fastRechargeUpgradeAbility;

        public AbilityTypeDictionary(RewindAbility rewindAbility, SlowEnemiesAbility slowEnemies, FastBuildingsAbility fastBuildings, FastRechargeUpgradeAbility fastRechargeUpgradeAbility)
        {
            this.rewindAbility = rewindAbility;
            this.slowEnemies = slowEnemies;
            this.fastBuildings = fastBuildings;
            this.fastRechargeUpgradeAbility = fastRechargeUpgradeAbility;
        }

        public Dictionary<AbilityType, Ability> Dictionary { get; private set; }

        public void Initialize()
        {
            Dictionary = new()
            {
                { AbilityType.Rewind, rewindAbility },
                { AbilityType.SlowEnemies, slowEnemies },
                { AbilityType.FastBuildings, fastBuildings },
                { AbilityType.RechargeUpgrade, fastRechargeUpgradeAbility },
            };
        }
    }
}
