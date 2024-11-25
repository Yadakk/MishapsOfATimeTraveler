using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Units.Damage
{
    public class UnitDamage
    {
        private readonly Settings settings;

        public UnitDamage(Settings settings)
        {
            this.settings = settings;
        }

        public float Value => settings.value;

        [System.Serializable]
        public class Settings
        {
            public float value = 10f;
        }
    }
}
