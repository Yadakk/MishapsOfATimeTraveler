using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOATT.Levels.Units.ReloadTime
{
    public class UnitReloadTime
    {
        private readonly Settings settings;

        public UnitReloadTime(Settings settings)
        {
            this.settings = settings;
        }

        public float Value => settings.value;

        [System.Serializable]
        public class Settings
        {
            public float value = 1f;
        }
    }
}
